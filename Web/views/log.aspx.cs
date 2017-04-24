using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //删除
            if (Request.QueryString["type"] == "clean")
            {
                int count = WebBLL.Tbl_LogManager.DeleteTbl_Log();
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
            //分页
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_LogManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            Rep_list.DataSource = WebBLL.Tbl_LogManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, " ID desc");
            Rep_list.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}