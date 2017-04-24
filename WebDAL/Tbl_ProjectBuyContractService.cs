using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectBuyContractService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectBuyContract(Tbl_ProjectBuyContract tbl_projectbuycontract)
        {
            string sql = "insert into [Tbl_ProjectBuyContract] ([ProjectID],[PBC_Company],[PBC_File],[PBC_Price],[PBC_FeeType],[Status],[DealUser]) values (@ProjectID,@PBC_Company,@PBC_File,@PBC_Price,@PBC_FeeType,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectbuycontract.ProjectID),
                new SqlParameter("@PBC_Company",tbl_projectbuycontract.PBC_Company),
                new SqlParameter("@PBC_File",tbl_projectbuycontract.PBC_File),
                new SqlParameter("@PBC_Price",tbl_projectbuycontract.PBC_Price),
                new SqlParameter("@PBC_FeeType",tbl_projectbuycontract.PBC_FeeType),
                new SqlParameter("@Status",tbl_projectbuycontract.Status),
                new SqlParameter("@DealUser",tbl_projectbuycontract.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectBuyContractById(Tbl_ProjectBuyContract tbl_projectbuycontract)
        {

            string sql = "update [Tbl_ProjectBuyContract] set [ProjectID]=@ProjectID,[PBC_Company]=@PBC_Company,[PBC_File]=@PBC_File,[PBC_Price]=@PBC_Price,[PBC_FeeType]=@PBC_FeeType,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectbuycontract.ID),
                new SqlParameter("@ProjectID",tbl_projectbuycontract.ProjectID),
                new SqlParameter("@PBC_Company",tbl_projectbuycontract.PBC_Company),
                new SqlParameter("@PBC_File",tbl_projectbuycontract.PBC_File),
                new SqlParameter("@PBC_Price",tbl_projectbuycontract.PBC_Price),
                new SqlParameter("@PBC_FeeType",tbl_projectbuycontract.PBC_FeeType),
                new SqlParameter("@Status",tbl_projectbuycontract.Status),
                new SqlParameter("@DealUser",tbl_projectbuycontract.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectBuyContractById(int ID)
        {

            string sql = "update from [Tbl_ProjectBuyContract] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectBuyContract GetTbl_ProjectBuyContractById(int ID)
        {

            string sql = "select * from [Tbl_ProjectBuyContract] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectBuyContractBySql(sql);

        }
        public IList<Tbl_ProjectBuyContract> GetTbl_ProjectBuyContractAll()
        {
            string sql = "select * from [Tbl_ProjectBuyContract] where DealFlag=0";
            return getTbl_ProjectBuyContractsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectBuyContract> getTbl_ProjectBuyContractsBySql(string sql)
        {
            IList<Tbl_ProjectBuyContract> list = new List<Tbl_ProjectBuyContract>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectBuyContract tbl_projectbuycontract = new Tbl_ProjectBuyContract();
                    tbl_projectbuycontract.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuycontract.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuycontract.PBC_Company = Convert.ToString(dr["PBC_Company"]);
                    tbl_projectbuycontract.PBC_File = Convert.ToString(dr["PBC_File"]);
                    tbl_projectbuycontract.PBC_Price = Convert.ToDouble(dr["PBC_Price"]);
                    tbl_projectbuycontract.PBC_FeeType = Convert.ToString(dr["PBC_FeeType"]);
                    tbl_projectbuycontract.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuycontract.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuycontract.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuycontract.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuycontract.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectbuycontract);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectBuyContract getTbl_ProjectBuyContractBySql(string sql)
        {
            Tbl_ProjectBuyContract tbl_projectbuycontract = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectbuycontract = new Tbl_ProjectBuyContract();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectbuycontract.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuycontract.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuycontract.PBC_Company = Convert.ToString(dr["PBC_Company"]);
                    tbl_projectbuycontract.PBC_File = Convert.ToString(dr["PBC_File"]);
                    tbl_projectbuycontract.PBC_Price = Convert.ToDouble(dr["PBC_Price"]);
                    tbl_projectbuycontract.PBC_FeeType = Convert.ToString(dr["PBC_FeeType"]);
                    tbl_projectbuycontract.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuycontract.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuycontract.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuycontract.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuycontract.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectbuycontract;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectBuyContract where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_ProjectBuyContract where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
