using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Disk_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Disk model = WebBLL.Tbl_DiskManager.GetTbl_DiskById(ID);
            this.D_Class.Text = model.D_Class.ToString();
            this.D_Title.Text = model.D_Title.ToString();
            //this.D_File.Text = model.D_File.ToString();
            this.Remark.Text = model.Remark.ToString();
            D_Class.Enabled = false;
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Disk model = WebBLL.Tbl_DiskManager.GetTbl_DiskById(ID);

            model.D_Class = Convert.ToString(this.D_Class.Text);
            model.D_Title = Convert.ToString(this.D_Title.Text);
            if (D_File.FileName != "") model.D_File = WebCommon.Public.UploadFile(D_File, "D_File");
            //WebCommon.Public.CutPic(model.D_File, model.D_File.Insert(model.D_File.Length - 4, "_"), 80, 60, 90);//生成缩略图
            model.Remark = Convert.ToString(this.Remark.Text);
            model.DealUser = WebCommon.Public.GetUserName();
            model.DealFlag = 0;
            model.DealTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            model.AddDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            int count = WebBLL.Tbl_DiskManager.UpdateTbl_Disk(model);
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