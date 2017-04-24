using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectBuilderLog_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //删除
            if (Request.QueryString["limit"] == "del")
            {
                string ids = Request.QueryString["id"].ToString();
                int count = WebCommon.Public.DataTableDel("tbl_ProjectBuilderLog", "id in(" + ids + ")");
                if (count > 0)
                {
                    WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                }
                else
                {
                    WebCommon.Script.AlertAndGoBack("删除失败！");
                }
            }
            //绑定列表
            string strWhere = "";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_ProjectBuilderLogManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_ProjectBuilderLogManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, " id desc");
            ProjectList.DataBind();
        }
    }
}