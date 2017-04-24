using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_User user = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName());
            //判断原始密码是否正确
            if (WebCommon.Public.GetMD5(password.Text) != user.UserPwd)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('原始密码不正确');", true);
                return;
            }
            //判断两次密码输入一样
            if (newspass.Text != newspass2.Text)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('两次密码输入不一样');", true);
                return;
            }
            //更新密码
            user.UserPwd = WebCommon.Public.GetMD5(this.newspass.Text);
            int count = WebBLL.Tbl_UserManager.UpdateTbl_User(user);
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