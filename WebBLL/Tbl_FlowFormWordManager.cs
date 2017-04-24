using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_FlowFormWordManager
    {
        public static int AddTbl_FlowFormWord(Tbl_FlowFormWord tbl_flowformword)
        {
            WebCommon.Public.WriteLog("ÃÌº”∂Ã”Ô£∫" + tbl_flowformword.IFW_Name);
            return new Tbl_FlowFormWordService().AddTbl_FlowFormWord(tbl_flowformword);
        }

        public static int UpdateTbl_FlowFormWord(Tbl_FlowFormWord tbl_flowformword)
        {
            WebCommon.Public.WriteLog("–ﬁ∏ƒ∂Ã”Ô£∫" + tbl_flowformword.IFW_Name);
            tbl_flowformword.DealUser = WebCommon.Public.GetUserName();
            tbl_flowformword.DealTime = DateTime.Now;
            return new Tbl_FlowFormWordService().UpdateTbl_FlowFormWordById(tbl_flowformword);
        }

        public static int DeleteTbl_FlowFormWord(int ID)
        {
            WebCommon.Public.WriteLog("…æ≥˝∂Ã”Ô£∫" + ID.ToString());
            return new Tbl_FlowFormWordService().DeleteTbl_FlowFormWordById(ID);
        }

        public static Tbl_FlowFormWord GetTbl_FlowFormWordById(int ID)
        {
            return new Tbl_FlowFormWordService().GetTbl_FlowFormWordById(ID);
        }

        public static IList<Tbl_FlowFormWord> GetTbl_FlowFormWordAll()
        {
            return new Tbl_FlowFormWordService().GetTbl_FlowFormWordAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_FlowFormWordService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_FlowFormWordService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
