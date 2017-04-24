using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Message_Detail : System.Web.UI.Page
    {
        public string UserNameFrom;
        public DateTime AddDate;
        public string MessageInfo;
        public string MessageFile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind() {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Message Message = WebBLL.Tbl_MessageManager.GetTbl_MessageById(ID);
            UserNameFrom = Message.UserNameFrom;
            AddDate = Message.AddDate;
            MessageInfo = Message.MessageInfo;
            MessageFile = Message.MessageFile;
        }
    }
}