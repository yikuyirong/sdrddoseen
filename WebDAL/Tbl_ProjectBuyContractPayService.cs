using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectBuyContractPayService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectBuyContractPay(Tbl_ProjectBuyContractPay tbl_projectbuycontractpay)
        {
            string sql = "insert into [Tbl_ProjectBuyContractPay] ([ProjectBuyContractID],[PayNum],[PayMoney],[PayPrice],[Status],[DealUser]) values (@ProjectBuyContractID,@PayNum,@PayMoney,@PayPrice,@Status,[DealUser])";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectBuyContractID",tbl_projectbuycontractpay.ProjectBuyContractID),
                new SqlParameter("@PayNum",tbl_projectbuycontractpay.PayNum),
                new SqlParameter("@PayMoney",tbl_projectbuycontractpay.PayMoney),
                new SqlParameter("@PayPrice",tbl_projectbuycontractpay.PayPrice),
                new SqlParameter("@Status",tbl_projectbuycontractpay.Status),
                 new SqlParameter("@DealUser",tbl_projectbuycontractpay.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectBuyContractPayById(Tbl_ProjectBuyContractPay tbl_projectbuycontractpay)
        {

            string sql = "update [Tbl_ProjectBuyContractPay] set [ProjectBuyContractID]=@ProjectBuyContractID,[PayNum]=@PayNum,[PayMoney]=@PayMoney,[PayPrice]=@PayPrice,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectbuycontractpay.ID),
                new SqlParameter("@ProjectBuyContractID",tbl_projectbuycontractpay.ProjectBuyContractID),
                new SqlParameter("@PayNum",tbl_projectbuycontractpay.PayNum),
                new SqlParameter("@PayMoney",tbl_projectbuycontractpay.PayMoney),
                new SqlParameter("@PayPrice",tbl_projectbuycontractpay.PayPrice),
                new SqlParameter("@Status",tbl_projectbuycontractpay.Status),
                new SqlParameter("@DealUser",tbl_projectbuycontractpay.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectBuyContractPayById(int ID)
        {

            string sql = "update from [Tbl_ProjectBuyContractPay] set DealFlag=1 where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectBuyContractPay GetTbl_ProjectBuyContractPayById(int ID)
        {

            string sql = "select * from [Tbl_ProjectBuyContractPay] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectBuyContractPayBySql(sql);

        }
        public IList<Tbl_ProjectBuyContractPay> GetTbl_ProjectBuyContractPayAll()
        {
            string sql = "select * from [Tbl_ProjectBuyContractPay] where DealFlag=0";
            return getTbl_ProjectBuyContractPaysBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectBuyContractPay> getTbl_ProjectBuyContractPaysBySql(string sql)
        {
            IList<Tbl_ProjectBuyContractPay> list = new List<Tbl_ProjectBuyContractPay>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectBuyContractPay tbl_projectbuycontractpay = new Tbl_ProjectBuyContractPay();
                    tbl_projectbuycontractpay.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuycontractpay.ProjectBuyContractID = Convert.ToInt32(dr["ProjectBuyContractID"]);
                    tbl_projectbuycontractpay.PayNum = Convert.ToInt32(dr["PayNum"]);
                    tbl_projectbuycontractpay.PayMoney = Convert.ToDouble(dr["PayMoney"]);
                    tbl_projectbuycontractpay.PayPrice = Convert.ToDouble(dr["PayPrice"]);
                    tbl_projectbuycontractpay.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuycontractpay.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuycontractpay.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuycontractpay.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuycontractpay.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectbuycontractpay);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectBuyContractPay getTbl_ProjectBuyContractPayBySql(string sql)
        {
            Tbl_ProjectBuyContractPay tbl_projectbuycontractpay = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectbuycontractpay = new Tbl_ProjectBuyContractPay();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectbuycontractpay.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuycontractpay.ProjectBuyContractID = Convert.ToInt32(dr["ProjectBuyContractID"]);
                    tbl_projectbuycontractpay.PayNum = Convert.ToInt32(dr["PayNum"]);
                    tbl_projectbuycontractpay.PayMoney = Convert.ToDouble(dr["PayMoney"]);
                    tbl_projectbuycontractpay.PayPrice = Convert.ToDouble(dr["PayPrice"]);
                    tbl_projectbuycontractpay.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuycontractpay.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuycontractpay.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuycontractpay.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectbuycontractpay.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_projectbuycontractpay;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectBuyContractPay where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_ProjectBuyContractPay where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
