using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;

using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_LimitService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Limit(Tbl_Limit tbl_limit)
        {
            string sql = "insert into [Tbl_Limit] ([LimitName],[LimitInfo],[Remark],[DealUser]) values (@LimitName,@LimitInfo,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@LimitName",tbl_limit.LimitName),
                new SqlParameter("@LimitInfo",tbl_limit.LimitInfo),
                new SqlParameter("@Remark",tbl_limit.Remark),
                new SqlParameter("@DealUser",tbl_limit.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_LimitById(Tbl_Limit tbl_limit)
        {

            string sql = "update [Tbl_Limit] set [LimitName]=@LimitName,[LimitInfo]=@LimitInfo,[Remark]=@Remark,[DealFlag]=@DealFlag,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@LimitName",tbl_limit.LimitName),
                new SqlParameter("@LimitInfo",tbl_limit.LimitInfo),
                new SqlParameter("@Remark",tbl_limit.Remark),
                 new SqlParameter("@DealFlag",tbl_limit.DealFlag),
                new SqlParameter("@DealUser",tbl_limit.DealUser),
                new SqlParameter("@DealTime",tbl_limit.DealTime.ToString()),
                new SqlParameter("@ID",tbl_limit.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }

        public int DeleteTbl_LimitById(int ID)
        {

            string sql = "update [Tbl_Limit] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_Limit GetTbl_LimitById(int ID)
        {

            string sql = "select * from [Tbl_Limit] where DealFlag=0 and ID=" + ID;
            return getTbl_LimitBySql(sql);

        }
        public IList<Tbl_Limit> GetTbl_LimitAll()
        {
            string sql = "select * from [Tbl_Limit] where DealFlag=0 order by limitname";
            return getTbl_LimitsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_Limit> getTbl_LimitsBySql(string sql)
        {
            IList<Tbl_Limit> list = new List<Tbl_Limit>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Limit tbl_limit = new Tbl_Limit();
                    tbl_limit.ID = Convert.ToInt32(dr["ID"]);
                    tbl_limit.LimitName = Convert.ToString(dr["LimitName"]);
                    tbl_limit.LimitInfo = Convert.ToString(dr["LimitInfo"]);
                    tbl_limit.Remark = Convert.ToString(dr["Remark"]);
                    tbl_limit.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_limit.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_limit.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_limit.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_limit);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Limit getTbl_LimitBySql(string sql)
        {
            Tbl_Limit tbl_limit = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_limit = new Tbl_Limit();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_limit.ID = Convert.ToInt32(dr["ID"]);
                    tbl_limit.LimitName = Convert.ToString(dr["LimitName"]);
                    tbl_limit.LimitInfo = Convert.ToString(dr["LimitInfo"]);
                    tbl_limit.Remark = Convert.ToString(dr["Remark"]);
                    tbl_limit.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_limit.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_limit.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_limit.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_limit;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Limit where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_Limit where DealFlag=0 ";
            if (Where != "") sql += " and   " + Where;
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
