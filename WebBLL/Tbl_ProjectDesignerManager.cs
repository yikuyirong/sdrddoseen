using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{


    public class Tbl_ProjectDesignerManager
    {
        public static int AddTbl_ProjectDesigner(Tbl_ProjectDesigner tbl_projectdesigner)
        {
            WebCommon.Public.WriteLog("添加主设：" + tbl_projectdesigner.UserName);
            return new Tbl_ProjectDesignerService().AddTbl_ProjectDesigner(tbl_projectdesigner);
        }

        public static int UpdateTbl_ProjectDesigner(Tbl_ProjectDesigner tbl_projectdesigner)
        {
            WebCommon.Public.WriteLog("修改主设：" + tbl_projectdesigner.UserName);
            tbl_projectdesigner.DealUser = WebCommon.Public.GetUserName();
            tbl_projectdesigner.DealTime = DateTime.Now;
            return new Tbl_ProjectDesignerService().UpdateTbl_ProjectDesignerById(tbl_projectdesigner);
        }

        public static int DeleteTbl_ProjectDesigner(int ID)
        {
            WebCommon.Public.WriteLog("删除主设：" + ID.ToString());
            return new Tbl_ProjectDesignerService().DeleteTbl_ProjectDesignerById(ID);
        }

        public static Tbl_ProjectDesigner GetTbl_ProjectDesignerById(int ID)
        {
            return new Tbl_ProjectDesignerService().GetTbl_ProjectDesignerById(ID);
        }
        public static IList<Tbl_ProjectDesigner> GetTbl_ProjectDesignerByProjectId(int ProjectID)
        {
            return new Tbl_ProjectDesignerService().GetTbl_ProjectDesignerByProjectId(ProjectID);
        }

        public static IList<Tbl_ProjectDesigner> GetTbl_ProjectDesignerAll()
        {
            return new Tbl_ProjectDesignerService().GetTbl_ProjectDesignerAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectDesignerService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectDesignerService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
