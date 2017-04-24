using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectOuterPay_Edit : System.Web.UI.Page
    {
        public string Title = "";
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
                //绑定合同ID
                ContractID.DataSource = WebBLL.Tbl_ProjectContractManager.GetTbl_ProjectContractAll();
                ContractID.DataTextField = "PC_Name";
                ContractID.DataValueField = "ID";
                ContractID.DataBind();

                Title = Request.QueryString["limit"];
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectOuterPay contract = WebBLL.Tbl_ProjectOuterPayManager.GetTbl_ProjectOuterPayById(ID);
            this.ContractID.Text = contract.ProjectOuterID.ToString();
            this.POP_Num.Text = contract.POP_Num.ToString();
            this.POP_Money.Value = contract.POP_Money.ToString();           
            this.POP_MoneyTime.Value = contract.POP_MoneyTime.ToString();
            this.Status.SelectedValue = contract.Status;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectOuterPay contract = WebBLL.Tbl_ProjectOuterPayManager.GetTbl_ProjectOuterPayById(ID);
            contract.POP_Money = Convert.ToInt32(this.POP_Money.Value);
            contract.POP_Price = 0; // Convert.ToInt32(this.POP_Price.Value);
            contract.POP_MoneyTime =this.POP_MoneyTime.Value;
            contract.Status = this.Status.SelectedValue;
            contract.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectOuterPayManager.UpdateTbl_ProjectOuterPay(contract);
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