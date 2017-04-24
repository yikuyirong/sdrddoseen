using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuyContract_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定项目              
                ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectID.DataTextField = "ProjectName";
                ProjectID.DataValueField = "ID";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0,new ListItem("选择项目",""));
                //供应单位              
                POC_Name.DataSource = WebBLL.Tbl_ProjectBuilderManager.GetTbl_ProjectBuilderAll();
                POC_Name.DataTextField = "POC_Name";
                POC_Name.DataValueField = "POC_Name";
                POC_Name.DataBind();
                POC_Name.Items.Insert(0,new ListItem("选择供应单位",""));
            }

        }
        protected void btn_submit_Click1(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectBuyContract Contract = new WebModels.Tbl_ProjectBuyContract();
            Contract.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            Contract.PBC_Company = this.POC_Name.SelectedValue;
            Contract.PBC_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectBuyContract");
            Contract.PBC_Price = Convert.ToDouble(this.PBC_Price.Value);
            Contract.PBC_FeeType = this.PO_FeeType.SelectedValue;
            Contract.Status = this.Stauts.SelectedValue;
            int count = WebBLL.Tbl_ProjectBuyContractManager.AddTbl_ProjectBuyContract(Contract);
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