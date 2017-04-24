using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_DesignVersionManager
    {
        public static int AddTbl_DesignVersion(Tbl_DesignVersion tbl_designversion)
        {
            WebCommon.Public.WriteLog("添加设计版本：" + tbl_designversion.DesignTaskID);
            return new Tbl_DesignVersionService().AddTbl_DesignVersion(tbl_designversion);
        }

        public static int UpdateTbl_DesignVersion(Tbl_DesignVersion tbl_designversion)
        {
            WebCommon.Public.WriteLog("修改设计版本：" + tbl_designversion.DesignTaskID);
            tbl_designversion.DealUser = WebCommon.Public.GetUserName();
            tbl_designversion.DealTime = DateTime.Now;
            return new Tbl_DesignVersionService().UpdateTbl_DesignVersionById(tbl_designversion);
        }

        public static int DeleteTbl_DesignVersion(int ID)
        {
            WebCommon.Public.WriteLog("删除设计版本：" + ID.ToString());
            return new Tbl_DesignVersionService().DeleteTbl_DesignVersionById(ID);
        }

        public static Tbl_DesignVersion GetTbl_DesignVersionById(int ID)
        {
            return new Tbl_DesignVersionService().GetTbl_DesignVersionById(ID);
        }

        public static IList<Tbl_DesignVersion> GetTbl_DesignVersionAll()
        {
            return new Tbl_DesignVersionService().GetTbl_DesignVersionAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_DesignVersionService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_DesignVersionService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
