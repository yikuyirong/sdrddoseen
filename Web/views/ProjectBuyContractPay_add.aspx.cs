using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuyContractPay_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目类型
                ProjectType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectType.DataTextField = "ClassName";
                ProjectType.DataValueField = "ClassName";
                ProjectType.DataBind();
                ProjectType.Items.Insert(0, new ListItem("选择项目类型",""));
                ProjectID.Items.Insert(0, new ListItem("选择项目",""));
                ContractID.Items.Insert(0, new ListItem("选择合同",""));
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectContractPay contract = new WebModels.Tbl_ProjectContractPay();
            contract.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            contract.ProjectContractID =Convert.ToInt32(this.ContractID.SelectedValue);
            contract.PCP_Num = Convert.ToInt32(this.PCP_Num.Value);
            contract.PCP_MoneyTime = "";
            contract.PCP_Money = Convert.ToInt32(this.PCP_Money.Value);
            contract.PCP_Price = Convert.ToInt32(this.PCP_Price.Value);
            contract.Status = this.Status.SelectedValue;
            contract.DealUser =WebCommon.Public.GetUserName();
            contract.PCP_Type = "采购付款";
            int count = WebBLL.Tbl_ProjectContractPayManager.AddTbl_ProjectContractPay(contract);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }

        protected void ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定项目ID
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectType.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目",""));
        }

        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定合同ID
            ContractID.DataSource = WebBLL.Tbl_ProjectContractManager.GetTbl_ProjectContractProjectID(Convert.ToInt32(this.ProjectID.SelectedValue));
            ContractID.DataTextField = "PC_Name";
            ContractID.DataValueField = "ID";
            ContractID.DataBind();
            ContractID.Items.Insert(0, new ListItem("选择合同",""));
        }

        protected void ContractID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PCP_Num.Value = (WebBLL.Tbl_ProjectContractPayManager.GetDataTableByCount("PCP_Type='采购付款' and ProjectContractID=" + ContractID.SelectedValue) + 1).ToString();
        }
    }
}