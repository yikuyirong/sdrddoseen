using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectDocument_Edit : System.Web.UI.Page
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
                //项目类型
                ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectID.DataTextField = "ProjectName";
                ProjectID.DataValueField = "ID";
                ProjectID.DataBind();
                //专业
                ClassName.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName.DataTextField = "ClassName";
                ClassName.DataValueField = "ClassName";
                ClassName.DataBind();
                Bind();
            }
        }

        public void Bind() {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectDocument document =WebBLL.Tbl_ProjectDocumentManager.GetTbl_ProjectDocumentById(ID);
            this.ProjectID.Text = document.ProjectID.ToString();
            this.ParentID.Text = document.ParentID.ToString();
            this.ClassName.Text = document.ClassName;
            this.PD_Type.Text = document.PD_Type;
            this.PD_Name.Value = document.PD_Name;
            this.PD_FileNo.Value = document.PD_FileNo;
            this.Remark.Value = document.Remark;
            this.Status.Text = document.Status;
            lishitizi.Visible = false;
           
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectDocument document = WebBLL.Tbl_ProjectDocumentManager.GetTbl_ProjectDocumentById(ID);           
            document.ClassName = this.ClassName.SelectedValue;
            document.PD_Type = this.PD_Type.SelectedValue;
            //if (this.PD_Type.SelectedValue != "新增提资")
            //{
            //    document.ParentID = Convert.ToInt32(this.ParentID.SelectedValue);
            //}
            //else {
            //    document.ParentID = 0;
            //}
            document.PD_Name = this.PD_Name.Value;
            if (FileUpload1.FileName != "")
            {
                document.PD_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectDocument");
            }
            document.PD_FileNo = this.PD_FileNo.Value;
            document.Remark = this.Remark.Value;
            document.PD_Users = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(1, 1, "projectid=" + document.ProjectID + " and classname='" + WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_Specialty + "'", "").Rows[0]["UserName"].ToString();
            document.Status = "提资主设审核";
            document.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectDocumentManager.UpdateTbl_ProjectDocument(document);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功,请等待主设审核!!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交失败!');", true);
            }
        }
        protected void PD_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.PD_Type.SelectedValue;
            if (type == "问题修改" || type == "问题重提")
            {
                lishitizi.Visible = true;
                ParentID.DataSource = WebBLL.Tbl_ProjectDocumentManager.GetTbl_ProjectDocumentParent(" ClassName='" + this.ClassName.SelectedValue + "' and ProjectID=" + Convert.ToInt32(this.ProjectID.SelectedValue));
                ParentID.DataTextField = "PD_Name";
                ParentID.DataValueField = "ID";
                ParentID.DataBind();
                ParentID.Items.Insert(0, "选择提资");
            }
            else
            {
                lishitizi.Visible = false;
            }
        }
        protected void ParentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PD_Name.Value = this.ParentID.SelectedItem.Text;
            this.PD_Name.Attributes["readonly"] = "readonly";
        }
    }
}