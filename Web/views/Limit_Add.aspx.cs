using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Limit_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Limit limit = new WebModels.Tbl_Limit();
            limit.LimitName = this.LimitName.Text;
            limit.LimitInfo = Request.Form["LimitInfo"];
            limit.Remark = this.Remark.Text;
            limit.DealUser ="";
            int count = WebBLL.Tbl_LimitManager.AddTbl_Limit(limit);
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