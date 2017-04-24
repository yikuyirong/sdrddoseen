using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectContractPay_add : System.Web.UI.Page
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
                ProjectType.Items.Insert(0, new ListItem("选择项目类型", ""));
                ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
                ContractID.Items.Insert(0, new ListItem("选择合同", ""));
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectContractPay contract = new WebModels.Tbl_ProjectContractPay();
            contract.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            contract.ProjectContractID = Convert.ToInt32(this.ContractID.SelectedValue);
            contract.PCP_Num = Convert.ToInt32(this.PCP_Num.SelectedValue);
            contract.PCP_Price = 0;
            contract.Status = this.Status.SelectedValue;
            contract.DealUser = WebCommon.Public.GetUserName();
            contract.PCP_Type = "经营收费";
            for (int i = 0; i < contract.PCP_Num; i++)
            {
                contract.PCP_MoneyTime=Request.Form["PCP_MoneyTime"].ToString().Split(',')[i];
                contract.PCP_Money=Convert.ToInt32(Request.Form["PCP_Money"].ToString().Split(',')[i]);
                WebBLL.Tbl_ProjectContractPayManager.AddTbl_ProjectContractPay(contract);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
        }

        protected void ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定项目ID
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectType.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
        }

        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定合同ID
            ContractID.DataSource = WebBLL.Tbl_ProjectContractManager.GetTbl_ProjectContractProjectID(Convert.ToInt32(this.ProjectID.SelectedValue));
            ContractID.DataTextField = "PC_Name";
            ContractID.DataValueField = "ID";
            ContractID.DataBind();
            ContractID.Items.Insert(0, new ListItem("选择合同", ""));
        }

        protected void PCP_Num_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jiedianStr = "<input type='text' name='PCP_MoneyTime' check='必,空,0,100' value='num' class='input1' style='width:45px' /> ";
            string kuanxiangStr = "<input type='text' name='PCP_Money' value='0' check='必,数,0,100' value='0' class='input1' style='width:45px' /> ";
            string kuanxiangStrs = "";
            string jiedianStrs = "";
            for (int i = 0; i <Convert.ToInt32(PCP_Num.SelectedValue); i++)
            {
                jiedianStrs += jiedianStr.Replace("num", (i+1).ToString());
                kuanxiangStrs += kuanxiangStr;
            }
            jiedian.InnerHtml = jiedianStrs;
            kuanxiang.InnerHtml = kuanxiangStrs;
        }
    }
}