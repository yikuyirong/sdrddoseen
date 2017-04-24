using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_FlowWorkManager
    {
        public static int AddTbl_FlowWork(Tbl_FlowWork tbl_flow)
        {
            WebCommon.Public.WriteLog("添加工作：" + tbl_flow.WorkName);
            return new Tbl_FlowWorkService().AddTbl_FlowWork(tbl_flow);
        }

        public static int UpdateTbl_FlowWork(Tbl_FlowWork tbl_flow)
        {
            WebCommon.Public.WriteLog("修改工作：" + tbl_flow.WorkName);
            //如果节点状态更新项目表的节点信息
            if (tbl_flow.ProjectID > 0)
            {
                WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(tbl_flow.ProjectID);
                if (tbl_flow.Status == "结束")
                {
                    project.NodeNo = "上传合同";
                    project.NodeUser = project.ProjectManager;
                    //project.ProjectNo = "";
                }
                else
                {
                    project.NodeUser = tbl_flow.NodeUser;
                    //project.ProjectNo = "";
                }
                WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            }
            tbl_flow.DealUser = WebCommon.Public.GetUserName();
            tbl_flow.DealTime = DateTime.Now;
            return new Tbl_FlowWorkService().UpdateTbl_FlowWorkById(tbl_flow);
        }

        public static int DeleteTbl_FlowWork(int ID)
        {
            WebCommon.Public.WriteLog("删除工作：" + ID.ToString());
            return new Tbl_FlowWorkService().DeleteTbl_FlowWorkById(ID);
        }

        public static Tbl_FlowWork GetTbl_FlowWorkById(int ID)
        {
            return new Tbl_FlowWorkService().GetTbl_FlowWorkById(ID);
        }

        public static IList<Tbl_FlowWork> GetTbl_FlowWorkType(string Type)
        {
            return new Tbl_FlowWorkService().GetTbl_FlowWorkType(Type);
        }
        public static IList<Tbl_FlowWork> GetTbl_FlowWorkAll()
        {
            return new Tbl_FlowWorkService().GetTbl_FlowWorkAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_FlowWorkService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_FlowWorkService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
