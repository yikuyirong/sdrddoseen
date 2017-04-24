using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{

    
    public class Tbl_PlanManageManager
    {
        public static int AddTbl_PlanManage(Tbl_PlanManage tbl_planmanage)
        {
            WebCommon.Public.WriteLog("添加计划进度");
            return new Tbl_PlanManageService().AddTbl_PlanManage(tbl_planmanage);
        }

        public static int UpdateTbl_PlanManage(Tbl_PlanManage tbl_planmanage)
        {
            WebCommon.Public.WriteLog("修改计划进度");
            return new Tbl_PlanManageService().UpdateTbl_PlanManageById(tbl_planmanage);
        }

        public static int DeleteTbl_PlanManage(int ID)
        {
            Tbl_PlanManage tbl_planmanage = GetTbl_PlanManageById(ID);
            WebCommon.Public.WriteLog("删除计划进度");
            return new Tbl_PlanManageService().DeleteTbl_PlanManageById(ID);
        }

        public static Tbl_PlanManage GetTbl_PlanManageById(int ID)
        {
            return new Tbl_PlanManageService().GetTbl_PlanManageById(ID);
        }

        public static IList<Tbl_PlanManage> GetTbl_PlanManageAll()
        {
            return new Tbl_PlanManageService().GetTbl_PlanManageAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_PlanManageService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_PlanManageService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
