using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public class Tbl_FlowFormManager
    {
        public static int AddTbl_FlowForm(Tbl_FlowForm tbl_flowform)
        {
            WebCommon.Public.WriteLog("添加表单：" + tbl_flowform.IF_Name);
            return new Tbl_FlowFormService().AddTbl_FlowForm(tbl_flowform);
        }

        public static int UpdateTbl_FlowForm(Tbl_FlowForm tbl_flowform)
        {
            WebCommon.Public.WriteLog("修改表单：" + tbl_flowform.IF_Name);
            tbl_flowform.DealUser = WebCommon.Public.GetUserName();
            tbl_flowform.DealTime = DateTime.Now;
            return new Tbl_FlowFormService().UpdateTbl_FlowFormById(tbl_flowform);
        }

        public static int DeleteTbl_FlowForm(int ID)
        {
            WebCommon.Public.WriteLog("删除表单：" + ID.ToString());
            return new Tbl_FlowFormService().DeleteTbl_FlowFormById(ID);
        }

        public static Tbl_FlowForm GetTbl_FlowFormById(int ID)
        {
            return new Tbl_FlowFormService().GetTbl_FlowFormById(ID);
        }
        public static IList<Tbl_FlowForm> GetTbl_FlowFormByType(string Type)
        {
            return new Tbl_FlowFormService().GetTbl_FlowFormByType(Type);
        }
        
        public static IList<Tbl_FlowForm> GetTbl_FlowFormAll()
        {
            return new Tbl_FlowFormService().GetTbl_FlowFormAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_FlowFormService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_FlowFormService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
