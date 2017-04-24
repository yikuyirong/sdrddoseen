using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{


    public static class Tbl_ProjectBuyContractPayManager
    {
        public static int AddTbl_ProjectBuyContractPay(Tbl_ProjectBuyContractPay tbl_projectbuycontractpay)
        {
            WebCommon.Public.WriteLog("添加收费：" + tbl_projectbuycontractpay.ProjectBuyContractID);
            return new Tbl_ProjectBuyContractPayService().AddTbl_ProjectBuyContractPay(tbl_projectbuycontractpay);
        }

        public static int UpdateTbl_ProjectBuyContractPay(Tbl_ProjectBuyContractPay tbl_projectbuycontractpay)
        {
            WebCommon.Public.WriteLog("修改收费：" + tbl_projectbuycontractpay.ProjectBuyContractID);
            tbl_projectbuycontractpay.DealUser = WebCommon.Public.GetUserName();
            tbl_projectbuycontractpay.DealTime = DateTime.Now;
            return new Tbl_ProjectBuyContractPayService().UpdateTbl_ProjectBuyContractPayById(tbl_projectbuycontractpay);
        }

        public static int DeleteTbl_ProjectBuyContractPay(int ID)
        {
            WebCommon.Public.WriteLog("删除收费：" + ID.ToString());
            return new Tbl_ProjectBuyContractPayService().DeleteTbl_ProjectBuyContractPayById(ID);
        }

        public static Tbl_ProjectBuyContractPay GetTbl_ProjectBuyContractPayById(int ID)
        {
            return new Tbl_ProjectBuyContractPayService().GetTbl_ProjectBuyContractPayById(ID);
        }

        public static IList<Tbl_ProjectBuyContractPay> GetTbl_ProjectBuyContractPayAll()
        {
            return new Tbl_ProjectBuyContractPayService().GetTbl_ProjectBuyContractPayAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectBuyContractPayService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectBuyContractPayService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }

}
