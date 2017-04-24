using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Alert : System.Web.UI.Page
    {
        public string AlertTitle;
        public string AlertType;
        public string AddDate;
        public string AlertInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //任务栏消息更新为已读
                int AlertID = WebCommon.Public.ToInt(Request.QueryString["AlertID"]);
                if (AlertID > 0)
                {
                    WebModels.Tbl_Alert alert = WebBLL.Tbl_AlertManager.GetTbl_AlertById(AlertID);
                    AlertTitle = alert.AlertTitle;
                    AlertType = alert.AlertType;
                    AddDate = alert.AddDate.ToString("yyyy-MM-dd");
                    AlertInfo = alert.AlertInfo;
                }
            }
        }
    }
}