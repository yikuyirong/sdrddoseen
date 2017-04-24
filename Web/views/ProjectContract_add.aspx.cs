using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectContract_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目类别
                ProjectTypes.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectTypes.DataTextField = "ClassName";
                ProjectTypes.DataValueField = "ClassName";
                ProjectTypes.DataBind();

                //从项目流程打开该页面时
                int projectid = WebCommon.Public.ToInt(Request.QueryString["ProjectID"]);
                if (projectid > 0)
                {
                    WebModels.Tbl_Project project=WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(projectid);
                    ProjectTypes.Items.Insert(0, new ListItem(project.ProjectTypes, project.ProjectTypes));
                    ProjectID.Items.Insert(0, new ListItem(project.ProjectName, projectid.ToString()));
                    ProjectNo.Value = WebBLL.Tbl_ProjectManager.GetProjectNo(project.ProjectTypes);
                }
                else
                {
                    ProjectTypes.Items.Insert(0, new ListItem("选择类别", ""));
                    ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
                }
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e) 
        {
            WebModels.Tbl_ProjectContract contract = new WebModels.Tbl_ProjectContract();
            contract.PC_Name = ProjectNo.Value;
            contract.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            if (FileUpload1.FileName != "")
            {
                contract.PC_File = WebCommon.Public.UploadFile(FileUpload1, "ProjectContract");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert请上传合同附件!');", true);
                return;
            }
            contract.PC_Price = Convert.ToDouble(this.PC_Price.Value);
            contract.PC_MoneyReceive = Convert.ToDouble(this.PC_MoneyReceive.Value);
            contract.PC_MoneyBill = Convert.ToDouble(this.PC_MoneyBill.Value);
            contract.PC_FeeType = this.PC_FeeType.SelectedValue;
            contract.Status = "已审核";//this.Stauts.SelectedValue;
            contract.DealUser = WebCommon.Public.GetUserName();
            try
            {
                int count = WebBLL.Tbl_ProjectContractManager.AddTbl_ProjectContract(contract);
                if (count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功,等待确认设总!');window.external.reload();window.external.close();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('请检查该项目是否已经存在合同!');", true);
            }
        }

        protected void ProjectTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectTypes.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目",""));
        }

        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ProjectNo.Value = ProjectID.SelectedItem.Text + "合同";
            ProjectNo.Value = WebBLL.Tbl_ProjectManager.GetProjectNo(this.ProjectTypes.SelectedValue);
        }
    }
}