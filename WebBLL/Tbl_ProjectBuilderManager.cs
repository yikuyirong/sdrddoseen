using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectBuilderManager
    {
        public static int AddTbl_ProjectBuilder(Tbl_ProjectBuilder tbl_projectbuilder)
        {
            WebCommon.Public.WriteLog("添加施工单位：" + tbl_projectbuilder.POC_Name);
            return new Tbl_ProjectBuilderService().AddTbl_ProjectBuilder(tbl_projectbuilder);
        }

        public static int UpdateTbl_ProjectBuilder(Tbl_ProjectBuilder tbl_projectbuilder)
        {
            WebCommon.Public.WriteLog("修改施工单位：" + tbl_projectbuilder.POC_Name);
            tbl_projectbuilder.DealUser = WebCommon.Public.GetUserName();
            tbl_projectbuilder.DealTime = DateTime.Now;
            return new Tbl_ProjectBuilderService().UpdateTbl_ProjectBuilderById(tbl_projectbuilder);
        }

        public static int DeleteTbl_ProjectBuilder(int ID)
        {
            WebCommon.Public.WriteLog("删除施工单位：" + ID.ToString());
            return new Tbl_ProjectBuilderService().DeleteTbl_ProjectBuilderById(ID);
        }

        public static Tbl_ProjectBuilder GetTbl_ProjectBuilderById(int ID)
        {
            return new Tbl_ProjectBuilderService().GetTbl_ProjectBuilderById(ID);
        }

        public static IList<Tbl_ProjectBuilder> GetTbl_ProjectBuilderAll()
        {
            return new Tbl_ProjectBuilderService().GetTbl_ProjectBuilderAll();
        }
    }
}
