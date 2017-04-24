using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Web.views
{
    public partial class PlanManage_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //删除
            if (Request.QueryString["limit"] == "del")
            {
                string ids = Request.QueryString["id"].ToString();
                int count = WebCommon.Public.DataTableDel("Tbl_PlanManage", "id in(" + ids + ")");
                if (count > 0)
                {
                    WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                }
                else
                {
                    WebCommon.Script.AlertAndGoBack("删除失败！");
                }
            }

            //更新超时编辑
            WebCommon.Public.ExcuteSql("update tbl_planmanage set status='正常' WHERE (DATEDIFF(minute, DealTime, GETDATE()) > 10)");


            //绑定列表
            ViewState["strWhere"] = "";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") ViewState["strWhere"] = Request.QueryString["where"];
            AspNetPager1.PageSize = 10;
            AspNetPager1.RecordCount = WebBLL.Tbl_PlanManageManager.GetDataTableByCount(ViewState["strWhere"].ToString());
        }

        public void Bind()
        {
            Rep_list.DataSource = WebBLL.Tbl_PlanManageManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, ViewState["strWhere"].ToString(), " ID desc");
            Rep_list.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}