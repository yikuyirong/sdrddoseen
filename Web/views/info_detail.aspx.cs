using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class info_detail : System.Web.UI.Page
    {
        public string I_Title;
        public DateTime AddDate;
        public string I_Content;
        public string I_File;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btn_btg.Visible = false;
                this.btn_fb.Visible = false;
                this.btn_tg.Visible = false;
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Info info = WebBLL.Tbl_InfoManager.GetTbl_InfoById(ID);
            I_Title = info.I_Title;
            AddDate = info.AddDate;
            I_Content = info.I_Content;
            I_File = info.I_File;
            if (info.NodeStatus == "信息登记审核")
            {
                this.btn_fb.Visible = true;
            }
            else
            {
                if (info.Status == "未审核" && info.NodeUser.Contains(WebCommon.Public.GetUserName()))
                {
                    this.btn_btg.Visible = true;
                    this.btn_fb.Visible = false;
                    this.btn_tg.Visible = true;
                }
            }
        }

        protected void btn_tg_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Info info = WebBLL.Tbl_InfoManager.GetTbl_InfoById(ID);
            switch (info.NodeStatus)
            {
                case "部门主管审核":
                    if (info.I_Type == "一般信息")
                    {
                        info.Status = "已审核";
                        info.NodeStatus = "已审核";// "部门经理审批";
                        WebModels.Tbl_User user = WebBLL.Tbl_UserManager.GetTbl_UserDepartManager(WebCommon.Public.GetUserName());
                        info.NodeUser = user.UserName;
                    }
                    else
                    {
                        info.NodeUser = info.UserName;
                        info.Status = "已审核";
                        info.NodeStatus = "已审核";// "院长审批";
                        WebModels.Tbl_Config cofig = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1);
                        info.NodeUser = cofig.C_Set4;
                    }
                    break;
                case "部门经理审批":
                    info.NodeStatus = "信息登记审核";
                    WebModels.Tbl_Config config = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1);
                    info.NodeUser = config.C_Set2;
                    break;
                case "院长审批":
                    info.NodeStatus = "信息登记审核";
                    WebModels.Tbl_Config config1 = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1);
                    info.NodeUser = config1.C_Set2;
                    break;
                case "信息登记审核":
                    info.NodeStatus = "已审核";
                    info.NodeUser = info.UserName;
                    info.Status = "已审核";
                    break;
            }
            int count = WebBLL.Tbl_InfoManager.UpdateTbl_Info(info);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作失败!');", true);
            }
        }

        protected void btn_btg_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Info info = WebBLL.Tbl_InfoManager.GetTbl_InfoById(ID);
            //switch (info.NodeStatus)
            //{
            //    case "部门主管审核":
            //        info.NodeStatus = "信息驳回";
            //        info.NodeUser = info.UserName;
            //        WebModels.Tbl_User user = WebBLL.Tbl_UserManager.GetTbl_UserDepartManager(WebCommon.Public.GetUserName());
            //        info.NodeUser = user.UserName;
            //        break;
            //    case "部门经理审批":
            //        info.NodeStatus = "信息驳回";
            //        info.NodeUser = info.UserName;
            //        WebModels.Tbl_Config config = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1);
            //        info.NodeUser = config.C_Set2;
            //        break;
            //    case "院长审批":
            //        info.NodeStatus = "信息驳回";
            //        info.NodeUser = info.UserName;
            //        WebModels.Tbl_Config config1 = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1);
            //        info.NodeUser = config1.C_Set2;
            //        break;
            //}
            info.NodeStatus = "信息驳回";
            info.NodeUser = info.UserName;
            int count = WebBLL.Tbl_InfoManager.UpdateTbl_Info(info);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作失败!');", true);
            }
        }

        protected void btn_fb_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            WebModels.Tbl_Info info = WebBLL.Tbl_InfoManager.GetTbl_InfoById(ID);
            info.NodeStatus = "已审核";
            info.NodeUser = info.UserName;
            info.Status = "已审核";
            int count = WebBLL.Tbl_InfoManager.UpdateTbl_Info(info);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('发布成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('发布失败!');", true);
            }
        }
    }
}