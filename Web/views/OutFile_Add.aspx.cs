using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class OutFile_Add : System.Web.UI.Page
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

            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_OutFile model = new WebModels.Tbl_OutFile();

            model.ProjectID = Convert.ToString(this.ProjectID.Text);
            model.ClassName = Convert.ToString(this.ClassName.Text);
            model.FileName = Convert.ToString(this.FileName.Text);
            model.FileUrl = WebCommon.Public.UploadFile(FileUrl, "FileUrl");
            //WebCommon.Public.CutPic(model.FileUrl, model.FileUrl.Insert(model.FileUrl.Length - 4, "_"), 80, 60, 90);//生成缩略图
            model.FileInfo = Convert.ToString(this.FileInfo.Text);
            model.DealUser = WebCommon.Public.GetUserName();
            model.DealFlag = 0;
            model.DealTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            model.AddDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            int count = WebBLL.Tbl_OutFileManager.AddTbl_OutFile(model);
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