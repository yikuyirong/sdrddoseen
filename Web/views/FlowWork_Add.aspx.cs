using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowWork_add : System.Web.UI.Page
    {
        protected string value = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //流程分类
                FlowID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(67);
                FlowID.DataTextField = "ClassName";
                FlowID.DataValueField = "ClassName";
                FlowID.DataBind();
                FlowID.Items.Insert(0, new ListItem("流程类型",""));
                FlowName.Items.Insert(0, new ListItem("选择流程",""));

                //绑定项目              
                ProjectType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectType.DataTextField = "ClassName";
                ProjectType.DataValueField = "ClassName";
                ProjectType.DataBind();
                ProjectType.Items.Insert(0, new ListItem("选择项目类别", ""));
                ProjectID.Items.Insert(0, new ListItem("选择项目", ""));

                //获取表单常用短语
                string FromWords = "";
                foreach (WebModels.Tbl_FlowFormWord formword in WebBLL.Tbl_FlowFormWordManager.GetTbl_FlowFormWordAll())
                {
                    FromWords += "<div onclick=InputText($(this).text()) style=margin:5px>" + formword.IFW_Name + "</div>";
                }
                //向表单注册验证程序
                string LocalPwd = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).UserPwd;
                string LimitScript = "" +
                    "$('.formctrl[disabled]').removeAttr('disabled');" +
                    "$('.formctrl[data-node!=1]').attr('disabled','disabled');" +
                    "$('.formctrl[type=textarea]').dblclick(function(){$(this).attr('lock','1');$$.MsgBox('常用短语', '" + FromWords + "', '关闭窗口');});" +
                    "$('.formctrl[value=电子签名]').click(function(){$$.MsgBox('密码验证', '<input type=password id=password>', '确定:InsertSign()', '取消');});" +
                    "function InsertSign(){" +
                    "if($.md5($('#password').val())=='" + LocalPwd + "'){$('.formctrl[value=电子签名]').hide();$$.MsgBox(0);" +
                    "$('.formctrl[value=电子签名]').after('<img src=" + WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_Sign + ">');" +
                    "}else{alert('密码不正确');}}" +
                    "function InputText(info){" +
                    "$('.formctrl[lock=1]').val(info);$(this).removeAttr('lock');$$.MsgBox(0);}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", LimitScript, true);

                //如果是项目流程发起的表单
                int flowid=WebCommon.Public.ToInt(Request.QueryString["FlowID"]);
                int projectid=WebCommon.Public.ToInt(Request.QueryString["ProjectID"]);
                if (flowid > 0 && projectid > 0)
                {
                    string flowname = WebBLL.Tbl_FlowManager.GetTbl_FlowById(flowid).FlowName;
                    string projectname = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(projectid).ProjectName;
                    FlowName.Items.Insert(0, new ListItem(flowname, flowid.ToString()));
                    ProjectID.Items.Insert(0, new ListItem(projectname, projectid.ToString()));
                    WorkName.Value = projectname + " " + flowname;
                    FormContent.InnerHtml = WebBLL.Tbl_FlowManager.GetTbl_FlowById(flowid).FormContent;

                    FlowID.Enabled = false;
                    FlowName.Enabled = false;
                    ProjectType.Enabled = false;
                    ProjectID.Enabled = false;
                }
            }
            hid.Value = ProjectID.SelectedItem.Text;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_FlowWork flowwork = new WebModels.Tbl_FlowWork();
            flowwork.UserName = "doseen";
            flowwork.WorkName = this.WorkName.Value;
            //WebModels.Tbl_Flow flow = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue));
            flowwork.FormContent = FormContentSet.Value;
            flowwork.ProjectID = WebCommon.Public.ToInt(ProjectID.SelectedValue);
            flowwork.FlowID = Convert.ToInt32(FlowName.SelectedValue);
            //通过flowid和nodeno获取节点信息
            try
            {
                DataRow dr = WebBLL.Tbl_FlowNodeManager.GetDataTableByPage(1, 1, "flowid=" + FlowName.SelectedValue + " and nodeno=2", "").Rows[0];
                flowwork.NodeID = Convert.ToInt32(dr["ID"]);
                flowwork.NodeNo = dr["NodeNo"].ToString();
                flowwork.NodeUser = dr["NodeUser"].ToString();
                flowwork.NodeStatus = "待审核";
                flowwork.Status = "进行中";
                flowwork.DealFlag = 0;
                flowwork.DealUser = WebCommon.Public.GetUserName();
                //如果是项目流程并且是合同审批表单那么更改项目节点状态
                if (WebCommon.Public.ToInt(Request.QueryString["ProjectID"]) > 0)
                {
                    WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(flowwork.ProjectID);
                    project.NodeNo = "合同评审处理";
                    project.NodeUser = dr["NodeUser"].ToString();
                    WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('请到流程管理配置节点!');", true);
            }
            int count = WebBLL.Tbl_FlowWorkManager.AddTbl_FlowWork(flowwork);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('处理成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('处理失败!');", true);
            }
        }

        protected void FlowID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //流程名称
            FlowName.DataSource = WebBLL.Tbl_FlowManager.GetTbl_FlowType(FlowID.SelectedValue);
            FlowName.DataTextField = "FlowName";
            FlowName.DataValueField = "ID";
            FlowName.DataBind();
            FlowName.Items.Insert(0, new ListItem("选择流程",""));
        }

        //显示表单内容
        protected void FlowName_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkName.Value += FlowName.SelectedItem;
            FormContent.InnerHtml = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue)).FormContent;
        }

        protected void ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectType.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
        }

        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkName.Value = ProjectID.SelectedItem.Text+" "+FlowName.SelectedItem;
            //只有这个项目的项目经理才可以发起
            if (ProjectID.SelectedValue != "")
            {
                int projectId = Convert.ToInt32(ProjectID.SelectedValue);
                //查询这个项目的项目经理
                string ProjectManager = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(projectId).ProjectManager;
                if (ProjectManager != WebCommon.Public.GetUserName())
                {
                    //WebCommon.Script.Alert(this, "11该项目的项目经理不是您，您无法发起该工作！\n该项目的项目经理为" + ProjectManager);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('该项目的项目经理不是您，您无法发起该工作！');", true);
                    ProjectID.SelectedIndex = 0;
                }
            }

            //向表单注册验证程序
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "$('.formctrl[data-node!=1]').attr('disabled','disabled');", true);
        }

    }
}