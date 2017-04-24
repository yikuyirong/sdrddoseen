using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectBidManager
    {
        public static int AddTbl_ProjectBid(Tbl_ProjectBid tbl_projectbid)
        {
            WebCommon.Public.WriteLog("添加客户信息：" + tbl_projectbid.PB_Name);
            return new Tbl_ProjectBidService().AddTbl_ProjectBid(tbl_projectbid);
        }

        public static int UpdateTbl_ProjectBid(Tbl_ProjectBid tbl_projectbid)
        {
            WebCommon.Public.WriteLog("修改客户信息：" + tbl_projectbid.PB_Name);
            tbl_projectbid.DealUser = WebCommon.Public.GetUserName();
            tbl_projectbid.DealTime = DateTime.Now;
            return new Tbl_ProjectBidService().UpdateTbl_ProjectBidById(tbl_projectbid);
        }

        public static int DeleteTbl_ProjectBid(int ID)
        {
            WebCommon.Public.WriteLog("删除客户信息：" + ID.ToString());
            return new Tbl_ProjectBidService().DeleteTbl_ProjectBidById(ID);
        }

        public static Tbl_ProjectBid GetTbl_ProjectBidById(int ID)
        {
            return new Tbl_ProjectBidService().GetTbl_ProjectBidById(ID);
        }

        public static IList<Tbl_ProjectBid> GetTbl_ProjectBidAll()
        {
            return new Tbl_ProjectBidService().GetTbl_ProjectBidAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectBidService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectBidService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
