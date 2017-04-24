using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Web.views
{
    public partial class Project_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //专业类别
                ProjectTypes.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectTypes.DataTextField = "ClassName";
                ProjectTypes.DataValueField = "ClassName";
                ProjectTypes.DataBind();
                ProjectTypes.Items.Insert(0,new ListItem("选择类型",""));
                //级别
                ProjectLevel.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(58);
                ProjectLevel.DataTextField = "ClassName";
                ProjectLevel.DataValueField = "ClassName";
                ProjectLevel.DataBind();
                ProjectLevel.Items.Insert(0, new ListItem("选择级别",""));
                //部门
                Depart.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(52);
                Depart.DataTextField = "ClassName";
                Depart.DataValueField = "ClassName";
                Depart.DataBind();
                Depart.Items.Insert(0, new ListItem("选择部门",""));
                ProjectManager.Items.Insert(0, new ListItem("选择负责人",""));
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Project project = new WebModels.Tbl_Project();
            project.ProjectNo = WebBLL.Tbl_ProjectManager.GetDataTableByCount("").ToString();//临时编号
            project.ProjectMW = this.ProjectMW.Text;
            project.ProjectName = this.ProjectName.Value;
            project.ProjectCustom = this.ProjectCustom.Value;
            project.ProjectManager = this.ProjectManager.SelectedValue;
            project.ProjectStartTime = DateTime.Now;
            project.ProjectEndTime = DateTime.Now;
            project.ProjectTypes = this.ProjectTypes.SelectedValue;
            project.ProjectCity = this.ProjectCity.Value;
            project.ProjectLevel = this.ProjectLevel.SelectedValue;
            project.ProjectInfo = this.ProjectInfo.Value;
            project.ProjectCustomContact = this.ProjectCustomContact.Value;
            project.ProjectCustomPhone = this.ProjectCustomPhone.Value;
            project.DealUser = WebCommon.Public.GetUserName();
            project.UserName = project.DealUser;
            project.NodeUser = WebCommon.Public.GetUserName();
            if (ProjectStatus.Text == "新项目")
            {
                project.NodeNo = "发起合同评审";
                if (RadioButtonList1.Text=="否") project.NodeNo = "上传合同";
                project.Status = "进行中";
            }
            else
            {
                project.NodeNo = "结束";
                project.Status = "结束";
            }
            int count = WebBLL.Tbl_ProjectManager.AddTbl_Project(project);
            if (count > 0)
            {
                ////建立项目文件夹并生成基本文件
                //string strPath = "/project/" + project.ProjectNo;
                //string FileSavePath = System.Web.HttpContext.Current.Server.MapPath("~" + strPath);
                //if (!Directory.Exists(FileSavePath)) Directory.CreateDirectory(FileSavePath);
                //string BlankFileReadPath=System.Web.HttpContext.Current.Server.MapPath("~/project/bank.dwg");
                //string BlankFileSavePath=System.Web.HttpContext.Current.Server.MapPath("~/project/"+project.ProjectNo+"/bank.dwg");
                //if (!File.Exists(BlankFileReadPath))
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('项目模板文件生成失败，请联系管理员!');", true);
                //}
                //else
                //{
                //    File.Copy(BlankFileReadPath, BlankFileSavePath);
                //}
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功,等待" + project.NodeUser + "进行下一步!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
        

        protected void Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectManager.DataSource = WebBLL.Tbl_UserManager.GetTbl_UserByDepartID(this.Depart.SelectedValue);
            ProjectManager.DataTextField = "UserName";
            ProjectManager.DataValueField = "UserName";
            ProjectManager.DataBind();
            ProjectManager.Items.Insert(0, new ListItem("选择负责人",""));
        }
    }
}