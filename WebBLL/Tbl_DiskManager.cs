using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{
    public class Tbl_DiskManager
    {
        public static int AddTbl_Disk(Tbl_Disk tbl_disk)
        {
            WebCommon.Public.WriteLog("添加共享资源");
            return new Tbl_DiskService().AddTbl_Disk(tbl_disk);
        }

        public static int UpdateTbl_Disk(Tbl_Disk tbl_disk)
        {
            WebCommon.Public.WriteLog("修改共享资源");
            return new Tbl_DiskService().UpdateTbl_DiskById(tbl_disk);
        }

        public static int DeleteTbl_Disk(int ID)
        {
            WebCommon.Public.WriteLog("删除共享资源"); 
            return new Tbl_DiskService().DeleteTbl_DiskById(ID);
        }

        public static Tbl_Disk GetTbl_DiskById(int ID)
        {
            return new Tbl_DiskService().GetTbl_DiskById(ID);
        }

        public static IList<Tbl_Disk> GetTbl_DiskAll()
        {
            return new Tbl_DiskService().GetTbl_DiskAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_DiskService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_DiskService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
