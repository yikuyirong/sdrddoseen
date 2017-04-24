using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Message_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(UserNameTo);
                UserNameTo.SelectedValue = Request.QueryString["usernameto"];
            }

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Message Message = new WebModels.Tbl_Message();
            Message.UserNameFrom = WebCommon.Public.GetUserName();
            Message.UserNameTo =WebCommon.Public.ListBoxValuesGet(UserNameTo);
            if (Message.UserNameTo.Contains(","))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('您只能向单个人发送消息!');", true);
                return;
            }
            Message.MessageInfo = this.MessageInfo.Value;
            Message.MessageFile = WebCommon.Public.UploadFile(MessageFile, "Message"); ;
            Message.Status = "未读";
            Message.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_MessageManager.AddTbl_Message(Message);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('发送成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('发送失败!');", true);
            }
        }
    }
}