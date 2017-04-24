using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;
namespace WebBLL
{


    public static class Tbl_ProjectDocumentManager
    {
        public static int AddTbl_ProjectDocument(Tbl_ProjectDocument tbl_projectdocument)
        {
            WebCommon.Public.WriteLog("����������ʣ�" + tbl_projectdocument.PD_Name);
            return new Tbl_ProjectDocumentService().AddTbl_ProjectDocument(tbl_projectdocument);
        }

        public static int UpdateTbl_ProjectDocument(Tbl_ProjectDocument tbl_projectdocument)
        {
            WebCommon.Public.WriteLog("�޸��������ʣ�" + tbl_projectdocument.PD_Name);
            //����������Ϣ�����רҵ����
            if (tbl_projectdocument.PD_Type != "��������" && tbl_projectdocument.Status == "��ȷ��")
            {
                foreach (WebModels.Tbl_User user in WebBLL.Tbl_UserManager.GetTbl_UserBySpecialty(tbl_projectdocument.ClassName))
                {
                    WebCommon.Public.WriteAlert(user.UserName, "���ʱ��", "���ƣ�" + tbl_projectdocument.PD_Name + " �汾��" + tbl_projectdocument.PD_FileNo, "views/ProjectDocument_Edit.aspx?type=read&ID=" + tbl_projectdocument.ID.ToString());
                }
            }
            tbl_projectdocument.DealUser = WebCommon.Public.GetUserName();
            tbl_projectdocument.DealTime = DateTime.Now;
            return new Tbl_ProjectDocumentService().UpdateTbl_ProjectDocumentById(tbl_projectdocument);
        }

        public static int DeleteTbl_ProjectDocument(int ID)
        {
            WebCommon.Public.WriteLog("ɾ���������ʣ�" + ID.ToString());
            return new Tbl_ProjectDocumentService().DeleteTbl_ProjectDocumentById(ID);
        }

        public static Tbl_ProjectDocument GetTbl_ProjectDocumentById(int ID)
        {
            return new Tbl_ProjectDocumentService().GetTbl_ProjectDocumentById(ID);
        }

        public static Tbl_ProjectDocument GetTbl_ProjectDocumentParentID(string where)
        {
            return new Tbl_ProjectDocumentService().GetTbl_ProjectDocumentParentID(where);
        }

        public static IList<Tbl_ProjectDocument> GetTbl_ProjectDocumentParent(string where)
        {
            return new Tbl_ProjectDocumentService().GetTbl_ProjectDocumentParent(where);
        }
        public static IList<Tbl_ProjectDocument> GetTbl_ProjectDocumentAll()
        {
            return new Tbl_ProjectDocumentService().GetTbl_ProjectDocumentAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectDocumentService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectDocumentService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
