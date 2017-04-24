using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectContractPayService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectContractPay(Tbl_ProjectContractPay tbl_projectcontractpay)
        {
            string sql = "insert into [Tbl_ProjectContractPay] ([ProjectID],[ProjectContractID],[PCP_Num],[PCP_MoneyTime],[PCP_Money],[PCP_Price],[PCP_Type],[Status],[DealUser]) values (@ProjectID,@ProjectContractID,@PCP_Num,@PCP_MoneyTime,@PCP_Money,@PCP_Price,@PCP_Type,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectcontractpay.ProjectID),
                new SqlParameter("@ProjectContractID",tbl_projectcontractpay.ProjectContractID),
                new SqlParameter("@PCP_Num",tbl_projectcontractpay.PCP_Num),
                new SqlParameter("@PCP_MoneyTime",tbl_projectcontractpay.PCP_MoneyTime),
                new SqlParameter("@PCP_Money",tbl_projectcontractpay.PCP_Money),
                new SqlParameter("@PCP_Price",tbl_projectcontractpay.PCP_Price),
                new SqlParameter("@PCP_Type",tbl_projectcontractpay.PCP_Type),
                new SqlParameter("@Status",tbl_projectcontractpay.Status),
                 new SqlParameter("@DealUser",tbl_projectcontractpay.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectContractPayById(Tbl_ProjectContractPay tbl_projectcontractpay)
        {
            string sql = "update [Tbl_ProjectContractPay] set [ProjectID]=@ProjectID,[ProjectContractID]=@ProjectContractID,[PCP_Num]=@PCP_Num,[PCP_MoneyTime]=@PCP_MoneyTime,[PCP_Money]=@PCP_Money,[PCP_Price]=@PCP_Price,[PCP_Type]=@PCP_Type,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectcontractpay.ID),
                new SqlParameter("@ProjectID",tbl_projectcontractpay.ProjectID),
                new SqlParameter("@Alert",tbl_projectcontractpay.Alert),
                new SqlParameter("@ProjectContractID",tbl_projectcontractpay.ProjectContractID),
                new SqlParameter("@PCP_Num",tbl_projectcontractpay.PCP_Num),
                new SqlParameter("@PCP_MoneyTime",tbl_projectcontractpay.PCP_MoneyTime),
                new SqlParameter("@PCP_Money",tbl_projectcontractpay.PCP_Money),
                new SqlParameter("@PCP_Price",tbl_projectcontractpay.PCP_Price),
                new SqlParameter("@PCP_Type",tbl_projectcontractpay.PCP_Type),
                new SqlParameter("@Status",tbl_projectcontractpay.Status),
                new SqlParameter("@DealUser",tbl_projectcontractpay.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectContractPayById(int ID)
        {

            string sql = "update from [Tbl_ProjectContractPay] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectContractPay GetTbl_ProjectContractPayById(int ID)
        {

            string sql = "select * from [Tbl_ProjectContractPay] where DealFlag=0 and  ID=" + ID;
            return getTbl_ProjectContractPayBySql(sql);

        }
        public IList<Tbl_ProjectContractPay> GetTbl_ProjectContractPayAll()
        {
            string sql = "select * from [Tbl_ProjectContractPay] where DealFlag=0";
            return getTbl_ProjectContractPaysBySql(sql);
        }
        public IList<Tbl_ProjectContractPay> GetTbl_ProjectContractPayProjectID(int ID)
        {
            string sql = "select * from [Tbl_ProjectContractPay] where DealFlag=0 and ProjectID=" + ID;
            return getTbl_ProjectContractPaysBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectContractPay> getTbl_ProjectContractPaysBySql(string sql)
        {
            IList<Tbl_ProjectContractPay> list = new List<Tbl_ProjectContractPay>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectContractPay tbl_projectcontractpay = new Tbl_ProjectContractPay();
                    tbl_projectcontractpay.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectcontractpay.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectcontractpay.ProjectContractID = Convert.ToInt32(dr["ProjectContractID"]);
                    tbl_projectcontractpay.PCP_Num = Convert.ToInt32(dr["PCP_Num"]);
                    tbl_projectcontractpay.PCP_MoneyTime = Convert.ToString(dr["PCP_MoneyTime"]);
                    tbl_projectcontractpay.PCP_Money = Convert.ToDouble(dr["PCP_Money"]);
                    tbl_projectcontractpay.PCP_Price = Convert.ToDouble(dr["PCP_Price"]);
                    tbl_projectcontractpay.PCP_Type = Convert.ToString(dr["PCP_Type"]);
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
        private Tbl_ProjectContractPay getTbl_ProjectContractPayBySql(string sql)
        {
            Tbl_ProjectContractPay tbl_projectcontractpay = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectcontractpay = new Tbl_ProjectContractPay();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectcontractpay.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectcontractpay.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectcontractpay.ProjectContractID = Convert.ToInt32(dr["ProjectContractID"]);
                    tbl_projectcontractpay.PCP_Num = Convert.ToInt32(dr["PCP_Num"]);
                    tbl_projectcontractpay.PCP_MoneyTime = Convert.ToString(dr["PCP_MoneyTime"]);
                    tbl_projectcontractpay.PCP_Money = Convert.ToDouble(dr["PCP_Money"]);
                    tbl_projectcontractpay.PCP_Price = Convert.ToDouble(dr["PCP_Price"]);
                    tbl_projectcontractpay.PCP_Type = Convert.ToString(dr["PCP_Type"]);
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
        /// 返回工作量统计
        /// </summary>
        public System.Data.DataTable GetDataTableByStatistics(string Where)
        {
            string sql = "select Tbl_ProjectContractPay.*,tbl_project.ProjectName from Tbl_ProjectContractPay left join tbl_project on tbl_project.id=Tbl_ProjectContractPay.projectid  where Tbl_ProjectContractPay.DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            sql = "select isnull(sum(pcp_money),0) from (" + sql + ") as tbl";
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select Tbl_ProjectContractPay.*,tbl_project.ProjectName from Tbl_ProjectContractPay left join tbl_project on tbl_project.id=Tbl_ProjectContractPay.projectid  where Tbl_ProjectContractPay.DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            sql = "select count(*) from (" + sql + ") as tbl";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select Tbl_ProjectContractPay.*,tbl_project.ProjectName from Tbl_ProjectContractPay left join tbl_project on tbl_project.id=Tbl_ProjectContractPay.projectid  where Tbl_ProjectContractPay.DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
