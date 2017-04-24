using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Alert_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定列表
            Bind();
        }

        public void Bind()
        {
            string strWhere = "username='"+WebCommon.Public.GetUserName()+"'";
            //分页
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_AlertManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            Rep_list.DataSource = WebBLL.Tbl_AlertManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, " ID desc");
            Rep_list.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}