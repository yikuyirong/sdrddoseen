using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectOuterPayService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectOuterPay(Tbl_ProjectOuterPay tbl_projectcontractpay)
        {
            string sql = "insert into [Tbl_ProjectOuterPay] ([ProjectID],[ProjectOuterID],[POP_Num],[POP_MoneyTime],[POP_Money],[POP_Price],[POP_Type],[Status],[DealUser]) values (@ProjectID,@ProjectOuterID,@POP_Num,@POP_MoneyTime,@POP_Money,@POP_Price,@POP_Type,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectcontractpay.ProjectID),
                new SqlParameter("@ProjectOuterID",tbl_projectcontractpay.ProjectOuterID),
                new SqlParameter("@POP_Num",tbl_projectcontractpay.POP_Num),
                new SqlParameter("@POP_MoneyTime",tbl_projectcontractpay.POP_MoneyTime),
                new SqlParameter("@POP_Money",tbl_projectcontractpay.POP_Money),
                new SqlParameter("@POP_Price",tbl_projectcontractpay.POP_Price),
                new SqlParameter("@POP_Type",tbl_projectcontractpay.POP_Type),
                new SqlParameter("@Status",tbl_projectcontractpay.Status),
                 new SqlParameter("@DealUser",tbl_projectcontractpay.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectOuterPayById(Tbl_ProjectOuterPay tbl_projectcontractpay)
        {
            string sql = "update [Tbl_ProjectOuterPay] set [ProjectID]=@ProjectID,[ProjectOuterID]=@ProjectOuterID,[POP_Num]=@POP_Num,[POP_MoneyTime]=@POP_MoneyTime,[POP_Money]=@POP_Money,[POP_Price]=@POP_Price,[POP_Type]=@POP_Type,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectcontractpay.ID),
                new SqlParameter("@ProjectID",tbl_projectcontractpay.ProjectID),
                new SqlParameter("@Alert",tbl_projectcontractpay.Alert),
                new SqlParameter("@ProjectOuterID",tbl_projectcontractpay.ProjectOuterID),
                new SqlParameter("@POP_Num",tbl_projectcontractpay.POP_Num),
                new SqlParameter("@POP_MoneyTime",tbl_projectcontractpay.POP_MoneyTime),
                new SqlParameter("@POP_Money",tbl_projectcontractpay.POP_Money),
                new SqlParameter("@POP_Price",tbl_projectcontractpay.POP_Price),
                new SqlParameter("@POP_Type",tbl_projectcontractpay.POP_Type),
                new SqlParameter("@Status",tbl_projectcontractpay.Status),
                new SqlParameter("@DealUser",tbl_projectcontractpay.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectOuterPayById(int ID)
        {

            string sql = "update from [Tbl_ProjectOuterPay] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectOuterPay GetTbl_ProjectOuterPayById(int ID)
        {

            string sql = "select * from [Tbl_ProjectOuterPay] where DealFlag=0 and  ID=" + ID;
            return getTbl_ProjectOuterPayBySql(sql);

        }
        public IList<Tbl_ProjectOuterPay> GetTbl_ProjectOuterPayAll()
        {
            string sql = "select * from [Tbl_ProjectOuterPay] where DealFlag=0";
            return getTbl_ProjectOuterPaysBySql(sql);
        }
        public IList<Tbl_ProjectOuterPay> GetTbl_ProjectOuterPayProjectID(int ID)
        {
            string sql = "select * from [Tbl_ProjectOuterPay] where DealFlag=0 and ProjectID=" + ID;
            return getTbl_ProjectOuterPaysBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectOuterPay> getTbl_ProjectOuterPaysBySql(string sql)
        {
            IList<Tbl_ProjectOuterPay> list = new List<Tbl_ProjectOuterPay>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectOuterPay tbl_projectcontractpay = new Tbl_ProjectOuterPay();
                    tbl_projectcontractpay.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectcontractpay.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectcontractpay.ProjectOuterID = Convert.ToInt32(dr["ProjectOuterID"]);
                    tbl_projectcontractpay.POP_Num = Convert.ToInt32(dr["POP_Num"]);
                    tbl_projectcontractpay.POP_MoneyTime = Convert.ToString(dr["POP_MoneyTime"]);
                    tbl_projectcontractpay.POP_Money = Convert.ToDouble(dr["POP_Money"]);
                    tbl_projectcontractpay.POP_Price = Convert.ToDouble(dr["POP_Price"]);
                    tbl_projectcontractpay.POP_Type = Convert.ToString(dr["POP_Type"]);
                    tbl_projectcontractpay.Status = Convert.ToString(dr["Status"]);
                    tbl_projectcontractpay.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectcontractpay.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectcontractpay.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectcontractpay.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectcontractpay);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectOuterPay getTbl_ProjectOuterPayBySql(string sql)
        {
            Tbl_ProjectOuterPay tbl_projectcontractpay = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectcontractpay = new Tbl_ProjectOuterPay();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectcontractpay.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectcontractpay.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectcontractpay.ProjectOuterID = Convert.ToInt32(dr["ProjectOuterID"]);
                    tbl_projectcontractpay.POP_Num = Convert.ToInt32(dr["POP_Num"]);
                    tbl_projectcontractpay.POP_MoneyTime = Convert.ToString(dr["POP_MoneyTime"]);
                    tbl_projectcontractpay.POP_Money = Convert.ToDouble(dr["POP_Money"]);
                    tbl_projectcontractpay.POP_Price = Convert.ToDouble(dr["POP_Price"]);
                    tbl_projectcontractpay.POP_Type = Convert.ToString(dr["POP_Type"]);
                    tbl_projectcontractpay.Alert = Convert.ToInt32(dr["Alert"]);
                    tbl_projectcontractpay.Status = Convert.ToString(dr["Status"]);
                    tbl_projectcontractpay.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectcontractpay.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectcontractpay.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectcontractpay.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectcontractpay;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectOuterPay where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectOuterPay.projectid) as ProjectName,(select PO_Name from tbl_projectouter where id=Tbl_ProjectOuterPay.ProjectOuterID) as PO_Name from Tbl_ProjectOuterPay  where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
