using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectOuterCompany_Edit : System.Web.UI.Page
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
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectOuterCompany company = WebBLL.Tbl_ProjectOuterCompanyManager.GetTbl_ProjectOuterCompanyById(ID);
            this.POC_Name.Value = company.POC_Name;
            this.POC_LinkMan.Value = company.POC_LinkMan;
            this.POC_LinkPhone.Value = company.POC_LinkPhone;
            this.POC_Email.Value = company.POC_Email;
            this.POC_Address.Value = company.POC_Address;
            this.Remark.Value = company.Remark;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectOuterCompany company = WebBLL.Tbl_ProjectOuterCompanyManager.GetTbl_ProjectOuterCompanyById(ID);
            company.POC_Name = this.POC_Name.Value;
            company.POC_LinkMan = this.POC_LinkMan.Value;
            company.POC_LinkPhone = this.POC_LinkPhone.Value;
            company.POC_Email = this.POC_Email.Value;
            company.POC_Address = this.POC_Address.Value;
            company.Remark = this.Remark.Value;
            company.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectOuterCompanyManager.UpdateTbl_ProjectOuterCompany(company);
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