using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_DesignCorrectManager
    {
        public static int AddTbl_DesignCorrect(Tbl_DesignCorrect tbl_designcorrect)
        {
            WebCommon.Public.WriteLog("添加设计文件：" + tbl_designcorrect.DC_File);
            return new Tbl_DesignCorrectService().AddTbl_DesignCorrect(tbl_designcorrect);
        }

        public static int UpdateTbl_DesignCorrect(Tbl_DesignCorrect tbl_designcorrect)
        {
            WebCommon.Public.WriteLog("修改设计文件：" + tbl_designcorrect.DesignTaskID.ToString());
            tbl_designcorrect.DealUser = WebCommon.Public.GetUserName();
            tbl_designcorrect.DealTime = DateTime.Now;
            return new Tbl_DesignCorrectService().UpdateTbl_DesignCorrectById(tbl_designcorrect);
        }

        public static int DeleteTbl_DesignCorrect(int ID)
        {
            WebCommon.Public.WriteLog("删除设计文件：" + ID.ToString());
            return new Tbl_DesignCorrectService().DeleteTbl_DesignCorrectById(ID);
        }

        public static Tbl_DesignCorrect GetTbl_DesignCorrectById(int ID)
        {
            return new Tbl_DesignCorrectService().GetTbl_DesignCorrectById(ID);
        }

        public static IList<Tbl_DesignCorrect> GetTbl_DesignCorrectAll()
        {
            return new Tbl_DesignCorrectService().GetTbl_DesignCorrectAll();
        }
        public static System.Data.DataTable GetDataTableByStatistics(string Where)
        {
            return new Tbl_DesignCorrectService().GetDataTableByStatistics(Where);
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_DesignCorrectService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_DesignCorrectService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
