using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_FlowService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Flow(Tbl_Flow tbl_flow)
        {
            string sql = "insert into [Tbl_Flow] ([FlowName],[FormID],[FormContent],[FlowType],[Remark],[DealUser]) values (@FlowName,@FormID,@FormContent,@FlowType,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@FlowName",tbl_flow.FlowName),
                new SqlParameter("@FormID",tbl_flow.FormID),
                new SqlParameter("@FormContent",tbl_flow.FormContent),
                new SqlParameter("@FlowType",tbl_flow.FlowType),
                new SqlParameter("@Remark",tbl_flow.Remark),
                new SqlParameter("@DealUser",tbl_flow.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_FlowById(Tbl_Flow tbl_flow)
        {

            string sql = "update [Tbl_Flow] set [FlowName]=@FlowName,[FormID]=@FormID,[FormContent]=@FormContent,[FlowType]=@FlowType,[Remark]=@Remark,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_flow.ID),
                new SqlParameter("@FlowName",tbl_flow.FlowName),
                new SqlParameter("@FormID",tbl_flow.FormID),
                new SqlParameter("@FormContent",tbl_flow.FormContent),
                new SqlParameter("@FlowType",tbl_flow.FlowType),
                new SqlParameter("@Remark",tbl_flow.Remark),
                new SqlParameter("@DealUser",tbl_flow.DealUser),
                new SqlParameter("@DealTime",tbl_flow.DealTime.ToString())
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_FlowById(int ID)
        {

            string sql = "update from [Tbl_Flow] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_Flow GetTbl_FlowById(int ID)
        {

            string sql = "select * from [Tbl_Flow] where DealFlag=0 and ID=" + ID;
            return getTbl_FlowBySql(sql);

        }
        public IList<Tbl_Flow> GetTbl_FlowType(string Type)
        {
            string sql = "select * from [Tbl_Flow] where DealFlag=0 and FlowType='" + Type + "'";
            return getTbl_FlowsBySql(sql);
        }
        public IList<Tbl_Flow> GetTbl_FlowAll()
        {
            string sql = "select * from [Tbl_Flow] where DealFlag=0";
            return getTbl_FlowsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_Flow> getTbl_FlowsBySql(string sql)
        {
            IList<Tbl_Flow> list = new List<Tbl_Flow>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Flow tbl_flow = new Tbl_Flow();
                    tbl_flow.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flow.FlowName = Convert.ToString(dr["FlowName"]);
                    tbl_flow.FormID = Convert.ToInt32(dr["FormID"]);
                    tbl_flow.FormContent = Convert.ToString(dr["FormContent"]);
                    tbl_flow.FlowType = Convert.ToString(dr["FlowType"]);
                    tbl_flow.Remark = Convert.ToString(dr["Remark"]);
                    tbl_flow.DealFlag = Convert.ToString(dr["DealFlag"]);
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
        private Tbl_Flow getTbl_FlowBySql(string sql)
        {
            Tbl_Flow tbl_flow = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_flow = new Tbl_Flow();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_flow.ID = Convert.ToInt32(dr["ID"]);
                    tbl_flow.FlowName = Convert.ToString(dr["FlowName"]);
                    tbl_flow.FormID = Convert.ToInt32(dr["FormID"]);
                    tbl_flow.FormContent = Convert.ToString(dr["FormContent"]);
                    tbl_flow.FlowType = Convert.ToString(dr["FlowType"]);
                    tbl_flow.Remark = Convert.ToString(dr["Remark"]);
                    tbl_flow.DealFlag = Convert.ToString(dr["DealFlag"]);
                    tbl_flow.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_flow.DealTime = Convert.ToDateTime(dr["DealTime"]);
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
            string sql = "select count(*) from Tbl_Flow where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_Flow where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
