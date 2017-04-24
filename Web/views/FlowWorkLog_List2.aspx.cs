using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowWorkLog_List2 : System.Web.UI.Page
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
            string strWhere = "parentid=0";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere += " and "+Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_FlowWorkLogManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_FlowWorkLogManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        protected void ProjectList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView row = (System.Data.DataRowView)e.Item.DataItem;
                int ID = Convert.ToInt32(row["ID"]);
                //相关文件
                Repeater history = (Repeater)e.Item.FindControl("Repeater1");
                history.DataSource = WebBLL.Tbl_FlowWorkLogManager.GetDataTableByPage(50, 1, "id=" + ID.ToString() + " or parentid=" + ID.ToString(), "id asc");
                history.DataBind();
            }
        }
    }
}