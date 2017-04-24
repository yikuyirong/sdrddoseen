using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{

    
    public class Tbl_LogManager
    {
        public static int AddTbl_Log(Tbl_Log tbl_log)
        {
            WebCommon.Public.WriteLog("添加日志：" + tbl_log.LogInfo);
            return new Tbl_LogService().AddTbl_Log(tbl_log);
        }

        public static int UpdateTbl_Log(Tbl_Log tbl_log)
        {
            WebCommon.Public.WriteLog("修改日志：" + tbl_log.LogInfo);
            tbl_log.DealUser = WebCommon.Public.GetUserName();
            tbl_log.DealTime = DateTime.Now;
            return new Tbl_LogService().UpdateTbl_LogById(tbl_log);
        }

        public static int DeleteTbl_Log()
        {
            WebCommon.Public.WriteLog("清空日志");
            return new Tbl_LogService().DeleteTbl_LogById();
        }
        public static int DeleteTbl_Log(int ID)
        {
            WebCommon.Public.WriteLog("删除日志：" + ID.ToString());
            return new Tbl_LogService().DeleteTbl_LogById(ID);
        }

        public static Tbl_Log GetTbl_LogById(int ID)
        {
            return new Tbl_LogService().GetTbl_LogById(ID);
        }

        public static IList<Tbl_Log> GetTbl_LogAll()
        {
            return new Tbl_LogService().GetTbl_LogAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_LogService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_LogService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
