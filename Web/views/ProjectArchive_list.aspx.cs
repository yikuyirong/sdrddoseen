using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectArchive_list : System.Web.UI.Page
    {
        public string limitShow = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    WebModels.Tbl_ProjectArchive archive = WebBLL.Tbl_ProjectArchiveManager.GetTbl_ProjectArchiveById(Convert.ToInt32(ids));
                    if (archive.Status == "已审核")
                    {
                        WebCommon.Script.AlertAndGoBack("不允许删除！");
                    }
                    else
                    {
                        int count = WebCommon.Public.DataTableDel("tbl_ProjectArchive", "id in(" + ids + ")");
                        if (count > 0)
                        {
                            WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                        }
                        else
                        {
                            WebCommon.Script.AlertAndGoBack("删除失败！");
                        }
                    }
                }
                //绑定列表
                Bind();

                //管理权限
                if (WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set1.Contains(WebCommon.Public.GetUserName()))
                {
                    limitShow="";
                }
                else
                {
                    limitShow = "none";
                }
            }
        }
        public void Bind()
        {
            string strWhere = "";
            
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            strWhere = strWhere.Replace("*", "'");
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_ProjectArchiveManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_ProjectArchiveManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}