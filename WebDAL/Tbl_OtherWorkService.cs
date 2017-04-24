using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_OtherWorkService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
		public int AddTbl_OtherWork(Tbl_OtherWork tbl_otherwork)
        {
            string Sql = "insert into [Tbl_OtherWork] ([ProjectID],[ProjectName],[UserName],[WorkType],[WorkDay],[WorkInfo],[NodeUser],[Status],[DealUser],[DealFlag],[DealTime],[AddDate]) values (@ProjectID,@ProjectName,@UserName,@WorkType,@WorkDay,@WorkInfo,@NodeUser,@Status,@DealUser,@DealFlag,@DealTime,@AddDate)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_otherwork.ProjectID),
                new SqlParameter("@ProjectName",tbl_otherwork.ProjectName),
                new SqlParameter("@UserName",tbl_otherwork.UserName),
                new SqlParameter("@WorkType",tbl_otherwork.WorkType),
                new SqlParameter("@WorkDay",tbl_otherwork.WorkDay),
                new SqlParameter("@WorkInfo",tbl_otherwork.WorkInfo),
                new SqlParameter("@NodeUser",tbl_otherwork.NodeUser),
                new SqlParameter("@Status",tbl_otherwork.Status),
                new SqlParameter("@DealUser",tbl_otherwork.DealUser),
                new SqlParameter("@DealFlag",tbl_otherwork.DealFlag),
                new SqlParameter("@DealTime",tbl_otherwork.DealTime),
                new SqlParameter("@AddDate",tbl_otherwork.AddDate)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
        }

        public int UpdateTbl_OtherWorkById(Tbl_OtherWork tbl_otherwork)
        {

            string Sql = "update [Tbl_OtherWork] set [ProjectID]=@ProjectID,[ProjectName]=@ProjectName,[UserName]=@UserName,[WorkType]=@WorkType,[WorkDay]=@WorkDay,[WorkInfo]=@WorkInfo,[NodeUser]=@NodeUser,[Status]=@Status,[DealUser]=@DealUser,[DealFlag]=@DealFlag,[DealTime]=@DealTime,[AddDate]=@AddDate where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_otherwork.ProjectID),
                new SqlParameter("@ProjectName",tbl_otherwork.ProjectName),
                new SqlParameter("@UserName",tbl_otherwork.UserName),
                new SqlParameter("@WorkType",tbl_otherwork.WorkType),
                new SqlParameter("@WorkDay",tbl_otherwork.WorkDay),
                new SqlParameter("@WorkInfo",tbl_otherwork.WorkInfo),
                new SqlParameter("@NodeUser",tbl_otherwork.NodeUser),
                new SqlParameter("@Status",tbl_otherwork.Status),
                new SqlParameter("@DealUser",tbl_otherwork.DealUser),
                new SqlParameter("@DealFlag",tbl_otherwork.DealFlag),
                new SqlParameter("@DealTime",tbl_otherwork.DealTime),
                new SqlParameter("@AddDate",tbl_otherwork.AddDate),
                new SqlParameter("@ID",tbl_otherwork.ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
            
        }

        public int DeleteTbl_OtherWorkById(int ID)
        {
            
            string Sql="update [Tbl_OtherWork] set [DealFlag]=1 where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
            
        }

        public Tbl_OtherWork GetTbl_OtherWorkById(int ID)
        {
            
            string Sql="select * from [Tbl_OtherWork] where [DealFlag]=0 and ID="+ID;
            return getTbl_OtherWorkBySql(Sql);
            
        }

        public IList<Tbl_OtherWork> GetTbl_OtherWorkAll()
        {
            string Sql="select * from [Tbl_OtherWork] where [DealFlag]=0";
            return getTbl_OtherWorksBySql(Sql);
        }

		/// <summary>
        ///根据Sql语句返回集合
        /// </summary>
        private IList<Tbl_OtherWork> getTbl_OtherWorksBySql(string Sql)
        {
            IList<Tbl_OtherWork> list = new List<Tbl_OtherWork>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_OtherWork tbl_otherwork = new Tbl_OtherWork();
                    tbl_otherwork.ID = Convert.ToInt32(dr["ID"]);
                    tbl_otherwork.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_otherwork.ProjectName = Convert.ToString(dr["ProjectName"]);
                    tbl_otherwork.UserName = Convert.ToString(dr["UserName"]);
                    tbl_otherwork.WorkType = Convert.ToString(dr["WorkType"]);
                    tbl_otherwork.WorkDay = Convert.ToString(dr["WorkDay"]);
                    tbl_otherwork.WorkInfo = Convert.ToString(dr["WorkInfo"]);
                    tbl_otherwork.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_otherwork.Status = Convert.ToString(dr["Status"]);
                    tbl_otherwork.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_otherwork.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_otherwork.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_otherwork.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_otherwork);
                }
            }
            return list;
        }

        /// <summary>
        ///根据Sql语句获取实体
        /// </summary>
        private Tbl_OtherWork getTbl_OtherWorkBySql(string Sql)
        {
            Tbl_OtherWork tbl_otherwork = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_otherwork = new Tbl_OtherWork();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_otherwork.ID = Convert.ToInt32(dr["ID"]);
                    tbl_otherwork.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_otherwork.ProjectName = Convert.ToString(dr["ProjectName"]);
                    tbl_otherwork.UserName = Convert.ToString(dr["UserName"]);
                    tbl_otherwork.WorkType = Convert.ToString(dr["WorkType"]);
                    tbl_otherwork.WorkDay = Convert.ToString(dr["WorkDay"]);
                    tbl_otherwork.WorkInfo = Convert.ToString(dr["WorkInfo"]);
                    tbl_otherwork.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_otherwork.Status = Convert.ToString(dr["Status"]);
                    tbl_otherwork.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_otherwork.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_otherwork.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_otherwork.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_otherwork;
        }

        /// <summary>
        /// 根据条件返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string Sql = "select count(*) from Tbl_OtherWork where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, Sql);
            return RecordNum;
        }

        /// <summary>
        /// 根据条件返回数据总数
        /// </summary>
        public DataTable GetDataTableBySum(string Where)
        {
            string Sql = "select sum(workday),max(worktype) from Tbl_OtherWork where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            Sql += " group by worktype";
            DataTable dt = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 返回条件返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string Sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_OtherWork where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            if (Order != "") Sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, Sql, startRecord, endRecord);
            return dt;
        }

    }
}
