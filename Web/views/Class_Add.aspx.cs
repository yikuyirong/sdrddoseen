using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Class_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParentID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByAllParentID(0);
                ParentID.DataTextField = "ClassName";
                ParentID.DataValueField = "ID";
                ParentID.DataBind();
                ParentID.Items.Insert(0, new ListItem("作为一级分类", "0"));

                if (Request.QueryString["pid"] != "")
                {
                    ParentID.SelectedValue = Request.QueryString["pid"];
                    ParentID.Enabled = false;
                }
            }
        }

        public void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Class tblClass = new WebModels.Tbl_Class();
            tblClass.Remark = this.Remark.Text;
            tblClass.ParentID = Convert.ToInt32(this.ParentID.Text);
            //tblClass.ClassName = this.ClassName.Text;
            //tblClass.ClassPic = WebCommon.Public.UploadFile(ClassPic, "Class_pic");
            //if (PicWidth.Text != "" && PicHeight.Text != "") WebCommon.Public.CutPic(tblClass.ClassPic, tblClass.ClassPic.Insert(tblClass.ClassPic.Length - 4, "_"), Convert.ToInt32(PicWidth.Text), Convert.ToInt32(PicHeight.Text), 90);//生成缩略图
            tblClass.OrderNum = Convert.ToInt32(this.OrderNum.Text);
            tblClass.Status = this.Status.Text;
            tblClass.DealUser = "";
            int count = 0;
            foreach (string str in ClassName.Text.Replace("\r", "").Split('\n'))
            {
                tblClass.ClassName = str.Trim();
                count = WebBLL.Tbl_ClassManager.AddTbl_Class(tblClass);
            }
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