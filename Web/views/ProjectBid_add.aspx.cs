using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBid_add : System.Web.UI.Page
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

                ProjectTypes.Items.Insert(0, new ListItem("选择类别", "0"));
                ProjectID.Items.Insert(0, new ListItem("选择项目", "0"));
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectBid bid = new WebModels.Tbl_ProjectBid();
            bid.PB_Name = this.PB_Name.Text;
            bid.PB_Info = this.PB_Info.Value;
            bid.Remark = this.Remark.Value;
            bid.Status = this.Stauts.SelectedValue;
            bid.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectBidManager.AddTbl_ProjectBid(bid);
            if (count > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }

        protected void ProjectTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectTypes.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
        }

        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PB_Name.Text = ProjectID.SelectedItem.Text;
        }
    }
}