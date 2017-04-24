using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Project_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置只读权限
                if (Request.QueryString["type"] == "read")
                {
                    btn_submit.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "$(function(){$('input').attr('readonly', 'readonly');$('select').attr('disabled', 'true');$('textarea').attr('readonly', 'readonly');});", true);
                }

                //专业类别
                ProjectTypes.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectTypes.DataTextField = "ClassName";
                ProjectTypes.DataValueField = "ClassName";
                ProjectTypes.DataBind();
                //级别
                ProjectLevel.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(58);
                ProjectLevel.DataTextField = "ClassName";
                ProjectLevel.DataValueField = "ClassName";
                ProjectLevel.DataBind();
                //部门
                Depart.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(52);
                Depart.DataTextField = "ClassName";
                Depart.DataValueField = "ClassName";
                Depart.DataBind();
                Depart.Items.Insert(0, new ListItem("选择部门",""));

                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            this.ProjectName.Value = project.ProjectName;
            this.ProjectNo.Value = project.ProjectNo;
            this.ProjectManager.Text = project.ProjectManager;
            this.ProjectManager.Items.Insert(0, project.ProjectManager);
            this.ProjectCustom.Value = project.ProjectCustom;
            //this.ProjectStartTime.Value = project.ProjectStartTime.ToString("yyyy-MM-dd");
            //this.ProjectEndTime.Value = project.ProjectEndTime.ToString("yyyy-MM-dd");
            this.ProjectTypes.Text = project.ProjectTypes;
            this.ProjectCity.Value = project.ProjectCity;
            this.ProjectLevel.Text = project.ProjectLevel;
            this.ProjectInfo.Value = project.ProjectInfo;
            this.ProjectCustomContact.Value = project.ProjectCustomContact;
            this.ProjectCustomPhone.Value = project.ProjectCustomPhone;
            ProjectMW.Text = project.ProjectMW;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            project.ProjectName = this.ProjectName.Value;
            project.ProjectNo = this.ProjectNo.Value;
            project.ProjectCustom = this.ProjectCustom.Value;
            project.ProjectManager = this.ProjectManager.SelectedValue;
            //project.ProjectStartTime = Convert.ToDateTime(this.ProjectStartTime.Value);
            //project.ProjectEndTime = Convert.ToDateTime(this.ProjectEndTime.Value);
            project.ProjectTypes = this.ProjectTypes.SelectedValue;
            project.ProjectCity = this.ProjectCity.Value;
            project.ProjectLevel = this.ProjectLevel.SelectedValue;
            project.ProjectInfo = this.ProjectInfo.Value;
            project.ProjectCustomContact = this.ProjectCustomContact.Value;
            project.ProjectCustomPhone = this.ProjectCustomPhone.Value;
            project.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }

        protected void Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectManager.DataSource = WebBLL.Tbl_UserManager.GetTbl_UserByDepartID(this.Depart.SelectedValue);
            ProjectManager.DataTextField = "UserName";
            ProjectManager.DataValueField = "UserName";
            ProjectManager.DataBind();
        }
    }
}