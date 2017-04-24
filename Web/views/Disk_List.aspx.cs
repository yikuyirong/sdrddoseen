using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Disk_List : System.Web.UI.Page
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
                    int count = WebCommon.Public.DataTableDel("tbl_disk", "id in(" + ids + ")");
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
            string strWhere = " d_class='根目录'";
            int pid = 281;
            if (WebCommon.Public.ToString(Request.QueryString["folder"]) != "")
            {
                pid = WebCommon.Public.ToInt(Request.QueryString["folderid"]);
                strWhere = " d_class='" + Request.QueryString["folder"] + "'";
            }
            
            //绑定文件夹数据
            Rep_List.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(pid);
            Rep_List.DataBind();

            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere = Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 10;
            AspNetPager1.RecordCount = WebBLL.Tbl_DiskManager.GetDataTableByCount(strWhere);
            //绑定文件数据
            Rep_List1.DataSource = WebBLL.Tbl_DiskManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, " ID desc");
            Rep_List1.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

    }
}