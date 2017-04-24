using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBid_Edit : System.Web.UI.Page
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
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectBid bid = WebBLL.Tbl_ProjectBidManager.GetTbl_ProjectBidById(ID);
            this.PB_Name.Text = bid.PB_Name;
            this.PB_Info.Value = bid.PB_Info;
            this.Status.Text = bid.Status.Trim();
            this.Remark.Value = bid.Remark;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectBid bid = WebBLL.Tbl_ProjectBidManager.GetTbl_ProjectBidById(ID);
            bid.PB_Info = this.PB_Info.Value;
            bid.Remark = this.Remark.Value;
            bid.Status = this.Status.SelectedValue;
            bid.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectBidManager.UpdateTbl_ProjectBid(bid);
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