using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Project_Edit3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            this.ProjectName.Value = project.ProjectName;
            this.ProjectNo.Value = project.ProjectNo;
            UserNameTo.Value = project.ProjectMainDesigner;
        }

        //同意
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            //更新项目的节点信息
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            project.NodeNo = "确认主设";
            project.NodeUser = project.ProjectMainDesigner;
            WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功!');window.external.reload();window.external.close();", true);
        }

        //不同意
        protected void btn_submit2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            //更新项目的节点信息
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            project.NodeNo = "确认设总";
            project.NodeUser = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set5;
            WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功!');window.external.reload();window.external.close();", true);
        }

    }
}