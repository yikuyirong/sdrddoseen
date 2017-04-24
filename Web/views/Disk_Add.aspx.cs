using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Disk_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                D_Class.Text = "根目录";
                if (WebCommon.Public.ToString(Request.QueryString["folder"]) != "") D_Class.Text = WebBLL.Tbl_ClassManager.GetTbl_ClassById(WebCommon.Public.ToInt(Request.QueryString["folder"])).ClassName;
                D_Class.Enabled = false;
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Disk model = new WebModels.Tbl_Disk();

            model.D_Class = Convert.ToString(this.D_Class.Text);
            model.D_Title = Convert.ToString(this.D_Title.Text);
            model.D_File = WebCommon.Public.UploadFile(D_File, "D_File");
            //WebCommon.Public.CutPic(model.D_File, model.D_File.Insert(model.D_File.Length - 4, "_"), 80, 60, 90);//生成缩略图
            model.Remark = Convert.ToString(this.Remark.Text);
            model.DealUser = WebCommon.Public.GetUserName();
            model.DealFlag = 0;
            model.DealTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            model.AddDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            int count = WebBLL.Tbl_DiskManager.AddTbl_Disk(model);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
    }
}