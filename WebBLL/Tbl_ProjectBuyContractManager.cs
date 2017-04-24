using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectBuyContractManager
    {
        public static int AddTbl_ProjectBuyContract(Tbl_ProjectBuyContract tbl_projectbuycontract)
        {
            WebCommon.Public.WriteLog("添加合同：" + tbl_projectbuycontract.PBC_Company);
            return new Tbl_ProjectBuyContractService().AddTbl_ProjectBuyContract(tbl_projectbuycontract);
        }

        public static int UpdateTbl_ProjectBuyContract(Tbl_ProjectBuyContract tbl_projectbuycontract)
        {
            WebCommon.Public.WriteLog("修改合同：" + tbl_projectbuycontract.PBC_Company);
            tbl_projectbuycontract.DealUser = WebCommon.Public.GetUserName();
            tbl_projectbuycontract.DealTime = DateTime.Now;
            return new Tbl_ProjectBuyContractService().UpdateTbl_ProjectBuyContractById(tbl_projectbuycontract);
        }

        public static int DeleteTbl_ProjectBuyContract(int ID)
        {
            WebCommon.Public.WriteLog("删除合同：" + ID.ToString());
            return new Tbl_ProjectBuyContractService().DeleteTbl_ProjectBuyContractById(ID);
        }

        public static Tbl_ProjectBuyContract GetTbl_ProjectBuyContractById(int ID)
        {
            return new Tbl_ProjectBuyContractService().GetTbl_ProjectBuyContractById(ID);
        }

        public static IList<Tbl_ProjectBuyContract> GetTbl_ProjectBuyContractAll()
        {
            return new Tbl_ProjectBuyContractService().GetTbl_ProjectBuyContractAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectBuyContractService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectBuyContractService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
