using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowWork_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //流程名称
                FlowName.DataSource = WebBLL.Tbl_FlowManager.GetTbl_FlowAll();
                FlowName.DataTextField = "FlowName";
                FlowName.DataValueField = "ID";
                FlowName.DataBind();
                FlowName.Items.Insert(0, new ListItem("选择流程",""));
                Bind();
            }
        }

        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_FlowWork flowwork = WebBLL.Tbl_FlowWorkManager.GetTbl_FlowWorkById(ID);
            this.WorkName.Value = flowwork.WorkName;
            this.FlowName.SelectedValue = flowwork.FlowID.ToString();
            this.FormContent.Text = flowwork.FormContent;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_FlowWork flowwork = WebBLL.Tbl_FlowWorkManager.GetTbl_FlowWorkById(ID);
            flowwork.UserName = "doseen";
            flowwork.WorkName = this.WorkName.Value;
            //int flowID = Convert.ToInt32(this.FlowName.SelectedValue);
            //WebModels.Tbl_FlowNode node = WebBLL.Tbl_FlowNodeManager.GetTbl_FlowNodesByFlowID(flowID);
            //WebModels.Tbl_Flow flow = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue));
            flowwork.FormContent =this.FormContent.Text;
            //flowwork.FlowID = node.FlowID;
            //flowwork.NodeID = node.ID;
            //flowwork.NodeNo = node.NodeNo;
            //flowwork.NodeUser = node.NodeUser;
            //flowwork.NodeStatus = "正常";
            //flowwork.Status = "进行中";
            //flowwork.DealFlag = 0;
            //flowwork.DealUser =WebCommon.Public.GetUserName();
            //flowwork.DealFlag = 0;
            flowwork.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowWorkManager.UpdateTbl_FlowWork(flowwork);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }
        protected void FlowName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormContent.Text = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue)).FormContent;
        }

    }
}