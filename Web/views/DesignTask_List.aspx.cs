using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignTask_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定列表
                Bind();
            }
        }
        public void Bind()
        {
            string sql = "SELECT top 100 percent MAX(ProjectID) AS ProjectID,MAX(ProjectName) AS ProjectName, MAX(ClassName1) AS ClassName1, MAX(DesignManager) AS DesignManager,MAX(DesignMain) AS DesignMain, MAX(AddDate) AS AddDate, COUNT(*) AS TaskNum FROM Tbl_DesignTask where dealflag=0 GROUP BY ProjectID, ClassName1";
            string strWhere = "1=1";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "")
            {
                strWhere = Request.QueryString["where"];
                sql = "SELECT top 100 percent MAX(ProjectID) AS ProjectID,MAX(ProjectName) AS ProjectName, MAX(ClassName1) AS ClassName1, MAX(DesignManager) AS DesignManager,MAX(DesignMain) AS DesignMain, MAX(AddDate) AS AddDate, COUNT(*) AS TaskNum FROM Tbl_DesignTask where " + strWhere + " and (dealflag=0) GROUP BY ProjectID, ClassName1";
            }
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebCommon.Public.GetDataTableByCount(sql);

            //绑定分页数据
            ProjectList.DataSource = WebCommon.Public.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sql, "ProjectName,ClassName1 asc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}