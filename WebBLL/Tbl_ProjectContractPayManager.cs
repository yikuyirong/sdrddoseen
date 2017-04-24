using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectContractPayManager
    {
        public static int AddTbl_ProjectContractPay(Tbl_ProjectContractPay tbl_projectcontractpay)
        {
            WebCommon.Public.WriteLog("添加项目收费：" + tbl_projectcontractpay.ProjectID);
            return new Tbl_ProjectContractPayService().AddTbl_ProjectContractPay(tbl_projectcontractpay);
        }

        public static int UpdateTbl_ProjectContractPay(Tbl_ProjectContractPay tbl_projectcontractpay)
        {
            WebCommon.Public.WriteLog("修改项目收费：" + tbl_projectcontractpay.ProjectID);
            tbl_projectcontractpay.DealUser = WebCommon.Public.GetUserName();
            tbl_projectcontractpay.DealTime = DateTime.Now;
            return new Tbl_ProjectContractPayService().UpdateTbl_ProjectContractPayById(tbl_projectcontractpay);
        }

        public static int DeleteTbl_ProjectContractPay(int ID)
        {
            WebCommon.Public.WriteLog("删除项目收费：" + ID.ToString());
            return new Tbl_ProjectContractPayService().DeleteTbl_ProjectContractPayById(ID);
        }

        public static Tbl_ProjectContractPay GetTbl_ProjectContractPayById(int ID)
        {
            return new Tbl_ProjectContractPayService().GetTbl_ProjectContractPayById(ID);
        }
        public static IList<Tbl_ProjectContractPay> GetTbl_ProjectContractPayProjectID(int ID)
        {
            return new Tbl_ProjectContractPayService().GetTbl_ProjectContractPayProjectID(ID);
        }
        public static IList<Tbl_ProjectContractPay> GetTbl_ProjectContractPayAll()
        {
            return new Tbl_ProjectContractPayService().GetTbl_ProjectContractPayAll();
        }

        public static System.Data.DataTable GetDataTableByStatistics(string Where)
        {
            return new Tbl_ProjectContractPayService().GetDataTableByStatistics(Where);
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectContractPayService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectContractPayService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
