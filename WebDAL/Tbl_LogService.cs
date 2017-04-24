using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_LogService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Log(Tbl_Log tbl_log)
        {
            string sql = "insert into [Tbl_Log] ([LogInfo],[DealUser]) values (@LogInfo,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@LogInfo",tbl_log.LogInfo),
                new SqlParameter("@DealUser",tbl_log.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_LogById(Tbl_Log tbl_log)
        {

            string sql = "update [Tbl_Log] set [LogInfo]=@LogInfo,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@LogInfo",tbl_log.LogInfo),
                new SqlParameter("@DealUser",tbl_log.DealUser),
                new SqlParameter("@DealTime",tbl_log.DealTime.ToString()),
                new SqlParameter("@tbl_log",tbl_log.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public int DeleteTbl_LogById()
        {

            string sql = "update [Tbl_Log] where DealFlag=0 and [DealFlag]=1";
            SqlParameter[] sp = new SqlParameter[]
            {
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_LogById(int ID)
        {
            
            string sql="update [Tbl_Log] set [DealFlag]=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public Tbl_Log GetTbl_LogById(int ID)
        {
            
            string sql="select * from [Tbl_Log] where DealFlag=0 and ID="+ID;
            return getTbl_LogBySql(sql);
            
        }
        public IList<Tbl_Log> GetTbl_LogAll()
        {
            string sql="select * from [Tbl_Log] where DealFlag=0 ";
            return getTbl_LogsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_Log> getTbl_LogsBySql(string sql)
        {
            IList<Tbl_Log> list = new List<Tbl_Log>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Log tbl_log = new Tbl_Log();
                    tbl_log.ID = Convert.ToInt32(dr["ID"]);
                    tbl_log.LogInfo = Convert.ToString(dr["LogInfo"]);
                    tbl_log.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_log.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_log.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_log.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_log);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Log getTbl_LogBySql(string sql)
        {
            Tbl_Log tbl_log = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_log = new Tbl_Log();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_log.ID = Convert.ToInt32(dr["ID"]);
                    tbl_log.LogInfo = Convert.ToString(dr["LogInfo"]);
                    tbl_log.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_log.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_log.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_log.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_log;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Log where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_Log where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
