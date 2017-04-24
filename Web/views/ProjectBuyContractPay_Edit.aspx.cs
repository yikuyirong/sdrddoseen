using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuyContractPay_Edit : System.Web.UI.Page
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
                //项目
                ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectID.DataTextField = "ProjectName";
                ProjectID.DataValueField = "ID";
                ProjectID.DataBind();
                //绑定合同ID
                ContractID.DataSource = WebBLL.Tbl_ProjectContractManager.GetTbl_ProjectContractAll();
                ContractID.DataTextField = "PC_Name";
                ContractID.DataValueField = "ID";
                ContractID.DataBind();
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectContractPay contract = WebBLL.Tbl_ProjectContractPayManager.GetTbl_ProjectContractPayById(ID);
            this.ContractID.Text = contract.ProjectContractID.ToString();
            this.ProjectID.Text = contract.ProjectID.ToString();
            this.PCP_Num.Text = contract.PCP_Num.ToString();
            this.PCP_Money.Value = contract.PCP_Money.ToString();
            this.PCP_Price.Value = contract.PCP_Price.ToString();
            this.Status.SelectedValue = contract.Status;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectContractPay contract = WebBLL.Tbl_ProjectContractPayManager.GetTbl_ProjectContractPayById(ID);
            contract.PCP_Money = Convert.ToInt32(this.PCP_Money.Value);
            contract.PCP_Price = Convert.ToInt32(this.PCP_Price.Value);
            contract.Status = this.Status.SelectedValue;
            contract.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectContractPayManager.UpdateTbl_ProjectContractPay(contract);
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