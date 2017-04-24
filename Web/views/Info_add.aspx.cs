using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Info_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(UserNameTo);
                ClassID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByAllParentID(45);
                ClassID.DataTextField = "ClassName";
                ClassID.DataValueField = "ClassName";
                ClassID.DataBind();
                ClassID.Items.Insert(0, new ListItem("选择信息分类", ""));
                this.AddDate.Text =Convert.ToString(System.DateTime.Now);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Info info = new WebModels.Tbl_Info();
            info.UserName = WebCommon.Public.GetUserName();
            info.ClassID = this.ClassID.SelectedValue.Remove(0, 1);
            info.I_Title = this.I_Title.Text;
            info.I_Keyword = this.I_Keyword.Text;
            info.I_Description = this.I_Description.Text;
            info.I_Content = this.I_Content.Value;
            info.I_File = WebCommon.Public.UploadFile(I_File, "info_file");
            info.I_Pic = WebCommon.Public.UploadFile(I_Pic, "info_pic");
            if (PicWidth.Text != "" && PicHeight.Text != "") WebCommon.Public.CutPic(info.I_Pic, info.I_Pic.Insert(info.I_Pic.Length - 4, "_"), Convert.ToInt32(PicWidth.Text), Convert.ToInt32(PicHeight.Text), 90);//生成缩略图
            info.I_Type = this.I_Type.SelectedValue;
            info.OrderNum = Convert.ToInt32(this.OrderNum.Text);
            //string StatusText = "";
            //foreach (ListItem li in Status.Items)
            //{
            //    if (li.Selected) StatusText += li.Text + ",";
            //}
            info.Status = this.Status.SelectedValue;
            info.NodeStatus = "部门主管审核";
            WebModels.Tbl_User user = WebBLL.Tbl_UserManager.GetTbl_UserDepartLeader(WebCommon.Public.GetUserName());
            info.NodeUser = user.UserName;
            info.UserNameTo = WebCommon.Public.ListBoxValuesGet(UserNameTo);
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