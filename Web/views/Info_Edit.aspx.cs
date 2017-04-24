using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Info_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(UserNameTo);
                //设置只读权限
                if (Request.QueryString["type"] == "read")
                {
                    btnSave.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "$(function(){$('input').attr('readonly', 'readonly');$('select').attr('disabled', 'true');$('textarea').attr('readonly', 'readonly');});", true);
                }
                ClassID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByAllParentID(45);
                ClassID.DataTextField = "ClassName";
                ClassID.DataValueField = "ClassName";
                ClassID.DataBind();
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            WebModels.Tbl_Info info = WebBLL.Tbl_InfoManager.GetTbl_InfoById(ID);
            this.ClassID.SelectedValue = info.ClassID.ToString();
            this.I_Title.Text = info.I_Title;
            this.I_Keyword.Text = info.I_Keyword;
            this.I_Description.Text = info.I_Description;
            this.I_Content.Value = info.I_Content;
            this.I_Type.SelectedValue = info.I_Type;
            this.AddDate.Text = info.AddDate.ToString("yyyy-MM-dd");
            WebCommon.Public.ListBoxValuesSet(UserNameTo,info.UserNameTo);
            this.OrderNum.Text = Convert.ToString(info.OrderNum);
            //string[] chkList = info.Status.ToString().Split(',');
            ////CheckBoxList遍历赋值
            //for (int i = 0; i < info.Status.Split(',').Length - 1; i++)
            //{
            //    foreach (ListItem li in Status.Items)
            //    {
            //        if (info.Status.Split(',')[i] == li.Text) li.Selected = true;
            //    }
            //}
            this.Status.SelectedValue = info.Status;
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            WebModels.Tbl_Info info = WebBLL.Tbl_InfoManager.GetTbl_InfoById(ID);
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
            info.DealUser =WebCommon.Public.GetUserName();
            if (this.AddDate.Text != "")
            {
                info.AddDate = Convert.ToDateTime(this.AddDate.Text);
            }
            else
            {
                info.AddDate = System.DateTime.Now;
            }
            info.UserNameTo = WebCommon.Public.ListBoxValuesGet(UserNameTo);
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