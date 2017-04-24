using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectBuilderContractPayService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectBuilderContractPay(Tbl_ProjectBuilderContractPay tbl_projectbuildercontractpay)
        {
            string sql = "insert into [Tbl_ProjectBuilderContractPay] ([ProjectID],[ProjectBuilderContractID],[PBCP_Num],[PBCP_Money],[PBCP_Price],[Status],[DealUser]) values (@ProjectID,@ProjectBuilderContractID,@PBCP_Num,@PBCP_Money,@PBCP_Price,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectbuildercontractpay.ProjectID),
                new SqlParameter("@ProjectBuilderContractID",tbl_projectbuildercontractpay.ProjectBuilderContractID),
                new SqlParameter("@PBCP_Num",tbl_projectbuildercontractpay.PBCP_Num),
                new SqlParameter("@PBCP_Money",tbl_projectbuildercontractpay.PBCP_Money),
                new SqlParameter("@PBCP_Price",tbl_projectbuildercontractpay.PBCP_Price),
                new SqlParameter("@Status",tbl_projectbuildercontractpay.Status),
                new SqlParameter("@DealUser",tbl_projectbuildercontractpay.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectBuilderContractPayById(Tbl_ProjectBuilderContractPay tbl_projectbuildercontractpay)
        {

            string sql = "update [Tbl_ProjectBuilderContractPay] set [ProjectID]=@ProjectID,[ProjectBuilderContractID]=@ProjectBuilderContractID,[PBCP_Num]=@PBCP_Num,[PBCP_Money]=@PBCP_Money,[PBCP_Price]=@PBCP_Price,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectbuildercontractpay.ID),
                new SqlParameter("@ProjectID",tbl_projectbuildercontractpay.ProjectID),
                new SqlParameter("@ProjectBuilderContractID",tbl_projectbuildercontractpay.ProjectBuilderContractID),
                new SqlParameter("@PBCP_Num",tbl_projectbuildercontractpay.PBCP_Num),
                new SqlParameter("@PBCP_Money",tbl_projectbuildercontractpay.PBCP_Money),
                new SqlParameter("@PBCP_Price",tbl_projectbuildercontractpay.PBCP_Price),
                new SqlParameter("@Status",tbl_projectbuildercontractpay.Status),
                new SqlParameter("@DealUser",tbl_projectbuildercontractpay.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectBuilderContractPayById(int ID)
        {

            string sql = "update from [Tbl_ProjectBuilderContractPay] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectBuilderContractPay GetTbl_ProjectBuilderContractPayById(int ID)
        {

            string sql = "select * from [Tbl_ProjectBuilderContractPay] where DealFlag=0 and [DealFlag]=0 and ID=" + ID;
            return getTbl_ProjectBuilderContractPayBySql(sql);

        }
        public IList<Tbl_ProjectBuilderContractPay> GetTbl_ProjectBuilderContractPayAll()
        {
            string sql = "select * from [Tbl_ProjectBuilderContractPay] where DealFlag=0";
            return getTbl_ProjectBuilderContractPaysBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectBuilderContractPay> getTbl_ProjectBuilderContractPaysBySql(string sql)
        {
            IList<Tbl_ProjectBuilderContractPay> list = new List<Tbl_ProjectBuilderContractPay>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectBuilderContractPay tbl_projectbuildercontractpay = new Tbl_ProjectBuilderContractPay();
                    tbl_projectbuildercontractpay.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuildercontractpay.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuildercontractpay.ProjectBuilderContractID = Convert.ToInt32(dr["ProjectBuilderContractID"]);
                    tbl_projectbuildercontractpay.PBCP_Num = Convert.ToInt32(dr["PBCP_Num"]);
                    tbl_projectbuildercontractpay.PBCP_Money = Convert.ToDouble(dr["PBCP_Money"]);
                    tbl_projectbuildercontractpay.PBCP_Price = Convert.ToDouble(dr["PBCP_Price"]);
                    tbl_projectbuildercontractpay.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuildercontractpay.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuildercontractpay.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuildercontractpay.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuildercontractpay.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectbuildercontractpay);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectBuilderContractPay getTbl_ProjectBuilderContractPayBySql(string sql)
        {
            Tbl_ProjectBuilderContractPay tbl_projectbuildercontractpay = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectbuildercontractpay = new Tbl_ProjectBuilderContractPay();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectbuildercontractpay.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuildercontractpay.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuildercontractpay.ProjectBuilderContractID = Convert.ToInt32(dr["ProjectBuilderContractID"]);
                    tbl_projectbuildercontractpay.PBCP_Num = Convert.ToInt32(dr["PBCP_Num"]);
                    tbl_projectbuildercontractpay.PBCP_Money = Convert.ToDouble(dr["PBCP_Money"]);
                    tbl_projectbuildercontractpay.PBCP_Price = Convert.ToDouble(dr["PBCP_Price"]);
                    tbl_projectbuildercontractpay.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuildercontractpay.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuildercontractpay.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuildercontractpay.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuildercontractpay.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectbuildercontractpay;
        }
    }
}
