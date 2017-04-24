using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectOuterDesign_Edit : System.Web.UI.Page
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
                ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectName.DataTextField = "ProjectName";
                ProjectName.DataValueField = "ID";
                ProjectName.DataBind();
                PO_CompanyID.DataSource = WebBLL.Tbl_ProjectOuterCompanyManager.GetTbl_ProjectOuterCompanyAll();
                PO_CompanyID.DataTextField = "POC_Name";
                PO_CompanyID.DataValueField = "ID";
                PO_CompanyID.DataBind();
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectOuterDesign Design = WebBLL.Tbl_ProjectOuterDesignManager.GetTbl_ProjectOuterDesignById(ID);
            this.ProjectName.Text = Design.ProjectID.ToString();
            this.PO_CompanyID.Text = Design.PO_CompanyID.ToString();
            this.PO_Content.Value = Design.PO_Content;
            this.PO_Price.Value = Design.PO_Price.ToString();
            this.PO_StartTime.Value = Design.PO_StartTime.ToString("yyyy-MM-dd");
            this.Stauts.SelectedValue = Design.Status;
            this.Remark.Value = Design.Remark;
            this.PO_FeeType.SelectedValue = Design.PO_FeeType;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectOuterDesign Design = WebBLL.Tbl_ProjectOuterDesignManager.GetTbl_ProjectOuterDesignById(ID);
            Design.PO_Content = this.PO_Content.Value;
            Design.PO_StartTime = Convert.ToDateTime(this.PO_StartTime.Value);
            Design.PO_Price = Convert.ToDouble(this.PO_Price.Value);
            Design.PO_FeeType = this.PO_FeeType.SelectedValue;
            Design.Status = this.Stauts.SelectedValue;
            Design.Remark = this.Remark.Value;
            if (FileUpload1.FileName != "")
            {
                Design.PO_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectOuterDesign");
            }
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
    }
}