using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectOuter_add : System.Web.UI.Page
    {
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定项目              
                ProjectID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectID.DataTextField = "ClassName";
                ProjectID.DataValueField = "ClassName";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("选择项目类别", ""));
                ProjectName.Items.Insert(0, new ListItem("选择项目", ""));
                //单位类型
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
                POC_Type1.Enabled = false;
                POC_Type2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(POC_Type1.SelectedValue));
                POC_Type2.DataTextField = "ClassName";
                POC_Type2.DataValueField = "ID";
                POC_Type2.DataBind();
                POC_Type2.Items.Insert(0, new ListItem("选择单位子类", ""));
                PO_CompanyID.Items.Insert(0, new ListItem("选择单位", ""));
            }

            Title = WebCommon.Public.ToString(Request.QueryString["limit"]);
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectOuter Design = new WebModels.Tbl_ProjectOuter();
            Design.PO_Type = Title;
            Design.ProjectID = Convert.ToInt32(this.ProjectName.SelectedValue);
            Design.PO_CompanyID = Convert.ToInt32(this.PO_CompanyID.SelectedValue);
            Design.PO_Content = this.PO_Content.Value;
            Design.PO_Name = PO_Name.Value;
            Design.PO_StartTime = Convert.ToDateTime(this.PO_StartTime.Value);
            Design.PO_Time1 = Convert.ToDateTime(this.PO_Time1.Value);
            Design.PO_Time2 = Convert.ToDateTime(this.PO_Time2.Value);
            Design.PO_Link = Convert.ToString(this.PO_Link.Value);
            Design.PO_LinkPhone = Convert.ToString(this.PO_LinkPhone.Value);
            Design.PO_Price = Convert.ToDouble(this.PO_Price.Value);
            Design.PO_PricePay = Convert.ToDouble(this.PO_PricePay.Value);
            Design.PO_PriceBill = Convert.ToDouble(this.PO_PriceBill.Value);
            Design.PO_FeeType = this.PO_FeeType.SelectedValue;
            Design.Status = "已完成";
            Design.Remark = this.Remark.Value;
            Design.DealUser = WebCommon.Public.GetUserName();
            Design.PO_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectBuyAcount");
            int count = WebBLL.Tbl_ProjectOuterManager.AddTbl_ProjectOuter(Design);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectID.SelectedValue);
            ProjectName.DataTextField = "ProjectName";
            ProjectName.DataValueField = "ID";
            ProjectName.DataBind();
            ProjectName.Items.Insert(0, new ListItem("选择项目", ""));
        }

        protected void POC_Type1_SelectedIndexChanged(object sender, EventArgs e)
        {
            POC_Type2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(POC_Type1.SelectedValue));
            POC_Type2.DataTextField = "ClassName";
            POC_Type2.DataValueField = "ID";
            POC_Type2.DataBind();
            POC_Type2.Items.Insert(0, new ListItem("选择单位子类", ""));
        }

        protected void POC_Type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PO_CompanyID.DataSource = WebBLL.Tbl_ProjectOuterCompanyManager.GetDataTableByPage(100, 1, "poc_type2='" + this.POC_Type2.SelectedItem.Text + "'","");
            PO_CompanyID.DataTextField = "POC_Name";
            PO_CompanyID.DataValueField = "ID";
            PO_CompanyID.DataBind();
            PO_CompanyID.Items.Insert(0, new ListItem("选择单位", ""));
        }

        protected void PO_CompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //读取联系人
            PO_Link.Value = WebBLL.Tbl_ProjectOuterCompanyManager.GetTbl_ProjectOuterCompanyById(Convert.ToInt32(PO_CompanyID.SelectedValue)).POC_LinkMan;
            PO_Link.Value = WebBLL.Tbl_ProjectOuterCompanyManager.GetTbl_ProjectOuterCompanyById(Convert.ToInt32(PO_CompanyID.SelectedValue)).POC_LinkPhone;
        }
    }
}