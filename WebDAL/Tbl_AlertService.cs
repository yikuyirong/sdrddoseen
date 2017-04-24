using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_AlertService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Alert(Tbl_Alert tbl_alert)
        {
            string sql="insert into [Tbl_Alert] ([UserName],[AlertType],[AlertTitle],[AlertInfo],[AlertUrl],[AlertMode],[Status]) values (@UserName,@AlertType,@AlertTitle,@AlertInfo,@AlertUrl,@AlertMode,@Status)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_alert.UserName),
                new SqlParameter("@AlertType",tbl_alert.AlertType),
                new SqlParameter("@AlertTitle",tbl_alert.AlertTitle),
                new SqlParameter("@AlertInfo",tbl_alert.AlertInfo),
                new SqlParameter("@AlertUrl",tbl_alert.AlertUrl),
                new SqlParameter("@AlertMode",tbl_alert.AlertMode),
                new SqlParameter("@Status",tbl_alert.Status)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_AlertById(Tbl_Alert tbl_alert)
        {
            
            string sql="update [Tbl_Alert] set [UserName]=@UserName,[AlertType]=@AlertType,[AlertTitle]=@AlertTitle,[AlertInfo]=@AlertInfo,[AlertUrl]=@AlertUrl,[AlertMode]=@AlertMode,[Status]=@Status,[DealFlag]=@DealFlag,[DealUser]=@DealUser,[DealTime]=@DealTime where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_alert.ID),
                new SqlParameter("@UserName",tbl_alert.UserName),
                new SqlParameter("@AlertType",tbl_alert.AlertType),
                new SqlParameter("@AlertTitle",tbl_alert.AlertTitle),
                new SqlParameter("@AlertInfo",tbl_alert.AlertInfo),
                new SqlParameter("@AlertUrl",tbl_alert.AlertUrl),
                new SqlParameter("@AlertMode",tbl_alert.AlertMode),
                new SqlParameter("@Status",tbl_alert.Status),
                new SqlParameter("@DealFlag",tbl_alert.DealFlag),
                new SqlParameter("@DealUser",tbl_alert.DealUser),
                new SqlParameter("@DealTime",tbl_alert.DealTime)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public int DeleteTbl_AlertById(int ID)
        {

            string sql = "update from [Tbl_Alert] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public Tbl_Alert GetTbl_AlertById(int ID)
        {

            string sql = "select * from [Tbl_Alert] where DealFlag=0 and ID=" + ID;
            return getTbl_AlertBySql(sql);
            
        }
        public IList<Tbl_Alert> GetTbl_AlertAll()
        {
            string sql = "select * from [Tbl_Alert] where DealFlag=0";
            return getTbl_AlertsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_Alert> getTbl_AlertsBySql(string sql)
        {
            IList<Tbl_Alert> list = new List<Tbl_Alert>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Alert tbl_alert = new Tbl_Alert();
                    tbl_alert.ID = Convert.ToInt32(dr["ID"]);
                    tbl_alert.UserName = Convert.ToString(dr["UserName"]);
                    tbl_alert.AlertType = Convert.ToString(dr["AlertType"]);
                    tbl_alert.AlertTitle = Convert.ToString(dr["AlertTitle"]);
                    tbl_alert.AlertInfo = Convert.ToString(dr["AlertInfo"]);
                    tbl_alert.AlertUrl = Convert.ToString(dr["AlertUrl"]);
                    tbl_alert.AlertMode = Convert.ToString(dr["AlertMode"]);
                    tbl_alert.Status = Convert.ToString(dr["Status"]);
                    tbl_alert.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_alert.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_alert.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_alert.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_alert);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Alert getTbl_AlertBySql(string sql)
        {
            Tbl_Alert tbl_alert = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_alert = new Tbl_Alert();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_alert.ID = Convert.ToInt32(dr["ID"]);
                    tbl_alert.UserName = Convert.ToString(dr["UserName"]);
                    tbl_alert.AlertType = Convert.ToString(dr["AlertType"]);
                    tbl_alert.AlertTitle = Convert.ToString(dr["AlertTitle"]);
                    tbl_alert.AlertInfo = Convert.ToString(dr["AlertInfo"]);
                    tbl_alert.AlertUrl = Convert.ToString(dr["AlertUrl"]);
                    tbl_alert.AlertMode = Convert.ToString(dr["AlertMode"]);
                    tbl_alert.Status = Convert.ToString(dr["Status"]);
                    tbl_alert.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_alert.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_alert.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_alert.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_alert;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Alert where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_Alert where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
