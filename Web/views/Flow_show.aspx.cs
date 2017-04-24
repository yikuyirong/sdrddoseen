using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
	public partial class Flow_show : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Repeater1.DataSource = WebBLL.Tbl_FlowNodeManager.GetTbl_FlowNodesByFlowID(WebCommon.Public.ToInt(Request.QueryString["flowid"]));
            Repeater1.DataBind();
            if (Repeater1.Items.Count == 0)
            {
                WebCommon.Script.Alert("流程图不存在");
            }
		}
	}
}