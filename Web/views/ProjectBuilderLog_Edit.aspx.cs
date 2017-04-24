using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuilderLog_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //专业类别
                ProjectTypes.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectTypes.DataTextField = "ClassName";
                ProjectTypes.DataValueField = "ClassName";
                ProjectTypes.DataBind();
                ProjectTypes.Items.Insert(0, new ListItem("选择类型", ""));

                Bind();
                
            }
        }
        protected void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectBuilderLog log = WebBLL.Tbl_ProjectBuilderLogManager.GetTbl_ProjectBuilderLogById(ID);
            this.PBL_Time.Text = log.PBL_Time.ToString("yyyy-MM-dd");
            this.PBL_Whether.Value = log.PBL_Whether;
            this.PBL_Temperature.Value = log.PBL_Temperature;
            this.PBL_Wind.Value = log.PBL_Wind;
            this.PBL_Info1.Value = log.PBL_Info1;
            this.PBL_Info2.Value = log.PBL_Info2;
            this.PBL_Info3.Value = log.PBL_Info3;
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(log.ProjectID);
            ProjectID.Items.Insert(0, new ListItem(project.ProjectName, project.ID.ToString()));
        }
        protected void ProjectTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectTypes.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectBuilderLog log = WebBLL.Tbl_ProjectBuilderLogManager.GetTbl_ProjectBuilderLogById(ID);
            log.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            log.PBL_Time = Convert.ToDateTime(this.PBL_Time.Text);
            log.PBL_Whether = this.PBL_Whether.Value;
            log.PBL_Wind = this.PBL_Wind.Value;
            log.PBL_Temperature = this.PBL_Temperature.Value;
            log.PBL_Info1 = this.PBL_Info1.Value;
            log.PBL_Info2 = this.PBL_Info2.Value;
            log.PBL_Info3 = this.PBL_Info3.Value;
            if (PBL_Info1File.FileName != "") log.PBL_Info1File = WebCommon.Public.UploadFile(PBL_Info1File, "ProjectBuilderLog");
            if (PBL_Info2File.FileName != "") log.PBL_Info2File = WebCommon.Public.UploadFile(PBL_Info2File, "ProjectBuilderLog");
            if (PBL_Info3File.FileName != "") log.PBL_Info3File = WebCommon.Public.UploadFile(PBL_Info3File, "ProjectBuilderLog");
            log.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectBuilderLogManager.UpdateTbl_ProjectBuilderLog(log);
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