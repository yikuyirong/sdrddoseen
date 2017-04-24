using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignTask_list2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //会签发送
                string pddesigner = WebCommon.Public.ToString(Request.QueryString["Designer"]);
                int DesignTaskID = WebCommon.Public.ToInt(Request.QueryString["ID"]);
                if (pddesigner != "")
                {
                    //转入审定
                    if (pddesigner == "审核")
                    {
                        WebModels.Tbl_DesignTask Task = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(DesignTaskID);
                        Task.Status = "等待审核";
                        if (Task.DT_ShenHeRen != "")
                        {
                            Task.NodeUser = Task.DT_ShenHeRen;
                            WebBLL.Tbl_DesignTaskManager.UpdateTbl_DesignTask(Task);

                            WebCommon.Public.DataTableUpdate("tbl_designcorrect", "NodeUser='" + Task.DT_ShenHeRen + "',status='等待审核'", "designtaskid=" + DesignTaskID.ToString() + "");

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('转入审核成功');location.href='" + WebCommon.Public.GetFromUrl() + "';", true);
                            return;
                        }
                        else//没有审定人的话就结束任务并存档
                        {
                            Task.Status="结束";
                            WebBLL.Tbl_DesignTaskManager.UpdateTbl_DesignTask(Task);
                            WebCommon.Public.DataTableUpdate("tbl_designcorrect", "status='结束'", "designtaskid="+DesignTaskID.ToString());
                            WebModels.Tbl_ProjectArchive archive = new WebModels.Tbl_ProjectArchive();
                            archive.ProjectID = Task.ProjectID;
                            archive.ClassName1 = Task.ClassName1;
                            archive.ClassName2 = Task.ClassName2;
                            archive.ClassName3 = Task.ClassName3;
                            archive.PA_Type1 = "项目档案";
                            archive.PA_Type2 = "电子版";
                            archive.ParentID = 0;
                            archive.PA_Limit = "普通";
                            archive.PA_Name = Task.ClassName3;
                            archive.PA_File = WebBLL.Tbl_DesignCorrectManager.GetDataTableByPage(1, 1, "DesignTaskID=" + Task.ID + " and Tbl_DesignCorrect.status='结束'", "Tbl_DesignCorrect.id desc").Rows[0]["DC_File"].ToString();
                            archive.PA_FileNo = "";
                            archive.PA_Info = "项目流程自动存档";
                            archive.Status = "已审核";
                            archive.DealUser = WebCommon.Public.GetUserName();
                            WebBLL.Tbl_ProjectArchiveManager.AddTbl_ProjectArchive(archive);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('没有审定人任务直接结束并存档成功');location.href='" + WebCommon.Public.GetFromUrl() + "';", true);
                            return;
                        }
                    }
                    else
                    {
                        //正常会签
                        //务必把NodeUserLast清空由此服务器端判断那个会签人不通过好下次修改设计直接返回会签人
                        WebCommon.Public.DataTableUpdate("tbl_designtask", "NodeUserLast='',NodeUser='" + pddesigner + "'", "id=" + DesignTaskID.ToString());
                        WebCommon.Public.DataTableUpdate("tbl_designcorrect", "NodeUser='" + pddesigner + "'", "designtaskid=" + DesignTaskID.ToString() + " and status='等待会签'");

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('发送会签成功');location.href='"+WebCommon.Public.GetFromUrl()+"';", true);
                        return;
                    }
                }

                //开始设计生成设计文件和属性文件
                if (WebCommon.Public.ToString(Request.QueryString["type"]) == "开始设计")
                {
                    int taskId = Convert.ToInt32(Request.QueryString["taskid"]);
                    WebModels.Tbl_DesignTask designtask = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(taskId);

                    //生成上传文件名
                    string RndName = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTasFileNamekByTaskId(taskId);

                    //获取专业编号
                    string ClassNo = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='"+designtask.ClassName1+"'", "").Rows[0]["remark"].ToString();

                    //获取项目资料生成属性
                    WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(designtask.ProjectID);
            
                    //生成属性文件
                    string folderpathStr = "/project/" + project.ProjectNo + "/" + ClassNo + "/" + designtask.DT_TuHao;
                    string folderPath = System.Web.HttpContext.Current.Server.MapPath(folderpathStr);
                    if (!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);
                    string path = folderPath + "\\" + RndName + " - 属性.txt";
                    if (!System.IO.File.Exists(path)) System.IO.File.Create(path).Close();
                    System.Text.StringBuilder strBuilderErrorMessage = new System.Text.StringBuilder();
                    strBuilderErrorMessage.Append("工程名称：" + project.ProjectName + "\r\n");
                    strBuilderErrorMessage.Append("图纸名称：请手动输入\r\n");
                    strBuilderErrorMessage.Append("卷册检索号：" + designtask.ProjectNo +"|"+designtask.DT_TuHao + "\r\n");
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
                    string serverUrl = folderpathStr + "/" + RndName + " - 属性.txt|" + WebCommon.Public.Get_BlankFilePath;
                    string SaveUrl = folderpathStr + "/" + RndName + " - 属性.txt|" + folderpathStr + "/" + RndName + " - 设计.dwg";
                    //下载属性文件和空白CAD文件
                    //WebCommon.Script.ResponseScript("alert('" + serverUrl + "  " + SaveUrl + "')");
                    WebCommon.Script.ResponseScript("window.external.download('" + serverUrl + "','" + SaveUrl + "',true)");
                    //WebCommon.Script.GoBack();
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

                //绑定会签人员
                WebBLL.Tbl_UserManager.GetUsersByDropDownList(Designer);
                Designer.Items.Insert(0, new ListItem("选择会签人员", ""));
            }
        }

        protected string status = "";
        public void Bind()
        {
            string projectid = WebCommon.Public.ToString(Request.QueryString["ProjectID"]);
            string wherePlus="1=1";
            if (projectid != "") wherePlus += " and projectid=" + projectid;
            //string status = WebCommon.Public.ToString(Request.QueryString["Status"]);
            if (status != "") wherePlus += " and status='" + status + "'";
            string strWhere = wherePlus+" and (NodeUser like '%" + WebCommon.Public.GetUserName() + "%' or DT_SheJiRen='" + WebCommon.Public.GetUserName() + "' or DT_JiaoDuiRen='" + WebCommon.Public.GetUserName() + "' or DT_ShenHeRen='" + WebCommon.Public.GetUserName() + "' or DT_ShenDingRen='" + WebCommon.Public.GetUserName() + "')";

            string where = WebCommon.Public.ToString(Request.QueryString["where"]);
            if (where != "") strWhere += " and (" + where + ")";

            
            //分页设置
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = WebBLL.Tbl_DesignTaskManager.GetDataTableByCount(strWhere);

            //绑定分页数据
            ProjectList.DataSource = WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere, "id desc");
            ProjectList.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }


        protected void ProjectList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //System.Data.DataRowView row = (System.Data.DataRowView)e.Item.DataItem;
                //int ID = Convert.ToInt32(row["ID"]);
                ////相关文件
                //Repeater history = (Repeater)e.Item.FindControl("Repeater1");
                //history.DataSource = WebBLL.Tbl_FlowWorkLogManager.GetDataTableByPage(50, 1, "id=" + ID.ToString() + " or parentid=" + ID.ToString(), "id asc");
                //history.DataBind();
            }
        }

        protected void Status1_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = Status1.SelectedItem.Value;
            if (Status1.SelectedItem.Value == "") status = "";
            Bind();
        }
    }
}