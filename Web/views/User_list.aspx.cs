using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class User_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //删除
            if (Request.QueryString["limit"] == "del")
            {
                string ids = Request.QueryString["id"].ToString();
                int count = WebCommon.Public.DataTableDel("tbl_user", "id in(" + ids + ")");
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
            Bind();
        }

        public void Bind()
        {
            string strWhere = "";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            //分页
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_UserManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            Rep_list.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, " limitid desc");
            Rep_list.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

    }
}