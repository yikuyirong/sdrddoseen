using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Web.views
{
    public partial class DesignTask_Correct : System.Web.UI.Page
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
                MainDesigner.Text = task.DesignMain;
                PaperNum1.Text = task.PaperNum1.ToString();
                PaperNum2.Text = task.PaperNum2.ToString();
                PaperNum3.Text = task.PaperNum3.ToString();
                //获取错误统计
                int error1num1,error1num2,error1num3,error2num1,error2num2,error2num3,error3num1,error3num2,error3num3;
                error1num1=error1num2=error1num3=error2num1=error2num2=error2num3=error3num1=error3num2=error3num3=0;
                string errorInfo = "";
                string errorInfo2 = "";
                DataTable dt= WebBLL.Tbl_DesignCorrectManager.GetDataTableByPage(100,1,"designtaskid="+taskid.ToString(),"");
                foreach (DataRow dr in dt.Rows)
                {
                    string dc_file1correctinfo = dr["dc_file1correctinfo"].ToString();
                    string dc_file2correctinfo = dr["dc_file2correctinfo"].ToString();
                    string dc_file3correctinfo = dr["dc_file3correctinfo"].ToString();
                    string dc_file1correct = dr["dc_file1correct"].ToString();
                    string dc_file2correct = dr["dc_file2correct"].ToString();
                    string dc_file3correct = dr["dc_file3correct"].ToString();
                    if (dc_file1correctinfo != "")
                    {
                        errorInfo += "<br>校对意见 ↓<br>";//- "+dr["DC_File1Time"].ToString() + "
                        errorInfo += dc_file1correctinfo + "<br>";
                        errorInfo2 += "<br>校对意见 ↓<br>" + dc_file1correct + "<br>";
                        error1num1 += Regex.Matches(dc_file1correctinfo, @"原则性错误").Count;
                        error1num2 += Regex.Matches(dc_file1correctinfo, @"技术性错误").Count;
                        error1num3 += Regex.Matches(dc_file1correctinfo, @"一般性错误").Count;
                    }
                    if (dc_file2correctinfo != "")
                    {
                        errorInfo += "<br>审核意见 ↓<br>";//- " + dr["DC_File2Time"].ToString() + "
                        errorInfo += dc_file2correctinfo + "<br>";
                        errorInfo2 += "<br>审核意见 ↓<br>" + dc_file2correct + "<br>";
                        error2num1 += Regex.Matches(dc_file2correctinfo, @"原则性错误").Count;
                        error2num2 += Regex.Matches(dc_file2correctinfo, @"技术性错误").Count;
                        error2num3 += Regex.Matches(dc_file2correctinfo, @"一般性错误").Count;
                    }
                    if (dc_file3correctinfo != "")
                    {
                        errorInfo += "<br>审定意见 ↓<br>";//- " + dr["DC_File2Time"].ToString() + "
                        errorInfo += dc_file3correctinfo + "<br>";
                        errorInfo2 += "<br>审定意见 ↓<br>" + dc_file3correct + "<br>";
                        error3num1 += Regex.Matches(dc_file3correctinfo, @"原则性错误").Count;
                        error3num2 += Regex.Matches(dc_file3correctinfo, @"技术性错误").Count;
                        error3num3 += Regex.Matches(dc_file3correctinfo, @"一般性错误").Count;
                    }
                }
                error1Num1.Text = error1num1.ToString();
                error1Num2.Text = error1num2.ToString();
                error1Num3.Text = error1num3.ToString();
                error2Num1.Text = error2num1.ToString();
                error2Num2.Text = error2num2.ToString();
                error2Num3.Text = error2num3.ToString();
                error3Num1.Text = error3num1.ToString();
                error3Num2.Text = error3num2.ToString();
                error3Num3.Text = error3num3.ToString();
                correctinfo.InnerHtml = errorInfo.Replace("\r\n","<br>");

                correctinfo2.InnerHtml = errorInfo2;
            }
        }
    }
}