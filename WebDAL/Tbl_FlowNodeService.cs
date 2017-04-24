using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_FlowNodeService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_FlowNode(Tbl_FlowNode tbl_flownode)
        {
            string sql = "insert into [Tbl_FlowNode] ([FlowID],[NodeNo],[NodeName],[NodeStage],[NodeType],[NodeUser],[NodeUserLimit],[DealUser]) values (@FlowID,@NodeNo,@NodeName,@NodeStage,@NodeType,@NodeUser,@NodeUserLimit,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@FlowID",tbl_flownode.FlowID),
                new SqlParameter("@NodeNo",tbl_flownode.NodeNo),
                new SqlParameter("@NodeName",tbl_flownode.NodeName),
                new SqlParameter("@NodeStage",tbl_flownode.NodeStage),
                new SqlParameter("@NodeType",tbl_flownode.NodeType),
                new SqlParameter("@NodeUser",tbl_flownode.NodeUser),
                new SqlParameter("@NodeUserLimit",tbl_flownode.NodeUserLimit),
                new SqlParameter("@DealUser",tbl_flownode.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_FlowNodeById(Tbl_FlowNode tbl_flownode)
        {

            string sql = "update [Tbl_FlowNode] set [FlowID]=@FlowID,[NodeNo]=@NodeNo,[NodeName]=@NodeName,[NodeStage]=@NodeStage,[NodeType]=@NodeType,[NodeUser]=@NodeUser,[NodeUserLimit]=@NodeUserLimit,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_flownode.ID),
                new SqlParameter("@FlowID",tbl_flownode.FlowID),
                new SqlParameter("@NodeNo",tbl_flownode.NodeNo),
                new SqlParameter("@NodeName",tbl_flownode.NodeName),
                new SqlParameter("@NodeStage",tbl_flownode.NodeStage),
                new SqlParameter("@NodeType",tbl_flownode.NodeType),
                new SqlParameter("@NodeUser",tbl_flownode.NodeUser),
                new SqlParameter("@NodeUserLimit",tbl_flownode.NodeUserLimit),
                new SqlParameter("@DealUser",tbl_flownode.DealUser),
                new SqlParameter("@DealTime",tbl_flownode.DealTime.ToString())
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_FlowNodeById(int ID)
        {

            string sql = "update from [Tbl_FlowNode] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_FlowNode GetTbl_FlowNodeById(int ID)
        {

            string sql = "select * from [Tbl_FlowNode] where DealFlag=0 and ID=" + ID;
            return getTbl_FlowNodeBySql(sql);

        }
        public IList<Tbl_FlowNode> GetTbl_FlowNodeAll()
        {
            string sql = "select * from [Tbl_FlowNode] where DealFlag=0";
            return getTbl_FlowNodesBySql(sql);
        }
        public IList<Tbl_FlowNode> GetTbl_FlowNodesByFlowID(int FlowID)
        {
            string sql = "select * from [Tbl_FlowNode] where DealFlag=0 and FlowID=" + FlowID+" order by NodeNo asc";
            return getTbl_FlowNodesBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_FlowNode> getTbl_FlowNodesBySql(string sql)
        {
            IList<Tbl_FlowNode> list = new List<Tbl_FlowNode>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_FlowNode tbl_flownode = new Tbl_FlowNode();
                    tbl_flownode.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flownode.FlowID = Convert.ToInt32(dr["FlowID"]);
                    tbl_flownode.NodeNo = Convert.ToString(dr["NodeNo"]);
                    tbl_flownode.NodeName = Convert.ToString(dr["NodeName"]);
                    tbl_flownode.NodeStage = Convert.ToString(dr["NodeStage"]);
                    tbl_flownode.NodeType = Convert.ToString(dr["NodeType"]);
                    tbl_flownode.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_flownode.NodeUserLimit = Convert.ToString(dr["NodeUserLimit"]);
                    tbl_flownode.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flownode.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flownode.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flownode.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_flownode);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_FlowNode getTbl_FlowNodeBySql(string sql)
        {
            Tbl_FlowNode tbl_flownode = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_flownode = new Tbl_FlowNode();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_flownode.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flownode.FlowID = Convert.ToInt32(dr["FlowID"]);
                    tbl_flownode.NodeNo = Convert.ToString(dr["NodeNo"]);
                    tbl_flownode.NodeName = Convert.ToString(dr["NodeName"]);
                    tbl_flownode.NodeStage = Convert.ToString(dr["NodeStage"]);
                    tbl_flownode.NodeType = Convert.ToString(dr["NodeType"]);
                    tbl_flownode.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_flownode.NodeUserLimit = Convert.ToString(dr["NodeUserLimit"]);
                    tbl_flownode.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_flownode.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flownode.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_flownode.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_flownode;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_FlowNode where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select FlowName from tbl_flow where id=Tbl_FlowNode.FlowID) as FlowName from Tbl_FlowNode where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
