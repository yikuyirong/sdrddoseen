using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuilderLog_Add : System.Web.UI.Page
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
                ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
                PBL_Time.Text = DateTime.Now.ToString("yyy-MM-dd");
            }
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
            WebModels.Tbl_ProjectBuilderLog log = new WebModels.Tbl_ProjectBuilderLog();
            log.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            log.PBL_Time = Convert.ToDateTime(this.PBL_Time.Text);
            log.PBL_Whether = this.PBL_Whether.Value;
            log.PBL_Wind = this.PBL_Wind.Value;
            log.PBL_Temperature = this.PBL_Temperature.Value;
            log.PBL_Info1 = this.PBL_Info1.Value;
            log.PBL_Info1File = WebCommon.Public.UploadFile(PBL_Info1File, "ProjectBuilderLog");
            log.PBL_Info2File = WebCommon.Public.UploadFile(PBL_Info2File, "ProjectBuilderLog");
            log.PBL_Info3File = WebCommon.Public.UploadFile(PBL_Info3File, "ProjectBuilderLog");
            log.PBL_Info2 = this.PBL_Info2.Value;
            log.PBL_Info3 = this.PBL_Info3.Value;
            log.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectBuilderLogManager.AddTbl_ProjectBuilderLog(log);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
    }
}