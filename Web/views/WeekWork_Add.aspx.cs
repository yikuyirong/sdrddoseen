using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class WeekWork_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClassID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByAllParentID(79);
                ClassID.DataTextField = "ClassName";
                ClassID.DataValueField = "ClassName";
                ClassID.DataBind();
                ClassID.Items.Insert(0, new ListItem("选择信息分类", ""));
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Info info = new WebModels.Tbl_Info();
            info.ClassID = this.ClassID.SelectedValue.Remove(0, 1);
            info.I_Title = this.I_Title.Text;
            info.I_Keyword = "";
            info.I_Description = "";
            info.I_Content = this.I_Content.Value;
            info.I_File = "";
            info.I_Pic = "";
            info.I_Type = "";
            info.NodeUser = "";
            info.OrderNum = 0;
            info.NodeStatus = "";
            info.Status = "";
            info.UserNameTo = "";
            info.UserName = WebCommon.Public.GetUserName();
            info.DealUser =WebCommon.Public.GetUserName();
            if (this.AddDate.Text != "")
            {
                info.AddDate = Convert.ToDateTime(this.AddDate.Text);
            }
            else
            {
                info.AddDate = System.DateTime.Now;
            }
            int count = WebBLL.Tbl_InfoManager.AddTbl_Info(info);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
    }
}