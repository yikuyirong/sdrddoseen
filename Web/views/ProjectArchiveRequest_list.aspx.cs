using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectArchiveRequest_list : System.Web.UI.Page
    {
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    string ids = Request.QueryString["id"].ToString();
                    int count = WebCommon.Public.DataTableDel("tbl_ProjectArchiveRequest", "id in(" + ids + ")");
                    if (count > 0)
                    {
                        WebCommon.Script.Redirect(WebCommon.Public.GetFromUrl());
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败！");
                    }
                }

                //节点操作
                string nodeno = WebCommon.Public.ToString(Request.QueryString["nodeno"]);
                if (nodeno != "")
                {
                    //更新状态
                    int id = WebCommon.Public.ToInt(Request.QueryString["id"]);
                    WebModels.Tbl_ProjectArchiveRequest archiverequest = WebBLL.Tbl_ProjectArchiveRequestManager.GetTbl_ProjectArchiveRequestById(id);
                    archiverequest.NodeNo = nodeno;
                    WebBLL.Tbl_ProjectArchiveRequestManager.UpdateTbl_ProjectArchiveRequest(archiverequest);
                    WebCommon.Script.GoBack();
                }

                //状态操作
                string type = WebCommon.Public.ToString(Request.QueryString["statustype"]);
                if (type !="")
                {
                    //更新状态
                    int id = WebCommon.Public.ToInt(Request.QueryString["id"]);
                    WebModels.Tbl_ProjectArchiveRequest archiverequest = WebBLL.Tbl_ProjectArchiveRequestManager.GetTbl_ProjectArchiveRequestById(id);
                    archiverequest.Status = type;
                    if (type == "通过")
                    {
                        archiverequest.NodeUser = WebBLL.Tbl_UserManager.GetUsersByDepartName("技术质量部");
                    }
                    WebBLL.Tbl_ProjectArchiveRequestManager.UpdateTbl_ProjectArchiveRequest(archiverequest);
                    WebCommon.Script.GoBack();
                }

                Title = Request.QueryString["limit"];
                //绑定列表
                Bind();
            }
        }
        public void Bind()
        {
            string strWhere = "(NodeUser='" + WebCommon.Public.GetUserName() + "' or UserName='" + WebCommon.Public.GetUserName() + "') and RequestType='" + Request.QueryString["limit"] + "'";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere += " and "+Request.QueryString["where"];
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_ProjectArchiveRequestManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_ProjectArchiveRequestManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}