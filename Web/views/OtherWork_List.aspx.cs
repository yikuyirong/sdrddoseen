using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class OtherWork_List : System.Web.UI.Page
    {
        string whereStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("Tbl_OtherWork", "id in(" + ids + ")");
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
                if (Request.QueryString["pass"] == "1")
                {
                    int id =WebCommon.Public.ToInt(Request.QueryString["id"].ToString());
                    WebModels.Tbl_OtherWork model= WebBLL.Tbl_OtherWorkManager.GetTbl_OtherWorkById(id);
                    model.Status = "通过";
                    WebBLL.Tbl_OtherWorkManager.UpdateTbl_OtherWork(model);
                    WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                }
                if (Request.QueryString["pass"] == "0")
                {
                    int id = WebCommon.Public.ToInt(Request.QueryString["id"].ToString());
                    WebModels.Tbl_OtherWork model = WebBLL.Tbl_OtherWorkManager.GetTbl_OtherWorkById(id);
                    model.Status = "拒绝";
                    WebBLL.Tbl_OtherWorkManager.UpdateTbl_OtherWork(model);
                    WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                }

                //绑定列表
                ViewState["strWhere"] = "UserName='" + WebCommon.Public.GetUserName() + "' or NodeUser='" + WebCommon.Public.GetUserName() + "'";
                if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") ViewState["strWhere"] += Request.QueryString["where"];
                AspNetPager1.PageSize = 10;
                AspNetPager1.RecordCount = WebBLL.Tbl_OtherWorkManager.GetDataTableByCount("("+ViewState["strWhere"].ToString()+")");
            }
        }

        public void Bind()
        {
            Rep_list.DataSource = WebBLL.Tbl_OtherWorkManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, "(" + ViewState["strWhere"].ToString() + ")", " ID desc");
            Rep_list.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

    }
}