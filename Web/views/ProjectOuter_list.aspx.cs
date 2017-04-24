using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectOuter_list : System.Web.UI.Page
    {
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("tbl_ProjectOuter", "id in(" + ids + ")");
                    if (count > 0)
                    {
                        WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败！");
                    }
                }

                Title = WebCommon.Public.ToString(Request.QueryString["limit"]);

                //绑定列表
                Bind();
            }
        }
        public void Bind()
        {
            string strWhere = "";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_ProjectOuterManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            Rep_List.DataSource = WebBLL.Tbl_ProjectOuterManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc");
            Rep_List.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}