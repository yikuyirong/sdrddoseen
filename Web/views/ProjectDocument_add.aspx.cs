using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectDocument_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断当前人是不是设计师权限
                if (!WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_DesignLimit.Contains("设计人"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('您不是设计人没有提资权限!');window.external.close();", true);
                    btn_submit.Visible = false;
                }

                //项目类型
                ProjectType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectType.DataTextField = "ClassName";
                ProjectType.DataValueField = "ClassName";
                ProjectType.DataBind();
                ProjectType.Items.Insert(0, new ListItem("选择项目类别",""));
                ProjectID.Items.Insert(0, new ListItem("选择项目",""));
                //专业
                ClassName.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName.DataTextField = "ClassName";
                ClassName.DataValueField = "ClassName";
                ClassName.DataBind();
                ClassName.Items.Insert(0, new ListItem("选择专业",""));
                lishitizi.Visible = false;

                string cfromStr=WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_Specialty;
                foreach (string str in cfromStr.Split(','))
                {
                    if (str!="") ClassNameFrom.Items.Insert(0, str);
                }
                ClassNameFrom.SelectedIndex = 0;
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectDocument document = new WebModels.Tbl_ProjectDocument();
            document.UserName = WebCommon.Public.GetUserName();
            document.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            document.ClassName = this.ClassName.SelectedValue;
            document.PD_Type = this.PD_Type.SelectedValue;
            if (this.PD_Type.SelectedValue != "新增提资")
            {
                document.ParentID = Convert.ToInt32(this.ParentID.SelectedValue);
            }
            else {
                document.ParentID = 0;
            }
            document.PD_Name = this.PD_Name.Value;
            document.PD_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectDocument");
            document.PD_FileNo = this.PD_FileNo.Value;
            document.Remark = this.Remark.Value;
            document.Status = this.Status.SelectedValue;
            document.DealUser =WebCommon.Public.GetUserName();
            //查询提资主设
            string MainDeigner = "";
            try
            {
                MainDeigner = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(1, 1, "projectid=" + document.ProjectID + " and classname='" + ClassNameFrom.Text + "'", "").Rows[0]["UserName"].ToString();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('尚未发现该项目中你的主设人是谁因此不能提资!');", true);
                return;
            }
            document.PD_Users = MainDeigner;
            int count = WebBLL.Tbl_ProjectDocumentManager.AddTbl_ProjectDocument(document);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功,请等待主设审核!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交失败!');", true);
            }
        }

        protected void ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectType.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目",""));
        }

        protected void PD_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.PD_Type.SelectedValue;
            if (type == "问题修改" || type == "问题重提")
            {
                lishitizi.Visible = true;
            }
            else
            {
                lishitizi.Visible = false;
            }
        }

        protected void ClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //判断该专业是否存在于这个项目
                int rows = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(1, 1, "ClassName='" + this.ClassName.SelectedValue + "' and ProjectID=" + Convert.ToInt32(this.ProjectID.SelectedValue), "").Rows.Count;
                if (rows < 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('该项目不存在这个专业!');", true);
                    ClassName.SelectedIndex = 0;
                    return;
                }
                //获取这个项目这个专业的提资
                ParentID.DataSource = WebBLL.Tbl_ProjectDocumentManager.GetTbl_ProjectDocumentParent(" ClassName='" + this.ClassName.SelectedValue + "' and ProjectID=" + Convert.ToInt32(this.ProjectID.SelectedValue));
                ParentID.DataTextField = "PD_Name";
                ParentID.DataValueField = "ID";
                ParentID.DataBind();
                ParentID.Items.Insert(0, new ListItem("选择提资", ""));
            }
            catch(Exception ex)
            {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('请先选择对应项目!');", true);
            }
        }

        protected void ParentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PD_Name.Value = this.ParentID.SelectedItem.Text;
            this.PD_Name.Attributes["readonly"] = "readonly";
        }
    }
}