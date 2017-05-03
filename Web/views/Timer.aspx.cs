using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Timer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int SetTime =Convert.ToInt32( WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set3);
            Timer1.Interval = SetTime * 1000;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                /*
                //非授权限制
                TimeSpan TS = DateTime.Now - Convert.ToDateTime("2017-03-25");
                if (TS.Days > 3)
                {
                    WebCommon.Script.ResponseScript("window.external.notify('敬告', '系统已过试用期请谨慎使用！', 'http://www.doseen.com', 1);");
                }

                */


                //读取实时提醒消息
                DataTable dt = WebBLL.Tbl_AlertManager.GetDataTableByPage(1, 1, "UserName='" + WebCommon.Public.GetUserName() + "' and status='未读'", "id desc");
                foreach (DataRow dr in dt.Rows)
                {
                    string AlertUrl = dr["AlertUrl"].ToString();
                    if (AlertUrl.Contains("?"))
                    {
                        AlertUrl += "&AlertID=" + dr["ID"];
                    }
                    else
                    {
                        AlertUrl += "?AlertID=" + dr["ID"];
                    }
                    WebCommon.Script.ResponseScript("window.external.notify('" + dr["AlertTitle"] + "', '" + dr["AlertInfo"] + "', '" + AlertUrl + "', " + dr["AlertMode"] + ");");
                }

                ////合同提醒(已经改成由项目设总确定什么时候提醒收费)
                //DataTable dt1 = WebBLL.Tbl_ProjectContractPayManager.GetDataTableByPage(1, 1, "status='未付' and alert<>1", "id desc");
                //foreach (DataRow dr in dt1.Rows)
                //{
                //    string AlertInfo = WebBLL.Tbl_ProjectContractManager.GetTbl_ProjectContractById(Convert.ToInt32(dr["ProjectContractID"])).PC_Name + " 第" + dr["PCP_Num"].ToString() + "次收费 金额" + dr["PCP_Money"].ToString() + "元";
                //    WebCommon.Public.WriteAlert("doseen", "收费提醒", AlertInfo, "views/ProjectContractPay_Edit.aspx?type=read&id=" + dr["id"].ToString());
                //    WebModels.Tbl_ProjectContractPay pcp = WebBLL.Tbl_ProjectContractPayManager.GetTbl_ProjectContractPayById(Convert.ToInt32(dr["id"]));
                //    pcp.Alert = 1;
                //    WebBLL.Tbl_ProjectContractPayManager.UpdateTbl_ProjectContractPay(pcp);
                //}
            }
            catch { }
        }
    }
}