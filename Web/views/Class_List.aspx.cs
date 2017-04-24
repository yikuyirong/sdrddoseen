using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Class_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //排序
            if (Request.QueryString["deal"] == "up")
            {
                WebModels.Tbl_Class tblclass = WebBLL.Tbl_ClassManager.GetTbl_ClassById(Convert.ToInt32(Request.QueryString["id"]));
                if (tblclass.OrderNum > 0) tblclass.OrderNum = tblclass.OrderNum - 1;
                WebBLL.Tbl_ClassManager.UpdateTbl_Class(tblclass);
            }
            if (Request.QueryString["deal"] == "down")
            {
                WebModels.Tbl_Class tblclass = WebBLL.Tbl_ClassManager.GetTbl_ClassById(Convert.ToInt32(Request.QueryString["id"]));
                tblclass.OrderNum = tblclass.OrderNum + 1;
                WebBLL.Tbl_ClassManager.UpdateTbl_Class(tblclass);
            }

            //删除
            if (Request.QueryString["limit"] == "del")
            {
                int ID = int.Parse(Request.QueryString["id"].ToString());
                int count = WebBLL.Tbl_ClassManager.DeleteTbl_Class(ID);
                if (count > 0)
                {
                    WebCommon.Script.AlertAndGoBack("删除成功！");
                }
                else
                {
                    WebCommon.Script.AlertAndGoBack("删除失败！");
                }
            }

            //绑定列表
            Bind();
        }

        public int pid = 0;
        public void Bind()
        {
            pid = WebCommon.Public.ToInt(Request.QueryString["pid"]);
            if (pid > 0)
            {
                Label1.Text = WebBLL.Tbl_ClassManager.GetTbl_ClassById(pid).ClassName;
                Label2.Text = Label1.Text.Substring(0, 2);
                Rep_list.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByAllParentID(pid);
                Rep_list.DataBind();
            }
            else
            {
                Rep_list.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(pid);
                Rep_list.DataBind();
            }
        }
    }
}