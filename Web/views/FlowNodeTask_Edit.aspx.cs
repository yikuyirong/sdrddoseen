using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowNodeTask_Edit : System.Web.UI.Page
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
                //项目
                ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectName.DataTextField = "ProjectName";
                ProjectName.DataValueField = "ID";
                ProjectName.DataBind();
                //节点ID
                FlowNodeID.DataSource = WebBLL.Tbl_FlowNodeManager.GetTbl_FlowNodeAll();
                FlowNodeID.DataTextField = "NodeName";
                FlowNodeID.DataValueField = "ID";
                FlowNodeID.DataBind();
                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(UserName);
                Bind();
            }
        }
        public void Bind() {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_FlowNodeTask task =WebBLL.Tbl_FlowNodeTaskManager.GetTbl_FlowNodeTaskById(ID);
            this.ProjectName.Text = task.ProjectID.ToString();
            this.FlowNodeID.Text = task.FlowNodeID.ToString();
            this.EndTime.Value = task.EndTime.ToString("yyyy-MM-dd");
            WebCommon.Public.ListBoxValuesSet(UserName,task.UserName);
            this.FNT_Info.Value = task.FNT_Info;
            this.Status.SelectedValue = task.Status;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_FlowNodeTask task = WebBLL.Tbl_FlowNodeTaskManager.GetTbl_FlowNodeTaskById(ID);           
            task.EndTime = Convert.ToDateTime(this.EndTime.Value);
            task.UserName = WebCommon.Public.ListBoxValuesGet(UserName);
            task.FNT_Info = this.FNT_Info.Value;
            task.Status = this.Status.SelectedValue;
            task.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowNodeTaskManager.UpdateTbl_FlowNodeTask(task);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }
      
    }
}