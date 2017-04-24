using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class OutFile_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定项目              
                ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectID.DataTextField = "ProjectName";
                ProjectID.DataValueField = "ID";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("选择项目", ""));

                //专业
                ClassName.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName.DataTextField = "ClassName";
                ClassName.DataValueField = "ClassName";
                ClassName.DataBind();
                ClassName.Items.Insert(0, new ListItem("选择专业", ""));


                //读取信息
                ReadValue();
            }
        }

        public void ReadValue()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_OutFile model = WebBLL.Tbl_OutFileManager.GetTbl_OutFileById(ID);
            this.ProjectID.Text = model.ProjectID.ToString();
            this.ClassName.Text = model.ClassName.ToString();
            this.FileName.Text = model.FileName.ToString();
            //this.FileUrl.Text = model.FileUrl.ToString();
            this.FileInfo.Text = model.FileInfo.ToString();

        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_OutFile model = WebBLL.Tbl_OutFileManager.GetTbl_OutFileById(ID);

            model.ProjectID = Convert.ToString(this.ProjectID.Text);
            model.ClassName = Convert.ToString(this.ClassName.Text);
            model.FileName = Convert.ToString(this.FileName.Text);
            if (FileUrl.FileName != "") model.FileUrl = WebCommon.Public.UploadFile(FileUrl, "FileUrl");
            //WebCommon.Public.CutPic(model.FileUrl, model.FileUrl.Insert(model.FileUrl.Length - 4, "_"), 80, 60, 90);//生成缩略图
            model.FileInfo = Convert.ToString(this.FileInfo.Text);
            model.DealUser = WebCommon.Public.GetUserName();
            model.DealFlag = 0;
            model.DealTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            model.AddDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            int count = WebBLL.Tbl_OutFileManager.UpdateTbl_OutFile(model);
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