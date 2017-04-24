using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebModels;

namespace Web.views
{
    public partial class Report1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目类别
                ProjectTypes.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectTypes.DataTextField = "ClassName";
                ProjectTypes.DataValueField = "ClassName";
                ProjectTypes.DataBind();
                ProjectTypes.Items.Insert(0,new ListItem("选择项目类别",""));
                //级别
                ProjectLevel.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(58);
                ProjectLevel.DataTextField = "ClassName";
                ProjectLevel.DataValueField = "ClassName";
                ProjectLevel.DataBind();
                ProjectLevel.Items.Insert(0, new ListItem("选择项目级别", ""));

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
            String Sql = "SELECT Tbl_ProjectContract.*,Tbl_Project.ProjectNo, Tbl_Project.ProjectName,Tbl_Project.ProjectCustom, Tbl_Project.ProjectManager, Tbl_Project.ProjectCustomContact,Tbl_Project.ProjectCustomPhone, Tbl_Project.ProjectStartTime, Tbl_Project.ProjectEndTime, Tbl_Project.ProjectTypes,Tbl_Project.ProjectCity, Tbl_Project.ProjectLevel, Tbl_Project.ProjectInfo FROM  Tbl_ProjectContract LEFT OUTER JOIN Tbl_Project ON Tbl_ProjectContract.ProjectID = Tbl_Project.ID where Tbl_ProjectContract.dealflag=0 and " + strWhere;
            //分页设置
            AspNetPager1.PageSize = 15;
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
                int ID = Convert.ToInt32(row["ID"]);
                int ProjectID = Convert.ToInt32(row["ProjectID"]);
                //收费
                Repeater ContractPay = (Repeater)e.Item.FindControl("ContractPay");
                ContractPay.DataSource = WebBLL.Tbl_ProjectContractPayManager.GetDataTableByPage(20,1,"ProjectContractid="+ID.ToString(),"");
                ContractPay.DataBind(); 
                //外包
                Repeater Outer = (Repeater)e.Item.FindControl("Outer");
                Outer.DataSource = WebBLL.Tbl_ProjectOuterManager.GetDataTableByPage(100,1,"projectid="+ProjectID.ToString(),"id desc");
                Outer.DataBind();
            }
        }
    }
}