using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set1);
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set2);
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set4);
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set5);
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set6);
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set7);
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set8);
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set9);
                WebBLL.Tbl_UserManager.GetUsersByListBox(C_Set10);
                ReadValue();
            }
        }
        public void ReadValue()
        {
            WebModels.Tbl_Config config = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1);
            WebCommon.Public.ListBoxValuesSet(C_Set1, config.C_Set1);
            WebCommon.Public.ListBoxValuesSet(C_Set2, config.C_Set2);
            C_Set3.Text = config.C_Set3;
            WebCommon.Public.ListBoxValuesSet(C_Set4, config.C_Set4);
            WebCommon.Public.ListBoxValuesSet(C_Set5, config.C_Set5);
            WebCommon.Public.ListBoxValuesSet(C_Set6, config.C_Set6);
            WebCommon.Public.ListBoxValuesSet(C_Set7, config.C_Set7);
            WebCommon.Public.ListBoxValuesSet(C_Set8, config.C_Set8);
            WebCommon.Public.ListBoxValuesSet(C_Set9, config.C_Set9);
            WebCommon.Public.ListBoxValuesSet(C_Set10, config.C_Set10);
            C_Set11.Text = config.C_Set11;
            C_Set12.Text = config.C_Set12;
            C_Set13.Text = config.C_Set13;
            C_Set14.Text = config.C_Set14;
            C_Set15.Text = config.C_Set15;
        }

        public void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_Config config = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1);
            config.C_Set1 = WebCommon.Public.ListBoxValuesGet(C_Set1);
            config.C_Set2 = WebCommon.Public.ListBoxValuesGet(C_Set2);
            config.C_Set3 = C_Set3.Text;
            config.C_Set4 = WebCommon.Public.ListBoxValuesGet(C_Set4);
            config.C_Set5 = WebCommon.Public.ListBoxValuesGet(C_Set5);
            config.C_Set6 = C_Set6.Text;
            config.C_Set7 = C_Set7.Text;
            config.C_Set8 = C_Set8.Text;
            config.C_Set9 = WebCommon.Public.ListBoxValuesGet(C_Set9);
            config.C_Set10 = WebCommon.Public.ListBoxValuesGet(C_Set10);
            config.C_Set11 = C_Set11.Text;
            config.C_Set12 = C_Set12.Text;
            config.C_Set13 = C_Set13.Text;
            config.C_Set14 = C_Set14.Text;
            config.C_Set15 = C_Set15.Text;
            config.DealTime = DateTime.Now;
            config.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ConfigManager.UpdateTbl_Config(config);
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