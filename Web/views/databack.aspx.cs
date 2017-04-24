using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class databack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = "DoseenDesign" + DateTime.Now.Ticks.ToString() + ".bak";
            string sqlstr = "BACKUP DATABASE DB_DoseenDesign TO DISK = '" + fileName + "'";
            try
            {
                WebDAL.DBHelper.ExecuteNonQuery(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, System.Data.CommandType.Text, sqlstr, null);
                WebCommon.Script.Alert("数据库在服务器上备份成功，备份文件名为：" + fileName);
            }
            catch
            {
                WebCommon.Script.Alert("操作失败");
            }
        }
    }
}