using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_FlowWorkLogService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_FlowWorkLog(Tbl_FlowWorkLog tbl_FlowWorkLog)
        {
            string sql = "insert into [Tbl_FlowWorkLog] ([UserName],[LogType],[ParentID],[ProjectID],[FlowID],[FlowWorkID],[FlowNodeID],[FileLog],[Remark],[DealUser]) values (@UserName,@LogType,@ParentID,@ProjectID,@FlowID,@FlowWorkID,@FlowNodeID,@FileLog,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_FlowWorkLog.UserName),
                new SqlParameter("@LogType",tbl_FlowWorkLog.LogType),
                new SqlParameter("@ParentID",tbl_FlowWorkLog.ParentID),
                new SqlParameter("@ProjectID",tbl_FlowWorkLog.ProjectID),
                new SqlParameter("@FlowID",tbl_FlowWorkLog.FlowID),
                new SqlParameter("@FlowWorkID",tbl_FlowWorkLog.FlowWorkID),
                new SqlParameter("@FlowNodeID",tbl_FlowWorkLog.FlowNodeID),
                new SqlParameter("@FileLog",tbl_FlowWorkLog.FileLog),
                new SqlParameter("@Remark",tbl_FlowWorkLog.Remark),
                new SqlParameter("@DealUser",tbl_FlowWorkLog.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_FlowWorkLogById(Tbl_FlowWorkLog tbl_FlowWorkLog)
        {

            string sql = "update [Tbl_FlowWorkLog] set [UserName]=@UserName,[LogType]=@LogType,[ProjectID]=@ProjectID,[FlowID]=@FlowID,[FlowWorkID]=@FlowWorkID,[FlowNodeID]=@FlowNodeID,[FileLog]=@FileLog,[Remark]=@Remark,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_FlowWorkLog.ID),
                new SqlParameter("@LogType",tbl_FlowWorkLog.LogType),
                new SqlParameter("@UserName",tbl_FlowWorkLog.UserName),
                new SqlParameter("@ProjectID",tbl_FlowWorkLog.ProjectID),
                new SqlParameter("@FlowID",tbl_FlowWorkLog.FlowID),
                new SqlParameter("@FlowWorkID",tbl_FlowWorkLog.FlowWorkID),
                new SqlParameter("@FlowNodeID",tbl_FlowWorkLog.FlowNodeID),
                new SqlParameter("@FileLog",tbl_FlowWorkLog.FileLog),
                new SqlParameter("@Remark",tbl_FlowWorkLog.Remark),
                new SqlParameter("@DealUser",tbl_FlowWorkLog.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_FlowWorkLogById(int ID)
        {

            string sql = "update from [Tbl_FlowWorkLog] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_FlowWorkLog GetTbl_FlowWorkLogById(int ID)
        {

            string sql = "select * from [Tbl_FlowWorkLog] where DealFlag=0 and ID=" + ID;
            return getTbl_FlowWorkLogBySql(sql);

        }
        public IList<Tbl_FlowWorkLog> GetTbl_FlowWorkLogAll()
        {
            string sql = "select * from [Tbl_FlowWorkLog] where DealFlag=0";
            return getTbl_FlowWorkLogsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_FlowWorkLog> getTbl_FlowWorkLogsBySql(string sql)
        {
            IList<Tbl_FlowWorkLog> list = new List<Tbl_FlowWorkLog>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_FlowWorkLog tbl_FlowWorkLog = new Tbl_FlowWorkLog();
                    tbl_FlowWorkLog.ID = Convert.ToInt32(dr["ID"]);
                    tbl_FlowWorkLog.UserName = Convert.ToString(dr["UserName"]);
                    tbl_FlowWorkLog.LogType = Convert.ToString(dr["LogType"]);
                    tbl_FlowWorkLog.ParentID = Convert.ToInt32(dr["ParentID"]);
                    tbl_FlowWorkLog.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_FlowWorkLog.FlowID = Convert.ToInt32(dr["FlowID"]);
                    tbl_FlowWorkLog.FlowWorkID = Convert.ToInt32(dr["FlowWorkID"]);
                    tbl_FlowWorkLog.FlowNodeID = Convert.ToInt32(dr["FlowNodeID"]);
                    tbl_FlowWorkLog.FileLog = Convert.ToString(dr["FileLog"]);
                    tbl_FlowWorkLog.Remark = Convert.ToString(dr["Remark"]);
                    tbl_FlowWorkLog.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_FlowWorkLog.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_FlowWorkLog.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_FlowWorkLog.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_FlowWorkLog);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_FlowWorkLog getTbl_FlowWorkLogBySql(string sql)
        {
            Tbl_FlowWorkLog tbl_FlowWorkLog = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_FlowWorkLog = new Tbl_FlowWorkLog();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_FlowWorkLog.ID = Convert.ToInt32(dr["ID"]);
                    tbl_FlowWorkLog.UserName = Convert.ToString(dr["UserName"]);
                    tbl_FlowWorkLog.LogType = Convert.ToString(dr["LogType"]);
                    tbl_FlowWorkLog.ParentID = Convert.ToInt32(dr["ParentID"]);
                    tbl_FlowWorkLog.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_FlowWorkLog.FlowID = Convert.ToInt32(dr["FlowID"]);
                    tbl_FlowWorkLog.FlowWorkID = Convert.ToInt32(dr["FlowWorkID"]);
                    tbl_FlowWorkLog.FlowNodeID = Convert.ToInt32(dr["FlowNodeID"]);
                    tbl_FlowWorkLog.FileLog = Convert.ToString(dr["FileLog"]);
                    tbl_FlowWorkLog.Remark = Convert.ToString(dr["Remark"]);
                    tbl_FlowWorkLog.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_FlowWorkLog.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_FlowWorkLog.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_FlowWorkLog.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_FlowWorkLog;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_FlowWorkLog where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=a.projectid) as ProjectName,(select FlowName from tbl_flow where id=a.flowid) as FlowName,(select WorkName from tbl_flowwork where id=a.flowworkid) as WorkName,(select NodeName from tbl_flowNode where id=a.flownodeid) as NodeName from Tbl_FlowWorkLog as a  where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
