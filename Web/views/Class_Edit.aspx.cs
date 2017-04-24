using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Class_Edit : System.Web.UI.Page
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
                ReadValue();
            }

        }
        public void ReadValue()
        {
            ParentID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByAllParentID(0);
            ParentID.DataTextField = "ClassName";
            ParentID.DataValueField = "ID";
            ParentID.DataBind();
            ParentID.Items.Insert(0, new ListItem("作为一级分类", "0"));

            int pid = WebCommon.Public.ToInt(Request.QueryString["pid"]);
            if (pid > 0)
            {
                ParentID.Enabled = false;
            }

            int ID = int.Parse(Request.QueryString["id"].ToString());
            WebModels.Tbl_Class tblClass = WebBLL.Tbl_ClassManager.GetTbl_ClassById(ID);
            this.ClassName.Text = tblClass.ClassName;
            this.ParentID.Text = tblClass.ParentID.ToString();
            this.Remark.Text = tblClass.Remark;
            this.Status.Text = tblClass.Status;
            this.OrderNum.Text = tblClass.OrderNum.ToString();
        }
        public void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["id"].ToString());
            WebModels.Tbl_Class tblClass = WebBLL.Tbl_ClassManager.GetTbl_ClassById(ID);
            tblClass.Remark = this.Remark.Text;
            tblClass.ParentID = Convert.ToInt32(this.ParentID.Text);
            tblClass.ClassName = this.ClassName.Text;
            tblClass.Status = this.Status.Text;
            tblClass.OrderNum = Convert.ToInt32(this.OrderNum.Text);
            tblClass.DealTime = DateTime.Now;
            tblClass.DealUser = "";
            int count = WebBLL.Tbl_ClassManager.UpdateTbl_Class(tblClass);
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