using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectArchive_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目类别
                ProjectType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectType.DataTextField = "ClassName";
                ProjectType.DataValueField = "ClassName";
                ProjectType.DataBind();
                ProjectType.Items.Insert(0, new ListItem("选择项目类别",""));
                ProjectID.Items.Insert(0, new ListItem("选择项目","0"));
                //专业
                ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName1.DataTextField = "ClassName";
                ClassName1.DataValueField = "ID";
                ClassName1.DataBind();
                ClassName1.Items.Insert(0, new ListItem("选择专业", ""));
                lishitizi.Visible = false;
                //卷册
                ClassName2.Items.Insert(0, new ListItem("选择卷", ""));
                ClassName3.Items.Insert(0, new ListItem("选择册", ""));
            }

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectArchive archive = new WebModels.Tbl_ProjectArchive();
            archive.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            archive.ClassName1 = this.ClassName1.SelectedItem.Text;
            archive.ClassName2 = this.ClassName2.SelectedItem.Text;
            archive.ClassName3 = this.ClassName3.SelectedItem.Text;
            archive.PA_Type1 = this.PA_Type1.SelectedValue;
            archive.PA_Type2 = this.PA_Type2.SelectedValue;
            archive.ParentID = 0;
            archive.PA_Limit = this.PA_Limit.SelectedValue;
            archive.PA_Name = this.PA_Name.Value;
            archive.PA_File = WebCommon.Public.UploadFile(PA_File, "ProjectArchive");
            archive.PA_FileNo = this.PA_FileNo.Value;
            archive.PA_Info = this.PA_Info.Value; ;
            archive.Status = this.Status.SelectedValue;
            archive.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectArchiveManager.AddTbl_ProjectArchive(archive);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }

        protected void ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectType.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目","0"));
        }

        protected void PA_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string type = this.PA_Type1.SelectedValue;
        }
        protected void ParentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PA_Name.Value = this.ParentID.SelectedItem.Text;
            this.PA_Name.Attributes["readonly"] = "readonly";
        }
        protected void ClassName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PA_Type1.SelectedValue == "项目档案")
            {
                //卷
                ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName1.SelectedValue));
                ClassName2.DataTextField = "ClassName";
                ClassName2.DataValueField = "ClassName";
                ClassName2.DataBind();
                ClassName2.Items.Insert(0, new ListItem("选择卷", ""));
            }
            else
            {
                //二级分类
                ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName1.SelectedValue));
                ClassName2.DataTextField = "ClassName";
                ClassName2.DataValueField = "ID";
                ClassName2.DataBind();
                ClassName2.Items.Insert(0, new ListItem("二级分类", ""));
            }
        }
        protected void ClassName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PA_Type1.SelectedValue == "项目档案")
            {
                //册
                ClassName3.DataSource = WebBLL.Tbl_DesignVolumeManager.GetDataTableByPage(100, 1, "classname2='" + this.ClassName2.SelectedValue + "'", "");
                ClassName3.DataTextField = "VolumeName";
                ClassName3.DataValueField = "VolumeNo";
                ClassName3.DataBind();
                ClassName3.Items.Insert(0, new ListItem("选择册", ""));
            }
            else
            {
                //三级分类
                ClassName3.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName2.SelectedValue));
                ClassName3.DataTextField = "ClassName";
                ClassName3.DataValueField = "ID";
                ClassName3.DataBind();
                ClassName3.Items.Insert(0, new ListItem("三级分类", ""));
            }
            PA_Name.Value = this.ClassName3.SelectedValue;
        }

        //如果选择了公共档案
        protected void PA_Type1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(227);
            ClassName1.DataTextField = "ClassName";
            ClassName1.DataValueField = "ID";
            ClassName1.DataBind();
            ClassName1.Items.Insert(0, new ListItem("一级分类", ""));
            ClassName2.Items[0].Text = "二级分类";
            ClassName3.Items[0].Text = "三级分类";
        }
    }
}