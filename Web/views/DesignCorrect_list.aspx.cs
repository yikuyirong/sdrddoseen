using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignCorrect_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("tbl_DesignCorrect", "id in(" + ids + ")");
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
        }
        public void Bind()
        {
            string strWhere = "(tbl_designcorrect.NodeUser like '%" + WebCommon.Public.GetUserName() + "%' or UserName='" + WebCommon.Public.GetUserName() + "' or DT_JiaoDuiRen='" + WebCommon.Public.GetUserName() + "' or DT_ShenHeRen='" + WebCommon.Public.GetUserName() + "' or DT_ShenDingRen='" + WebCommon.Public.GetUserName() + "')";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere += " and "+Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 6;
            AspNetPager1.RecordCount = WebBLL.Tbl_DesignCorrectManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_DesignCorrectManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "tbl_DesignCorrect.id desc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}