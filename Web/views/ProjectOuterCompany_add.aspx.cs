using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectOuterCompany_add : System.Web.UI.Page
    {
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                POC_Type1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(97);
                POC_Type1.DataTextField = "ClassName";
                POC_Type1.DataValueField = "ID";
                POC_Type1.DataBind();
                POC_Type1.Items.Insert(0, new ListItem("选择单位类型", ""));
                foreach (ListItem li in POC_Type1.Items)
                {
                    if (li.Text.Contains(Request.QueryString["limit"]))
                    {
                        li.Selected = true;
                        break;
                    }
                }

                POC_Type2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(POC_Type1.SelectedValue));
                POC_Type2.DataTextField = "ClassName";
                POC_Type2.DataValueField = "ID";
                POC_Type2.DataBind();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectOuterCompany company = new WebModels.Tbl_ProjectOuterCompany();
            company.POC_Type1 = this.POC_Type1.SelectedItem.Text;
            company.POC_Type2 = this.POC_Type2.SelectedItem.Text;
            company.POC_Name = this.POC_Name.Value;
            company.POC_LinkMan = this.POC_LinkMan.Value;
            company.POC_LinkPhone = this.POC_LinkPhone.Value;
            company.POC_Email = this.POC_Email.Value;
            company.POC_Address = this.POC_Address.Value;
            company.Remark = this.Remark.Value;
            company.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectOuterCompanyManager.AddTbl_ProjectOuterCompany(company);
            if (true)
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