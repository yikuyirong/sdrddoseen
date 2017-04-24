using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Limit_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //删除
            if (Request.QueryString["limit"] == "del")
            {
                int ids =Convert.ToInt32(Request.QueryString["id"].ToString());
                int count = WebBLL.Tbl_LimitManager.DeleteTbl_Limit(ids);
               
                if (count > 0)
                {
                    WebCommon.Script.AlertAndGoBack("删除成功！");
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
            //分页
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_LimitManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            Rep_List.DataSource = WebBLL.Tbl_LimitManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "LimitName");
            Rep_List.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}