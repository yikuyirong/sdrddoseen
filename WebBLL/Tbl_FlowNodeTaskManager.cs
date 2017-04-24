using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_FlowNodeTaskManager
    {
        public static int AddTbl_FlowNodeTask(Tbl_FlowNodeTask tbl_flownodetask)
        {
            WebCommon.Public.WriteLog("添加任务：" + tbl_flownodetask.ProjectID);
            return new Tbl_FlowNodeTaskService().AddTbl_FlowNodeTask(tbl_flownodetask);
        }

        public static int UpdateTbl_FlowNodeTask(Tbl_FlowNodeTask tbl_flownodetask)
        {
            WebCommon.Public.WriteLog("修改任务：" + tbl_flownodetask.ProjectID);
            tbl_flownodetask.DealUser = WebCommon.Public.GetUserName();
            tbl_flownodetask.DealTime = DateTime.Now;
            return new Tbl_FlowNodeTaskService().UpdateTbl_FlowNodeTaskById(tbl_flownodetask);
        }

        public static int DeleteTbl_FlowNodeTask(int ID)
        {
            WebCommon.Public.WriteLog("删除任务：" + ID.ToString());
            return new Tbl_FlowNodeTaskService().DeleteTbl_FlowNodeTaskById(ID);
        }

        public static Tbl_FlowNodeTask GetTbl_FlowNodeTaskById(int ID)
        {
            return new Tbl_FlowNodeTaskService().GetTbl_FlowNodeTaskById(ID);
        }

        public static IList<Tbl_FlowNodeTask> GetTbl_FlowNodeTaskAll()
        {
            return new Tbl_FlowNodeTaskService().GetTbl_FlowNodeTaskAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_FlowNodeTaskService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_FlowNodeTaskService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
