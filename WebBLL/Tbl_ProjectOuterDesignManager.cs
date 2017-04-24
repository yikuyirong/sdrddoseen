using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectOuterDesignManager
    {
        public static int AddTbl_ProjectOuterDesign(Tbl_ProjectOuterDesign tbl_projectouterdesign)
        {
            WebCommon.Public.WriteLog("添加设计外包：" + tbl_projectouterdesign.PO_Content);
            return new Tbl_ProjectOuterDesignService().AddTbl_ProjectOuterDesign(tbl_projectouterdesign);
        }

        public static int UpdateTbl_ProjectOuterDesign(Tbl_ProjectOuterDesign tbl_projectouterdesign)
        {
            WebCommon.Public.WriteLog("修改设计外包：" + tbl_projectouterdesign.PO_Content);
            tbl_projectouterdesign.DealUser = WebCommon.Public.GetUserName();
            tbl_projectouterdesign.DealTime = DateTime.Now;
            return new Tbl_ProjectOuterDesignService().UpdateTbl_ProjectOuterDesignById(tbl_projectouterdesign);
        }

        public static int DeleteTbl_ProjectOuterDesign(int ID)
        {
            WebCommon.Public.WriteLog("删除设计外包：" + ID.ToString());
            return new Tbl_ProjectOuterDesignService().DeleteTbl_ProjectOuterDesignById(ID);
        }

        public static Tbl_ProjectOuterDesign GetTbl_ProjectOuterDesignById(int ID)
        {
            return new Tbl_ProjectOuterDesignService().GetTbl_ProjectOuterDesignById(ID);
        }

        public static IList<Tbl_ProjectOuterDesign> GetTbl_ProjectOuterDesignAll()
        {
            return new Tbl_ProjectOuterDesignService().GetTbl_ProjectOuterDesignAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectOuterDesignService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectOuterDesignService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
