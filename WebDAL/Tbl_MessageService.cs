using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_MessageService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Message(Tbl_Message tbl_message)
        {
            string sql = "insert into [Tbl_Message] ([UserNameFrom],[UserNameTo],[MessageInfo],[MessageFile],[Status],[DealUser]) values (@UserNameFrom,@UserNameTo,@MessageInfo,@MessageFile,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserNameFrom",tbl_message.UserNameFrom),
                new SqlParameter("@UserNameTo",tbl_message.UserNameTo),
                new SqlParameter("@MessageInfo",tbl_message.MessageInfo),
                new SqlParameter("@MessageFile",tbl_message.MessageFile),
                new SqlParameter("@Status",tbl_message.Status),
                 new SqlParameter("@DealUser",tbl_message.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_MessageById(Tbl_Message tbl_message)
        {

            string sql = "update [Tbl_Message] set [UserNameFrom]=@UserNameFrom,[UserNameTo]=@UserNameTo,[MessageInfo]=@MessageInfo,[MessageFile]=@MessageFile,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_message.ID),
                new SqlParameter("@UserNameFrom",tbl_message.UserNameFrom),
                new SqlParameter("@UserNameTo",tbl_message.UserNameTo),
                new SqlParameter("@MessageInfo",tbl_message.MessageInfo),
                new SqlParameter("@MessageFile",tbl_message.MessageFile),
                new SqlParameter("@Status",tbl_message.Status),
                new SqlParameter("@DealUser",tbl_message.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_MessageById(int ID)
        {

            string sql = "update from [Tbl_Message] set [DealFlag]=1 where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_Message GetTbl_MessageById(int ID)
        {

            string sql = "select * from [Tbl_Message] where DealFlag=0 and ID=" + ID;
            return getTbl_MessageBySql(sql);

        }
        public IList<Tbl_Message> GetTbl_MessageAll()
        {
            string sql = "select * from [Tbl_Message] where DealFlag=0";
            return getTbl_MessagesBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_Message> getTbl_MessagesBySql(string sql)
        {
            IList<Tbl_Message> list = new List<Tbl_Message>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Message tbl_message = new Tbl_Message();
                    tbl_message.ID = Convert.ToInt32(dr["ID"]);
                    tbl_message.UserNameFrom = Convert.ToString(dr["UserNameFrom"]);
                    tbl_message.UserNameTo = Convert.ToString(dr["UserNameTo"]);
                    tbl_message.MessageInfo = Convert.ToString(dr["MessageInfo"]);
                    tbl_message.MessageFile = Convert.ToString(dr["MessageFile"]);
                    tbl_message.Status = Convert.ToString(dr["Status"]);
                    tbl_message.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_message.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_message.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_message.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_message);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Message getTbl_MessageBySql(string sql)
        {
            Tbl_Message tbl_message = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_message = new Tbl_Message();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_message.ID = Convert.ToInt32(dr["ID"]);
                    tbl_message.UserNameFrom = Convert.ToString(dr["UserNameFrom"]);
                    tbl_message.UserNameTo = Convert.ToString(dr["UserNameTo"]);
                    tbl_message.MessageInfo = Convert.ToString(dr["MessageInfo"]);
                    tbl_message.MessageFile = Convert.ToString(dr["MessageFile"]);
                    tbl_message.Status = Convert.ToString(dr["Status"]);
                    tbl_message.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_message.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_message.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_message.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_message;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Message where DealFlag=0";
            if (Where != "") sql +=" and "+ Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_Message where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
