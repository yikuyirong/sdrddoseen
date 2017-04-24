using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{

    
    public class Tbl_GbookManager
    {
        public static int AddTbl_Gbook(Tbl_Gbook tbl_gbook)
        {
            WebCommon.Public.WriteLog("ÃÌº”¡Ù—‘£∫" + tbl_gbook.G_Content);
            return new Tbl_GbookService().AddTbl_Gbook(tbl_gbook);
        }

        public static int UpdateTbl_Gbook(Tbl_Gbook tbl_gbook)
        {
            WebCommon.Public.WriteLog("–ﬁ∏ƒ¡Ù—‘£∫" + tbl_gbook.G_Content);
            tbl_gbook.DealUser = WebCommon.Public.GetUserName();
            tbl_gbook.DealTime = DateTime.Now;
            return new Tbl_GbookService().UpdateTbl_GbookById(tbl_gbook);
        }

        public static int DeleteTbl_Gbook(int ID)
        {
            WebCommon.Public.WriteLog("…æ≥˝¡Ù—‘£∫" + ID.ToString());
            return new Tbl_GbookService().DeleteTbl_GbookById(ID);
        }

        public static Tbl_Gbook GetTbl_GbookById(int ID)
        {
            return new Tbl_GbookService().GetTbl_GbookById(ID);
        }

        public static IList<Tbl_Gbook> GetTbl_GbookAll()
        {
            return new Tbl_GbookService().GetTbl_GbookAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_GbookService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_GbookService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
