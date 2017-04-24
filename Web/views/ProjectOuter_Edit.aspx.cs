using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectOuter_Edit : System.Web.UI.Page
    {
        public string Title = "";
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
                Bind();
            }

            Title = WebCommon.Public.ToString(Request.QueryString["limit"]);
        }
        public void Bind() {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectOuter outer = WebBLL.Tbl_ProjectOuterManager.GetTbl_ProjectOuterById(ID);
            this.PO_Name.Value = outer.PO_Name;
            this.PO_Content.Value = outer.PO_Content;
            this.PO_StartTime.Value = outer.PO_StartTime.ToString("yyyy-MM-dd");
            this.PO_Time1.Value = outer.PO_Time1.ToString("yyyy-MM-dd");
            this.PO_Time2.Value = outer.PO_Time2.ToString("yyyy-MM-dd");
            this.PO_Link.Value = outer.PO_Link;
            this.PO_LinkPhone.Value = outer.PO_LinkPhone;
            this.PO_FeeType.SelectedValue = outer.PO_FeeType;
            this.PO_Price.Value = outer.PO_Price.ToString();
            this.PO_PricePay.Value = outer.PO_PricePay.ToString();
            this.PO_PriceBill.Value = outer.PO_PriceBill.ToString();
            this.Remark.Value = outer.Remark.ToString();
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectOuter Design = WebBLL.Tbl_ProjectOuterManager.GetTbl_ProjectOuterById(ID);
            Design.PO_Content = this.PO_Content.Value;
            Design.PO_Name = PO_Name.Value;
            Design.PO_StartTime = Convert.ToDateTime(this.PO_StartTime.Value);
            Design.PO_Time1 = Convert.ToDateTime(this.PO_Time1.Value);
            Design.PO_Time2 = Convert.ToDateTime(this.PO_Time2.Value);
            Design.PO_Link = Convert.ToString(this.PO_Link.Value);
            Design.PO_LinkPhone = Convert.ToString(this.PO_LinkPhone.Value);
            Design.PO_Price = Convert.ToDouble(this.PO_Price.Value);
            Design.PO_PricePay = Convert.ToDouble(this.PO_PricePay.Value);
            Design.PO_PriceBill = Convert.ToDouble(this.PO_PriceBill.Value);
            Design.PO_FeeType = this.PO_FeeType.SelectedValue;
            Design.Remark = this.Remark.Value;
            Design.DealUser = WebCommon.Public.GetUserName();
            if (FileUpload1.FileName!="") Design.PO_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectBuyAcount");
            int count = WebBLL.Tbl_ProjectOuterManager.UpdateTbl_ProjectOuter(Design);
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