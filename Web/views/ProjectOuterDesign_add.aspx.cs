using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectOuterDesign_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定项目              
                ProjectID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectID.DataTextField = "ClassName";
                ProjectID.DataValueField = "ClassName";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("选择项目类别",""));
                ProjectName.Items.Insert(0, new ListItem("选择项目",""));
                //单位类型
                PO_CompanyType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(97);
                PO_CompanyType.DataTextField = "ClassName";
                PO_CompanyType.DataValueField = "ClassName";
                PO_CompanyType.DataBind();
                PO_CompanyType.Items.Insert(0, new ListItem("选择单位类型",""));
                PO_CompanyID.Items.Insert(0, new ListItem("选择单位",""));
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectOuterDesign Design = new WebModels.Tbl_ProjectOuterDesign();
            Design.ProjectID = Convert.ToInt32(this.ProjectName.SelectedValue);
            Design.PO_CompanyID = Convert.ToInt32(this.PO_CompanyID.SelectedValue);
            Design.PO_Content = this.PO_Content.Value;
            Design.PO_StartTime = Convert.ToDateTime(this.PO_StartTime.Value);
            Design.PO_Price = Convert.ToDouble(this.PO_Price.Value);
            Design.PO_FeeType = this.PO_FeeType.SelectedValue;
            Design.Status = this.Stauts.SelectedValue;
            Design.Remark = this.Remark.Value;
            Design.DealUser =WebCommon.Public.GetUserName();
            Design.PO_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectOuterDesign");
            int count = WebBLL.Tbl_ProjectOuterDesignManager.AddTbl_ProjectOuterDesign(Design);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
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
        protected void PO_CompanyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PO_CompanyID.DataSource = WebBLL.Tbl_ProjectOuterCompanyManager.GetTbl_ProjectOuterCompanyType(this.PO_CompanyType.SelectedValue);
            //PO_CompanyID.DataTextField = "POC_Name";
            //PO_CompanyID.DataValueField = "ID";
            //PO_CompanyID.DataBind();
            //PO_CompanyID.Items.Insert(0, new ListItem("选择单位", ""));
        }
    }
}