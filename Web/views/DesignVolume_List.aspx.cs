using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignVolume_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定专业
                ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName1.DataTextField = "ClassName";
                ClassName1.DataValueField = "ClassName";
                ClassName1.DataBind();
                ClassName1.Items.Insert(0, new ListItem("全部专业", ""));

                //绑定列表
                Bind();
            }
        }
        public void Bind()
        {
            string sql = "SELECT top 100 percent MAX(ID) AS ID,MAX(ClassName1) AS ClassName1, MAX(ClassName2) AS ClassName2, MAX(ClassName3) AS ClassName3, COUNT(*) AS TaskNum FROM Tbl_DesignVolume where dealflag=0 and " + wheres + " GROUP BY  ClassName1,ClassName2";
            string strWhere = "1=1";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "")
            {
                strWhere = Request.QueryString["where"];
                sql = "SELECT top 100 percent MAX(ID) AS ID,MAX(ClassName1) AS ClassName1, MAX(ClassName2) AS ClassName2, MAX(ClassName3) AS ClassName3, COUNT(*) AS TaskNum FROM Tbl_DesignVolume where " + strWhere + " and (dealflag=0) GROUP BY  ClassName1,ClassName2";
            }
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebCommon.Public.GetDataTableByCount(sql);

            //绑定分页数据
            ProjectList.DataSource = WebCommon.Public.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sql, "ClassName1 asc,ClassName2 asc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        protected string wheres = "1=1";
        protected void ClassName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            wheres = "classname1='" + ClassName1.SelectedValue+ "'";
            if (ClassName1.SelectedValue == "") wheres = "1=1";
            Bind();
        }
    }
}