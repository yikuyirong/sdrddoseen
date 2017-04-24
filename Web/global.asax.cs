using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Net;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            //前台权限判断
            //string KeyUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            //string FileName = KeyUrl.Split('/')[KeyUrl.Split('/').Length - 1].ToLower();
            ////bool result = true;
            //if (KeyUrl.Contains(".html") && !KeyUrl.Contains("error"))
            //{
            //    Session["key"] = KeyUrl;//页面地址作为API的密钥如果和ASHX获取到的请求地址不一致则拒绝访问
            //    //string NoScanFile = "Default.html|DoSeen_Main.html|DoSeen_Index.html|DoSeen.html";
            //    //string[] NoScanFileSplit = NoScanFile.Split('|');
            //    //foreach (string str in NoScanFileSplit)
            //    //{
            //    //    if (str.ToLower() == FileName)
            //    //    {
            //    //        if (WebCommon.Public.GetUserName() == "") result = false;
            //    //        break;
            //    //    }
            //    //}
            //}
            ////if (!result) WebCommon.Script.AlertAndGoBack("请登录会员");

            //全局所有页面按钮权限验证
            //WebCommon.Script.ResponseScript("$(function(){CheckLimit('" + WebCommon.Public.GetUserLimit().ToLower() + "');});");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Request.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");//解决request中文乱码
            string BackFolder = "views";//后台访问路径views
            string FilePath = Request.FilePath.ToLower();
            string FileName = FilePath.Split('/')[FilePath.Split('/').Length - 1].ToLower();

            //后台权限判断主程序
            if (FilePath.Contains(BackFolder.ToLower() + "/"))
            {
                //后台权限判断模块
                bool IsFile = false;
                //接受检查的文件仅限aspx文件
                if (FileName == "") return;
                if (FileName.Split('.')[1] == "aspx" || FileName.Split('.')[1] == "html")
                {
                    //FileName = FileName.Split('.')[0];
                    IsFile = true;
                    //判断该文件是否受权限约束(指定后台不受约束的文件外都算约束范围用|隔开文件名)
                    string NoScanFile = "Project_Flow.aspx|Alert.aspx|Alert_List.aspx|Default.aspx|Top.aspx|Password.aspx|Middle.aspx|Main.aspx|Left.aspx|Foot.aspx|Middle_left.aspx|FlowWork_Home.aspx|FlowWork_Deal.aspx|Info_Detail.aspx|Timer.aspx";
                    string[] NoScanFileSplit = NoScanFile.Split('|');
                    foreach (string str in NoScanFileSplit)
                    {
                        if (str.ToLower() == FileName)
                        {
                            IsFile = false;
                            break;
                        }
                    }
                }
                //如果页面传值type=read那么忽略该页面权限
                if (WebCommon.Public.ToString(Request.QueryString["type"]) == "read")
                {
                    IsFile = false;
                }
                //判断在权限约束范围内的文件是否拥有访问权
                if (IsFile)
                {
                    //判断用户是否已经登录
                    if (WebCommon.Public.GetUserName() == "")
                    {
                        WebCommon.Script.AlertAndParentRedirect("尚未登录，请您正常登录后使用该系统！", "../Default.aspx");
                    }
                    //开始判断权限字符是否呼应
                    bool IsPass = false;
                    string LimitStr = WebCommon.Public.GetUserLimit();
                    string[] LimitStrSplit = LimitStr.Split(',');
                    //WebCommon.Script.Alert(FileName);
                    foreach (string str in LimitStrSplit)
                    {
                        if (str != "")
                        {
                            if (FileName.Contains(str.ToLower().Split('.')[0]))
                            {
                                if (WebCommon.Public.ToString(Request.QueryString["limit"]) == "")
                                {
                                    IsPass = true;
                                    break;
                                }
                                else
                                {
                                    if (str.ToLower().Split('.').Length > 1)
                                    {
                                        if (str.ToLower().Split('.')[1].Contains(Request.QueryString["limit"]))
                                        {
                                            IsPass = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //当页面未通过验证时提醒
                    if (!IsPass)
                    {
                        WebCommon.Script.AlertAndGoBack("您尚未获得管理员授权许可！");
                    }
                }
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //在应用程序启动时运行的代码
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //在应用程序关闭时运行的代码

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //在出现未处理的错误时运行的代码

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //在新会话启动时运行的代码

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式 
            //设置为 StateServer 或 SQLServer，则不会引发该事件。

        }
    }
}