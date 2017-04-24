using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignChange_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //审核
                if (WebCommon.Public.ToString(Request.QueryString["type"]) != "")
                {
                    int id = WebCommon.Public.ToInt(Request.QueryString["id"]);
                    WebModels.Tbl_DesignChange change = WebBLL.Tbl_DesignChangeManager.GetTbl_DesignChangeById(id);
                    change.Status = Request.QueryString["type"];
                    WebBLL.Tbl_DesignChangeManager.UpdateTbl_DesignChange(change);
                    WebCommon.Script.AlertAndRedirect("操作成功", WebCommon.Public.GetFromUrl());
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
            AspNetPager1.RecordCount = WebBLL.Tbl_DesignChangeManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_DesignChangeManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        //判断当前用户是否该项目的设总
        protected bool IsDesignManager(string projectid)
        {
            try
            {
                string mainer1 = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(Convert.ToInt32(projectid)).ProjectMainDesigner;
                if (mainer1 == WebCommon.Public.GetUserName())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}