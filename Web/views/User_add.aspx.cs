using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class User_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_User user = new WebModels.Tbl_User();
            user.UserName = this.UserName.Value;
            user.LimitID = this.LimitID.SelectedValue;
            user.UserPwd = WebCommon.Public.GetMD5(this.UserPwd.Text);
            user.U_DepartID = this.U_DepartID.SelectedValue;
            user.U_JobID = this.U_JobID.SelectedValue;
            user.U_Name = this.U_Name.Value;
            user.U_Phone = this.U_Phone.Value;
            user.U_Mobile = this.U_Mobile.Value;
            user.U_Email = this.U_Email.Value;
            user.U_Sex = this.U_Sex.SelectedValue;
            user.U_Degrees = this.U_Degrees.Value;
            user.U_GraduateTime =Convert.ToDateTime(this.U_GraduateTime.Value);
            user.U_EntryTime = Convert.ToDateTime(this.U_EntryTime.Value);
            user.U_Professional = this.U_Professional.Value;
            user.Status = this.Status.SelectedValue;
            user.U_Specialty = this.U_Specialty.SelectedValue;
            user.U_Sign = "";
            user.DealUser = "";
            user.U_SignDxf = "";
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
            user.U_DesignLimit=DesignLimit;
            user.Remark = this.Remark.Value;
            string where = "username='" + this.UserName.Value + "'";
            int usercount = WebBLL.Tbl_UserManager.GetDataTableByCount(where);
            if (usercount < 1)
            {
                int count = WebBLL.Tbl_UserManager.AddTbl_User(user);
                if (count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
                }
            }
            else {
                this.UserName.Value = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('该用户名已存在,请重新输入!');", true);
            }
        }

        protected void U_JobID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (U_JobID.SelectedItem.Text.Contains("设计师"))
            //{
            //    U_Specialty.Enabled = true;
            //}
        }
    }
}