using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectOuterManager
    {
        public static int AddTbl_ProjectOuter(Tbl_ProjectOuter tbl_projectouter)
        {
            WebCommon.Public.WriteLog("添加合作信息：" + tbl_projectouter.PO_Content);
            return new Tbl_ProjectOuterService().AddTbl_ProjectOuter(tbl_projectouter);
        }

        public static int UpdateTbl_ProjectOuter(Tbl_ProjectOuter tbl_projectouter)
        {
            WebCommon.Public.WriteLog("修改合作信息：" + tbl_projectouter.PO_Content);
            tbl_projectouter.DealUser = WebCommon.Public.GetUserName();
            tbl_projectouter.DealTime = DateTime.Now;
            return new Tbl_ProjectOuterService().UpdateTbl_ProjectOuterById(tbl_projectouter);
        }

        public static int DeleteTbl_ProjectOuter(int ID)
        {
            WebCommon.Public.WriteLog("删除外包大项：" + ID.ToString());
            return new Tbl_ProjectOuterService().DeleteTbl_ProjectOuterById(ID);
        }

        public static Tbl_ProjectOuter GetTbl_ProjectOuterById(int ID)
        {
            return new Tbl_ProjectOuterService().GetTbl_ProjectOuterById(ID);
        }
        public static IList<Tbl_ProjectOuter> GetTbl_ProjectOuterAll()
        {
            return new Tbl_ProjectOuterService().GetTbl_ProjectOuterAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectOuterService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectOuterService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
