using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_FlowNodeManager
    {
        public static int AddTbl_FlowNode(Tbl_FlowNode tbl_flownode)
        {
            WebCommon.Public.WriteLog("添加节点：" + tbl_flownode.NodeName);
            return new Tbl_FlowNodeService().AddTbl_FlowNode(tbl_flownode);
        }

        public static int UpdateTbl_FlowNode(Tbl_FlowNode tbl_flownode)
        {
            WebCommon.Public.WriteLog("修改节点：" + tbl_flownode.NodeName);
            tbl_flownode.DealUser = WebCommon.Public.GetUserName();
            tbl_flownode.DealTime = DateTime.Now;
            return new Tbl_FlowNodeService().UpdateTbl_FlowNodeById(tbl_flownode);
        }

        public static int DeleteTbl_FlowNode(int ID)
        {
            WebCommon.Public.WriteLog("删除节点：" + ID.ToString());
            return new Tbl_FlowNodeService().DeleteTbl_FlowNodeById(ID);
        }

        public static Tbl_FlowNode GetTbl_FlowNodeById(int ID)
        {
            return new Tbl_FlowNodeService().GetTbl_FlowNodeById(ID);
        }

        public static IList<Tbl_FlowNode> GetTbl_FlowNodesByFlowID(int FlowID)
        {
            return new Tbl_FlowNodeService().GetTbl_FlowNodesByFlowID(FlowID);
        }
        public static IList<Tbl_FlowNode> GetTbl_FlowNodeAll()
        {
            return new Tbl_FlowNodeService().GetTbl_FlowNodeAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_FlowNodeService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_FlowNodeService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
