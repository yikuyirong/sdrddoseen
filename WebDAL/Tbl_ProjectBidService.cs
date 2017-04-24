using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectBidService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectBid(Tbl_ProjectBid tbl_projectbid)
        {
            string sql = "insert into [Tbl_ProjectBid] ([PB_Name],[PB_Info],[Status],[Remark],[DealUser]) values (@PB_Name,@PB_Info,@Status,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@PB_Name",tbl_projectbid.PB_Name),
                new SqlParameter("@PB_Info",tbl_projectbid.PB_Info),
                new SqlParameter("@Status",tbl_projectbid.Status),
                new SqlParameter("@Remark",tbl_projectbid.Remark),
                new SqlParameter("@DealUser",tbl_projectbid.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectBidById(Tbl_ProjectBid tbl_projectbid)
        {

            string sql = "update [Tbl_ProjectBid] set [PB_Name]=@PB_Name,[PB_Info]=@PB_Info,[Status]=@Status,[Remark]=@Remark,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectbid.ID),
                new SqlParameter("@PB_Name",tbl_projectbid.PB_Name),
                new SqlParameter("@PB_Info",tbl_projectbid.PB_Info),
                new SqlParameter("@Status",tbl_projectbid.Status),
                new SqlParameter("@Remark",tbl_projectbid.Remark),
                new SqlParameter("@DealUser",tbl_projectbid.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectBidById(int ID)
        {

            string sql = "update from [Tbl_ProjectBid] set [DealFlag]=1 where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectBid GetTbl_ProjectBidById(int ID)
        {

            string sql = "select * from [Tbl_ProjectBid] where DealFlag=0 and [DealFlag]=0 and ID=" + ID;
            return getTbl_ProjectBidBySql(sql);

        }
        public IList<Tbl_ProjectBid> GetTbl_ProjectBidAll()
        {
            string sql = "select * from [Tbl_ProjectBid] where DealFlag=0";
            return getTbl_ProjectBidsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectBid> getTbl_ProjectBidsBySql(string sql)
        {
            IList<Tbl_ProjectBid> list = new List<Tbl_ProjectBid>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectBid tbl_projectbid = new Tbl_ProjectBid();
                    tbl_projectbid.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbid.PB_Name = Convert.ToString(dr["PB_Name"]);
                    tbl_projectbid.PB_Info = Convert.ToString(dr["PB_Info"]);
                    tbl_projectbid.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectbid.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbid.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbid.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbid.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbid.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectbid);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectBid getTbl_ProjectBidBySql(string sql)
        {
            Tbl_ProjectBid tbl_projectbid = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectbid = new Tbl_ProjectBid();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectbid.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbid.PB_Name = Convert.ToString(dr["PB_Name"]);
                    tbl_projectbid.PB_Info = Convert.ToString(dr["PB_Info"]);
                    tbl_projectbid.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectbid.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbid.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbid.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbid.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbid.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectbid;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectBid where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_ProjectBid where ";
            if (Where != "") sql += Where + " and (DealFlag=0) ";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
