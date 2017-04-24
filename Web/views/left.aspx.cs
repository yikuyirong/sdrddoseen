using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定工作计划
                Repeater1.DataSource = WebBLL.Tbl_InfoManager.GetDataTableByPage(5, 1, "(classid='院级工作' or classid='部门工作')", "id desc");
                Repeater1.DataBind();

                //绑定内部消息
                InfoList.DataSource = WebBLL.Tbl_MessageManager.GetDataTableByPage(5, 1, "UserNameTo like '%" + WebCommon.Public.GetUserName() + "%'", "");
                InfoList.DataBind();

                //绑定新闻公告
                InfoList2.DataSource = WebBLL.Tbl_InfoManager.GetDataTableByPage(5, 1, "(classid<>'院级工作' and classid<>'部门工作' and status='已审核')", "AddDate desc");
                InfoList2.DataBind();
            }
        }
        public static string GetSubString(string origStr, int endIndex) { if (origStr == null || origStr.Length == 0 || endIndex < 0)     return ""; int bytesCount = System.Text.Encoding.GetEncoding("gb2312").GetByteCount(origStr); if (bytesCount > endIndex) { int readyLength = 0; int byteLength; for (int i = 0; i < origStr.Length; i++) { byteLength = System.Text.Encoding.GetEncoding("gb2312").GetByteCount(new char[] { origStr[i] }); readyLength += byteLength; if (readyLength == endIndex) { origStr = origStr.Substring(0, i + 1) + "..."; break; } else if (readyLength > endIndex) { origStr = origStr.Substring(0, i) + "..."; break; } } } return origStr; }
    }
}