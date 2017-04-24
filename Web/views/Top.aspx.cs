using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Top : System.Web.UI.Page
    {
        public string MenuStyle = "cursor: pointer; margin:0 5px;border-bottom: 1px solid #4f9ec2;margin-top: 10px; height: 18px; line-height: 18px; text-align: center; font-size: 12px;color: #fff";
        public string LimitStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            LimitStr = WebCommon.Public.GetUserLimit();
            LocalUser.Text = WebCommon.Public.GetUserName();
            LocalJueSe.Text = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).LimitID;
        }
    }
}