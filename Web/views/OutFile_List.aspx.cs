using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class OutFile_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //删除
            if (Request.QueryString["limit"] == "del")
            {
                string ids = Request.QueryString["id"].ToString();
                int count = WebCommon.Public.DataTableDel("Tbl_OutFile", "id in(" + ids + ")");
                if (count > 0)
                {
                    WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                }
                else
                {
                    WebCommon.Script.AlertAndGoBack("删除失败！");
                }
            }

            //导出
            if (Request.QueryString["excel"] == "out")
            {
                string ExcelPath = WebCommon.Public.ToExcel(WebBLL.Tbl_OutFileManager.GetDataTableByPage(1000, 1, "projectid=" + WebCommon.Public.ToInt(Request.QueryString["projectid"]), ""), "excel/外来资料_" + Request.QueryString["projectid"] + ".xls", "id:编号,projectname:所属项目,classname:所属专业,FileName:资料名称,FileInfo:资料概述,adddate:提交日期");
                Response.Redirect(ExcelPath);
            }

            //绑定列表
            ViewState["strWhere"] = "";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") ViewState["strWhere"] = Request.QueryString["where"];
            AspNetPager1.PageSize = 10;
            AspNetPager1.RecordCount = WebBLL.Tbl_OutFileManager.GetDataTableByCount(ViewState["strWhere"].ToString());



            //绑定项目              
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
        }

        public void Bind()
        {
            Rep_List.DataSource = WebBLL.Tbl_OutFileManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, ViewState["strWhere"].ToString(), " ID desc");
            Rep_List.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

    }
}