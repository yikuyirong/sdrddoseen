using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowNode_Edit : System.Web.UI.Page
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
                //流程名称
                FlowName.DataSource = WebBLL.Tbl_FlowManager.GetTbl_FlowAll();
                FlowName.DataTextField = "FlowName";
                FlowName.DataValueField = "ID";
                FlowName.DataBind();
                FlowName.Items.Insert(0, new ListItem("选择流程",""));

                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(NodeUser);

                Bind();
            }
        }

        public void Bind() {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_FlowNode node = WebBLL.Tbl_FlowNodeManager.GetTbl_FlowNodeById(ID);
            this.FlowName.SelectedValue = node.FlowID.ToString();
            this.NodeName.Value = node.NodeName;
            this.NodeNo.Value=node.NodeNo;
            this.NodeStage.SelectedValue = node.NodeStage;
            this.NodeType.SelectedValue = node.NodeType;
            this.NodeUserLimit.SelectedValue = node.NodeUserLimit;
            WebCommon.Public.ListBoxValuesSet(NodeUser,node.NodeUser);
            NodeFormArea.Value = WebBLL.Tbl_FlowManager.GetTbl_FlowById(node.FlowID).FormContent;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_FlowNode node = WebBLL.Tbl_FlowNodeManager.GetTbl_FlowNodeById(ID);
            node.NodeNo = this.NodeNo.Value;
            node.NodeName = this.NodeName.Value;
            node.NodeStage = this.NodeStage.SelectedValue;
            node.NodeType = this.NodeType.SelectedValue;
            node.NodeUserLimit = this.NodeUserLimit.SelectedValue;
            node.NodeUser = WebCommon.Public.ListBoxValuesGet(NodeUser);
            int count = WebBLL.Tbl_FlowNodeManager.UpdateTbl_FlowNode(node);
            if (count > 0)
            {
                WebModels.Tbl_Flow tbl_flow = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue));
                tbl_flow.FormContent = NodeFormArea.Value;
                WebBLL.Tbl_FlowManager.UpdateTbl_Flow(tbl_flow);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }

        }

        protected void FlowName_SelectedIndexChanged(object sender, EventArgs e)
        {
            NodeNo.Value = (WebBLL.Tbl_FlowNodeManager.GetDataTableByCount("  flowid=" + FlowName.SelectedValue) + 1).ToString();
            NodeFormArea.Value = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue)).FormContent;
        }
    }
}