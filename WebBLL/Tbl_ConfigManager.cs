using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{

    
    public class Tbl_ConfigManager
    {
        public static int AddTbl_Config(Tbl_Config tbl_config)
        {
            return new Tbl_ConfigService().AddTbl_Config(tbl_config);
        }

        public static int UpdateTbl_Config(Tbl_Config tbl_config)
        {
            WebCommon.Public.WriteLog("修改系统设置");
            tbl_config.DealUser = WebCommon.Public.GetUserName();
            tbl_config.DealTime = DateTime.Now;
            return new Tbl_ConfigService().UpdateTbl_ConfigById(tbl_config);
        }
        public static int DeleteTbl_Config(int ID)
        {
            return new Tbl_ConfigService().DeleteTbl_ConfigById(ID);
        }

        public static Tbl_Config GetTbl_ConfigById(int ID)
        {
            return new Tbl_ConfigService().GetTbl_ConfigById(ID);
        }

        public static IList<Tbl_Config> GetTbl_ConfigAll()
        {
            return new Tbl_ConfigService().GetTbl_ConfigAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ConfigService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ConfigService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
