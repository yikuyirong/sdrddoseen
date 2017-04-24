using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectBuilderLogService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectBuilderLog(Tbl_ProjectBuilderLog tbl_projectbuilderlog)
        {
            string sql = "insert into [Tbl_ProjectBuilderLog] ([ProjectID],[PBL_Time],[PBL_Whether],[PBL_Temperature],[PBL_Wind],[PBL_Info1],[PBL_Info2],[PBL_Info3],[PBL_Info1File],[PBL_Info2File],[PBL_Info3File],[DealUser]) values (@ProjectID,@PBL_Time,@PBL_Whether,@PBL_Temperature,@PBL_Wind,@PBL_Info1,@PBL_Info2,@PBL_Info3,@PBL_Info1File,@PBL_Info2File,@PBL_Info3File,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectbuilderlog.ProjectID),
                new SqlParameter("@PBL_Time",tbl_projectbuilderlog.PBL_Time.ToString()),
                new SqlParameter("@PBL_Whether",tbl_projectbuilderlog.PBL_Whether),
                new SqlParameter("@PBL_Temperature",tbl_projectbuilderlog.PBL_Temperature),
                new SqlParameter("@PBL_Wind",tbl_projectbuilderlog.PBL_Wind),
                new SqlParameter("@PBL_Info1",tbl_projectbuilderlog.PBL_Info1),
                new SqlParameter("@PBL_Info2",tbl_projectbuilderlog.PBL_Info2),
                new SqlParameter("@PBL_Info3",tbl_projectbuilderlog.PBL_Info3),
                new SqlParameter("@PBL_Info1File",tbl_projectbuilderlog.PBL_Info1File),
                new SqlParameter("@PBL_Info2File",tbl_projectbuilderlog.PBL_Info2File),
                new SqlParameter("@PBL_Info3File",tbl_projectbuilderlog.PBL_Info3File),
                new SqlParameter("@DealUser",tbl_projectbuilderlog.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectBuilderLogById(Tbl_ProjectBuilderLog tbl_projectbuilderlog)
        {

            string sql = "update [Tbl_ProjectBuilderLog] set [ProjectID]=@ProjectID,[PBL_Time]=@PBL_Time,[PBL_Whether]=@PBL_Whether,[PBL_Temperature]=@PBL_Temperature,[PBL_Wind]=@PBL_Wind,[PBL_Info1]=@PBL_Info1,[PBL_Info2]=@PBL_Info2,[PBL_Info3]=@PBL_Info3,[PBL_Info1File]=@PBL_Info1File,[PBL_Info2File]=@PBL_Info2File,[PBL_Info3File]=@PBL_Info3File,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectbuilderlog.ID),
                 new SqlParameter("@ProjectID",tbl_projectbuilderlog.ProjectID),
                new SqlParameter("@PBL_Time",tbl_projectbuilderlog.PBL_Time.ToString()),
                new SqlParameter("@PBL_Whether",tbl_projectbuilderlog.PBL_Whether),
                new SqlParameter("@PBL_Temperature",tbl_projectbuilderlog.PBL_Temperature),
                new SqlParameter("@PBL_Wind",tbl_projectbuilderlog.PBL_Wind),
                new SqlParameter("@PBL_Info1",tbl_projectbuilderlog.PBL_Info1),
                new SqlParameter("@PBL_Info2",tbl_projectbuilderlog.PBL_Info2),
                new SqlParameter("@PBL_Info3",tbl_projectbuilderlog.PBL_Info3),
                new SqlParameter("@PBL_Info1File",tbl_projectbuilderlog.PBL_Info1File),
                new SqlParameter("@PBL_Info2File",tbl_projectbuilderlog.PBL_Info2File),
                new SqlParameter("@PBL_Info3File",tbl_projectbuilderlog.PBL_Info3File),
                new SqlParameter("@DealUser",tbl_projectbuilderlog.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectBuilderLogById(int ID)
        {

            string sql = "update from [Tbl_ProjectBuilderLog] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectBuilderLog GetTbl_ProjectBuilderLogById(int ID)
        {

            string sql = "select * from [Tbl_ProjectBuilderLog] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectBuilderLogBySql(sql);

        }
        public IList<Tbl_ProjectBuilderLog> GetTbl_ProjectBuilderLogAll()
        {
            string sql = "select * from [Tbl_ProjectBuilderLog] where DealFlag=0";
            return getTbl_ProjectBuilderLogsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectBuilderLog> getTbl_ProjectBuilderLogsBySql(string sql)
        {
            IList<Tbl_ProjectBuilderLog> list = new List<Tbl_ProjectBuilderLog>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectBuilderLog tbl_projectbuilderlog = new Tbl_ProjectBuilderLog();
                    tbl_projectbuilderlog.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuilderlog.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuilderlog.PBL_Time = Convert.ToDateTime(dr["PBL_Time"]);
                    tbl_projectbuilderlog.PBL_Whether = Convert.ToString(dr["PBL_Whether"]);
                    tbl_projectbuilderlog.PBL_Wind = Convert.ToString(dr["PBL_Wind"]);
                    tbl_projectbuilderlog.PBL_Temperature = Convert.ToString(dr["PBL_Temperature"]);
                    tbl_projectbuilderlog.PBL_Info1 = Convert.ToString(dr["PBL_Info1"]);
                    tbl_projectbuilderlog.PBL_Info2 = Convert.ToString(dr["PBL_Info2"]);
                    tbl_projectbuilderlog.PBL_Info3 = Convert.ToString(dr["PBL_Info3"]);
                    tbl_projectbuilderlog.PBL_Info1File = Convert.ToString(dr["PBL_Info1File"]);
                    tbl_projectbuilderlog.PBL_Info2File = Convert.ToString(dr["PBL_Info2File"]);
                    tbl_projectbuilderlog.PBL_Info3File = Convert.ToString(dr["PBL_Info3File"]);
                    tbl_projectbuilderlog.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuilderlog.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuilderlog.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuilderlog.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectbuilderlog);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectBuilderLog getTbl_ProjectBuilderLogBySql(string sql)
        {
            Tbl_ProjectBuilderLog tbl_projectbuilderlog = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectbuilderlog = new Tbl_ProjectBuilderLog();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectbuilderlog.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuilderlog.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuilderlog.PBL_Time = Convert.ToDateTime(dr["PBL_Time"]);
                    tbl_projectbuilderlog.PBL_Whether = Convert.ToString(dr["PBL_Whether"]);
                    tbl_projectbuilderlog.PBL_Wind = Convert.ToString(dr["PBL_Wind"]);
                    tbl_projectbuilderlog.PBL_Temperature = Convert.ToString(dr["PBL_Temperature"]);
                    tbl_projectbuilderlog.PBL_Info1 = Convert.ToString(dr["PBL_Info1"]);
                    tbl_projectbuilderlog.PBL_Info2 = Convert.ToString(dr["PBL_Info2"]);
                    tbl_projectbuilderlog.PBL_Info3 = Convert.ToString(dr["PBL_Info3"]);
                    tbl_projectbuilderlog.PBL_Info1File = Convert.ToString(dr["PBL_Info1File"]);
                    tbl_projectbuilderlog.PBL_Info2File = Convert.ToString(dr["PBL_Info2File"]);
                    tbl_projectbuilderlog.PBL_Info3File = Convert.ToString(dr["PBL_Info3File"]);
                    tbl_projectbuilderlog.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuilderlog.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuilderlog.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuilderlog.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectbuilderlog;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectBuilderLog where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectBuilderLog.projectID) as ProjectName from Tbl_ProjectBuilderLog  where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
