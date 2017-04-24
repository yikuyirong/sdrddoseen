using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public class Tbl_ProjectBuilderContractPayManager
    {
        public int AddTbl_ProjectBuilderContractPay(Tbl_ProjectBuilderContractPay tbl_projectbuildercontractpay)
        {
            WebCommon.Public.WriteLog("���ʩ���շѣ�" + tbl_projectbuildercontractpay.ProjectBuilderContractID);
            return new Tbl_ProjectBuilderContractPayService().AddTbl_ProjectBuilderContractPay(tbl_projectbuildercontractpay);
        }

        public int UpdateTbl_ProjectBuilderContractPay(Tbl_ProjectBuilderContractPay tbl_projectbuildercontractpay)
        {
            WebCommon.Public.WriteLog("�޸�ʩ���շѣ�" + tbl_projectbuildercontractpay.ProjectBuilderContractID);
            tbl_projectbuildercontractpay.DealUser = WebCommon.Public.GetUserName();
            tbl_projectbuildercontractpay.DealTime = DateTime.Now;
            return new Tbl_ProjectBuilderContractPayService().UpdateTbl_ProjectBuilderContractPayById(tbl_projectbuildercontractpay);
        }

        public int DeleteTbl_ProjectBuilderContractPay(int ID)
        {
            WebCommon.Public.WriteLog("ɾ��ʩ���շѣ�" + ID.ToString());
            return new Tbl_ProjectBuilderContractPayService().DeleteTbl_ProjectBuilderContractPayById(ID);
        }

        public Tbl_ProjectBuilderContractPay GetTbl_ProjectBuilderContractPayById(int ID)
        {
            return new Tbl_ProjectBuilderContractPayService().GetTbl_ProjectBuilderContractPayById(ID);
        }

        public IList<Tbl_ProjectBuilderContractPay> GetTbl_ProjectBuilderContractPayAll()
        {
            return new Tbl_ProjectBuilderContractPayService().GetTbl_ProjectBuilderContractPayAll();
        }
    }
}
