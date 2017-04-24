using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuilder_add : System.Web.UI.Page
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

            }
        }
    }
}