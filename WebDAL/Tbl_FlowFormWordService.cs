using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_FlowFormWordService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_FlowFormWord(Tbl_FlowFormWord tbl_flowformword)
        {
            string sql = "insert into [Tbl_FlowFormWord] ([FlowFormID],[IFW_Name],[DealUser]) values (@FlowFormID,@IFW_Name,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@FlowFormID",tbl_flowformword.FlowFormID),
                new SqlParameter("@IFW_Name",tbl_flowformword.IFW_Name),
                new SqlParameter("@DealUser",tbl_flowformword.DealUser)                
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_FlowFormWordById(Tbl_FlowFormWord tbl_flowformword)
        {

            string sql = "update [Tbl_FlowFormWord] set [FlowFormID]=@FlowFormID,[IFW_Name]=@IFW_Name,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_flowformword.ID),
                new SqlParameter("@FlowFormID",tbl_flowformword.FlowFormID),
                new SqlParameter("@IFW_Name",tbl_flowformword.IFW_Name),
                new SqlParameter("@DealUser",tbl_flowformword.DealUser)  
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_FlowFormWordById(int ID)
        {

            string sql = "update from [Tbl_FlowFormWord] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_FlowFormWord GetTbl_FlowFormWordById(int ID)
        {

            string sql = "select * from [Tbl_FlowFormWord] where DealFlag=0 and ID=" + ID;
            return getTbl_FlowFormWordBySql(sql);

        }
        public IList<Tbl_FlowFormWord> GetTbl_FlowFormWordAll()
        {
            string sql = "select * from [Tbl_FlowFormWord] where DealFlag=0";
            return getTbl_FlowFormWordsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_FlowFormWord> getTbl_FlowFormWordsBySql(string sql)
        {
            IList<Tbl_FlowFormWord> list = new List<Tbl_FlowFormWord>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_FlowFormWord tbl_flowformword = new Tbl_FlowFormWord();
                    tbl_flowformword.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flowformword.FlowFormID = Convert.ToInt32(dr["FlowFormID"]);
                    tbl_flowformword.IFW_Name = Convert.ToString(dr["IFW_Name"]);
                    tbl_flowformword.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flowformword.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flowformword.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flowformword.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_flowformword);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_FlowFormWord getTbl_FlowFormWordBySql(string sql)
        {
            Tbl_FlowFormWord tbl_flowformword = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_flowformword = new Tbl_FlowFormWord();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_flowformword.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flowformword.FlowFormID = Convert.ToInt32(dr["FlowFormID"]);
                    tbl_flowformword.IFW_Name = Convert.ToString(dr["IFW_Name"]);
                    tbl_flowformword.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flowformword.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flowformword.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flowformword.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_flowformword;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_FlowFormWord where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_FlowFormWord where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
