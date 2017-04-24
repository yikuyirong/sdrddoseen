using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState; 

namespace Web
{
    public class API : IHttpHandler, IReadOnlySessionState//注意IRequiresSessionState效能低于IReadOnlySessionState至少2.5倍
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";//头信息

            //初始化变量
            string result = "";//返回结果
            string str = "";//通用字符变量
            string username = WebCommon.Public.GetUserName();//当前登录用户


            //判断请求地址拒绝未授权地址  来源地址：http://localhost:59197/Index.html
            string FromUrl=WebCommon.Public.GetFromUrl();
            string AgreeUrl = WebCommon.Public.DataTableFieldGet("tbl_config", "c_set1", "id=1");
            if (AgreeUrl == "") goto Next;
            foreach (string url in AgreeUrl.Split('|'))
            {
                if (FromUrl.Contains(url)) goto Next;
            }
            result = "{\"result\":\"No Url\"}";
            goto End;
            Next:

            //判断许可KEY - 授权KeY写在Global.asax里面
            if (WebCommon.Public.ToString(context.Session["key"]) != FromUrl)
            {
                result = "{\"result\":\"No Key\"}";
                goto End;
            }
            
            //通用URL变量
            string action = WebCommon.Public.ToString(context.Request.QueryString["action"]);//读取目标方法
            string keyword = WebCommon.Public.ToString(context.Request.QueryString["keyword"]);//通用自由变量(验证码手机号码等)
            int pagesize =WebCommon.Public.ToInt(context.Request.QueryString["pagesize"]);//读取每页数量
            int pageindex = WebCommon.Public.ToInt(context.Request.QueryString["pageindex"]);//读取当前页值
            string where = WebCommon.Public.ToString(context.Request.QueryString["where"]);//读取查询条件
            string order = WebCommon.Public.ToString(context.Request.QueryString["order"]);//读取排序方式
            string table = WebCommon.Public.ToString(context.Request.QueryString["table"]);//读取表名
            string id = WebCommon.Public.ToString(context.Request.QueryString["id"]);//读取数据ID值
            string field = WebCommon.Public.ToString(context.Request.QueryString["field"]);//读取字段名称
            string folder = WebCommon.Public.ToString(context.Request.QueryString["folder"]);//读取文件夹名
            int size = WebCommon.Public.ToInt(context.Request.QueryString["size"]);//读取大小
            int width = WebCommon.Public.ToInt(context.Request.QueryString["width"]);//读取宽
            int height = WebCommon.Public.ToInt(context.Request.QueryString["height"]);//读取高
            string sql = WebCommon.Public.ToString(context.Request.QueryString["sql"]);//读取SQL语句并解密
            string[] data = HttpContext.Current.Request.Form.AllKeys;//读取Post传过来的Json数据
            if (order == "") order = "id desc";
            switch (action.ToLower())
            {
                case "data_read":
                    #region data_read (通用读取)根据SQL语句返回数据列表JSON 范例：api.ashx?action=data_read&sql=加密的SQL字符串或未加密SQL或表名&where=&order=&pagesize=10&pageindex=1&callback=?
                    try{sql = WebCommon.Public.DeCode(sql);}catch { }//尝试解密SQL参数
                    if (sql.Trim().IndexOf("select")==0)//如果是SQL语句
                    {
                        //如果所传加密的SQL字符串需要where或者order那么请在加密前加入2个通配符:select * from table where {where} order by {order}
                        if (where != "") sql = sql.Replace("{where}", where);
                        if (order != "") sql = sql.Replace("{order}", order);
                        result = WebCommon.Public.DataTableToJson(WebCommon.Public.DataTableGetBySql(sql, pagesize, pageindex));
                    }
                    else//如果是表名
                    {
                        //范例：api.ashx?action=data_read&sql=tbl_log&pagesize=10&pageindex=1&where=id>8&order=id desc&callback=?
                        result = WebCommon.Public.DataTableToJson(WebCommon.Public.DataTableGet(sql, pagesize, pageindex, where, order));
                    }
                    break;
                    #endregion
                case "data_add":
                    #region data_add (通用添加)根据POST数据进行数据库添加操作并返回主键ID值 范例：$.post("api.ashx?action=data_add&table=tbl_log&callback=?", { LogInfo: "测试增加一条日志", DealUser: "doseen" }, function(data){}, "json");
                    result = "{\"result\":\"" + WebCommon.Public.DataTableAdd(table, data).ToString() + "\"}";//返回ID值
                    break;
                    #endregion
                case "data_edit":
                    #region data_edit (通用修改)根据POST数据进行数据库修改操作并返回真假结果 范例：$.post("api.ashx?action=data_edit&table=tbl_log&where=id="+id+"&callback=?", { LogInfo: "测试修改", DealUser: "doseen" }, function(data){},"json");
                    result = "{\"result\":\"" + WebCommon.Public.DataTableEdit(table, data, where).ToString() + "\"}";//返回真假
                    break;
                    #endregion
                case "data_del":
                    #region data_del (通用删除)根据条件删除表数据并返回删除的条数 范例：api.ashx?action=data_del&table=tbl_log&where=id<12&callback=?
                    result = WebCommon.Public.DataTableDel(table, where).ToString();
                    result = "{\"result\":\"" + result + "\"}"; 
                    break;
                    #endregion
                case "data_sms":
                    #region data_sms (通用验证码)发送手机验证码并返回当前验证码值 范例：$.getJSON("api.ashx?action=data_sms&keyword=13622882281&callback=?",function(data){alert(data.result)});
                    str = WebCommon.Public.GetRnd(1000, 9999).ToString();
                    result = WebCommon.Public.DataTableFieldGet("tbl_config", "c_set2", "id=1").Replace("{mobile}",keyword).Replace("{msg}",str);
                    result = WebCommon.Public.GetHtml(result);
                    result = "{\"result\":\"" + str + "\"}";
                    break;
                    #endregion
                case "data_getvalue":
                    #region data_getvalue (通用读取)根据ID读取某个表的某个字段值 范例：api.ashx?action=data_getvalue&table=tbl_admin&field=username&where=id=1&callback=?
                    result = WebCommon.Public.DataTableFieldGet(table, field, where);
                    result = "{\"result\":\"" + result + "\"}"; 
                    break;
                    #endregion
                case "data_upload":
                    #region data_upload (通用读取)配合AJAX上传文件返回文件径路 范例：$$.Upload("filename1", "api.ashx?action=data_upload&folder=pic&size=500000&width=300&height=300&callback=?", function(data, status){});
                    if (size == 0) size = 100000000;//默认100M
                    string filename = WebCommon.Public.UploadFile(context.Request.Files[0], folder,"", size, true);
                    if(width>0&&height>0)WebCommon.Public.CutPic(filename,filename.Insert(filename.Length-4,"_"),width,height,90);
                    context.Response.Write(filename);
                    context.Response.End();
                    break;
                    #endregion
                case "data_encrypt":
                    #region data_encrypt (通用加密)可逆加解密字符串 范例：api.ashx?action=data_encrypt&sql=select * from tbl_user&callback=?
                    try
                    {
                        result = WebCommon.Public.DeCode(sql);
                    }
                    catch
                    {
                        result = WebCommon.Public.EnCode(sql);
                    }
                    result = "{\"result\":\"" + result + "\"}";
                    break;
                    #endregion
                case "userlogin":
                    #region userlogin 会员登录 范例：api.ashx?action=userlogin&username=darden&userpwd=123456&callback=?
                    string logname = WebCommon.Public.ToString(context.Request.QueryString["username"]);
                    string logpwd = WebCommon.Public.ToString(context.Request.QueryString["userpwd"]);
                    result = "{\"result\":\"false\"}";
                    if (WebBLL.Tbl_UserManager.UserLogin(logname, logpwd)) result = "{\"result\":\"true\"}";
                    break;
                    #endregion
                case "userlogout":
                    #region userlogin 会员退出 范例：api.ashx?action=userlogout&callback=?
                    WebBLL.Tbl_UserManager.UserLogout();
                    result = "{\"result\":\"true\"}";
                    break;
                    #endregion
            }
        //输出Json字符串
        End: context.Response.Write(context.Request.QueryString.Get("callback") + "(" + result + ")");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
