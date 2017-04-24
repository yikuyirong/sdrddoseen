using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class User_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置只读权限
                if (Request.QueryString["type"] == "read")
                {
                    btn_submit.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "$(function(){$('input').attr('readonly', 'readonly');$('select').attr('disabled', 'true');$('textarea').attr('readonly', 'readonly');});", true);
                }
                //角色
                LimitID.DataSource = WebBLL.Tbl_LimitManager.GetTbl_LimitAll();
                LimitID.DataTextField = "LimitName";
                LimitID.DataValueField = "LimitName";
                LimitID.DataBind();
                LimitID.Items.Insert(0, new ListItem("选择角色", ""));
                //部门
                U_DepartID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(52);
                U_DepartID.DataTextField = "ClassName";
                U_DepartID.DataValueField = "ClassName";
                U_DepartID.DataBind();
                U_DepartID.Items.Insert(0, new ListItem("选择部门", ""));
                //职位
                U_JobID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(54);
                U_JobID.DataTextField = "ClassName";
                U_JobID.DataValueField = "ClassName";
                U_JobID.DataBind();
                U_JobID.Items.Insert(0, new ListItem("选择职位", ""));
                //职级
                U_JobRank.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(215);
                U_JobRank.DataTextField = "ClassName";
                U_JobRank.DataValueField = "ClassName";
                U_JobRank.DataBind();
                U_JobRank.Items.Insert(0, new ListItem("选择职级", ""));
                //职称
                U_JobTitle.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(220);
                U_JobTitle.DataTextField = "ClassName";
                U_JobTitle.DataValueField = "ClassName";
                U_JobTitle.DataBind();
                U_JobTitle.Items.Insert(0, new ListItem("选择职称", ""));
                //专业
                U_Specialty.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                U_Specialty.DataTextField = "ClassName";
                U_Specialty.DataValueField = "ClassName";
                U_Specialty.DataBind();
                //U_Specialty.Items.Insert(0, new ListItem("选择专业", ""));
                ReadValue();
            }
        }

        public void ReadValue()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_User user = WebBLL.Tbl_UserManager.GetTbl_UserById(ID);
            this.UserName.Value = user.UserName;
            this.LimitID.SelectedValue = user.LimitID.ToString();
            U_DesignLimit.SelectedValue = user.U_DesignLimit;
            this.UserPwd.Text = user.UserPwd;
            this.U_DepartID.SelectedValue = user.U_DepartID.ToString();
            this.U_JobID.SelectedValue = user.U_JobID.ToString();
            foreach (ListItem li in U_Specialty.Items)
            {
                if (user.U_Specialty.Contains(li.Text)) li.Selected = true;
            }
            this.U_Name.Value = user.U_Name;
            this.U_Phone.Value = user.U_Phone;
            this.U_Mobile.Value = user.U_Mobile;
            this.U_Email.Value = user.U_Email;
            this.U_Sex.SelectedValue = user.U_Sex;
            this.U_Degrees.Value = user.U_Degrees;
            this.U_GraduateTime.Value = user.U_GraduateTime.ToString("yyyy-MM-dd");
            this.U_EntryTime.Value = user.U_EntryTime.ToString("yyyy-MM-dd");
            this.U_Professional.Value = user.U_Professional;
            this.Status.Text = user.Status;
            this.U_JobRank.SelectedValue = user.U_JobRank;
            this.U_JobTitle.SelectedValue = user.U_JobTitle;
            this.U_ContractStartTime.Value = user.U_ContractStartTime.ToString("yyyy-MM-dd");
            this.U_ContractEndTime.Value = user.U_ContractEndTime.ToString("yyyy-MM-dd");
            this.U_DocumentTime.Value = user.U_DocumentTime.ToString("yyyy-MM-dd");
            this.U_CardID.Value = user.U_CardID;
            this.Remark.Value = user.Remark;
            foreach (ListItem li in U_DesignLimit.Items)
            {
                if (user.U_DesignLimit.Contains(li.Text)) li.Selected = true ;
            }
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_User user = WebBLL.Tbl_UserManager.GetTbl_UserById(ID);
            user.UserName = this.UserName.Value;
            user.LimitID = this.LimitID.SelectedValue;
            if (this.UserPwd.Text != "") user.UserPwd = WebCommon.Public.GetMD5(this.UserPwd.Text);
            user.U_DepartID = this.U_DepartID.SelectedValue;
            user.U_JobID = this.U_JobID.SelectedValue;
            user.U_Name = this.U_Name.Value;
            user.U_Phone = this.U_Phone.Value;
            user.U_Mobile = this.U_Mobile.Value;
            user.U_Sex = this.U_Sex.SelectedValue;
            user.U_Email = this.U_Email.Value;
            user.Status = this.Status.SelectedValue;
            user.U_Degrees = this.U_Degrees.Value;
            user.U_GraduateTime = Convert.ToDateTime(this.U_GraduateTime.Value);
            user.U_EntryTime = Convert.ToDateTime(this.U_EntryTime.Value);
            user.U_Professional = this.U_Professional.Value;
            string U_SpecialtyText = "";
            foreach (ListItem li in U_Specialty.Items)
            {
                if (li.Selected) U_SpecialtyText += li.Value + ",";
            }
            user.U_Specialty = U_SpecialtyText;
            user.U_JobRank = this.U_JobRank.SelectedValue;
            user.U_JobTitle = this.U_JobTitle.SelectedValue;
            user.U_ContractStartTime = Convert.ToDateTime(this.U_ContractStartTime.Value);
            user.U_ContractEndTime = Convert.ToDateTime(this.U_ContractEndTime.Value);
            user.U_DocumentTime = Convert.ToDateTime(this.U_DocumentTime.Value);
            user.U_CardID = this.U_CardID.Value;
            string DesignLimit = "";
            foreach (ListItem li in U_DesignLimit.Items)
            {
                if (li.Selected) DesignLimit += "," + li.Text;
            }
            if (DesignLimit.Contains(",")) DesignLimit = DesignLimit.Remove(0, 1);
            user.U_DesignLimit = DesignLimit;
            user.Remark = this.Remark.Value;
            //user.U_Sign = "";
            //user.U_SignDxf = "";
            user.DealUser = "";
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