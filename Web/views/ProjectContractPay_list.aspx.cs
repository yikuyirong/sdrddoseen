using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectContractPay_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("tbl_ProjectContractPay", "id in(" + ids + ")");
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
            string strWhere = "PCP_Type='经营收费'";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_ProjectContractPayManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            Rep_List.DataSource = WebBLL.Tbl_ProjectContractPayManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "Tbl_ProjectContractPay.projectid desc,Tbl_ProjectContractPay.PCP_Num desc");
            Rep_List.DataBind();
            
            //统计结果
            System.Data.DataTable dt = WebBLL.Tbl_ProjectContractPayManager.GetDataTableByStatistics(strWhere);
            Label1.Text =(Convert.ToDouble(dt.Rows[0][0])/10000).ToString()+"万";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}