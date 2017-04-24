using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectOuterCompanyManager
    {
        public static int AddTbl_ProjectOuterCompany(Tbl_ProjectOuterCompany tbl_projectoutercompany)
        {
            WebCommon.Public.WriteLog("添加外包单位：" + tbl_projectoutercompany.POC_Name);
            return new Tbl_ProjectOuterCompanyService().AddTbl_ProjectOuterCompany(tbl_projectoutercompany);
        }

        public static int UpdateTbl_ProjectOuterCompany(Tbl_ProjectOuterCompany tbl_projectoutercompany)
        {
            WebCommon.Public.WriteLog("修改外包单位：" + tbl_projectoutercompany.POC_Name);
            tbl_projectoutercompany.DealUser = WebCommon.Public.GetUserName();
            tbl_projectoutercompany.DealTime = DateTime.Now;
            return new Tbl_ProjectOuterCompanyService().UpdateTbl_ProjectOuterCompanyById(tbl_projectoutercompany);
        }

        public static int DeleteTbl_ProjectOuterCompany(int ID)
        {
            WebCommon.Public.WriteLog("删除外包单位：" + ID.ToString());
            return new Tbl_ProjectOuterCompanyService().DeleteTbl_ProjectOuterCompanyById(ID);
        }

        public static Tbl_ProjectOuterCompany GetTbl_ProjectOuterCompanyById(int ID)
        {
            return new Tbl_ProjectOuterCompanyService().GetTbl_ProjectOuterCompanyById(ID);
        }
        public static IList<Tbl_ProjectOuterCompany> GetTbl_ProjectOuterCompanyAll()
        {
            return new Tbl_ProjectOuterCompanyService().GetTbl_ProjectOuterCompanyAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectOuterCompanyService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectOuterCompanyService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
