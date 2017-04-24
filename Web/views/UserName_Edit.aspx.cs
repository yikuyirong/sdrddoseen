using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class UserName_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_User user =WebBLL.Tbl_UserManager.GetTbl_UserById(ID);
            this.username.Text = user.UserName;
            this.u_name.Text = user.U_Name;
            
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_User user = WebBLL.Tbl_UserManager.GetTbl_UserById(ID);
            user.U_Sign = WebCommon.Public.UploadFile(FileUpload1, "Sign");
            user.U_SignDxf = WebCommon.Public.UploadFile(FileUpload2, "SignDxf");
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