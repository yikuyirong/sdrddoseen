using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_FlowWorkService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_FlowWork(Tbl_FlowWork tbl_flow)
        {
            string sql = "insert into [Tbl_FlowWork] ([UserName],[WorkName],[ProjectID],[FlowID],[FormContent],[NodeID],[NodeNo],[NodeUser],[NodeStatus],[Status],[DealUser]) values (@UserName,@WorkName,@ProjectID,@FlowID,@FormContent,@NodeID,@NodeNo,@NodeUser,@NodeStatus,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_flow.UserName),
                new SqlParameter("@WorkName",tbl_flow.WorkName),
                new SqlParameter("@ProjectID",tbl_flow.ProjectID),
                new SqlParameter("@FlowID",tbl_flow.FlowID),
                new SqlParameter("@FormContent",tbl_flow.FormContent),
                new SqlParameter("@NodeID",tbl_flow.NodeID),
                 new SqlParameter("@NodeNo",tbl_flow.NodeNo),
                new SqlParameter("@NodeUser",tbl_flow.NodeUser),
                new SqlParameter("@NodeStatus",tbl_flow.NodeStatus),
                new SqlParameter("@Status",tbl_flow.Status),
                new SqlParameter("@DealUser",tbl_flow.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_FlowWorkById(Tbl_FlowWork tbl_flow)
        {

            string sql = "update [Tbl_FlowWork] set [UserName]=@UserName,[WorkName]=@WorkName,[FlowID]=@FlowID,[FormContent]=@FormContent,[NodeID]=@NodeID,[NodeNo]=@NodeNo,[NodeUser]=@NodeUser,[NodeStatus]=@NodeStatus,[Status]=@Status,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_flow.ID),
                new SqlParameter("@UserName",tbl_flow.UserName),
                new SqlParameter("@WorkName",tbl_flow.WorkName),
                new SqlParameter("@FlowID",tbl_flow.FlowID),
                new SqlParameter("@FormContent",tbl_flow.FormContent),
                new SqlParameter("@NodeID",tbl_flow.NodeID),
                new SqlParameter("@NodeNo",tbl_flow.NodeNo),
                new SqlParameter("@NodeUser",tbl_flow.NodeUser),
                new SqlParameter("@NodeStatus",tbl_flow.NodeStatus),
                new SqlParameter("@Status",tbl_flow.Status),
                new SqlParameter("@DealUser",tbl_flow.DealUser),
                new SqlParameter("@DealTime",tbl_flow.DealTime.ToString())
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_FlowWorkById(int ID)
        {

            string sql = "update from [Tbl_FlowWork] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_FlowWork GetTbl_FlowWorkById(int ID)
        {

            string sql = "select * from [Tbl_FlowWork] where DealFlag=0 and ID=" + ID;
            return getTbl_FlowWorkBySql(sql);

        }
        public IList<Tbl_FlowWork> GetTbl_FlowWorkType(string Type)
        {
            string sql = "select * from [Tbl_FlowWork] where DealFlag=0 and FlowType='" + Type + "'";
            return getTbl_FlowWorksBySql(sql);
        }
        public IList<Tbl_FlowWork> GetTbl_FlowWorkAll()
        {
            string sql = "select * from [Tbl_FlowWork] where DealFlag=0";
            return getTbl_FlowWorksBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_FlowWork> getTbl_FlowWorksBySql(string sql)
        {
            IList<Tbl_FlowWork> list = new List<Tbl_FlowWork>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_FlowWork tbl_flow = new Tbl_FlowWork();
                    tbl_flow.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flow.UserName = Convert.ToString(dr["UserName"]);
                    tbl_flow.WorkName = Convert.ToString(dr["WorkName"]);
                    tbl_flow.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_flow.FlowID = Convert.ToInt32(dr["FlowID"]);
                    tbl_flow.FormContent = Convert.ToString(dr["FormContent"]);
                    tbl_flow.NodeID = Convert.ToInt32(dr["NodeID"]);
                    tbl_flow.NodeNo = Convert.ToString(dr["NodeNo"]);
                    tbl_flow.NodeStatus = Convert.ToString(dr["NodeStatus"]);
                    tbl_flow.Status = Convert.ToString(dr["Status"]);
                    tbl_flow.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flow.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flow.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flow.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_flow);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_FlowWork getTbl_FlowWorkBySql(string sql)
        {
            Tbl_FlowWork tbl_flow = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_flow = new Tbl_FlowWork();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_flow.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flow.UserName = Convert.ToString(dr["UserName"]);
                    tbl_flow.WorkName = Convert.ToString(dr["WorkName"]);
                    tbl_flow.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_flow.FlowID = Convert.ToInt32(dr["FlowID"]);
                    tbl_flow.FormContent = Convert.ToString(dr["FormContent"]);
                    tbl_flow.NodeID = Convert.ToInt32(dr["NodeID"]);
                    tbl_flow.NodeNo = Convert.ToString(dr["NodeNo"]);
                    tbl_flow.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_flow.NodeStatus = Convert.ToString(dr["NodeStatus"]);
                    tbl_flow.Status = Convert.ToString(dr["Status"]);
                    tbl_flow.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flow.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flow.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flow.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_flow.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_flow;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_FlowWork where DealFlag=0 ";
            if (Where != "") sql += " and "+Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select FlowName from tbl_flow where id=a.flowid) as FlowName,(select NodeName from tbl_flownode where id=a.nodeid) as NodeName,(select ProjectName from tbl_project where id=a.ProjectID) as ProjectName from tbl_flowwork as a where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
