using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{

    
    public class Tbl_PageManager
    {
        public static int AddTbl_Page(Tbl_Page tbl_page)
        {
            WebCommon.Public.WriteLog("添加单页："+tbl_page.P_Title);
            return new Tbl_PageService().AddTbl_Page(tbl_page);
        }

        public static int UpdateTbl_Page(Tbl_Page tbl_page)
        {
            WebCommon.Public.WriteLog("修改单页：" + tbl_page.P_Title);
            tbl_page.DealUser = WebCommon.Public.GetUserName();
            tbl_page.DealTime = DateTime.Now;
            return new Tbl_PageService().UpdateTbl_PageById(tbl_page);
        }

        public static int DeleteTbl_Page(int ID)
        {
            WebCommon.Public.WriteLog("删除单页：" + ID.ToString());
            return new Tbl_PageService().DeleteTbl_PageById(ID);
        }

        public static Tbl_Page GetTbl_PageById(int ID)
        {
            return new Tbl_PageService().GetTbl_PageById(ID);
        }

        public static IList<Tbl_Page> GetTbl_PageAll()
        {
            return new Tbl_PageService().GetTbl_PageAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_PageService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_PageService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
