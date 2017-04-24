using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignChange_Edit : System.Web.UI.Page
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
                ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectName.DataTextField = "ProjectName";
                ProjectName.DataValueField = "ID";
                ProjectName.DataBind();
                Bind();
            }

        }
        public string ChangeFile = "";
        public string ChangeDwg = "";
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_DesignChange change = WebBLL.Tbl_DesignChangeManager.GetTbl_DesignChangeById(ID);
            this.ProjectName.Text = change.ProjectID.ToString();
            this.Contact.Value = change.Contact;
            this.Phone.Value = change.Phone;
            this.ChangeTime.Value = change.ChangeTime.ToString("yyyy-MM-dd");
            this.ChangeInfo.Value = change.ChangeInfo;
            this.FileNo.Value = change.FileNo;
            ChangeFile = change.ChangeFile;
            ChangeDwg = change.ChangeDwg;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_DesignChange change = WebBLL.Tbl_DesignChangeManager.GetTbl_DesignChangeById(ID);
           
            change.Contact = this.Contact.Value;
            change.Phone = this.Phone.Value;
            change.ChangeTime = Convert.ToDateTime(this.ChangeTime.Value);
            change.ProjectID = Convert.ToInt32(this.ProjectName.SelectedValue);
            change.ChangeInfo = this.ChangeInfo.Value;
            change.FileNo = this.FileNo.Value;
            change.Status = "设总审核";
            change.DealUser =WebCommon.Public.GetUserName();
            if (FileUpload1.FileName!="")
            {
                change.ChangeFile = WebCommon.Public.UploadFile(FileUpload1, "DesginChange");
            }
            if (FileUpload2.FileName != "")
            {
                change.ChangeDwg = WebCommon.Public.UploadFile(FileUpload2, "DesginChange");
            }
          
            int count = WebBLL.Tbl_DesignChangeManager.UpdateTbl_DesignChange(change);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功,请等待设总审核!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }
    }
}