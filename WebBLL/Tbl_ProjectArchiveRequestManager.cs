using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectArchiveRequestManager
    {
        public static int AddTbl_ProjectArchiveRequest(Tbl_ProjectArchiveRequest tbl_projectarchiverequest)
        {
            WebCommon.Public.WriteLog("��ӵ���������" + tbl_projectarchiverequest.ProjectArchiveID);
            //����������Ϣ
            WebCommon.Public.WriteAlert(tbl_projectarchiverequest.NodeUser, tbl_projectarchiverequest.RequestType + "���", "���ݣ�" + tbl_projectarchiverequest.ClassName1 + " " + tbl_projectarchiverequest.ClassName2 + " " + tbl_projectarchiverequest.ClassName3 + " " + tbl_projectarchiverequest.Remark, "views/alert.aspx");
            return new Tbl_ProjectArchiveRequestService().AddTbl_ProjectArchiveRequest(tbl_projectarchiverequest);
        }

        public static int UpdateTbl_ProjectArchiveRequest(Tbl_ProjectArchiveRequest tbl_projectarchiverequest)
        {
            WebCommon.Public.WriteLog("�޸ĵ���������" + tbl_projectarchiverequest.ProjectArchiveID);
            //����������Ϣ
            if (tbl_projectarchiverequest.Status != "δ��")
            {
                WebCommon.Public.WriteAlert(tbl_projectarchiverequest.UserName, tbl_projectarchiverequest.RequestType + "���", "״̬��" + tbl_projectarchiverequest.Status + " " + tbl_projectarchiverequest.Remark, "views/alert.aspx");
            }
            tbl_projectarchiverequest.DealUser = WebCommon.Public.GetUserName();
            tbl_projectarchiverequest.DealTime = DateTime.Now;
            return new Tbl_ProjectArchiveRequestService().UpdateTbl_ProjectArchiveRequestById(tbl_projectarchiverequest);
        }

        public static int DeleteTbl_ProjectArchiveRequest(int ID)
        {
            WebCommon.Public.WriteLog("ɾ������������" + ID.ToString());
            return new Tbl_ProjectArchiveRequestService().DeleteTbl_ProjectArchiveRequestById(ID);
        }

        public static Tbl_ProjectArchiveRequest GetTbl_ProjectArchiveRequestById(int ID)
        {
            return new Tbl_ProjectArchiveRequestService().GetTbl_ProjectArchiveRequestById(ID);
        }

        public static IList<Tbl_ProjectArchiveRequest> GetTbl_ProjectArchiveRequestAll()
        {
            return new Tbl_ProjectArchiveRequestService().GetTbl_ProjectArchiveRequestAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectArchiveRequestService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectArchiveRequestService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
