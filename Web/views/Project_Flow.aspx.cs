using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
	public partial class Project_Flow : System.Web.UI.Page
	{
        public string NodeNo = "";
		protected void Page_Load(object sender, EventArgs e)
		{
            int projectid = WebCommon.Public.ToInt(Request.QueryString["ProjectID"]);
            WebModels.Tbl_Project project=WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(projectid);
            NodeNo = project.NodeNo;
		}
	}
}