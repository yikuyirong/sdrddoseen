using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectArchive_Search : System.Web.UI.Page
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
                ProjectID.Items.Insert(0, new ListItem("选择项目",""));

                //专业
                ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName1.DataTextField = "ClassName";
                ClassName1.DataValueField = "ID";
                ClassName1.DataBind();
                ClassName1.Items.Insert(0, new ListItem("选择专业", ""));
                lishitizi.Visible = false;
                //卷册
                ClassName2.Items.Insert(0, new ListItem("选择卷", ""));
                //卷册
                //ClassName3.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(60);
                //ClassName3.DataTextField = "ClassName";
                //ClassName3.DataValueField = "ClassName";
                //ClassName3.DataBind();
                //ClassName3.Items.Insert(0, new ListItem("选择册", ""));
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string where = "1=1";
            if (this.ProjectID.SelectedValue != "") where += " and ProjectID=*" + this.ProjectID.SelectedValue + "*";
            if (this.ClassName1.SelectedValue != "") where += " and ClassName1=*" + this.ClassName1.SelectedItem.Text+"*";
            if (this.ClassName2.SelectedValue != "") where += " and ClassName2=*" + this.ClassName2.SelectedItem.Text+"*";
            if (this.PA_Type1.SelectedValue != "") where += " and PA_Type1=*" + this.PA_Type1.SelectedValue + "*";
            if (this.PA_Name.Value != "") where += " and PA_Nome=*" + this.PA_Name.Value+"*";
            if (this.PA_FileNo.Value != "") where += " and PA_FileNo=*" + this.PA_FileNo.Value+"*";
            if (this.PA_Info.Value != "") where += " and PA_Info=*" + this.PA_Info.Value + "*";

            //故意将上面的单引号改成*的不然会冲突,可以在查询页面把*替换成单引号
            string hrefUrl = "views/ProjectArchive_List.aspx?where=" + where;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "window.external.href('" + hrefUrl + "');window.external.close();", true);
        }
        protected void ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectType.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目",""));
        }

        protected void PA_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string type = this.PA_Type.SelectedValue;
        }
        protected void ParentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PA_Name.Value = this.ParentID.SelectedItem.Text;
            this.PA_Name.Attributes["readonly"] = "readonly";
        }

        protected void 工作计划(object sender, EventArgs e)
        {
            ParentID.DataSource = WebBLL.Tbl_ProjectArchiveManager.GetTbl_ProjectArchiveParentName(" ClassName1='" + this.ClassName1.SelectedValue + "' and ProjectID=" + Convert.ToInt32(this.ProjectID.SelectedValue) + "and ClassName2='" + this.ClassName2.SelectedValue + "'");
            ParentID.DataTextField = "PA_Name";
            ParentID.DataValueField = "ID";
            ParentID.DataBind();
            ParentID.Items.Insert(0, new ListItem("选择卷册",""));
        }

        protected void ClassName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //卷册
            ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(ClassName1.SelectedValue));
            ClassName2.DataTextField = "ClassName";
            ClassName2.DataValueField = "ID";
            ClassName2.DataBind();
            ClassName2.Items.Insert(0, new ListItem("选择卷", ""));
        }
    }
}