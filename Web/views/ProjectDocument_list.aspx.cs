using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectDocument_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("tbl_ProjectDocument", "id in(" + ids + ")");
                    if (count > 0)
                    {
                        WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败！");
                    }
                }
                //审核
                if (Request.QueryString["type"] == "通过")
                {
                    //插入数据
                    int id = WebCommon.Public.ToInt(Request.QueryString["id"]);
                    WebModels.Tbl_ProjectDocument document = WebBLL.Tbl_ProjectDocumentManager.GetTbl_ProjectDocumentById(id);
                    //查询受资主设
                    switch (document.Status)
                    {
                        case "提资主设审核":
                            document.Status = "受资主设审核";
                            document.PD_Users = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(1, 1, "projectid=" + document.ProjectID + " and classname='" + document.ClassName + "'", "").Rows[0]["UserName"].ToString();
                            break;
                        case "受资主设审核":
                            document.Status = "发送设计人";
                            break;
                    }
                    WebBLL.Tbl_ProjectDocumentManager.UpdateTbl_ProjectDocument(document);
                    WebCommon.Script.AlertAndRedirect("操作成功", WebCommon.Public.GetFromUrl());
                }

                if (Request.QueryString["type"] == "不通过")
                {
                    //插入数据
                    int id = WebCommon.Public.ToInt(Request.QueryString["id"]);
                    WebModels.Tbl_ProjectDocument document = WebBLL.Tbl_ProjectDocumentManager.GetTbl_ProjectDocumentById(id);
                    document.PD_Users = document.UserName;
                    document.Status = "异议返回";
                    WebBLL.Tbl_ProjectDocumentManager.UpdateTbl_ProjectDocument(document);
                    WebCommon.Script.AlertAndRedirect("操作成功",WebCommon.Public.GetFromUrl());
                }

                //发送设计师
                string pddesigner=WebCommon.Public.ToString( Request.QueryString["Designer"]);
                int pdid = WebCommon.Public.ToInt(Request.QueryString["ID"]);
                if (pddesigner != "")
                {
                    WebModels.Tbl_ProjectDocument document = WebBLL.Tbl_ProjectDocumentManager.GetTbl_ProjectDocumentById(pdid);
                    document.PD_Users = pddesigner;
                    document.Status = "已存档";
                    WebBLL.Tbl_ProjectDocumentManager.UpdateTbl_ProjectDocument(document);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('发送成功');", true);
                }

                //绑定设计师
                Designer.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(200, 1, "U_DesignLimit like '%设计人%'", "username desc");
                Designer.DataTextField = "UserName";
                Designer.DataValueField = "UserName";
                Designer.DataBind();
                Designer.Items.Insert(0, new ListItem("选择设计师", ""));

                //绑定列表
                Bind();
            }
        }
        public void Bind()
        {
            //string strWhere = "classname='" + WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_Specialty + "'";
            string strWhere = "username='" + WebCommon.Public.GetUserName() + "' or PD_Users='" + WebCommon.Public.GetUserName() + "'";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_ProjectDocumentManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_ProjectDocumentManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}