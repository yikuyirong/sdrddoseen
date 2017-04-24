using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowFormWord_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_FlowFormWord word = new WebModels.Tbl_FlowFormWord();
            word.FlowFormID = 0;
            word.IFW_Name = this.IFW_Name.Value;
            word.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowFormWordManager.AddTbl_FlowFormWord(word);
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