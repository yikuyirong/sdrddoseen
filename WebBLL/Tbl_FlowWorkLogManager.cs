using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_FlowWorkLogManager
    {
        public static int AddTbl_FlowWorkLog(Tbl_FlowWorkLog tbl_FlowWorkLog)
        {
            WebCommon.Public.WriteLog("添加设计文件：" + tbl_FlowWorkLog.ProjectID);
            return new Tbl_FlowWorkLogService().AddTbl_FlowWorkLog(tbl_FlowWorkLog);
        }

        public static int UpdateTbl_FlowWorkLog(Tbl_FlowWorkLog tbl_FlowWorkLog)
        {
            WebCommon.Public.WriteLog("修改设计文件：" + tbl_FlowWorkLog.ProjectID);
            tbl_FlowWorkLog.DealUser = WebCommon.Public.GetUserName();
            tbl_FlowWorkLog.DealTime = DateTime.Now;
            return new Tbl_FlowWorkLogService().UpdateTbl_FlowWorkLogById(tbl_FlowWorkLog);
        }

        public static int DeleteTbl_FlowWorkLog(int ID)
        {
            WebCommon.Public.WriteLog("删除设计文件：" + ID.ToString());
            return new Tbl_FlowWorkLogService().DeleteTbl_FlowWorkLogById(ID);
        }

        public static Tbl_FlowWorkLog GetTbl_FlowWorkLogById(int ID)
        {
            return new Tbl_FlowWorkLogService().GetTbl_FlowWorkLogById(ID);
        }

        public static IList<Tbl_FlowWorkLog> GetTbl_FlowWorkLogAll()
        {
            return new Tbl_FlowWorkLogService().GetTbl_FlowWorkLogAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_FlowWorkLogService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_FlowWorkLogService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
