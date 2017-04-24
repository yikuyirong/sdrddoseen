using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowWork_Deal : System.Web.UI.Page
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //流程名称
                FlowName.DataSource = WebBLL.Tbl_FlowManager.GetTbl_FlowAll();
                FlowName.DataTextField = "FlowName";
                FlowName.DataValueField = "ID";
                FlowName.DataBind();
                FlowName.Items.Insert(0, "选择流程");

                //获取当前工作ID
                ID = Convert.ToInt32(Request.QueryString["id"]);
                
                //如果是项目流程发起的表单
                int projectid = WebCommon.Public.ToInt(Request.QueryString["ProjectID"]);
                if (projectid > 0)
                {
                    ID = WebCommon.Public.ToInt(WebBLL.Tbl_FlowWorkManager.GetDataTableByPage(1, 1, "projectid=" + projectid.ToString(), "id desc").Rows[0]["ID"]);
                }
                FlowWorkID.Value = ID.ToString();

                //获取当前工作内容
                WebModels.Tbl_FlowWork flowwork = WebBLL.Tbl_FlowWorkManager.GetTbl_FlowWorkById(ID);
                this.NodeLocal.Value = WebBLL.Tbl_FlowNodeManager.GetTbl_FlowNodeById(flowwork.NodeID).NodeName;
                this.WorkName.Value = flowwork.WorkName;
                this.FlowName.SelectedValue = flowwork.FlowID.ToString();
                this.FormContent.InnerHtml = flowwork.FormContent;

                //获取表单常用短语
                string FromWords = "";
                foreach (WebModels.Tbl_FlowFormWord formword in WebBLL.Tbl_FlowFormWordManager.GetTbl_FlowFormWordAll())
                {
                    FromWords += "<div onclick=InputText($(this).text()) style=margin:5px>"+formword.IFW_Name+"</div>";
                }
                //向表单注册验证程序
                string LocalPwd = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).UserPwd;
                string LimitScript = "" +
                    "$('.formctrl[disabled]').removeAttr('disabled');" +
                    "$('.formctrl[data-node!=" + flowwork.NodeNo + "]').attr('disabled','disabled');" +
                    "$('.formctrl[type^=text]').dblclick(function(){$(this).attr('lock','1');$$.MsgBox('常用短语', '" + FromWords + "', '关闭窗口');});" +
                    "$('.formctrl[value=电子签名]').click(function(){$$.MsgBox('密码验证', '<input type=password id=password>', '确定:InsertSign()', '取消');});" +
                    "function InsertSign(){" +
                    "if($.md5($('#password').val())=='" + LocalPwd + "'){$('.formctrl[value=电子签名]').hide();$$.MsgBox(0);" +
                    "$('.formctrl[value=电子签名]').after('<img src=" + WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_Sign + ">');" +
                    "}else{alert('密码不正确');}}" +
                    "function InputText(info){" +
                    "$('.formctrl[lock=1]').val(info);$('.formctrl[lock=1]').removeAttr('lock');$$.MsgBox(0);}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", LimitScript, true);

                //流程的当前节点绑定
                NodeID.DataSource = WebBLL.Tbl_FlowNodeManager.GetTbl_FlowNodesByFlowID(flowwork.FlowID);
                NodeID.DataTextField = "NodeName";
                NodeID.DataValueField = "NodeNo";
                NodeID.DataBind();
                NodeID.Enabled = false;
                NodeID.SelectedValue = (Convert.ToInt32(flowwork.NodeNo) + 1).ToString();
                //如果是最后一个节点那么不再跳转
                if (NodeID.SelectedValue == "1")
                {
                    NodeID.SelectedIndex = NodeID.Items.Count-1;
                }

                //判断节点权限
                DataRow dr = WebBLL.Tbl_FlowNodeManager.GetDataTableByPage(1, 1, "flowid=" + flowwork.FlowID.ToString() + " and nodeno=" + flowwork.NodeNo, "").Rows[0];
                if (flowwork.Status == "结束") { btn_submit.Visible = false; }
                if (!dr["NodeUserLimit"].ToString().Contains("允许驳回")) Button1.Visible = false;
                if (!dr["NodeUserLimit"].ToString().Contains("允许跳过")) Button2.Visible = false;
                if (!dr["NodeUserLimit"].ToString().Contains("允许终止")) Button3.Visible = false;
                if (!dr["NodeUser"].ToString().Contains(WebCommon.Public.GetUserName())) btn_submit.Visible = false;
            }
        }

        //正常流转
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            ID = WebCommon.Public.ToInt(FlowWorkID.Value);
            WebModels.Tbl_FlowWork flowwork = WebBLL.Tbl_FlowWorkManager.GetTbl_FlowWorkById(ID);
            //flowwork.WorkName = this.WorkName.Value;
            //int flowID = Convert.ToInt32(this.FlowName.SelectedValue);
            //WebModels.Tbl_FlowNode node = WebBLL.Tbl_FlowNodeManager.GetTbl_FlowNodesByFlowID(flowID);
            //WebModels.Tbl_Flow flow = WebBLL.Tbl_FlowManager.GetTbl_FlowById(Convert.ToInt32(FlowName.SelectedValue));
            flowwork.FormContent = this.FormContentSet.Value;
            //flowwork.FlowID = FlowName.SelectedValue;
            //通过flowid和nodeno获取需要跳转到的节点信息
            DataRow dr = WebBLL.Tbl_FlowNodeManager.GetDataTableByPage(1, 1, "flowid=" + FlowName.SelectedValue + " and nodeno=" + NodeID.SelectedValue, "").Rows[0];
            flowwork.NodeID =Convert.ToInt32( dr["id"]);
            flowwork.NodeUser = dr["NodeUser"].ToString();

            //计算流程节点数并判断是否结束流程
            int flownodenum = WebBLL.Tbl_FlowNodeManager.GetDataTableByCount("flowid=" + flowwork.FlowID);
            flowwork.NodeStatus = "完成";
            if (flownodenum == Convert.ToInt32(flowwork.NodeNo))
            {
                flowwork.Status = "结束";
            }
            else
            {
                flowwork.Status = "进行中";
            }
            flowwork.NodeNo = NodeID.SelectedValue;//必须在判断完之后写入新的no
            flowwork.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowWorkManager.UpdateTbl_FlowWork(flowwork);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('处理成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('处理失败!');", true);
            }
        }

        //流程驳回
        protected void btn_submit_Click1(object sender, EventArgs e)
        {
            ID = WebCommon.Public.ToInt(FlowWorkID.Value);
            WebModels.Tbl_FlowWork flowwork = WebBLL.Tbl_FlowWorkManager.GetTbl_FlowWorkById(ID);
            flowwork.FormContent = this.FormContentSet.Value;
            //flowwork.FlowID = FlowName.SelectedValue;
            //通过flowid和nodeno获取上一节点信息
            int nodeno =Convert.ToInt32(NodeID.SelectedValue)-1;
            if (nodeno == 0) nodeno = 1;
            DataRow dr = WebBLL.Tbl_FlowNodeManager.GetDataTableByPage(1, 1, "flowid=" + FlowName.SelectedValue + " and nodeno=" + nodeno.ToString(), "").Rows[0];
            flowwork.NodeNo = dr["NodeNo"].ToString();
            flowwork.NodeID = Convert.ToInt32(dr["id"]);
            flowwork.NodeUser = flowwork.UserName;
            flowwork.NodeStatus = "驳回";
            flowwork.Status = "进行中";
            flowwork.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowWorkManager.UpdateTbl_FlowWork(flowwork);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('驳回处理成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('驳回处理失败!');", true);
            }
        }

        //流程跳过
        protected void btn_submit_Click2(object sender, EventArgs e)
        {
            btn_submit_Click(sender,e);
        }

        //流程终止
        protected void btn_submit_Click3(object sender, EventArgs e)
        {
            ID = WebCommon.Public.ToInt(FlowWorkID.Value);
            WebModels.Tbl_FlowWork flowwork = WebBLL.Tbl_FlowWorkManager.GetTbl_FlowWorkById(ID); flowwork.FormContent = this.FormContentSet.Value;
            //flowwork.FlowID = FlowName.SelectedValue;
            //flowwork.NodeNo = NodeID.SelectedValue;
            //通过flowid和nodeno获取节点信息
            //DataRow dr = WebBLL.Tbl_FlowNodeManager.GetDataTableByPage(1, 1, "flowid=" + FlowName.SelectedValue + " and nodeno=" + NodeID.SelectedValue, "").Rows[0];
            //flowwork.NodeID = Convert.ToInt32(dr["id"]);
            //flowwork.NodeUser = dr["NodeUser"].ToString();
            flowwork.NodeStatus = "终止";
            flowwork.Status = "终止";
            flowwork.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowWorkManager.UpdateTbl_FlowWork(flowwork);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('终止处理成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('终止处理失败!');", true);
            }
        }

        protected void AutoNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AutoNext.SelectedValue == "手动跳转")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('您没有该权限');", true);
                NodeID.Enabled = true;
            }
            else
            {
                Response.Redirect("FlowWork_Deal.aspx?id=" + ID.ToString());
            }
        }

    }
}