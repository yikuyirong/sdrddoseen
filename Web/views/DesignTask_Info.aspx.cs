using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignTask_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int taskid = WebCommon.Public.ToInt(Request.QueryString["TaskID"]);
                //任务评级
                string pingji = WebCommon.Public.ToString(Request.QueryString["pingji"]);
                if (pingji !="")
                {
                    //初始化任务表
                    WebCommon.Public.DataTableUpdate("tbl_designtask", "papernum3=" + pingji, "id=" + taskid.ToString());
                    WebCommon.Script.Alert("评级成功");
                }

                //任务重置
                int chongzhi = WebCommon.Public.ToInt(Request.QueryString["chongzhi"]);
                if (chongzhi==1)
                {
                    //初始化任务表
                    WebCommon.Public.DataTableUpdate("tbl_designtask", "status='等待设计',statuslast='',papernum1=0,papernum2=0", "id=" + taskid.ToString());
                    //删除校审表记录
                    WebCommon.Public.DataTableDel("tbl_designcorrect","designtaskid="+taskid.ToString(),true);
                    WebCommon.Script.Alert("重置成功");
                }

                //项目ID
                ProjectID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectID.DataTextField = "ClassName";
                ProjectID.DataValueField = "ClassName";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("选择项目类别", ""));

                //专业
                string classname=WebCommon.Public.ToString(Server.UrlDecode(Request.QueryString["ClassName1"]));
                ClassName.Items.Insert(0, new ListItem(classname, classname));
                ClassName.Enabled = false;

                //如果是通过任务明细连接过来
                int projectid = WebCommon.Public.ToInt(Request.QueryString["ProjectID"]);
                if (projectid > 0)
                {
                    ProjectName.SelectedValue = projectid.ToString();
                    WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(Convert.ToInt32(Request.QueryString["ProjectID"]));
                    ProjectName.Items.Insert(0, new ListItem(project.ProjectName, Request.QueryString["ProjectID"]));
                    ProjectID.SelectedValue = project.ProjectTypes;
                    ProjectNo.Value = project.ProjectNo;
                    ProjectName.Enabled = false;
                    ProjectID.Enabled = false;
                    ProjectNo.Attributes.Add("readonly", "readonly");

                    //设总默认
                    DesignManager.Items.Insert(0, new ListItem(project.ProjectMainDesigner, project.ProjectMainDesigner));
                    DesignManager.Enabled = false;

                    //主设默认
                    //DesignMain.Items.Insert(0, new ListItem(WebCommon.Public.GetUserName(), WebCommon.Public.GetUserName()));
                    //DesignMain.Enabled = false;
                    DesignMain.DataSource = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(10, 1, "projectid=" + ProjectName.SelectedValue + " and ClassName='" + classname + "'", "");
                    DesignMain.DataTextField = "UserName";
                    DesignMain.DataValueField = "ClassName";
                    DesignMain.DataBind();
                    //DesignMain.Items.Insert(0, new ListItem("选择主设", ""));

                    //专业默认
                    //string classname = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_Specialty;
                    //if (WebCommon.Public.ToString(Request.QueryString["ClassName"]) != "") classname = Request.QueryString["ClassName"];
                    //ClassName.Items.Insert(0, new ListItem(classname, classname));

                    //卷默认
                    //ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetDataTableByPage(10, 1, "parentid=(select top 1 id from tbl_class where classname='" + classname + "')", "id desc");
                    //ClassName1.DataTextField = "ClassName";
                    //ClassName1.DataValueField = "ID";
                    //ClassName1.DataBind();
                    ClassName1.Items.Insert(0, new ListItem("选择卷", ""));
                    ClassName1.Enabled = false;

                    //绑定当前任务
                    BindList();
                }
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
        }
        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定项目
            ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectID.SelectedValue);
            ProjectName.DataTextField = "ProjectName";
            ProjectName.DataValueField = "ID";
            ProjectName.DataBind();
            ProjectName.Items.Insert(0, new ListItem("选择项目", ""));
        }

        protected void ProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebModels.Tbl_Project tbl_project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(Convert.ToInt32(this.ProjectName.SelectedValue));
            ProjectNo.Value = tbl_project.ProjectNo;
            this.ProjectNo.Attributes["readonly"] = "readonly";
            if (ClassName.SelectedValue != "") BindList();
        }

        protected void ClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择卷
            ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName.SelectedValue));
            ClassName1.DataTextField = "ClassName";
            ClassName1.DataValueField = "ID";
            ClassName1.DataBind();
            ClassName1.Items.Insert(0, new ListItem("选择卷", ""));
            if (ProjectName.SelectedValue != "") BindList();
        }

        protected void BindList()
        {
            string WhereStr = "ProjectID=" + ProjectName.SelectedValue + " and className1='" + this.ClassName.SelectedValue + "'";
            int count = WebBLL.Tbl_DesignTaskManager.GetDataTableByCount(WhereStr);
            if (count > 0)
            {
                TaskList.DataSource = WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(200, 1, WhereStr, "");
                TaskList.DataBind();
            }
            else
            {
                TaskList.DataSource = "";
                TaskList.DataBind();
            }
        }

        protected void DesignMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassName.SelectedValue = DesignMain.SelectedValue;
            BindList();
        }

    }
}