using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class WeekWork_Edit : System.Web.UI.Page
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
            ClassID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByAllParentID(79);
            ClassID.DataTextField = "ClassName";
            ClassID.DataValueField = "ClassName";
            ClassID.DataBind();

            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            WebModels.Tbl_Info info = WebBLL.Tbl_InfoManager.GetTbl_InfoById(ID);
            this.ClassID.Text = info.ClassID.ToString();
            this.I_Title.Text = info.I_Title;
            this.I_Content.Value = info.I_Content;
            this.AddDate.Text =Convert.ToString(info.AddDate);
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            WebModels.Tbl_Info info = WebBLL.Tbl_InfoManager.GetTbl_InfoById(ID);
            info.ClassID = this.ClassID.SelectedValue.Remove(0, 1);
            info.I_Title = this.I_Title.Text;
            info.I_Keyword = "";
            info.I_Description = "";
            info.I_Content = this.I_Content.Value;
            info.I_File = "";
            info.I_Pic = "";
            info.OrderNum = 0;
            info.Status = "";
            info.DealUser =WebCommon.Public.GetUserName();
            if (this.AddDate.Text != "")
            {
                info.AddDate = Convert.ToDateTime(this.AddDate.Text);
            }
            else
            {
                info.AddDate = System.DateTime.Now;
            }
            int count = WebBLL.Tbl_InfoManager.UpdateTbl_Info(info);
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