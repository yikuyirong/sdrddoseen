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
    public partial class PlanManage_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定分类
                PlanContent.Text = WebBLL.Tbl_FlowFormManager.GetTbl_FlowFormById(64).IF_Content;
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_PlanManage model = new WebModels.Tbl_PlanManage();

            model.PlanDate = Convert.ToString(this.PlanDate.Text);
            model.PlanContent = Convert.ToString(this.PlanContent.Text);
            model.NodeUser = WebCommon.Public.GetUserName();
            model.Status = "正常";
            model.DealUser = WebCommon.Public.GetUserName();
            model.DealFlag = 0;
            model.DealTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            model.AddDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            int count = WebBLL.Tbl_PlanManageManager.AddTbl_PlanManage(model);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                PlanContent.Text = WebBLL.Tbl_PlanManageManager.GetDataTableByPage(1, 1, "", "id desc").Rows[0]["PlanContent"].ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('无数据可用');", true);
            }
        }
    }
}