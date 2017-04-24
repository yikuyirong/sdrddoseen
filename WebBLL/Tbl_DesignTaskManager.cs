using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;
using System.Web.UI.WebControls;

namespace WebBLL
{


    public static class Tbl_DesignTaskManager
    {
        public static int AddTbl_DesignTask(Tbl_DesignTask tbl_designtask)
        {
            WebCommon.Public.WriteLog("添加卷册任务：" + tbl_designtask.ClassName1 + " " + tbl_designtask.ClassName2 + " " + tbl_designtask.ClassName3);
            return new Tbl_DesignTaskService().AddTbl_DesignTask(tbl_designtask);
        }

        public static int UpdateTbl_DesignTask(Tbl_DesignTask tbl_designtask)
        {
            WebCommon.Public.WriteLog("修改卷册任务：" + tbl_designtask.ClassName1 + " " + tbl_designtask.ClassName2 + " " + tbl_designtask.ClassName3);
            tbl_designtask.DealUser = WebCommon.Public.GetUserName();
            tbl_designtask.DealTime = DateTime.Now;
            return new Tbl_DesignTaskService().UpdateTbl_DesignTaskById(tbl_designtask);
        }

        public static string GetTbl_DesignTasFileNamekByTaskId(int TaskID)
        {
            //根据任务ID生成文件名
            WebModels.Tbl_DesignTask designtask = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(TaskID);
            //int RndNum = WebBLL.Tbl_DesignCorrectManager.GetDataTableByCount("DesignTaskID=" + TaskID.ToString()) + 1;
            //string ClassCode = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='" + designtask.ClassName1.ToString() + "'", "").Rows[0]["Remark"].ToString();
            string RndName = designtask.ProjectNo.ToString().Trim() + "-" + designtask.DT_TuHao.ToString().Trim();// +"-" + RndNum.ToString();
            return RndName;
        }

        public static string GetTbl_DesignTasFileFullNamekByTaskId(int TaskID)
        {
            //根据任务ID生成文件名
            WebModels.Tbl_DesignTask designtask = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(TaskID);
            //生成上传文件名
            string RndName = designtask.ProjectNo.ToString() + "-" + designtask.DT_TuHao.ToString();// +"-" + RndNum.ToString();
            
            //获取专业编号
            string ClassNo = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='" + designtask.ClassName1 + "'", "").Rows[0]["remark"].ToString();

            //获取项目资料生成属性
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(designtask.ProjectID);

            //生成属性文件
            string folderpathStr = "../project/" + project.ProjectNo.Trim() + "/" + ClassNo.Trim() + "/" + designtask.DT_TuHao.Trim();
            string folderPath = System.Web.HttpContext.Current.Server.MapPath(folderpathStr);
            if (!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);
            return folderpathStr + "/" + RndName;
        }

        public static Tbl_DesignTask GetTbl_DesignTaskById(int ID)
        {
            return new Tbl_DesignTaskService().GetTbl_DesignTaskById(ID);
        }

        public static IList<Tbl_DesignTask> GetTbl_DesignTaskAll()
        {
            return new Tbl_DesignTaskService().GetTbl_DesignTaskAll();
        }

        public static IList<Tbl_DesignTask> GetTbl_DesignTaskByProjectID(int ParentID)
        {
            return new Tbl_DesignTaskService().GetTbl_DesignTaskByProjectID(ParentID);
        }
        public static System.Data.DataTable GetDataTableByStatistics(string Where)
        {
            return new Tbl_DesignTaskService().GetDataTableByStatistics(Where);
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_DesignTaskService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_DesignTaskService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }   
    }
}
