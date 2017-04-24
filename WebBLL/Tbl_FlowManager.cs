using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_FlowManager
    {
        public static int AddTbl_Flow(Tbl_Flow tbl_flow)
        {
            WebCommon.Public.WriteLog("添加流程：" + tbl_flow.FlowName);
            return new Tbl_FlowService().AddTbl_Flow(tbl_flow);
        }

        public static int UpdateTbl_Flow(Tbl_Flow tbl_flow)
        {
            WebCommon.Public.WriteLog("修改流程：" + tbl_flow.FlowName);
            tbl_flow.DealUser = WebCommon.Public.GetUserName();
            tbl_flow.DealTime = DateTime.Now;
            return new Tbl_FlowService().UpdateTbl_FlowById(tbl_flow);
        }

        public static int DeleteTbl_Flow(int ID)
        {
            WebCommon.Public.WriteLog("删除流程：" + ID.ToString());
            return new Tbl_FlowService().DeleteTbl_FlowById(ID);
        }

        public static Tbl_Flow GetTbl_FlowById(int ID)
        {
            return new Tbl_FlowService().GetTbl_FlowById(ID);
        }

        public static IList<Tbl_Flow> GetTbl_FlowType(string Type)
        {
            return new Tbl_FlowService().GetTbl_FlowType(Type);
        }
        public static IList<Tbl_Flow> GetTbl_FlowAll()
        {
            return new Tbl_FlowService().GetTbl_FlowAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_FlowService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_FlowService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
