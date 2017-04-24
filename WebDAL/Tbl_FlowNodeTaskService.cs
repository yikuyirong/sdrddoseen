using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_FlowNodeTaskService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_FlowNodeTask(Tbl_FlowNodeTask tbl_flownodetask)
        {
            string sql = "insert into [Tbl_FlowNodeTask] ([ProjectID],[FlowNodeID],[UserName],[EndTime],[FNT_Info],[Status],[DealUser]) values (@ProjectID,@FlowNodeID,@UserName,@EndTime,@FNT_Info,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_flownodetask.ProjectID),
                new SqlParameter("@FlowNodeID",tbl_flownodetask.FlowNodeID),
                new SqlParameter("@UserName",tbl_flownodetask.UserName),
                new SqlParameter("@EndTime",tbl_flownodetask.EndTime),
                new SqlParameter("@FNT_Info",tbl_flownodetask.FNT_Info),
                new SqlParameter("@Status",tbl_flownodetask.Status),
                new SqlParameter("@DealUser",tbl_flownodetask.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_FlowNodeTaskById(Tbl_FlowNodeTask tbl_flownodetask)
        {

            string sql = "update [Tbl_FlowNodeTask] set [ProjectID]=@ProjectID,[FlowNodeID]=@FlowNodeID,[UserName]=@UserName,[EndTime]=@EndTime,[FNT_Info]=@FNT_Info,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_flownodetask.ID),
                new SqlParameter("@ProjectID",tbl_flownodetask.ProjectID),
                new SqlParameter("@FlowNodeID",tbl_flownodetask.FlowNodeID),
                new SqlParameter("@UserName",tbl_flownodetask.UserName),
                new SqlParameter("@EndTime",tbl_flownodetask.EndTime),
                new SqlParameter("@FNT_Info",tbl_flownodetask.FNT_Info),
                new SqlParameter("@Status",tbl_flownodetask.Status),
                new SqlParameter("@DealUser",tbl_flownodetask.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_FlowNodeTaskById(int ID)
        {

            string sql = "update from [Tbl_FlowNodeTask] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_FlowNodeTask GetTbl_FlowNodeTaskById(int ID)
        {

            string sql = "select * from [Tbl_FlowNodeTask] where DealFlag=0 and ID=" + ID;
            return getTbl_FlowNodeTaskBySql(sql);

        }
        public IList<Tbl_FlowNodeTask> GetTbl_FlowNodeTaskAll()
        {
            string sql = "select * from [Tbl_FlowNodeTask] where DealFlag=0";
            return getTbl_FlowNodeTasksBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_FlowNodeTask> getTbl_FlowNodeTasksBySql(string sql)
        {
            IList<Tbl_FlowNodeTask> list = new List<Tbl_FlowNodeTask>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_FlowNodeTask tbl_flownodetask = new Tbl_FlowNodeTask();
                    tbl_flownodetask.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flownodetask.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_flownodetask.FlowNodeID = Convert.ToInt32(dr["FlowNodeID"]);
                    tbl_flownodetask.UserName = Convert.ToString(dr["UserName"]);
                    tbl_flownodetask.EndTime = Convert.ToDateTime(dr["EndTime"]);
                    tbl_flownodetask.FNT_Info = Convert.ToString(dr["FNT_Info"]);
                    tbl_flownodetask.Status = Convert.ToString(dr["Status"]);
                    tbl_flownodetask.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flownodetask.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flownodetask.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flownodetask.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_flownodetask);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_FlowNodeTask getTbl_FlowNodeTaskBySql(string sql)
        {
            Tbl_FlowNodeTask tbl_flownodetask = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_flownodetask = new Tbl_FlowNodeTask();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_flownodetask.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flownodetask.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_flownodetask.FlowNodeID = Convert.ToInt32(dr["FlowNodeID"]);
                    tbl_flownodetask.UserName = Convert.ToString(dr["UserName"]);
                    tbl_flownodetask.EndTime = Convert.ToDateTime(dr["EndTime"]);
                    tbl_flownodetask.FNT_Info = Convert.ToString(dr["FNT_Info"]);
                    tbl_flownodetask.Status = Convert.ToString(dr["Status"]);
                    tbl_flownodetask.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flownodetask.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flownodetask.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flownodetask.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_flownodetask;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_FlowNodeTask where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_Project where id=Tbl_FlowNodeTask.ProjectID) as ProjectName,(select NodeName from tbl_FlowNode where id=Tbl_FlowNodeTask.FlowNodeID) as NodeName from Tbl_FlowNodeTask where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
