using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectContract_Edit : System.Web.UI.Page
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
                Bind();
            }
        }
        public void Bind() {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectContract contract = WebBLL.Tbl_ProjectContractManager.GetTbl_ProjectContractById(ID);

            this.PC_Price.Value = Convert.ToString(contract.PC_Price);
            this.PC_MoneyReceive.Value = Convert.ToString(contract.PC_MoneyReceive);
            this.PC_MoneyBill.Value = Convert.ToString(contract.PC_MoneyBill);
            this.PC_FeeType.SelectedValue = contract.PC_FeeType;
            this.PC_Name.Value = contract.PC_Name;
            //审批权限
            if (WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set4.Contains(WebCommon.Public.GetUserName()))
            {
                this.Status.Enabled = true;
            }
            else
            {
                this.Status.Enabled = false;
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_ProjectContract contract =WebBLL.Tbl_ProjectContractManager.GetTbl_ProjectContractById(ID);
            if (FileUpload1.FileName!="")
            {
                contract.PC_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectContract");
            }
            if (Status.Text != "")
            {
                contract.Status = Status.Text;
            }
            contract.PC_Price = Convert.ToDouble(this.PC_Price.Value);
            contract.PC_MoneyReceive = Convert.ToDouble(this.PC_MoneyReceive.Value);
            contract.PC_MoneyBill = Convert.ToDouble(this.PC_MoneyBill.Value);
            contract.PC_FeeType = this.PC_FeeType.SelectedValue;
            contract.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectContractManager.UpdateTbl_ProjectContract(contract);
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