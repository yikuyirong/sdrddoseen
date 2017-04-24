using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.inc
{
    public partial class wintop : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //任务栏消息更新为已读
            int AlertID = WebCommon.Public.ToInt(Request.QueryString["AlertID"]);
            if (AlertID > 0)
            {
                WebModels.Tbl_Alert alert = WebBLL.Tbl_AlertManager.GetTbl_AlertById(AlertID);
                alert.Status = "已读";
                WebBLL.Tbl_AlertManager.UpdateTbl_Alert(alert);
            }
        }
    }
}