using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Project_Edit2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(ProjectMainDesigner);
                ProjectMainDesigner.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "u_designlimit like '%设总%'", "");
                ProjectMainDesigner.DataTextField = "UserName";
                ProjectMainDesigner.DataValueField = "ID";
                ProjectMainDesigner.DataBind();
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            this.ProjectName.Value = project.ProjectName;
            this.ProjectNo.Value = project.ProjectNo;
            ProjectMainDesigner.SelectedValue = project.ProjectMainDesigner;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            project.ProjectMainDesigner = this.ProjectMainDesigner.SelectedItem.Text;
            project.DealUser = WebCommon.Public.GetUserName();
            project.NodeNo = "设总人员审批";
            //project.NodeUser = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set4;//院长审批
            project.NodeUser = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set5;//技术院长审批
            int count = WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加设总成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加设总失败!');", true);
            }
        }
    }
}