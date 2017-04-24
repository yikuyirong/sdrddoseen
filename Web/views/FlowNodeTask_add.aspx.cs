using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowNodeTask_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目类型绑定
                ProjectID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectID.DataTextField = "ClassName";
                ProjectID.DataValueField = "ClassName";
                ProjectID.DataBind();

                ProjectID.Items.Insert(0, new ListItem("选择项目类别",""));
                ProjectName.Items.Insert(0, new ListItem("选择项目", ""));
                FlowWorkID.Items.Insert(0, new ListItem("选择流程", ""));
                FlowNodeID.Items.Insert(0, new ListItem("选择节点", ""));

                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(UserName);
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_FlowNodeTask task = new WebModels.Tbl_FlowNodeTask();
            task.ProjectID = Convert.ToInt32(this.ProjectName.SelectedValue);
            task.FlowNodeID = Convert.ToInt32(this.FlowNodeID.SelectedValue);
            task.EndTime = Convert.ToDateTime(this.EndTime.Value);
            task.UserName = this.UserName.SelectedValue;
            task.FNT_Info = this.FNT_Info.Value;
            task.Status = this.Status.SelectedValue;
            task.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowNodeTaskManager.AddTbl_FlowNodeTask(task);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectID.SelectedValue);
            ProjectName.DataTextField = "ProjectName";
            ProjectName.DataValueField = "ID";
            ProjectName.DataBind();
            ProjectName.Items.Insert(0, new ListItem("选择项目",""));
        }

        protected void ProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //流程工作ID
            FlowWorkID.DataSource = WebBLL.Tbl_FlowWorkManager.GetDataTableByPage(20, 1, "projectid=" + ProjectName.SelectedValue, "");
            FlowWorkID.DataTextField = "WorkName";
            FlowWorkID.DataValueField = "FlowID";
            FlowWorkID.DataBind();
            FlowWorkID.Items.Insert(0, new ListItem("选择流程", ""));

            if (FlowWorkID.Items.Count == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('该项目尚未发起任何流程工作');", true);
            }

        }

        protected void FlowWorkID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //流程工作对应的流程的节点
            FlowNodeID.DataSource = WebBLL.Tbl_FlowNodeManager.GetDataTableByPage(20, 1, "flowid=" + FlowWorkID.SelectedValue, "nodeno asc");
            FlowNodeID.DataTextField = "NodeName";
            FlowNodeID.DataValueField = "ID";
            FlowNodeID.DataBind();
            FlowNodeID.Items.Insert(0, new ListItem("选择节点", ""));
        }
    }
}