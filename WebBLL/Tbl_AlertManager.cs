using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public class Tbl_AlertManager
    {
        public static int AddTbl_Alert(Tbl_Alert tbl_alert)
        {
            return new Tbl_AlertService().AddTbl_Alert(tbl_alert);
        }

        public static int UpdateTbl_Alert(Tbl_Alert tbl_alert)
        {
            tbl_alert.DealUser = WebCommon.Public.GetUserName();
            tbl_alert.DealTime = DateTime.Now;
            return new Tbl_AlertService().UpdateTbl_AlertById(tbl_alert);
        }

        public static int DeleteTbl_Alert(int ID)
        {
            return new Tbl_AlertService().DeleteTbl_AlertById(ID);
        }

        public static Tbl_Alert GetTbl_AlertById(int ID)
        {
            return new Tbl_AlertService().GetTbl_AlertById(ID);
        }

        public static IList<Tbl_Alert> GetTbl_AlertAll()
        {
            return new Tbl_AlertService().GetTbl_AlertAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_AlertService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_AlertService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
