using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_ProjectArchiveManager
    {
        public static int AddTbl_ProjectArchive(Tbl_ProjectArchive tbl_projectarchive)
        {
            WebCommon.Public.WriteLog("�����Ŀ�浵��" + tbl_projectarchive.PA_Name);
            return new Tbl_ProjectArchiveService().AddTbl_ProjectArchive(tbl_projectarchive);
        }

        public static int UpdateTbl_ProjectArchive(Tbl_ProjectArchive tbl_projectarchive)
        {
            WebCommon.Public.WriteLog("�޸���Ŀ�浵��" + tbl_projectarchive.PA_Name);
            //����������Ϣ
            if (tbl_projectarchive.Status != "δ���")
            {
                WebCommon.Public.WriteAlert(tbl_projectarchive.DealUser, "��Ŀ�浵���", "���ƣ�" + tbl_projectarchive.PA_Name + " �汾��" + tbl_projectarchive.PA_FileNo + " ״̬��" + tbl_projectarchive.Status, "views/alert.aspx");
            }
            tbl_projectarchive.DealUser = WebCommon.Public.GetUserName();
            tbl_projectarchive.DealTime = DateTime.Now;
            return new Tbl_ProjectArchiveService().UpdateTbl_ProjectArchiveById(tbl_projectarchive);
        }

        public static int DeleteTbl_ProjectArchive(int ID)
        {
            WebCommon.Public.WriteLog("ɾ����Ŀ�浵��" + ID.ToString());
            return new Tbl_ProjectArchiveService().DeleteTbl_ProjectArchiveById(ID);
        }

        public static Tbl_ProjectArchive GetTbl_ProjectArchiveById(int ID)
        {
            return new Tbl_ProjectArchiveService().GetTbl_ProjectArchiveById(ID);
        }
        public static IList<Tbl_ProjectArchive> GetTbl_ProjectArchiveParentName(string where)
        {
            return new Tbl_ProjectArchiveService().GetTbl_ProjectArchiveParentName(where);
        }
        public static IList<Tbl_ProjectArchive> GetTbl_ProjectArchiveAll()
        {
            return new Tbl_ProjectArchiveService().GetTbl_ProjectArchiveAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectArchiveService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectArchiveService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
