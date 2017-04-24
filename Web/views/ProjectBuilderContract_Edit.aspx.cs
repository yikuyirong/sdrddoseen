using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuilderContract_Edit : System.Web.UI.Page
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
                //项目类别
                ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectName.DataTextField = "ProjectName";
                ProjectName.DataValueField = "ID";
                ProjectName.DataBind();
                //单位类型
                PBC_CompanyID.DataSource = WebBLL.Tbl_ProjectOuterCompanyManager.GetTbl_ProjectOuterCompanyAll();
                PBC_CompanyID.DataTextField = "POC_Name";
                PBC_CompanyID.DataValueField = "ID";
                PBC_CompanyID.DataBind();
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectBuilderContract project = WebBLL.Tbl_ProjectBuilderContractManager.GetTbl_ProjectBuilderContractById(ID);
            this.ProjectName.SelectedValue = project.ProjectID.ToString();
            this.PBC_CompanyID.SelectedValue = project.PBC_CompanyID.ToString();
            this.PBC_StartTime.Value = project.PBC_StartTime.ToString("yyyy-MM-dd");
            this.PBC_Time1.Value = project.PBC_Time1.ToString("yyyy-MM-dd");
            this.PBC_Time2.Value = project.PBC_Time2.ToString("yyyy-MM-dd");
            this.PBC_Link.Value = project.PBC_Link.ToString();
            this.PBC_Content.Value = project.PBC_Content.ToString();
            this.PBC_Price.Value = project.PBC_Price.ToString();
            this.PBC_FeeType.SelectedValue = project.PBC_FeeType.ToString();
            this.Remark.Value = project.Remark.ToString();
            this.Stauts.SelectedValue = project.Status.ToString();
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectBuilderContract BuilderContract = WebBLL.Tbl_ProjectBuilderContractManager.GetTbl_ProjectBuilderContractById(ID);
            BuilderContract.PBC_StartTime = Convert.ToDateTime(this.PBC_StartTime.Value);
            BuilderContract.PBC_Time1 = Convert.ToDateTime(this.PBC_Time1.Value);
            BuilderContract.PBC_Time2 = Convert.ToDateTime(this.PBC_Time2.Value);
            BuilderContract.PBC_Link = this.PBC_Link.Value;
            BuilderContract.PBC_Content = this.PBC_Content.Value;
            if (FileUpload1.FileName != "")
            {
                BuilderContract.PBC_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectBuilderContract");
            }

            BuilderContract.PBC_Price = Convert.ToInt32(this.PBC_Price.Value);
            BuilderContract.PBC_FeeType = this.PBC_FeeType.SelectedValue;
            BuilderContract.Remark = this.Remark.Value;
            BuilderContract.Status = this.Stauts.SelectedValue;
            int count = WebBLL.Tbl_ProjectBuilderContractManager.UpdateTbl_ProjectBuilderContract(BuilderContract);
            if (true)
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