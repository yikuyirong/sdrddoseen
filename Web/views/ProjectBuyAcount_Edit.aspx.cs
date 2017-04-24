using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuyAcount_Edit : System.Web.UI.Page
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
                //设置外看只读权限
                if (Request.QueryString["limt"] == "read2")
                {
                    this.Acount.Visible = false;
                    this.AcountMoney.Visible = false;
                    btn_submit.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "$(function(){$('input').attr('readonly', 'readonly');$('select').attr('disabled', 'true');$('textarea').attr('readonly', 'readonly');});", true);
                }
                //绑定项目              
                ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectName.DataTextField = "ProjectName";
                ProjectName.DataValueField = "ID";
                ProjectName.DataBind();
                //单位
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
            WebModels.Tbl_ProjectBuyAcount Design = WebBLL.Tbl_ProjectBuyAcountManager.GetTbl_ProjectBuyAcountById(ID);
            this.ProjectName.Text = Design.ProjectID.ToString();
            this.PO_CompanyID.Text = Design.PO_CompanyID.ToString();
            this.PO_Content.Value = Design.PO_Content;
            this.PO_StartTime.Value = Design.PO_StartTime.ToString("yyyy-MM-dd");
            this.PO_Time1.Value = Design.PO_Time1.ToString("yyyy-MM-dd");
            this.PO_Time2.Value = Design.PO_Time2.ToString("yyyy-MM-dd");
            this.PO_Link.Value = Design.PO_Link;
            this.PO_Price.Value = Design.PO_Price.ToString();
            this.PO_FeeType.SelectedValue = Design.PO_FeeType;
            this.Stauts.SelectedValue = Design.Status;
            this.Remark.Value = Design.Remark;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectBuyAcount Design = WebBLL.Tbl_ProjectBuyAcountManager.GetTbl_ProjectBuyAcountById(ID);
            Design.PO_Content = this.PO_Content.Value;
            Design.PO_StartTime = Convert.ToDateTime(this.PO_StartTime.Value);
            Design.PO_Time1 = Convert.ToDateTime(this.PO_Time1.Value);
            Design.PO_Time2 = Convert.ToDateTime(this.PO_Time2.Value);
            Design.PO_Link = Convert.ToString(this.PO_Link.Value);
            Design.PO_Price = Convert.ToDouble(this.PO_Price.Value);
            Design.PO_FeeType = this.PO_FeeType.SelectedValue;
            Design.Status = this.Stauts.SelectedValue;
            Design.Remark = this.Remark.Value;
            Design.DealUser =WebCommon.Public.GetUserName();
            if (FileUpload1.FileName != "")
            {
                Design.PO_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectBuyAcount");
            }

            int count = WebBLL.Tbl_ProjectBuyAcountManager.UpdateTbl_ProjectBuyAcount(Design);
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