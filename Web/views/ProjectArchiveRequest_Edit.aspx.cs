using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectArchiveRequest_Edit : System.Web.UI.Page
    {
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Title = Request.QueryString["limit"];
                //设置只读权限
                if (Request.QueryString["type"] == "read")
                {
                    btn_submit.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "$(function(){$('input').attr('readonly', 'readonly');$('select').attr('disabled', 'true');$('textarea').attr('readonly', 'readonly');});", true);
                }
                //项目
                ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectID.DataTextField = "ProjectName";
                ProjectID.DataValueField = "ID";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
                PA_Name.DataSource = WebBLL.Tbl_ProjectArchiveManager.GetTbl_ProjectArchiveAll();
                PA_Name.DataTextField = "PA_Name";
                PA_Name.DataValueField = "ID";
                PA_Name.DataBind();
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectArchiveRequest project = WebBLL.Tbl_ProjectArchiveRequestManager.GetTbl_ProjectArchiveRequestById(ID);
            this.ProjectID.SelectedValue = project.ProjectID.ToString();
            this.PA_Name.SelectedValue = project.ProjectArchiveID.ToString();
            this.Remark.InnerText = project.Remark;
            this.RequestType.SelectedValue = project.RequestType;
            this.Status.SelectedValue = project.Status;
           
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectArchiveRequest project = WebBLL.Tbl_ProjectArchiveRequestManager.GetTbl_ProjectArchiveRequestById(ID);
            //project.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            //project.ClassName = this.ClassName.SelectedValue;
            //project.ClassType = this.ClassType.SelectedValue;
            //project.ProjectArchiveID = Convert.ToInt32(this.ProjectArchiveID.SelectedValue);
            project.Remark = Convert.ToString(this.Remark.Value);
            project.RequestType = Convert.ToString(this.RequestType.SelectedValue);
            project.Status = this.Status.SelectedValue;
            project.UserName = "doseen";
            int count = WebBLL.Tbl_ProjectArchiveRequestManager.UpdateTbl_ProjectArchiveRequest(project);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }
    }
}