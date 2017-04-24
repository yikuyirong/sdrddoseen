using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_FlowFormService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_FlowForm(Tbl_FlowForm tbl_flowform)
        {
            string sql = "insert into [Tbl_FlowForm] ([IF_Name],[IF_Type],[IF_Content],[DealUser]) values (@IF_Name,@IF_Type,@IF_Content,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@IF_Name",tbl_flowform.IF_Name),
                new SqlParameter("@IF_Type",tbl_flowform.IF_Type),
                new SqlParameter("@IF_Content",tbl_flowform.IF_Content),
                new SqlParameter("@DealUser",tbl_flowform.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_FlowFormById(Tbl_FlowForm tbl_flowform)
        {

            string sql = "update [Tbl_FlowForm] set [IF_Name]=@IF_Name,[IF_Type]=@IF_Type,[IF_Content]=@IF_Content,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_flowform.ID),
                new SqlParameter("@IF_Name",tbl_flowform.IF_Name),
                new SqlParameter("@IF_Type",tbl_flowform.IF_Type),
                new SqlParameter("@IF_Content",tbl_flowform.IF_Content), 
                new SqlParameter("@DealUser",tbl_flowform.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_FlowFormById(int ID)
        {

            string sql = "update from [Tbl_FlowForm] set DealFlag=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_FlowForm GetTbl_FlowFormById(int ID)
        {

            string sql = "select * from [Tbl_FlowForm] where DealFlag=0 and ID=" + ID;
            return getTbl_FlowFormBySql(sql);

        }

        public IList<Tbl_FlowForm> GetTbl_FlowFormByType(string Type)
        {
            string sql = "select * from [Tbl_FlowForm] where DealFlag=0 and IF_Type='" + Type + "'";
            return getTbl_FlowFormsBySql(sql);

        }
        public IList<Tbl_FlowForm> GetTbl_FlowFormAll()
        {
            string sql = "select * from [Tbl_FlowForm] where DealFlag=0";
            return getTbl_FlowFormsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_FlowForm> getTbl_FlowFormsBySql(string sql)
        {
            IList<Tbl_FlowForm> list = new List<Tbl_FlowForm>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_FlowForm tbl_flowform = new Tbl_FlowForm();
                    tbl_flowform.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flowform.IF_Name = Convert.ToString(dr["IF_Name"]);
                    tbl_flowform.IF_Type = Convert.ToString(dr["IF_Type"]);
                    tbl_flowform.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flowform.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flowform.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flowform.IF_Content = Convert.ToString(dr["IF_Content"]);
                    tbl_flowform.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_flowform);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_FlowForm getTbl_FlowFormBySql(string sql)
        {
            Tbl_FlowForm tbl_flowform = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_flowform = new Tbl_FlowForm();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_flowform.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flowform.IF_Name = Convert.ToString(dr["IF_Name"]);
                    tbl_flowform.IF_Type = Convert.ToString(dr["IF_Type"]);
                    tbl_flowform.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flowform.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flowform.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flowform.IF_Content = Convert.ToString(dr["IF_Content"]);
                    tbl_flowform.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_flowform;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_FlowForm where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_FlowForm where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
