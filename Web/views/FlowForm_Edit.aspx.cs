using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowForm_Edit : System.Web.UI.Page
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
                //专业类别
                IF_Type.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(61);
                IF_Type.DataTextField = "ClassName";
                IF_Type.DataValueField = "ClassName";
                IF_Type.DataBind();
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_FlowForm iso = WebBLL.Tbl_FlowFormManager.GetTbl_FlowFormById(ID);
            this.IF_Name.Value = iso.IF_Name;
            this.IF_Type.SelectedValue = iso.IF_Type;
            this.IF_Content.Value = iso.IF_Content;

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_FlowForm iso = WebBLL.Tbl_FlowFormManager.GetTbl_FlowFormById(ID);
            iso.IF_Name = this.IF_Name.Value;
            iso.IF_Type = this.IF_Type.SelectedValue;
            iso.IF_Content = this.IF_Content.Value;
            int count = WebBLL.Tbl_FlowFormManager.UpdateTbl_FlowForm(iso);
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