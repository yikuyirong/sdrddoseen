using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebModels;

namespace Web.views
{
    public partial class Report2_Flow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目类别
                //ProjectTypes.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                //ProjectTypes.DataTextField = "ClassName";
                //ProjectTypes.DataValueField = "ClassName";
                //ProjectTypes.DataBind();
                //ProjectTypes.Items.Insert(0,new ListItem("选择项目类别",""));
                ////级别
                //ProjectLevel.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(58);
                //ProjectLevel.DataTextField = "ClassName";
                //ProjectLevel.DataValueField = "ClassName";
                //ProjectLevel.DataBind();
                //ProjectLevel.Items.Insert(0, new ListItem("选择项目级别", ""));

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
            string strWhere = "1=1";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            string Sql = "select * from tbl_flowwork where dealflag=0 and "+strWhere;
            //分页设置
            AspNetPager1.PageSize = 5;
            AspNetPager1.RecordCount = WebCommon.Public.GetDataTableByCount(Sql);

            //绑定分页数据
            ProjectList.DataSource = WebCommon.Public.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, Sql, "");
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
                int FlowWorkID = Convert.ToInt32(row["ID"]);
                int ProjectID = Convert.ToInt32(row["ProjectID"]);
                ////合同
                Repeater DesginTask = (Repeater)e.Item.FindControl("DesginTask");
                DesginTask.DataSource = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskByProjectID(ProjectID);
                DesginTask.DataBind();
            }
        }
    }
}