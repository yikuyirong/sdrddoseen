using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectOuterPayManager
    {
        public static int AddTbl_ProjectOuterPay(Tbl_ProjectOuterPay tbl_projectcontractpay)
        {
            WebCommon.Public.WriteLog("添加项目收费：" + tbl_projectcontractpay.ProjectID);
            return new Tbl_ProjectOuterPayService().AddTbl_ProjectOuterPay(tbl_projectcontractpay);
        }

        public static int UpdateTbl_ProjectOuterPay(Tbl_ProjectOuterPay tbl_projectcontractpay)
        {
            WebCommon.Public.WriteLog("修改项目收费：" + tbl_projectcontractpay.ProjectID);
            tbl_projectcontractpay.DealUser = WebCommon.Public.GetUserName();

            tbl_projectcontractpay.DealTime = DateTime.Now;
            return new Tbl_ProjectOuterPayService().UpdateTbl_ProjectOuterPayById(tbl_projectcontractpay);
        }

        public static int DeleteTbl_ProjectOuterPay(int ID)
        {
            WebCommon.Public.WriteLog("删除项目收费：" + ID.ToString());
            return new Tbl_ProjectOuterPayService().DeleteTbl_ProjectOuterPayById(ID);
        }

        public static Tbl_ProjectOuterPay GetTbl_ProjectOuterPayById(int ID)
        {
            return new Tbl_ProjectOuterPayService().GetTbl_ProjectOuterPayById(ID);
        }
        public static IList<Tbl_ProjectOuterPay> GetTbl_ProjectOuterPayProjectID(int ID)
        {
            return new Tbl_ProjectOuterPayService().GetTbl_ProjectOuterPayProjectID(ID);
        }
        public static IList<Tbl_ProjectOuterPay> GetTbl_ProjectOuterPayAll()
        {
            return new Tbl_ProjectOuterPayService().GetTbl_ProjectOuterPayAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectOuterPayService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectOuterPayService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
