using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignTask_Edit : System.Web.UI.Page
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
                //遍历绑定人员列表
                DT_SheJiRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(100, 1, "u_designlimit like '%设计人%'", "username asc");
                DT_SheJiRen.DataTextField = "UserName";
                DT_SheJiRen.DataValueField = "UserName";
                DT_SheJiRen.DataBind();
                DT_SheJiRen.Items.Insert(0, new ListItem("选设计人", ""));

                DT_JiaoDuiRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(100, 1, "u_designlimit like '%校对人%'", "username asc");
                DT_JiaoDuiRen.DataTextField = "UserName";
                DT_JiaoDuiRen.DataValueField = "UserName";
                DT_JiaoDuiRen.DataBind();
                DT_JiaoDuiRen.Items.Insert(0, new ListItem("选校对人", ""));

                DT_ShenHeRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "u_designlimit like '%审核人%'", "username asc");
                DT_ShenHeRen.DataTextField = "UserName";
                DT_ShenHeRen.DataValueField = "UserName";
                DT_ShenHeRen.DataBind();
                DT_ShenHeRen.Items.Insert(0, new ListItem("选审核人", ""));

                DT_ShenDingRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "u_designlimit like '%审定人%'", "username asc");
                DT_ShenDingRen.DataTextField = "UserName";
                DT_ShenDingRen.DataValueField = "UserName";
                DT_ShenDingRen.DataBind();
                DT_ShenDingRen.Items.Insert(0, new ListItem("选审定人", ""));
                //WebBLL.Tbl_UserManager.GetUsersByDropDownList(DT_HeZhunRen);

                Bind();
            }

        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_DesignTask DesignTask = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(ID);
            this.DT_XuHao.Text = DesignTask.DT_XuHao;
            this.DT_TuHao.Text = DesignTask.DT_TuHao;
            this.ClassName3.Text = DesignTask.ClassName3;
            this.DT_GuGong.Text = DesignTask.DT_GuGong.ToString();
            this.DT_SheJiRen.Text = DesignTask.DT_SheJiRen;
            this.DT_SheJiTime.Text = DesignTask.DT_SheJiTime.ToString("yyyy-MM-dd");
            this.DT_JiaoDuiRen.Text = DesignTask.DT_JiaoDuiRen;
            this.DT_JiaoDuiTime.Text = DesignTask.DT_JiaoDuiTime.ToString("yyyy-MM-dd");
            this.DT_ShenHeRen.Text = DesignTask.DT_ShenHeRen;
            this.DT_ShenHeTime.Text = DesignTask.DT_ShenHeTime.ToString("yyyy-MM-dd");
            this.DT_ShenDingRen.Text = DesignTask.DT_ShenDingRen;
            this.DT_ShenDingTime.Text = DesignTask.DT_ShenDingTime.ToString("yyyy-MM-dd");
            //this.DT_HeZhunRen.Text = DesignTask.DT_HeZhunRen;
            //this.DT_HeZhunTime.Text = DesignTask.DT_HeZhunTime.ToString("yyyy-MM-dd");
            this.DT_PublishTime.Text = DesignTask.DT_PublishTime.ToString("yyyy-MM-dd");
            this.Remark.Text = DesignTask.Remark;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_DesignTask DesignTask = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(ID);
            DesignTask.DT_XuHao = this.DT_XuHao.Text;
            DesignTask.DT_TuHao = this.DT_TuHao.Text;
            DesignTask.ClassName3 = this.ClassName3.Text;
            DesignTask.DT_GuGong = Convert.ToDouble(this.DT_GuGong.Text);
            DesignTask.DT_SheJiRen = this.DT_SheJiRen.Text;
            DesignTask.DT_SheJiTime = Convert.ToDateTime(this.DT_SheJiTime.Text);
            DesignTask.DT_JiaoDuiRen = this.DT_JiaoDuiRen.Text;
            DesignTask.DT_JiaoDuiTime = Convert.ToDateTime(this.DT_JiaoDuiTime.Text);
            DesignTask.DT_ShenHeRen = this.DT_ShenHeRen.Text;
            DesignTask.DT_ShenHeTime = Convert.ToDateTime(this.DT_ShenHeTime.Text);
            DesignTask.DT_ShenDingRen = this.DT_ShenDingRen.Text;
            if (DT_ShenDingTime.Text != "")
            {
                DesignTask.DT_ShenDingTime = Convert.ToDateTime(this.DT_ShenDingTime.Text);
            }
            else
            {
                DesignTask.DT_ShenDingTime = new DateTime(1900, 1, 1);
            }
            //DesignTask.DT_HeZhunRen = this.DT_HeZhunRen.Text;
            //DesignTask.DT_HeZhunTime = Convert.ToDateTime(this.DT_HeZhunTime.Text);
            DesignTask.DT_PublishTime = Convert.ToDateTime(this.DT_PublishTime.Text);
            DesignTask.Remark = this.Remark.Text;
            DesignTask.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_DesignTaskManager.UpdateTbl_DesignTask(DesignTask);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            }
        }
    }
}