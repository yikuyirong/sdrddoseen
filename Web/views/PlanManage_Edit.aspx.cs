using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Web.views
{
    public partial class PlanManage_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定分类


                //读取信息
                ReadValue();
            }
        }

        public void ReadValue()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_PlanManage model = WebBLL.Tbl_PlanManageManager.GetTbl_PlanManageById(ID);
            this.PlanDate.Text = model.PlanDate.ToString();
            this.PlanContent.Text = model.PlanContent.ToString();

            model.Status = "编辑中";
            model.DealTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            WebBLL.Tbl_PlanManageManager.UpdateTbl_PlanManage(model);
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_PlanManage model = WebBLL.Tbl_PlanManageManager.GetTbl_PlanManageById(ID);

            model.PlanDate = Convert.ToString(this.PlanDate.Text);
            model.PlanContent = Convert.ToString(this.PlanContent.Text);
            model.NodeUser = WebCommon.Public.GetUserName();
            model.Status = "正常";
            model.DealUser = WebCommon.Public.GetUserName();
            model.DealFlag = 0;
            model.DealTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            model.AddDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            int count = WebBLL.Tbl_PlanManageManager.UpdateTbl_PlanManage(model);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }
    }
}