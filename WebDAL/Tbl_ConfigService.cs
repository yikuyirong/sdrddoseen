using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_ConfigService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Config(Tbl_Config tbl_config)
        {
            string sql = "insert into [Tbl_Config] ([C_Set1],[C_Set2],[C_Set4],[C_Set5],[C_Set6],[C_Set7],[C_Set8],[C_Set9],[C_Set10],[C_Set11],[C_Set12],[C_Set13],[C_Set14],[C_Set15],[DealUser]) values (@C_Set1,@C_Set2,@C_Set4,@C_Set5,@C_Set6,@C_Set7,@C_Set8,@C_Set9,@C_Set10,@C_Set11,@C_Set12,@C_Set13,@C_Set14,@C_Set15,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@C_Set1",tbl_config.C_Set1),
                new SqlParameter("@C_Set2",tbl_config.C_Set2),
                new SqlParameter("@C_Set4",tbl_config.C_Set4),
                new SqlParameter("@C_Set5",tbl_config.C_Set5),
                new SqlParameter("@C_Set6",tbl_config.C_Set6),
                new SqlParameter("@C_Set7",tbl_config.C_Set7),
                new SqlParameter("@C_Set8",tbl_config.C_Set8),
                new SqlParameter("@C_Set9",tbl_config.C_Set9),
                new SqlParameter("@C_Set10",tbl_config.C_Set10),
                new SqlParameter("@C_Set11",tbl_config.C_Set11),
                new SqlParameter("@C_Set12",tbl_config.C_Set12),
                new SqlParameter("@C_Set13",tbl_config.C_Set13),
                new SqlParameter("@C_Set14",tbl_config.C_Set14),
                new SqlParameter("@C_Set15",tbl_config.C_Set15),
                new SqlParameter("@DealUser",tbl_config.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_ConfigById(Tbl_Config tbl_config)
        {

            string sql = "update [Tbl_Config] set [C_Set1]=@C_Set1,[C_Set2]=@C_Set2,[C_Set3]=@C_Set3,[C_Set4]=@C_Set4,[C_Set5]=@C_Set5,[C_Set6]=@C_Set6,[C_Set7]=@C_Set7,[C_Set8]=@C_Set8,[C_Set9]=@C_Set9,[C_Set10]=@C_Set10,[C_Set11]=@C_Set11,[C_Set12]=@C_Set12,[C_Set13]=@C_Set13,[C_Set14]=@C_Set14,[C_Set15]=@C_Set15,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@C_Set1",tbl_config.C_Set1),
                new SqlParameter("@C_Set2",tbl_config.C_Set2),
                new SqlParameter("@C_Set3",tbl_config.C_Set3),
                new SqlParameter("@C_Set4",tbl_config.C_Set4),
                new SqlParameter("@C_Set5",tbl_config.C_Set5),
                new SqlParameter("@C_Set6",tbl_config.C_Set6),
                new SqlParameter("@C_Set7",tbl_config.C_Set7),
                new SqlParameter("@C_Set8",tbl_config.C_Set8),
                new SqlParameter("@C_Set9",tbl_config.C_Set9),
                new SqlParameter("@C_Set10",tbl_config.C_Set10),
                new SqlParameter("@C_Set11",tbl_config.C_Set11),
                new SqlParameter("@C_Set12",tbl_config.C_Set12),
                new SqlParameter("@C_Set13",tbl_config.C_Set13),
                new SqlParameter("@C_Set14",tbl_config.C_Set14),
                new SqlParameter("@C_Set15",tbl_config.C_Set15),
                new SqlParameter("@DealUser",tbl_config.DealUser),
                new SqlParameter("@DealTime",tbl_config.DealTime.ToString()),
                new SqlParameter("@ID",tbl_config.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public int DeleteTbl_ConfigById(int ID)
        {
            
            string sql="update [Tbl_Config] set [DealFlag]=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public Tbl_Config GetTbl_ConfigById(int ID)
        {
            
            string sql="select * from [Tbl_Config] where DealFlag=0 and ID="+ID;
            return getTbl_ConfigBySql(sql);
            
        }
        public IList<Tbl_Config> GetTbl_ConfigAll()
        {
            string sql="select * from [Tbl_Config] where DealFlag=0";
            return getTbl_ConfigsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_Config> getTbl_ConfigsBySql(string sql)
        {
            IList<Tbl_Config> list = new List<Tbl_Config>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Config tbl_config = new Tbl_Config();
                    tbl_config.ID = Convert.ToInt32(dr["ID"]);
                    tbl_config.C_Set1 = Convert.ToString(dr["C_Set1"]);
                    tbl_config.C_Set2 = Convert.ToString(dr["C_Set2"]);
                    tbl_config.C_Set3 = Convert.ToString(dr["C_Set3"]);
                    tbl_config.C_Set4 = Convert.ToString(dr["C_Set4"]);
                    tbl_config.C_Set5 = Convert.ToString(dr["C_Set5"]);
                    tbl_config.C_Set6 = Convert.ToString(dr["C_Set6"]);
                    tbl_config.C_Set7 = Convert.ToString(dr["C_Set7"]);
                    tbl_config.C_Set8 = Convert.ToString(dr["C_Set8"]);
                    tbl_config.C_Set9 = Convert.ToString(dr["C_Set9"]);
                    tbl_config.C_Set10 = Convert.ToString(dr["C_Set10"]);
                    tbl_config.C_Set11 = Convert.ToString(dr["C_Set11"]);
                    tbl_config.C_Set12 = Convert.ToString(dr["C_Set12"]);
                    tbl_config.C_Set13 = Convert.ToString(dr["C_Set13"]);
                    tbl_config.C_Set14 = Convert.ToString(dr["C_Set14"]);
                    tbl_config.C_Set15 = Convert.ToString(dr["C_Set15"]);
                    tbl_config.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_config.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_config.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_config.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_config);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Config getTbl_ConfigBySql(string sql)
        {
            Tbl_Config tbl_config = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_config = new Tbl_Config();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_config.ID = Convert.ToInt32(dr["ID"]);
                    tbl_config.C_Set1 = Convert.ToString(dr["C_Set1"]);
                    tbl_config.C_Set2 = Convert.ToString(dr["C_Set2"]);
                    tbl_config.C_Set3 = Convert.ToString(dr["C_Set3"]);
                    tbl_config.C_Set4 = Convert.ToString(dr["C_Set4"]);
                    tbl_config.C_Set5 = Convert.ToString(dr["C_Set5"]);
                    tbl_config.C_Set6 = Convert.ToString(dr["C_Set6"]);
                    tbl_config.C_Set7 = Convert.ToString(dr["C_Set7"]);
                    tbl_config.C_Set8 = Convert.ToString(dr["C_Set8"]);
                    tbl_config.C_Set9 = Convert.ToString(dr["C_Set9"]);
                    tbl_config.C_Set10 = Convert.ToString(dr["C_Set10"]);
                    tbl_config.C_Set11 = Convert.ToString(dr["C_Set11"]);
                    tbl_config.C_Set12 = Convert.ToString(dr["C_Set12"]);
                    tbl_config.C_Set13 = Convert.ToString(dr["C_Set13"]);
                    tbl_config.C_Set14 = Convert.ToString(dr["C_Set14"]);
                    tbl_config.C_Set15 = Convert.ToString(dr["C_Set15"]);
                    tbl_config.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_config.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_config.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_config.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_config;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Config where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_Config where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
