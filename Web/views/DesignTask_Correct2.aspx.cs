using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Web.views
{
    public partial class DesignTask_Correct2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int taskid = WebCommon.Public.ToInt(Request.QueryString["taskid"]);
                WebModels.Tbl_DesignTask task = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(taskid);
                ClassName1.Text = task.ClassName1;
                ProjectName.Text = task.ProjectName;
                ClassName3.Text = task.ClassName3;
                ProjectNo.Text = task.ProjectNo + "-" + task.DT_TuHao;
                Designer.Text = task.DT_SheJiRen;
                //获取错误统计
                int error1num1,error1num2,error1num3,error2num1,error2num2,error2num3,error3num1,error3num2,error3num3;
                error1num1=error1num2=error1num3=error2num1=error2num2=error2num3=error3num1=error3num2=error3num3=0;
                string errorInfo = "";
                DataTable dt= WebBLL.Tbl_DesignCorrectManager.GetDataTableByPage(100,1,"designtaskid="+taskid.ToString(),"");
                foreach (DataRow dr in dt.Rows)
                {
                    string dc_file4correctinfo = dr["dc_file4correctinfo"].ToString();
                    for (int i = 0; i < dc_file4correctinfo.Split('>').Length-1; i++)
                    {
                        string einfo = dc_file4correctinfo.Split('>')[i];
                        if (einfo == "") einfo = "通过";
                        errorInfo += "<tr>" +
                                  "<td style='background: #fff;text-align:center;height:50px'></td>" +
                                  "<td style='background: #fff;text-align:center' colspan=2></td>" +
                                  "<td style='background: #fff;text-align:center'>" +einfo + "</td>" +
                                  "</tr>";
                    }
                }
                correctinfo.InnerHtml = errorInfo;
            }
        }
    }
}