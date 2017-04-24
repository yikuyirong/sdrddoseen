using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{


    public static class Tbl_ProjectBuilderContractManager
    {
        public static int AddTbl_ProjectBuilderContract(Tbl_ProjectBuilderContract tbl_projectbuildercontract)
        {
            WebCommon.Public.WriteLog("添加施工合同：" + tbl_projectbuildercontract.ProjectID);
            return new Tbl_ProjectBuilderContractService().AddTbl_ProjectBuilderContract(tbl_projectbuildercontract);
        }

        public static int UpdateTbl_ProjectBuilderContract(Tbl_ProjectBuilderContract tbl_projectbuildercontract)
        {
            WebCommon.Public.WriteLog("修改施工合同：" + tbl_projectbuildercontract.ProjectID);
            tbl_projectbuildercontract.DealUser = WebCommon.Public.GetUserName();
            tbl_projectbuildercontract.DealTime = DateTime.Now;
            return new Tbl_ProjectBuilderContractService().UpdateTbl_ProjectBuilderContractById(tbl_projectbuildercontract);
        }

        public static int DeleteTbl_ProjectBuilderContract(int ID)
        {
            WebCommon.Public.WriteLog("删除施工合同：" + ID.ToString());
            return new Tbl_ProjectBuilderContractService().DeleteTbl_ProjectBuilderContractById(ID);
        }

        public static Tbl_ProjectBuilderContract GetTbl_ProjectBuilderContractById(int ID)
        {
            return new Tbl_ProjectBuilderContractService().GetTbl_ProjectBuilderContractById(ID);
        }

        public static IList<Tbl_ProjectBuilderContract> GetTbl_ProjectBuilderContractAll()
        {
            return new Tbl_ProjectBuilderContractService().GetTbl_ProjectBuilderContractAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectBuilderContractService().GetDataTableByCount(Where);
        }
        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectBuilderContractService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }

    }
}
