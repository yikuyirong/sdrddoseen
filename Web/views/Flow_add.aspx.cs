using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Flow_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //流程分类
                FlowType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(67);
                FlowType.DataTextField = "ClassName";
                FlowType.DataValueField = "ClassName";
                FlowType.DataBind();
                FlowType.SelectedIndex = 0;
                //表单分类
                FormType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(61);
                FormType.DataTextField = "ClassName";
                FormType.DataValueField = "ClassName";
                FormType.DataBind();
                FormType.Items.Insert(0, new ListItem("选择分类",""));
                FormID.Items.Insert(0, new ListItem("选择表单",""));
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Flow flow = new WebModels.Tbl_Flow();
            flow.FormID =Convert.ToInt32(this.FormID.SelectedValue);
            flow.FlowName = this.FlowName.Value;
            flow.FormID = Convert.ToInt32(FormID.SelectedValue);
            flow.FlowType = Convert.ToString(this.FlowType.SelectedValue);
            flow.FormContent = WebBLL.Tbl_FlowFormManager.GetTbl_FlowFormById(Convert.ToInt32(FormID.SelectedValue)).IF_Content;
            flow.Remark = this.Remark.Value;
            flow.DealFlag = "0";
            flow.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowManager.AddTbl_Flow(flow);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }

        protected void FormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择表单
            FormID.DataSource = WebBLL.Tbl_FlowFormManager.GetTbl_FlowFormByType(this.FormType.SelectedValue);
            FormID.DataTextField = "IF_Name";
            FormID.DataValueField = "ID";
            FormID.DataBind();
            FormID.Items.Insert(0, new ListItem("选择表单",""));
        }

        protected void FormID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlowName.Value = FormID.SelectedItem.Text;
        }
    }
}