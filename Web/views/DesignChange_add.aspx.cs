using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignChange_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目ID
                ProjectID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectID.DataTextField = "ClassName";
                ProjectID.DataValueField = "ClassName";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("选择项目类别",""));
                ProjectName.Items.Insert(0, new ListItem("选择项目",""));
                ChangeTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_DesignChange change = new WebModels.Tbl_DesignChange();
            change.UserName = WebCommon.Public.GetUserName();
            change.Contact = this.Contact.Value;
            change.Phone = this.Phone.Value;
            change.ChangeTime = Convert.ToDateTime(this.ChangeTime.Value);
            change.ProjectID = Convert.ToInt32(this.ProjectName.SelectedValue);
            change.ChangeInfo = this.ChangeInfo.Value;
            change.ChangeFile = WebCommon.Public.UploadFile(FileUpload1, "DesginChange");
            change.ChangeDwg = WebCommon.Public.UploadFile(FileUpload2, "DesginChange");
            change.FileNo = this.FileNo.Value;
            change.Status = "设总审核";
            change.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_DesignChangeManager.AddTbl_DesignChange(change);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功，请等待设总的审核!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectID.SelectedValue);
            ProjectName.DataTextField = "ProjectName";
            ProjectName.DataValueField = "ID";
            ProjectName.DataBind();
            ProjectName.Items.Insert(0, new ListItem("选择项目",""));
        }
    }
}