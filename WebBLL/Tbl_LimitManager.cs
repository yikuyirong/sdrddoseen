using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{
    
    public class Tbl_LimitManager
    {
        public static int AddTbl_Limit(Tbl_Limit tbl_limit)
        {
            WebCommon.Public.WriteLog("添加角色：" + tbl_limit.LimitName);
            return new Tbl_LimitService().AddTbl_Limit(tbl_limit);
        }

        public static int UpdateTbl_Limit(Tbl_Limit tbl_limit)
        {
            //WebBLL.Tbl_AdminManager.UpdateTbl_AdminLimitName(WebBLL.Tbl_LimitManager.GetTbl_LimitById(tbl_limit.ID).LimitName, tbl_limit.LimitName);
            //WebCommon.Public.WriteLog("修改角色：" + tbl_limit.LimitName);
            tbl_limit.DealUser = WebCommon.Public.GetUserName();
            tbl_limit.DealTime = DateTime.Now;
            return new Tbl_LimitService().UpdateTbl_LimitById(tbl_limit);
        }

        public static int DeleteTbl_Limit(int ID)
        {
            WebCommon.Public.WriteLog("删除角色：" + ID.ToString());
            return new Tbl_LimitService().DeleteTbl_LimitById(ID);
        }

        public static Tbl_Limit GetTbl_LimitById(int ID)
        {
            return new Tbl_LimitService().GetTbl_LimitById(ID);
        }

        public static string GetTbl_LimitByUserName(string UserName)
        {
            try
            {
                DataTable dt = new Tbl_LimitService().GetDataTableByPage(1, 1, "LimitName=(select top 1 LimitID from tbl_user where username='" + UserName + "')", "id desc");
                return dt.Rows[0]["LimitInfo"].ToString();
            }
            catch
            {
                return "";
            }
        }

        public static IList<Tbl_Limit> GetTbl_LimitAll()
        {
            return new Tbl_LimitService().GetTbl_LimitAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_LimitService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_LimitService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
