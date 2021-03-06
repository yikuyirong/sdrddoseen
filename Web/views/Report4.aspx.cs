﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class Report4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //开始设计生成设计文件和属性文件
                if (WebCommon.Public.ToString(Request.QueryString["type"]) == "开始设计")
                {
                    int taskId = Convert.ToInt32(Request.QueryString["taskid"]);
                    WebModels.Tbl_DesignTask designtask = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(taskId);

                    //生成上传文件名
                    string RndName = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTasFileNamekByTaskId(taskId);

                    //获取项目资料生成属性
                    WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(designtask.ProjectID);
            
                    //生成属性文件
                    string folderPath = System.Web.HttpContext.Current.Server.MapPath("/upload/DesignCorrect");
                    if (!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);
                    string path = folderPath + "\\" + RndName + " - 属性.txt";
                    if (!System.IO.File.Exists(path)) System.IO.File.Create(path).Close();
                    System.Text.StringBuilder strBuilderErrorMessage = new System.Text.StringBuilder();
                    strBuilderErrorMessage.Append("工程名称：" + project.ProjectName + "\r\n");
                    strBuilderErrorMessage.Append("图纸名称：请手动输入\r\n");
                    strBuilderErrorMessage.Append("卷册检索号：" + project.ProjectNo + "\r\n");
                    strBuilderErrorMessage.Append("专业：" + designtask.ClassName1 + "\r\n");
                    strBuilderErrorMessage.Append("阶段：施工图\r\n");
                    strBuilderErrorMessage.Append("卷册名称：" + designtask.ClassName3);
                    System.IO.File.WriteAllText(path, strBuilderErrorMessage.ToString(), System.Text.Encoding.Default);
                    //using (System.IO.StreamWriter sw = System.IO.File.CreateText(path))
                    //{
                    //    sw.Write(strBuilderErrorMessage);
                    //    sw.Flush();
                    //    sw.Close();
                    //}
                    //属性生成结束
                    string serverUrl="/upload/DesignCorrect/" + RndName + " - 属性.txt|"+WebCommon.Public.Get_BlankFilePath;
                    string SaveUrl = "/template/" + RndName + " - 属性.txt|/template/" + RndName + " - 设计.dwg";
                    //下载属性文件和空白CAD文件
                    WebCommon.Script.ResponseScript("window.external.download('" + serverUrl + "','" + SaveUrl + "',true)");
                    WebCommon.Script.GoBack();
                }

                //开始提交设计文件
                //if (WebCommon.Public.ToString(Request.QueryString["type"]) == "提交设计")
                //{
                //    int taskId = Convert.ToInt32(Request.QueryString["taskid"]);
                //    //生成上传文件名
                //    string RndName = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTasFileNamekByTaskId(taskId);

                //    string ServerUrl = "/upload/DesignCorrect/" + RndName + " - 设计.txt";
                //    string ClientUrl = ServerUrl;
                //    //上传CAD设计文件
                //    WebCommon.Script.ResponseScript("window.external.download('" + ServerUrl + "','" + ClientUrl + "',true)");
                //    WebCommon.Script.GoBack();
                //}

                //绑定列表
                Bind();
            }
        }
        public void Bind()
        {
            string strWhere = "status='结束'";
            if (WebCommon.Public.ToString(Request.QueryString["where"]) != "") strWhere += " and ("+Request.QueryString["where"]+")";
            
            //分页设置
            AspNetPager1.PageSize = 5;
            AspNetPager1.RecordCount = WebBLL.Tbl_DesignTaskManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "dealtime desc");
            ProjectList.DataBind();

            //统计结果
            System.Data.DataTable dt = WebBLL.Tbl_DesignTaskManager.GetDataTableByStatistics(strWhere);
            Label1.Text = dt.Rows[0][0].ToString();
            Label2.Text = dt.Rows[0][1].ToString();
            Label3.Text = dt.Rows[0][2].ToString();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }


        protected void ProjectList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView row = (System.Data.DataRowView)e.Item.DataItem;
                int ID = Convert.ToInt32(row["ID"]);
                ////相关统计工日分配
                Label Label4 = (Label)e.Item.FindControl("Label4");
                Label Label5 = (Label)e.Item.FindControl("Label5");
                Label Label6 = (Label)e.Item.FindControl("Label6");
                Label Label7 = (Label)e.Item.FindControl("Label7");

                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                double gugong = Convert.ToDouble(row["DT_GuGong"]);
                double pager3 = Convert.ToDouble(row["PaperNum3"]);
                if (row["Remark"].ToString() == "一级")//四级评审
                {
                    switch(row["CorrectLevel"].ToString())
                    {
                        case "优":
                            num1=gugong*0.8;
                            num2=gugong*0.1;
                            num3=gugong*0.05;
                            num4=gugong*0.05;
                            break;
                        case "良":
                            num1=gugong*0.75;
                            num2=gugong*0.125;
                            num3=gugong*0.075;
                            num4=gugong*0.05;
                            break;
                        case "合格":
                            num1=gugong*0.7;
                            num2=gugong*0.15;
                            num3=gugong*0.1;
                            num4=gugong*0.05;
                            break;
                        case "不合格":
                            num1=gugong*0.6;
                            num2=gugong*0.2;
                            num3=gugong*0.15;
                            num4=gugong*0.05;
                            break;
                    }
                }
                else//三级评审
                {
                    switch (row["CorrectLevel"].ToString())
                    {
                        case "优":
                            num1 = gugong * 0.85;
                            num2 = gugong * 0.1;
                            num3 = gugong * 0.05;
                            break;
                        case "良":
                            num1 = gugong * 0.8;
                            num2 = gugong * 0.125;
                            num3 = gugong * 0.075;
                            break;
                        case "合格":
                            num1 = gugong * 0.75;
                            num2 = gugong * 0.15;
                            num3 = gugong * 0.1;
                            break;
                        case "不合格":
                            num1 = gugong * 0.65;
                            num2 = gugong * 0.2;
                            num3 = gugong * 0.15;
                            break;
                    }
                }
                Label4.Text = (num1 * pager3).ToString("f2");
                Label5.Text = (num2 * pager3).ToString("f2");
                Label6.Text = (num3 * pager3).ToString("f2");
                Label7.Text = (num4 * pager3).ToString("f2");
            }
        }
    }
}