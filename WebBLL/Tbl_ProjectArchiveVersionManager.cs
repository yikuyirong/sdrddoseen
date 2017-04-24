using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public class Tbl_ProjectArchiveVersionManager
    {
        public static int AddTbl_ProjectArchiveVersion(Tbl_ProjectArchiveVersion tbl_projectarchiveversion)
        {
            WebCommon.Public.WriteLog("添加版本：" + tbl_projectarchiveversion.PAV_Info);
            return new Tbl_ProjectArchiveVersionService().AddTbl_ProjectArchiveVersion(tbl_projectarchiveversion);
        }

        public static int UpdateTbl_ProjectArchiveVersion(Tbl_ProjectArchiveVersion tbl_projectarchiveversion)
        {
            WebCommon.Public.WriteLog("修改版本：" + tbl_projectarchiveversion.PAV_Info);
            tbl_projectarchiveversion.DealUser = WebCommon.Public.GetUserName();
            tbl_projectarchiveversion.DealTime = DateTime.Now;
            return new Tbl_ProjectArchiveVersionService().UpdateTbl_ProjectArchiveVersionById(tbl_projectarchiveversion);
        }

        public static int DeleteTbl_ProjectArchiveVersion(int ID)
        {
            WebCommon.Public.WriteLog("删除版本：" + ID.ToString());
            return new Tbl_ProjectArchiveVersionService().DeleteTbl_ProjectArchiveVersionById(ID);
        }

        public static Tbl_ProjectArchiveVersion GetTbl_ProjectArchiveVersionById(int ID)
        {
            return new Tbl_ProjectArchiveVersionService().GetTbl_ProjectArchiveVersionById(ID);
        }

        public static IList<Tbl_ProjectArchiveVersion> GetTbl_ProjectArchiveVersionAll()
        {
            return new Tbl_ProjectArchiveVersionService().GetTbl_ProjectArchiveVersionAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectArchiveVersionService().GetDataTableByCount(Where);
        }
        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectArchiveVersionService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
