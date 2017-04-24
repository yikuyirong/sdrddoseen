using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_PlanManageService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
		public int AddTbl_PlanManage(Tbl_PlanManage tbl_planmanage)
        {
            string Sql = "insert into [Tbl_PlanManage] ([PlanDate],[PlanContent],[NodeUser],[Status],[DealUser],[DealFlag],[DealTime],[AddDate]) values (@PlanDate,@PlanContent,@NodeUser,@Status,@DealUser,@DealFlag,@DealTime,@AddDate)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@PlanDate",tbl_planmanage.PlanDate),
                new SqlParameter("@PlanContent",tbl_planmanage.PlanContent),
                new SqlParameter("@NodeUser",tbl_planmanage.NodeUser),
                new SqlParameter("@Status",tbl_planmanage.Status),
                new SqlParameter("@DealUser",tbl_planmanage.DealUser),
                new SqlParameter("@DealFlag",tbl_planmanage.DealFlag),
                new SqlParameter("@DealTime",tbl_planmanage.DealTime),
                new SqlParameter("@AddDate",tbl_planmanage.AddDate)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
        }

        public int UpdateTbl_PlanManageById(Tbl_PlanManage tbl_planmanage)
        {

            string Sql = "update [Tbl_PlanManage] set [PlanDate]=@PlanDate,[PlanContent]=@PlanContent,[NodeUser]=@NodeUser,[Status]=@Status,[DealUser]=@DealUser,[DealFlag]=@DealFlag,[DealTime]=@DealTime,[AddDate]=@AddDate where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@PlanDate",tbl_planmanage.PlanDate),
                new SqlParameter("@PlanContent",tbl_planmanage.PlanContent),
                new SqlParameter("@NodeUser",tbl_planmanage.NodeUser),
                new SqlParameter("@Status",tbl_planmanage.Status),
                new SqlParameter("@DealUser",tbl_planmanage.DealUser),
                new SqlParameter("@DealFlag",tbl_planmanage.DealFlag),
                new SqlParameter("@DealTime",tbl_planmanage.DealTime),
                new SqlParameter("@AddDate",tbl_planmanage.AddDate),
                new SqlParameter("@ID",tbl_planmanage.ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
            
        }

        public int DeleteTbl_PlanManageById(int ID)
        {
            
            string Sql="update [Tbl_PlanManage] set [DealFlag]=1 where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
            
        }

        public Tbl_PlanManage GetTbl_PlanManageById(int ID)
        {
            
            string Sql="select * from [Tbl_PlanManage] where [DealFlag]=0 and ID="+ID;
            return getTbl_PlanManageBySql(Sql);
            
        }

        public IList<Tbl_PlanManage> GetTbl_PlanManageAll()
        {
            string Sql="select * from [Tbl_PlanManage] where [DealFlag]=0";
            return getTbl_PlanManagesBySql(Sql);
        }

		/// <summary>
        ///根据Sql语句返回集合
        /// </summary>
        private IList<Tbl_PlanManage> getTbl_PlanManagesBySql(string Sql)
        {
            IList<Tbl_PlanManage> list = new List<Tbl_PlanManage>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_PlanManage tbl_planmanage = new Tbl_PlanManage();
                    tbl_planmanage.ID = Convert.ToInt32(dr["ID"]);
                    tbl_planmanage.PlanDate = Convert.ToString(dr["PlanDate"]);
                    tbl_planmanage.PlanContent = Convert.ToString(dr["PlanContent"]);
                    tbl_planmanage.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_planmanage.Status = Convert.ToString(dr["Status"]);
                    tbl_planmanage.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_planmanage.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_planmanage.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_planmanage.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_planmanage);
                }
            }
            return list;
        }

        /// <summary>
        ///根据Sql语句获取实体
        /// </summary>
        private Tbl_PlanManage getTbl_PlanManageBySql(string Sql)
        {
            Tbl_PlanManage tbl_planmanage = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_planmanage = new Tbl_PlanManage();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_planmanage.ID = Convert.ToInt32(dr["ID"]);
                    tbl_planmanage.PlanDate = Convert.ToString(dr["PlanDate"]);
                    tbl_planmanage.PlanContent = Convert.ToString(dr["PlanContent"]);
                    tbl_planmanage.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_planmanage.Status = Convert.ToString(dr["Status"]);
                    tbl_planmanage.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_planmanage.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_planmanage.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_planmanage.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_planmanage;
        }

        /// <summary>
        /// 根据条件返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string Sql = "select count(*) from Tbl_PlanManage where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, Sql);
            return RecordNum;
        }

        /// <summary>
        /// 返回条件返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string Sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_PlanManage where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            if (Order != "") Sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, Sql, startRecord, endRecord);
            return dt;
        }

    }
}
