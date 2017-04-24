using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebModels;

namespace Web.views
{
    public partial class Report3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("tbl_Project", "id in(" + ids + ")");
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
            string strWhere = "Tbl_DesignCorrect.status='结束'";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere += " and "+Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 50;
            AspNetPager1.RecordCount = WebBLL.Tbl_DesignCorrectManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_DesignCorrectManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "");
            ProjectList.DataBind();

            //统计结果
            System.Data.DataTable dt=WebBLL.Tbl_DesignCorrectManager.GetDataTableByStatistics(strWhere);
            Label1.Text = dt.Rows[0][0].ToString();
            Label2.Text = dt.Rows[0][1].ToString();
            Label3.Text = dt.Rows[0][2].ToString();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}