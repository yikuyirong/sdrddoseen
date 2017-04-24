using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Flow_Edit : System.Web.UI.Page
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

                //流程分类
                FlowType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(67);
                FlowType.DataTextField = "ClassName";
                FlowType.DataValueField = "ClassName";
                FlowType.DataBind();
                //表单
                FormID.DataSource = WebBLL.Tbl_FlowFormManager.GetTbl_FlowFormAll();
                FormID.DataTextField = "IF_Name";
                FormID.DataValueField = "ID";
                FormID.DataBind();
                Bind();
            }
           
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Flow project = WebBLL.Tbl_FlowManager.GetTbl_FlowById(ID);
            this.FormID.SelectedValue = project.FormID.ToString();
            this.FlowName.Value = project.FlowName;
            this.FlowType.SelectedValue = project.FlowType;
            this.Remark.Value = project.Remark;
            FormID.Items.Insert(0, new ListItem(WebBLL.Tbl_FlowFormManager.GetTbl_FlowFormById(project.FormID).IF_Name, project.FormID.ToString()));
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Flow contract = WebBLL.Tbl_FlowManager.GetTbl_FlowById(ID);
            contract.FormID =Convert.ToInt32(this.FormID.SelectedValue);
            contract.FlowName = this.FlowName.Value;
            contract.FlowType = this.FlowType.SelectedValue;
            contract.Remark = this.Remark.Value;
            contract.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowManager.UpdateTbl_Flow(contract);
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