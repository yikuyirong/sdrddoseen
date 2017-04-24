using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class FlowWork_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string typeStr = WebCommon.Public.ToString(Request.QueryString["Type"]);
                int ProjectID = WebCommon.Public.ToInt(Request.QueryString["ProjectID"]);
                //如果领导未审撤回
                if (typeStr == "cancel")
                {
                    WebModels.Tbl_Project project=WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ProjectID);
                    project.NodeNo = "项目撤回";
                    project.NodeUser = project.UserName;
                    project.Status = "结束";
                    WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
                    WebCommon.Script.AlertAndGoBack("撤回成功");
                }
                //项目结束并存档
                if (typeStr == "save")
                {
                    int count = 0;
                    int DesignTaskID = 0;// WebCommon.Public.ToInt(WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(1, 1, "ProjectID=" + ProjectID.ToString(), "id desc").Rows[0]["ID"]);
                    foreach (System.Data.DataRow dr in WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(100, 1, "ProjectID=" + ProjectID.ToString(), "id desc").Rows)
                    {
                        DesignTaskID =Convert.ToInt32(dr["ID"]);
                        WebModels.Tbl_DesignTask designtask = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(DesignTaskID);
                        WebModels.Tbl_ProjectArchive archive = new WebModels.Tbl_ProjectArchive();
                        archive.ProjectID = designtask.ProjectID;
                        archive.ClassName1 = designtask.ClassName1;
                        archive.ClassName2 = designtask.ClassName2;
                        archive.ClassName3 = designtask.ClassName3;
                        archive.PA_Type1 = "项目档案";
                        archive.PA_Type2 = "电子版";
                        archive.ParentID = 0;
                        archive.PA_Limit = "普通";
                        archive.PA_Name = designtask.ClassName3;
                        archive.PA_File = WebBLL.Tbl_DesignCorrectManager.GetDataTableByPage(1, 1, "DesignTaskID=" + designtask.ID + " and Tbl_DesignCorrect.status='结束'", "Tbl_DesignCorrect.id desc").Rows[0]["DC_File"].ToString();
                        archive.PA_FileNo = "";
                        archive.PA_Info = "项目流程自动存档";
                        archive.Status = "已审核";
                        archive.DealUser = WebCommon.Public.GetUserName();
                        WebBLL.Tbl_ProjectArchiveManager.AddTbl_ProjectArchive(archive);
                        count++;
                    }
                    if (count > 0)
                    {
                        WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ProjectID);
                        project.Status = "结束";
                        WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
                        WebCommon.Script.AlertAndGoBack("项目自动存档成功");
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("存档失败");
                    }
                }

                //绑定项目工作
                string username = WebCommon.Public.GetUserName();
                //进行中的节点用户或如果是设计工作处理节点的任务工作者
                string whereStr = "status='进行中' and (nodeuser like '%" + username + "%' or (nodeno='设计工作处理' and (select count(*) from tbl_designtask where projectid=tbl_project.id and (dt_shejiren='" + username + "' or dt_jiaoduiren='" + username + "' or dt_shenheren='" + username + "' or dt_shendingren='" + username + "'))>0))";
                Rep_List.DataSource = WebBLL.Tbl_ProjectManager.GetDataTableByPage(30, 1, whereStr, "id desc");
                Rep_List.DataBind();

                //绑定任务工作//按单个任务罗列
                //string strWhere = "status<>'结束' and status<>'任务录入' and status<>'任务审批' and NodeUser like '%" + WebCommon.Public.GetUserName() + "%'";
                //Rep_List2.DataSource = WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(30, 1, strWhere, "id desc");
                //Rep_List2.DataBind();

                //绑定任务工作//按单个项目罗列
                string strWhere = "id in (select projectid from tbl_designtask where status<>'结束' and status<>'任务录入' and status<>'任务审批' and NodeUser like '%" + WebCommon.Public.GetUserName() + "%')";
                Rep_List2.DataSource = WebBLL.Tbl_ProjectManager.GetDataTableByPage(30, 1, strWhere, "");
                Rep_List2.DataBind();
            }
        }

        //判断当前用户是否某个项目的主设并且还没录入卷册任务
        public bool CheckMainDesigner(object projectId)
        {
            int projectid=WebCommon.Public.ToInt(projectId);
            //foreach (WebModels.Tbl_ProjectDesigner pd in WebBLL.Tbl_ProjectDesignerManager.GetTbl_ProjectDesignerByProjectId(projectid))
            //{
            //    if (pd.UserName == WebCommon.Public.GetUserName()) return true;
            //}
            int MyNum = WebBLL.Tbl_DesignTaskManager.GetDataTableByCount("projectid=" + projectid.ToString() + " and status<>'任务录入' and designmain='" + WebCommon.Public.GetUserName() + "'");
            if(MyNum>0)return false;
            return true;
        }

        //判断当前用户是否是设计管理部经理或某个项目的室主任
        public bool CheckLeader(object projectId)
        {
            if (WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set7 == WebCommon.Public.GetUserName()) return true;
            int projectid = WebCommon.Public.ToInt(projectId);
            foreach (WebModels.Tbl_ProjectDesigner pd in WebBLL.Tbl_ProjectDesignerManager.GetTbl_ProjectDesignerByProjectId(projectid))
            {
                //添加室主任为节点人员
                string zhuanyeleader = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='" + pd.ClassName + "'", "").Rows[0]["status"].ToString();
                if (zhuanyeleader == WebCommon.Public.GetUserName()) return true;
            }
            return false;
        }
    }
}