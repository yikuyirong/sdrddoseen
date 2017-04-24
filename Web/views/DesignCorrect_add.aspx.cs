using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignCorrect_add : System.Web.UI.Page
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
                ProjectType.Items.Insert(0, new ListItem("选择类型",""));;

                //专业
                ClassName.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName.DataTextField = "ClassName";
                ClassName.DataValueField = "ClassName";
                ClassName.DataBind();
                ClassName.Items.Insert(0, new ListItem("选择专业", ""));

                DesignTaskID.Items.Insert(0, new ListItem("选择任务", ""));

                //如果是通过卷册任务执行点过来的话
                int taskid=WebCommon.Public.ToInt(Request.QueryString["taskid"]);
                if (taskid > 0)
                {
                    WebModels.Tbl_DesignTask task = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(taskid);
                    ProjectID.Items.Insert(0, new ListItem(task.ProjectName,task.ProjectID.ToString()));
                    ClassName.SelectedValue = task.ClassName1;
                    DesignTaskID.Items.Insert(0, new ListItem(task.DT_SheJiRen, task.ID.ToString()));
                }
                else
                {
                    ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
                }
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_DesignCorrect correct =new WebModels.Tbl_DesignCorrect();
            correct.UserName = WebCommon.Public.GetUserName();
            correct.DesignTaskID =Convert.ToInt32(DesignTaskID.SelectedValue);
            correct.DC_Name = DC_Name.Value;
            correct.DC_File = WebCommon.Public.UploadFile(DC_File, "DesignCorrect", WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTasFileNamekByTaskId(correct.DesignTaskID)+" - 设计");
            correct.DC_FileInfo = DC_FileInfo.Value;
            correct.DC_FileTime = DateTime.Now;
            correct.Status = "等待校对";
            int count = WebBLL.Tbl_DesignCorrectManager.AddTbl_DesignCorrect(correct);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功!');window.external.reload();window.external.close();", true);
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
            ProjectID.Items.Insert(0,new ListItem("选择项目",""));
        }

        protected void ClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProjectID.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('必须先选择项目!');", true);
                ClassName.SelectedIndex = 0;
                return;
            }
            DesignTaskID.DataSource = WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(50,1,"classname='"+ClassName.SelectedValue+"' and projectid='"+ProjectID.SelectedValue+"'","id desc");
            DesignTaskID.DataTextField = "TaskName";
            DesignTaskID.DataValueField = "ID";
            DesignTaskID.DataBind();
            DesignTaskID.Items.Insert(0, new ListItem("选择任务", ""));
            //DesignTaskID.SelectedItem.Text = WebCommon.Public.GetUserName();
            //DesignTaskID.Enabled = false;
            //if (DesignTaskID.SelectedValue == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('该项目该专业没有您的任务!');", true);
            //}
        }
    }
}