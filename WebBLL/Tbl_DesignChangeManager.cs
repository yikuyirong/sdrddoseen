using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_DesignChangeManager
    {
        public static int AddTbl_DesignChange(Tbl_DesignChange tbl_designchange)
        {
            WebCommon.Public.WriteLog("添加项目变更单：" + tbl_designchange.ProjectID);
            return new Tbl_DesignChangeService().AddTbl_DesignChange(tbl_designchange);
        }

        public static int UpdateTbl_DesignChange(Tbl_DesignChange tbl_designchange)
        {
            WebCommon.Public.WriteLog("修改项目变更单：" + tbl_designchange.ProjectID);
            tbl_designchange.DealUser = WebCommon.Public.GetUserName();
            tbl_designchange.DealTime = DateTime.Now;
            return new Tbl_DesignChangeService().UpdateTbl_DesignChangeById(tbl_designchange);
        }

        public static int DeleteTbl_DesignChange(int ID)
        {
            WebCommon.Public.WriteLog("删除项目变更单：" + ID.ToString());
            return new Tbl_DesignChangeService().DeleteTbl_DesignChangeById(ID);
        }

        public static Tbl_DesignChange GetTbl_DesignChangeById(int ID)
        {
            return new Tbl_DesignChangeService().GetTbl_DesignChangeById(ID);
        }

        public static IList<Tbl_DesignChange> GetTbl_DesignChangeAll()
        {
            return new Tbl_DesignChangeService().GetTbl_DesignChangeAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_DesignChangeService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_DesignChangeService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
