using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Limit_Edit : System.Web.UI.Page
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
                ReadValue();
            }

        }

        public string LimitInfoText = "";
        public void ReadValue()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Limit limit = WebBLL.Tbl_LimitManager.GetTbl_LimitById(ID);
            this.LimitName.Text = limit.LimitName;
            this.Remark.Text = limit.Remark;
            LimitInfoText = limit.LimitInfo;
        }

        public void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Limit limit = WebBLL.Tbl_LimitManager.GetTbl_LimitById(ID);
            limit.LimitName = this.LimitName.Text;
            limit.LimitInfo = Request.Form["LimitInfo"];
            limit.Remark = this.Remark.Text;
            limit.DealTime = DateTime.Now;
            limit.DealUser = "";
            int count = WebBLL.Tbl_LimitManager.UpdateTbl_Limit(limit);
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