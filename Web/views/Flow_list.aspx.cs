using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Flow_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("tbl_Flow", "id in(" + ids + ") and (select count(*) from tbl_flowwork where flowid=tbl_Flow.id and dealflag=0)=0");
                    if (count > 0)
                    {
                        WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败,请检查该流程是否有工作存在！");
                    }
                }
                //更新
                if (Request.QueryString["type"] == "update")
                {
                    int id =WebCommon.Public.ToInt(Request.QueryString["id"]);
                    WebModels.Tbl_Flow flow = WebBLL.Tbl_FlowManager.GetTbl_FlowById(id);
                    flow.FormContent = WebBLL.Tbl_FlowFormManager.GetTbl_FlowFormById(flow.FormID).IF_Content;
                    WebBLL.Tbl_FlowManager.UpdateTbl_Flow(flow);
                    WebCommon.Script.AlertAndGoBack("更新并同步表单成功！");
                }
                //绑定列表
                Bind();
            }
        }
        public void Bind()
        {
            string strWhere = "";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_FlowManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            Rep_List.DataSource = WebBLL.Tbl_FlowManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc");
            Rep_List.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}