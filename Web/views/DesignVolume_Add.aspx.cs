using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignVolume_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //专业
                ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName1.DataTextField = "ClassName";
                ClassName1.DataValueField = "ID";
                ClassName1.DataBind();
                //ClassName1.Items.Insert(0, new ListItem("选择专业", ""));
                //ClassName2.Items.Insert(0, new ListItem("选择卷册", ""));
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    int ids = Convert.ToInt32(Request.QueryString["id"].ToString());
                    int count = WebCommon.Public.DataTableDel("Tbl_DesignVolume", "id in(" + ids + ")");
                    if (count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('删除成功!');", true);
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败！");
                    }
                }
                if (WebCommon.Public.ToString(Request.QueryString["ClassName1"]) != "")
                {
                    ClassName1.Items.Insert(0, new ListItem(Request.QueryString["ClassName1"], Request.QueryString["ClassName1"]));
                    ClassName2.Items.Insert(0, new ListItem(Request.QueryString["ClassName2"], Request.QueryString["ClassName2"]));
                    BindList();
                }
                else
                {
                    ClassName1.Items.Insert(0, new ListItem("选择专业", ""));
                    ClassName2.Items.Insert(0, new ListItem("选择卷册", ""));
                }
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_DesignVolume designvolume = new WebModels.Tbl_DesignVolume();
            designvolume.ClassName1 = this.ClassName1.SelectedItem.Text;
            designvolume.ClassName2 = this.ClassName2.SelectedItem.Text;
            designvolume.ClassName3 = this.VolumeName.Text;
            designvolume.VolumeNo = this.VolumeNo.Text;
            designvolume.VolumeName = this.VolumeName.Text;
            designvolume.Volume25MW = Convert.ToInt32(this.Volume25MW.Text);
            designvolume.Volume50MW = Convert.ToInt32(this.Volume50MW.Text);
            designvolume.VolumeLevel = this.VolumeLevel.Text;
            designvolume.Remark = this.Remark.Text;
            designvolume.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_DesignVolumeManager.AddTbl_DesignVersion(designvolume);
            if (count > 0)
            {
                FindButton(this);
                BindList();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
        protected void BindList()
        {
            string WhereStr = "ClassName1='" + ClassName1.SelectedItem.Text + "' and ClassName2='" + this.ClassName2.SelectedItem.Text + "'";
            int count = WebBLL.Tbl_DesignVolumeManager.GetDataTableByCount(WhereStr);
            if (count > 0)
            {
                TaskList.DataSource = WebBLL.Tbl_DesignVolumeManager.GetDataTableByPage(200, 1, WhereStr, "VolumeNo asc");
                TaskList.DataBind();
            }
            else
            {
                TaskList.DataSource = "";
                TaskList.DataBind();
            }
        }
        //清空文本框值
        private void FindButton(Control c)
        {
            if (c.Controls != null)
            {

                foreach (Control x in c.Controls)
                {
                    if (x is TextBox)
                    {
                        ((TextBox)x).Text = "";
                    }
                    FindButton(x);
                }
            }
        }



        protected void ClassName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName1.SelectedValue));
            ClassName2.DataTextField = "ClassName";
            ClassName2.DataValueField = "ID";
            ClassName2.DataBind();
            ClassName2.Items.Insert(0, new ListItem("选择卷册", ""));
        }

        protected void ClassName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindList();
        }

    }
}