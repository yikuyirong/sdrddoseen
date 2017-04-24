using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Project_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("tbl_Project", "id in(" + ids + ")");
                    if (count > 0)
                    {
                        WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败！");
                    }
                }
                //重启
                if (Request.QueryString["limit"] == "reset")
                {
                    int ProjectID =WebCommon.Public.ToInt(Request.QueryString["id"].ToString());
                    WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ProjectID);
                    project.NodeNo = "发起合同评审";
                    project.Status = "进行中";
                    project.NodeUser = WebCommon.Public.GetUserName();
                    WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
                    WebCommon.Script.AlertAndGoBack("重启成功");
                }
                //绑定列表
                Bind();
            }
        }
        public void Bind()
        {
            string strWhere = "";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_ProjectManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_ProjectManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc,ProjectNo desc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}