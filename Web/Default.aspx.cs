using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserName.Value = HttpUtility.UrlDecode(Request.Cookies["UserName"].Value);
                    if (Request.Cookies["SavePwd"] != null)
                    {
                        ckPwd.Checked = true;
                        UserPwd.Attributes.Add("value", HttpUtility.UrlDecode(Request.Cookies["UserPwd"].Value));
                    }
                }
                catch { }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string strName = UserName.Value.Trim();
            string strPWD = UserPwd.Text;
            if (strName == "" || strPWD == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('用户名或密码不能为空');", true);
                return;
            }
            if (WebBLL.Tbl_UserManager.UserLogin(strName, strPWD))
            {
                HttpCookie UserLogName = new HttpCookie("UserName", HttpUtility.UrlEncode(strName));
                UserLogName.Expires = DateTime.Now.AddDays(15);
                Response.Cookies.Add(UserLogName);
                if (ckPwd.Checked)
                {
                    HttpCookie savePwd = new HttpCookie("SavePwd", HttpUtility.UrlEncode("1"));
                    savePwd.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(savePwd);
                    HttpCookie UserLogPwd = new HttpCookie("UserPwd", HttpUtility.UrlEncode(strPWD));
                    UserLogPwd.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(UserLogPwd);
                }
                else
                {
                    Response.Cookies["SavePwd"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Cookies["UserLimit"].Value = "" ;//清空权限cookies强制读取新的权限字符串
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "window.open('../views/Main.aspx');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('用户名密码错误或人员非在职状态');", true);
            }
        }


    }
}