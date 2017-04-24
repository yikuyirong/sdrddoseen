using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowWorkLog_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定项目流程            
                ProjectType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectType.DataTextField = "ClassName";
                ProjectType.DataValueField = "ClassName";
                ProjectType.DataBind();
                ProjectType.Items.Insert(0, new ListItem("选择项目类别", ""));
                ProjectID.Items.Insert(0, new ListItem("选择项目名称", ""));
                FlowWorkID.Items.Insert(0, new ListItem("选择工作流程", ""));
            }
        }

        protected void ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectType.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目名称", ""));
        }

        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlowWorkID.DataSource = WebBLL.Tbl_FlowWorkManager.GetDataTableByPage(100, 1, "projectid=" + ProjectID.SelectedValue, "id desc");
            FlowWorkID.DataTextField = "WorkName";
            FlowWorkID.DataValueField = "ID";
            FlowWorkID.DataBind();
            FlowWorkID.Items.Insert(0, new ListItem("选择工作流程", ""));
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int NodeID = WebBLL.Tbl_FlowWorkManager.GetTbl_FlowWorkById(Convert.ToInt32(FlowWorkID.SelectedValue)).NodeID;
            WebModels.Tbl_FlowWorkLog flowworklog = new WebModels.Tbl_FlowWorkLog();
            flowworklog.UserName = WebCommon.Public.GetUserName();
            flowworklog.LogType = WebCommon.Public.ToString(Request.QueryString["type"]);
            flowworklog.ParentID = WebCommon.Public.ToInt(Request.QueryString["pid"]);
            flowworklog.ProjectID = Convert.ToInt32(ProjectID.SelectedValue);
            flowworklog.FlowWorkID = Convert.ToInt32(FlowWorkID.SelectedValue);
            flowworklog.FlowNodeID = NodeID;
            //生成上传文件名
            int RndNum =WebCommon.Public.ToInt(WebBLL.Tbl_FlowWorkLogManager.GetDataTableByPage(1,1,"","id desc").Rows[0]["id"]);
            string RndName = flowworklog.ProjectID.ToString() + "_" + flowworklog.FlowWorkID.ToString() + "_" + flowworklog.FlowNodeID.ToString() + "_" + RndNum.ToString();
            string saveName = RndName + " - " + flowworklog.LogType;
            flowworklog.FileLog = WebCommon.Public.UploadFile(FileLog, "FlowWorkLog", saveName);
            //获取项目资料生成属性
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(flowworklog.ProjectID);
            //生成属性文件
            string folderPath = System.Web.HttpContext.Current.Server.MapPath("/upload/FlowWorkLog");
            if (!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);
            string path = folderPath + "\\" + RndName + " - 属性.txt";
            if (!System.IO.File.Exists(path)) System.IO.File.Create(path).Close();
            System.Text.StringBuilder strBuilderErrorMessage = new System.Text.StringBuilder();
            strBuilderErrorMessage.Append("project=" + project.ProjectName + "\r\n");
            strBuilderErrorMessage.Append("paper name=" + project.ProjectNo + "\r\n");
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.Write(strBuilderErrorMessage);
                sw.Flush();
                sw.Close();
            }
            //属性生成结束

            flowworklog.Remark = Remark.Value;
            flowworklog.DealUser = flowworklog.UserName;
            int flowworklogID = WebBLL.Tbl_FlowWorkLogManager.AddTbl_FlowWorkLog(flowworklog);
            if (flowworklogID > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交失败!');", true);
            }
        }
    }
}