using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowNode_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //流程分类
                FlowID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(67);
                FlowID.DataTextField = "ClassName";
                FlowID.DataValueField = "ClassName";
                FlowID.DataBind();
                FlowID.Items.Insert(0,new ListItem("流程类型",""));
                FlowName.Items.Insert(0,new ListItem("选择流程",""));

                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(NodeUser);
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_FlowNode node = new WebModels.Tbl_FlowNode();
            node.FlowID = Convert.ToInt32(this.FlowName.SelectedValue);
            node.NodeNo = this.NodeNo.Value;
            node.NodeName = this.NodeName.Value;
            node.NodeStage = this.NodeStage.SelectedValue;
            node.NodeType = this.NodeType.SelectedValue;
            node.NodeUser = WebCommon.Public.ListBoxValuesGet(NodeUser);
            node.NodeUserLimit = this.NodeUserLimit.SelectedValue;
            node.DealFlag = 0;
            node.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowNodeManager.AddTbl_FlowNode(node);
            if (count > 0)
            {
                WebModels.Tbl_Flow tbl_flow = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue));
                tbl_flow.FormContent = NodeFormArea.Value;
                WebBLL.Tbl_FlowManager.UpdateTbl_Flow(tbl_flow);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
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

        protected void FlowName_SelectedIndexChanged(object sender, EventArgs e)
        {
            NodeNo.Value = (WebBLL.Tbl_FlowNodeManager.GetDataTableByCount("  flowid=" + FlowName.SelectedValue) + 1).ToString();
            NodeFormArea.Value = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue)).FormContent;
        }
    }
}