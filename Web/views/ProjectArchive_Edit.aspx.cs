using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectArchive_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目
                ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectID.DataTextField = "ProjectName";
                ProjectID.DataValueField = "ID";
                ProjectID.DataBind();
                Bind();
            }

        }
        public string PA_FilePath="";
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectArchive project = WebBLL.Tbl_ProjectArchiveManager.GetTbl_ProjectArchiveById(ID);
            this.ProjectID.Text = project.ProjectID.ToString();
            this.ClassName1.Value = project.ClassName1;
            this.ClassName2.Value = project.ClassName2;
            this.ClassName3.Value = project.ClassName3;
            this.PA_Type1.Text = project.PA_Type1;
            this.PA_Type2.Text = project.PA_Type2;
            PA_FilePath = project.PA_File;
            this.ParentID.SelectedValue = project.ParentID.ToString();
            this.PA_Limit.SelectedValue = project.PA_Limit;
            this.PA_Name.Value = project.PA_Name;
            this.PA_FileNo.Value = project.PA_FileNo;
            this.PA_Info.Value = project.PA_Info; ;
            this.Status.Text = project.Status;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectArchive archive = WebBLL.Tbl_ProjectArchiveManager.GetTbl_ProjectArchiveById(ID);

            archive.PA_Type1 = this.PA_Type1.SelectedValue;
            archive.PA_Type2 = this.PA_Type2.SelectedValue;
            archive.ParentID = 0;
            archive.PA_Name = this.PA_Name.Value;
            if (PA_File.FileName != "")
            {
                archive.PA_File = WebCommon.Public.UploadFile(PA_File, "ProjectArchive");
            }
            archive.PA_Limit = this.PA_Limit.SelectedValue;
            archive.PA_FileNo = this.PA_FileNo.Value;
            archive.PA_Info = this.PA_Info.Value; ;
            archive.Status = this.Status.SelectedValue;
            archive.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectArchiveManager.UpdateTbl_ProjectArchive(archive);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }
        //protected void ClassName1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //部分
        //    ClassName12.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName1.SelectedValue));
        //    ClassName12.DataTextField = "ClassName";
        //    ClassName12.DataValueField = "ID";
        //    ClassName12.DataBind();
        //    ClassName12.Items.Insert(0, new ListItem("选择卷", ""));
        //}
        //protected void 工作计划(object sender, EventArgs e)
        //{
        //    ParentID.DataSource = WebBLL.Tbl_ProjectArchiveManager.GetTbl_ProjectArchiveParentName(" ClassName1='" + this.ClassName1.SelectedValue + "' and ProjectID=" + Convert.ToInt32(this.ProjectID.SelectedValue) + "and ClassName2='" + this.ClassName2.SelectedValue + "'");
        //    ParentID.DataTextField = "PA_Name";
        //    ParentID.DataValueField = "ID";
        //    ParentID.DataBind();
        //    ParentID.Items.Insert(0, new ListItem("选择卷册", ""));
        //}
        //protected void ClassName12_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //卷册
        //    ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName12.SelectedValue));
        //    ClassName2.DataTextField = "ClassName";
        //    ClassName2.DataValueField = "ClassName";
        //    ClassName2.DataBind();
        //    ClassName2.Items.Insert(0, new ListItem("选择卷册", ""));
        //}
        protected void PA_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.PA_Type1.SelectedValue;
        }
    }
}