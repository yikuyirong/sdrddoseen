using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectContractService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectContract(Tbl_ProjectContract tbl_projectcontract)
        {
            string sql = "insert into [Tbl_ProjectContract] ([ProjectID],[PC_Name],[PC_File],[PC_Price],[PC_MoneyReceive],[PC_MoneyBill],[PC_FeeType],[Status],[DealUser]) values (@ProjectID,@PC_Name,@PC_File,@PC_Price,@PC_MoneyReceive,@PC_MoneyBill,@PC_FeeType,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectcontract.ProjectID),
                 new SqlParameter("@PC_Name",tbl_projectcontract.PC_Name),
                new SqlParameter("@PC_File",tbl_projectcontract.PC_File),
                new SqlParameter("@PC_Price",tbl_projectcontract.PC_Price),
                new SqlParameter("@PC_MoneyReceive",tbl_projectcontract.PC_MoneyReceive),
                new SqlParameter("@PC_MoneyBill",tbl_projectcontract.PC_MoneyBill),
                new SqlParameter("@PC_FeeType",tbl_projectcontract.PC_FeeType),
                new SqlParameter("@Status",tbl_projectcontract.Status),
                new SqlParameter("@DealUser",tbl_projectcontract.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectContractById(Tbl_ProjectContract tbl_projectcontract)
        {

            string sql = "update [Tbl_ProjectContract] set [ProjectID]=@ProjectID,[PC_Name]=@PC_Name,[PC_File]=@PC_File,[PC_MoneyBill]=@PC_MoneyBill,[PC_MoneyReceive]=@PC_MoneyReceive,[PC_Price]=@PC_Price,[PC_FeeType]=@PC_FeeType,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectcontract.ID),
                new SqlParameter("@ProjectID",tbl_projectcontract.ProjectID),
                 new SqlParameter("@PC_Name",tbl_projectcontract.PC_Name),
                new SqlParameter("@PC_File",tbl_projectcontract.PC_File),
                new SqlParameter("@PC_Price",tbl_projectcontract.PC_Price),
                new SqlParameter("@PC_MoneyReceive",tbl_projectcontract.PC_MoneyReceive),
                new SqlParameter("@PC_MoneyBill",tbl_projectcontract.PC_MoneyBill),
                new SqlParameter("@PC_FeeType",tbl_projectcontract.PC_FeeType),
                new SqlParameter("@Status",tbl_projectcontract.Status),
                new SqlParameter("@DealUser",tbl_projectcontract.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectContractById(int ID)
        {

            string sql = "update from [Tbl_ProjectContract] set DealFlag=1 where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectContract GetTbl_ProjectContractById(int ID)
        {

            string sql = "select * from [Tbl_ProjectContract] where DealFlag=0 and  ID=" + ID;
            return getTbl_ProjectContractBySql(sql);

        }
        public IList<Tbl_ProjectContract> GetTbl_ProjectContractAll()
        {
            string sql = "select * from [Tbl_ProjectContract] where DealFlag=0";
            return getTbl_ProjectContractsBySql(sql);
        }
        public IList<Tbl_ProjectContract> GetTbl_ProjectContractProjectID(int ID)
        {
            string sql = "select * from [Tbl_ProjectContract] where DealFlag=0 and ProjectID=" + ID;
            return getTbl_ProjectContractsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectContract> getTbl_ProjectContractsBySql(string sql)
        {
            IList<Tbl_ProjectContract> list = new List<Tbl_ProjectContract>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectContract tbl_projectcontract = new Tbl_ProjectContract();
                    tbl_projectcontract.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectcontract.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectcontract.PC_Name = Convert.ToString(dr["PC_Name"]);
                    tbl_projectcontract.PC_File = Convert.ToString(dr["PC_File"]);
                    tbl_projectcontract.PC_Price = Convert.ToDouble(dr["PC_Price"]);
                    tbl_projectcontract.PC_MoneyReceive = Convert.ToDouble(dr["PC_MoneyReceive"]);
                    tbl_projectcontract.PC_MoneyBill = Convert.ToDouble(dr["PC_MoneyBill"]);
                    tbl_projectcontract.PC_FeeType = Convert.ToString(dr["PC_FeeType"]);
                    tbl_projectcontract.Status = Convert.ToString(dr["Status"]);
                    tbl_projectcontract.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectcontract.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectcontract.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectcontract.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectcontract);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectContract getTbl_ProjectContractBySql(string sql)
        {
            Tbl_ProjectContract tbl_projectcontract = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectcontract = new Tbl_ProjectContract();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectcontract.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectcontract.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectcontract.PC_Name = Convert.ToString(dr["PC_Name"]);
                    tbl_projectcontract.PC_File = Convert.ToString(dr["PC_File"]);
                    tbl_projectcontract.PC_Price = Convert.ToDouble(dr["PC_Price"]);
                    tbl_projectcontract.PC_MoneyReceive = Convert.ToDouble(dr["PC_MoneyReceive"]);
                    tbl_projectcontract.PC_MoneyBill = Convert.ToDouble(dr["PC_MoneyBill"]);
                    tbl_projectcontract.PC_FeeType = Convert.ToString(dr["PC_FeeType"]);
                    tbl_projectcontract.Status = Convert.ToString(dr["Status"]);
                    tbl_projectcontract.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectcontract.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectcontract.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectcontract.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectcontract;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectContract where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectContract.projectid) as ProjectName from Tbl_ProjectContract where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
