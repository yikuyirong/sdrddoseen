using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuilderContract_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
            //项目类别
            ProjectID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
            ProjectID.DataTextField = "ClassName";
            ProjectID.DataValueField = "ClassName";
            ProjectID.DataBind();
            ProjectName.Items.Insert(0, new ListItem("选择项目",""));
            //单位类型
            PBC_CompanyType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(97);
            PBC_CompanyType.DataTextField = "ClassName";
            PBC_CompanyType.DataValueField = "ClassName";
            PBC_CompanyType.DataBind();
            PBC_CompanyType.Items.Insert(0, new ListItem("选择单位类型",""));
            PBC_CompanyID.Items.Insert(0, new ListItem("选择单位",""));
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectBuilderContract BuilderContract = new WebModels.Tbl_ProjectBuilderContract();
            BuilderContract.ProjectID = Convert.ToInt32(this.ProjectName.SelectedValue);
            BuilderContract.PBC_CompanyID = Convert.ToInt32(this.PBC_CompanyID.SelectedValue);
            BuilderContract.PBC_StartTime = Convert.ToDateTime(this.PBC_StartTime.Value);
            BuilderContract.PBC_Time1 =Convert.ToDateTime(this.PBC_Time1.Value);
            BuilderContract.PBC_Time2 = Convert.ToDateTime(this.PBC_Time2.Value);
            BuilderContract.PBC_Link = this.PBC_Link.Value;
            BuilderContract.PBC_Content = this.PBC_Content.Value;
            BuilderContract.PBC_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectBuilderContract");
            BuilderContract.PBC_Price = Convert.ToInt32(this.PBC_Price.Value);
            BuilderContract.PBC_FeeType = this.PBC_FeeType.SelectedValue;
            BuilderContract.Remark = this.Remark.Value;
            BuilderContract.Status = this.Stauts.SelectedValue;
            BuilderContract.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectBuilderContractManager.AddTbl_ProjectBuilderContract(BuilderContract);
            if (true)
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
            ProjectName.Items.Insert(0,new ListItem("选择项目",""));
        }

        protected void PBC_CompanyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PBC_CompanyID.DataSource = WebBLL.Tbl_ProjectOuterCompanyManager.GetTbl_ProjectOuterCompanyType(this.PBC_CompanyType.SelectedValue);
            //PBC_CompanyID.DataTextField = "POC_Name";
            //PBC_CompanyID.DataValueField = "ID";
            //PBC_CompanyID.DataBind();
            //PBC_CompanyID.Items.Insert(0, new ListItem("选择单位",""));
        }
    }
}