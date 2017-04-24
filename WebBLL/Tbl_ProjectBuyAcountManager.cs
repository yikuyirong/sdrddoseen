using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{


    public static class Tbl_ProjectBuyAcountManager
    {
        public static int AddTbl_ProjectBuyAcount(Tbl_ProjectBuyAcount tbl_projectbuyacount)
        {
            WebCommon.Public.WriteLog("添加采购：" + tbl_projectbuyacount.ProjectID);
            return new Tbl_ProjectBuyAcountService().AddTbl_ProjectBuyAcount(tbl_projectbuyacount);
        }

        public static int UpdateTbl_ProjectBuyAcount(Tbl_ProjectBuyAcount tbl_projectbuyacount)
        {
            WebCommon.Public.WriteLog("修改采购：" + tbl_projectbuyacount.ProjectID);
            tbl_projectbuyacount.DealUser = WebCommon.Public.GetUserName();
            tbl_projectbuyacount.DealTime = DateTime.Now;
            return new Tbl_ProjectBuyAcountService().UpdateTbl_ProjectBuyAcountById(tbl_projectbuyacount);
        }

        public static int DeleteTbl_ProjectBuyAcount(int ID)
        {
            WebCommon.Public.WriteLog("删除采购：" + ID.ToString());
            return new Tbl_ProjectBuyAcountService().DeleteTbl_ProjectBuyAcountById(ID);
        }

        public static Tbl_ProjectBuyAcount GetTbl_ProjectBuyAcountById(int ID)
        {
            return new Tbl_ProjectBuyAcountService().GetTbl_ProjectBuyAcountById(ID);
        }

        public static IList<Tbl_ProjectBuyAcount> GetTbl_ProjectBuyAcountAll()
        {
            return new Tbl_ProjectBuyAcountService().GetTbl_ProjectBuyAcountAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectBuyAcountService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectBuyAcountService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }

    }
}
