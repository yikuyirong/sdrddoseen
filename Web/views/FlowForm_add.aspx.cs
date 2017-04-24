using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowForm_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //专业类别
                IF_Type.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(61);
                IF_Type.DataTextField = "ClassName";
                IF_Type.DataValueField = "ClassName";
                IF_Type.DataBind();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_FlowForm iso = new WebModels.Tbl_FlowForm();
            iso.IF_Name = this.IF_Name.Value;
            iso.IF_Type = this.IF_Type.SelectedValue;
            iso.IF_Content = this.IF_Content.Value;
            iso.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_FlowFormManager.AddTbl_FlowForm(iso);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
    }
}