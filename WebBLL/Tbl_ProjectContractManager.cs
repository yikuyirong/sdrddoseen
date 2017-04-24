using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{


    public static class Tbl_ProjectContractManager
    {
        public static int AddTbl_ProjectContract(Tbl_ProjectContract tbl_projectcontract)
        {
            WebCommon.Public.WriteLog("添加合同：" + tbl_projectcontract.ProjectID);
            int count= new Tbl_ProjectContractService().AddTbl_ProjectContract(tbl_projectcontract);
            if (count > 0)
            {
                //添加合同成功的时候更新项目的节点信息
                WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(tbl_projectcontract.ProjectID);
                project.ProjectNo = tbl_projectcontract.PC_Name;//生成项目编号
                project.NodeNo = "确认设总";
                project.NodeUser = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set5;//技术副院长
                WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            }
            return count;
        }

        public static int UpdateTbl_ProjectContract(Tbl_ProjectContract tbl_projectcontract)
        {
            WebCommon.Public.WriteLog("修改合同：" + tbl_projectcontract.ProjectID);
            tbl_projectcontract.DealUser = WebCommon.Public.GetUserName();
            tbl_projectcontract.DealTime = DateTime.Now;
            return new Tbl_ProjectContractService().UpdateTbl_ProjectContractById(tbl_projectcontract);
        }

        public static int DeleteTbl_ProjectContract(int ID)
        {
            WebCommon.Public.WriteLog("删除合同：" + ID.ToString());
            return new Tbl_ProjectContractService().DeleteTbl_ProjectContractById(ID);
        }

        public static Tbl_ProjectContract GetTbl_ProjectContractById(int ID)
        {
            return new Tbl_ProjectContractService().GetTbl_ProjectContractById(ID);
        }

        public static IList<Tbl_ProjectContract> GetTbl_ProjectContractProjectID(int ID)
        {
            return new Tbl_ProjectContractService().GetTbl_ProjectContractProjectID(ID);
        }
        public static IList<Tbl_ProjectContract> GetTbl_ProjectContractAll()
        {
            return new Tbl_ProjectContractService().GetTbl_ProjectContractAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectContractService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectContractService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
