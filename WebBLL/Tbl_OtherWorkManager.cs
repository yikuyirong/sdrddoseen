using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{

    
    public class Tbl_OtherWorkManager
    {
        public static int AddTbl_OtherWork(Tbl_OtherWork tbl_otherwork)
        {
            WebCommon.Public.WriteLog("添加其他工日");
            return new Tbl_OtherWorkService().AddTbl_OtherWork(tbl_otherwork);
        }

        public static int UpdateTbl_OtherWork(Tbl_OtherWork tbl_otherwork)
        {
            WebCommon.Public.WriteLog("修改其他工日");
            return new Tbl_OtherWorkService().UpdateTbl_OtherWorkById(tbl_otherwork);
        }

        public static int DeleteTbl_OtherWork(int ID)
        {
            Tbl_OtherWork tbl_otherwork = GetTbl_OtherWorkById(ID);
            WebCommon.Public.WriteLog("删除其他工日");
            return new Tbl_OtherWorkService().DeleteTbl_OtherWorkById(ID);
        }

        public static Tbl_OtherWork GetTbl_OtherWorkById(int ID)
        {
            return new Tbl_OtherWorkService().GetTbl_OtherWorkById(ID);
        }

        public static IList<Tbl_OtherWork> GetTbl_OtherWorkAll()
        {
            return new Tbl_OtherWorkService().GetTbl_OtherWorkAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_OtherWorkService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableBySum(string Where)
        {
            return new Tbl_OtherWorkService().GetDataTableBySum(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_OtherWorkService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
