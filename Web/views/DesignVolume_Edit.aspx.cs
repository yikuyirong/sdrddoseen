using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignVolume_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置只读权限
                if (Request.QueryString["type"] == "read")
                {
                    btn_submit.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "$(function(){$('input').attr('readonly', 'readonly');$('select').attr('disabled', 'true');$('textarea').attr('readonly', 'readonly');});", true);
                }                
                Bind();                
            }
        }
        public void Bind() {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_DesignVolume designvolume =WebBLL.Tbl_DesignVolumeManager.GetTbl_DesignVolumeById(ID);
            this.ClassName1.Text = designvolume.ClassName1;
            this.ClassName2.Text = designvolume.ClassName2;
            this.ClassName3.Text = designvolume.ClassName3;
            this.VolumeNo.Text = designvolume.VolumeNo;
            //this.VolumeName.Text = designvolume.VolumeName;
            this.Volume25MW.Text = designvolume.Volume25MW.ToString();
            this.Volume50MW.Text = designvolume.Volume50MW.ToString();
            this.VolumeLevel.Text = designvolume.VolumeLevel;
            this.Remark.Text = designvolume.Remark;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_DesignVolume designvolume = WebBLL.Tbl_DesignVolumeManager.GetTbl_DesignVolumeById(ID);
            designvolume.VolumeNo = this.VolumeNo.Text;
            designvolume.ClassName1 = this.ClassName1.Text;
            designvolume.ClassName2 = this.ClassName2.Text;
            designvolume.ClassName3 = this.ClassName3.Text;
            designvolume.VolumeName = this.ClassName3.Text;
            designvolume.Volume25MW = Convert.ToInt32(this.Volume25MW.Text);
            designvolume.Volume50MW = Convert.ToInt32(this.Volume50MW.Text);
            designvolume.VolumeLevel = this.VolumeLevel.Text;
            designvolume.Remark = this.Remark.Text;
            designvolume.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_DesignVolumeManager.UpdateTbl_DesignVolume(designvolume);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }
    }
}