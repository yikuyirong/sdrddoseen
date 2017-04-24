using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{


    public static class Tbl_MessageManager
    {
        public static int AddTbl_Message(Tbl_Message tbl_message)
        {
            WebCommon.Public.WriteLog("添加内部消息：" + tbl_message.MessageInfo);
            //foreach (var obj in tbl_message.UserNameTo.Split(','))
            //{
            //    WebCommon.Public.WriteAlert(obj, "消息", tbl_message.MessageInfo, "views/Message_Detail.aspx?ID=" + tbl_message.ID.ToString());
            //}
            //return new Tbl_MessageService().AddTbl_Message(tbl_message);
            int InfoID = new Tbl_MessageService().AddTbl_Message(tbl_message);
            foreach (var obj in tbl_message.UserNameTo.Split(','))
            {
                WebCommon.Public.WriteAlert(obj, "消息", tbl_message.MessageInfo, "views/Message_Detail.aspx?ID=" + InfoID.ToString());
            }
            return InfoID;
        }

        public static int UpdateTbl_Message(Tbl_Message tbl_message)
        {
            WebCommon.Public.WriteLog("修改内部消息：" + tbl_message.MessageInfo);
            tbl_message.DealUser = WebCommon.Public.GetUserName();
            tbl_message.DealTime = DateTime.Now;
            return new Tbl_MessageService().UpdateTbl_MessageById(tbl_message);
        }

        public static int DeleteTbl_Message(int ID)
        {
            WebCommon.Public.WriteLog("删除内部消息：" + ID.ToString());
            return new Tbl_MessageService().DeleteTbl_MessageById(ID);
        }

        public static Tbl_Message GetTbl_MessageById(int ID)
        {
            return new Tbl_MessageService().GetTbl_MessageById(ID);
        }

        public static IList<Tbl_Message> GetTbl_MessageAll()
        {
            return new Tbl_MessageService().GetTbl_MessageAll();
        }
        //public static System.Data.DataTable GetDataTable(string Where, string Order)
        //{
        //    return new Tbl_MessageService().GetDataTable(Where, Order);
        //}
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_MessageService().GetDataTableByCount(Where);
        }
        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_MessageService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}
