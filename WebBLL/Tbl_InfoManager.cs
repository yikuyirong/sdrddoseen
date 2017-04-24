using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{

    public class Tbl_InfoManager
    {
        public static int AddTbl_Info(Tbl_Info tbl_info)
        {
            WebCommon.Public.WriteLog("�����Ϣ��" + tbl_info.I_Title);
            int InfoID = new Tbl_InfoService().AddTbl_Info(tbl_info);
            foreach (var obj in tbl_info.NodeUser.Split(','))
            {
                WebCommon.Public.WriteAlert(obj, "������Ϣ", tbl_info.I_Title, "views/Info_Detail.aspx?ID=" + InfoID.ToString());
            }
            return InfoID;
        }

        public static int UpdateTbl_Info(Tbl_Info tbl_info)
        {
            WebCommon.Public.WriteLog("�޸���Ϣ��" + tbl_info.I_Title);
            tbl_info.DealUser = WebCommon.Public.GetUserName();
            tbl_info.DealTime = DateTime.Now;
            int InfoID = new Tbl_InfoService().UpdateTbl_InfoById(tbl_info);
            if (tbl_info.Status == "�����")
            {
                foreach (var obj in tbl_info.UserNameTo.Split(','))
                {
                    WebCommon.Public.WriteAlert(obj, tbl_info.I_Type, tbl_info.I_Title, "views/Info_Detail.aspx?ID=" + tbl_info.ID.ToString());
                }
            }
            return InfoID;
        }

        public static int DeleteTbl_Info(int ID)
        {
            WebCommon.Public.WriteLog("ɾ����Ϣ��" + ID.ToString());
            return new Tbl_InfoService().DeleteTbl_InfoById(ID);
        }

        public static Tbl_Info GetTbl_InfoById(int ID)
        {
            return new Tbl_InfoService().GetTbl_InfoById(ID);
        }

        public static IList<Tbl_Info> GetTbl_InfoAll()
        {
            return new Tbl_InfoService().GetTbl_InfoAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_InfoService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_InfoService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
