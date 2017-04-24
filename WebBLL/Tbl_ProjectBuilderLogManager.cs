using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectBuilderLogManager
    {
        public static int AddTbl_ProjectBuilderLog(Tbl_ProjectBuilderLog tbl_projectbuilderlog)
        {
            WebCommon.Public.WriteLog("添加施工日志：" + tbl_projectbuilderlog.ProjectID);
            return new Tbl_ProjectBuilderLogService().AddTbl_ProjectBuilderLog(tbl_projectbuilderlog);
        }

        public static int UpdateTbl_ProjectBuilderLog(Tbl_ProjectBuilderLog tbl_projectbuilderlog)
        {
            WebCommon.Public.WriteLog("修改施工日志：" + tbl_projectbuilderlog.ProjectID);
            tbl_projectbuilderlog.DealUser = WebCommon.Public.GetUserName();
            tbl_projectbuilderlog.DealTime = DateTime.Now;
            return new Tbl_ProjectBuilderLogService().UpdateTbl_ProjectBuilderLogById(tbl_projectbuilderlog);
        }

        public static int DeleteTbl_ProjectBuilderLog(int ID)
        {
            WebCommon.Public.WriteLog("删除施工日志：" + ID.ToString());
            return new Tbl_ProjectBuilderLogService().DeleteTbl_ProjectBuilderLogById(ID);
        }

        public static Tbl_ProjectBuilderLog GetTbl_ProjectBuilderLogById(int ID)
        {
            return new Tbl_ProjectBuilderLogService().GetTbl_ProjectBuilderLogById(ID);
        }

        public static IList<Tbl_ProjectBuilderLog> GetTbl_ProjectBuilderLogAll()
        {
            return new Tbl_ProjectBuilderLogService().GetTbl_ProjectBuilderLogAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectBuilderLogService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectBuilderLogService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
