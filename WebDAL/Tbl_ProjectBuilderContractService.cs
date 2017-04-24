using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectBuilderContractService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectBuilderContract(Tbl_ProjectBuilderContract tbl_projectbuildercontract)
        {
            string sql = "insert into [Tbl_ProjectBuilderContract] ([ProjectID],[PBC_CompanyID],[PBC_StartTime],[PBC_Time1],[PBC_Time2],[PBC_Link],[PBC_LinkPhone],[PBC_Content],[Remark],[PBC_File],[PBC_Price],[PBC_FeeType],[Status],[DealUser]) values (@ProjectID,@PBC_CompanyID,@PBC_StartTime,@PBC_Time1,@PBC_Time2,@PBC_Link,@PBC_LinkPhone,@PBC_Content,@Remark,@PBC_File,@PBC_Price,@PBC_FeeType,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectbuildercontract.ProjectID),
                new SqlParameter("@PBC_CompanyID",tbl_projectbuildercontract.PBC_CompanyID),
                 new SqlParameter("@PBC_StartTime",tbl_projectbuildercontract.PBC_StartTime),
                  new SqlParameter("@PBC_Time1",tbl_projectbuildercontract.PBC_Time1),
                   new SqlParameter("@PBC_Time2",tbl_projectbuildercontract.PBC_Time2),
                    new SqlParameter("@PBC_Link",tbl_projectbuildercontract.PBC_Link),
                    new SqlParameter("@PBC_LinkPhone",tbl_projectbuildercontract.PBC_LinkPhone),
                     new SqlParameter("@PBC_Content",tbl_projectbuildercontract.PBC_Content),
                      new SqlParameter("@Remark",tbl_projectbuildercontract.Remark),
                new SqlParameter("@PBC_File",tbl_projectbuildercontract.PBC_File),
                new SqlParameter("@PBC_Price",tbl_projectbuildercontract.PBC_Price),
                new SqlParameter("@PBC_FeeType",tbl_projectbuildercontract.PBC_FeeType),
                new SqlParameter("@Status",tbl_projectbuildercontract.Status),
                new SqlParameter("@DealUser",tbl_projectbuildercontract.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectBuilderContractById(Tbl_ProjectBuilderContract tbl_projectbuildercontract)
        {

            string sql = "update [Tbl_ProjectBuilderContract] set [ProjectID]=@ProjectID,[PBC_CompanyID]=@PBC_CompanyID,[PBC_StartTime]=@PBC_StartTime,[PBC_Time1]=@PBC_Time1,[PBC_Time2]=@PBC_Time2,[PBC_Link]=@PBC_Link,[PBC_LinkPhone]=@PBC_LinkPhone,[PBC_Content]=@PBC_Content,[Remark]=@Remark,[PBC_File]=@PBC_File,[PBC_Price]=@PBC_Price,[PBC_FeeType]=@PBC_FeeType,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectbuildercontract.ID),
                new SqlParameter("@ProjectID",tbl_projectbuildercontract.ProjectID),
                new SqlParameter("@PBC_CompanyID",tbl_projectbuildercontract.PBC_CompanyID),
                 new SqlParameter("@PBC_StartTime",tbl_projectbuildercontract.PBC_StartTime),
                  new SqlParameter("@PBC_Time1",tbl_projectbuildercontract.PBC_Time1),
                   new SqlParameter("@PBC_Time2",tbl_projectbuildercontract.PBC_Time2),
                    new SqlParameter("@PBC_Link",tbl_projectbuildercontract.PBC_Link),
                    new SqlParameter("@PBC_LinkPhone",tbl_projectbuildercontract.PBC_LinkPhone),
                     new SqlParameter("@PBC_Content",tbl_projectbuildercontract.PBC_Content),
                      new SqlParameter("@Remark",tbl_projectbuildercontract.Remark),
                new SqlParameter("@PBC_File",tbl_projectbuildercontract.PBC_File),
                new SqlParameter("@PBC_Price",tbl_projectbuildercontract.PBC_Price),
                new SqlParameter("@PBC_FeeType",tbl_projectbuildercontract.PBC_FeeType),
                new SqlParameter("@Status",tbl_projectbuildercontract.Status),
                new SqlParameter("@DealUser",tbl_projectbuildercontract.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectBuilderContractById(int ID)
        {

            string sql = "update from [Tbl_ProjectBuilderContract] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectBuilderContract GetTbl_ProjectBuilderContractById(int ID)
        {

            string sql = "select * from [Tbl_ProjectBuilderContract] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectBuilderContractBySql(sql);

        }
        public IList<Tbl_ProjectBuilderContract> GetTbl_ProjectBuilderContractAll()
        {
            string sql = "select * from [Tbl_ProjectBuilderContract] where DealFlag=0";
            return getTbl_ProjectBuilderContractsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectBuilderContract> getTbl_ProjectBuilderContractsBySql(string sql)
        {
            IList<Tbl_ProjectBuilderContract> list = new List<Tbl_ProjectBuilderContract>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectBuilderContract tbl_projectbuildercontract = new Tbl_ProjectBuilderContract();
                    tbl_projectbuildercontract.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuildercontract.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuildercontract.PBC_CompanyID = Convert.ToInt32(dr["PBC_CompanyID"]);
                    tbl_projectbuildercontract.PBC_StartTime = Convert.ToDateTime(dr["PBC_StartTime"]);
                    tbl_projectbuildercontract.PBC_Time1 = Convert.ToDateTime(dr["PBC_Time1"]);
                    tbl_projectbuildercontract.PBC_Time2 = Convert.ToDateTime(dr["PBC_Time2"]);
                    tbl_projectbuildercontract.PBC_Link = Convert.ToString(dr["PBC_Link"]);
                    tbl_projectbuildercontract.PBC_LinkPhone = Convert.ToString(dr["PBC_LinkPhone"]);
                    tbl_projectbuildercontract.PBC_Content = Convert.ToString(dr["PBC_Content"]);
                    tbl_projectbuildercontract.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectbuildercontract.PBC_File = Convert.ToString(dr["PBC_File"]);
                    tbl_projectbuildercontract.PBC_Price = Convert.ToDouble(dr["PBC_Price"]);
                    tbl_projectbuildercontract.PBC_FeeType = Convert.ToString(dr["PBC_FeeType"]);
                    tbl_projectbuildercontract.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuildercontract.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuildercontract.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuildercontract.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuildercontract.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectbuildercontract);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectBuilderContract getTbl_ProjectBuilderContractBySql(string sql)
        {
            Tbl_ProjectBuilderContract tbl_projectbuildercontract = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectbuildercontract = new Tbl_ProjectBuilderContract();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectbuildercontract.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuildercontract.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuildercontract.PBC_CompanyID = Convert.ToInt32(dr["PBC_CompanyID"]);
                    tbl_projectbuildercontract.PBC_StartTime = Convert.ToDateTime(dr["PBC_StartTime"]);
                    tbl_projectbuildercontract.PBC_Time1 = Convert.ToDateTime(dr["PBC_Time1"]);
                    tbl_projectbuildercontract.PBC_Time2 = Convert.ToDateTime(dr["PBC_Time2"]);
                    tbl_projectbuildercontract.PBC_Link = Convert.ToString(dr["PBC_Link"]);
                    tbl_projectbuildercontract.PBC_LinkPhone = Convert.ToString(dr["PBC_LinkPhone"]);
                    tbl_projectbuildercontract.PBC_Content = Convert.ToString(dr["PBC_Content"]);
                    tbl_projectbuildercontract.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectbuildercontract.PBC_File = Convert.ToString(dr["PBC_File"]);
                    tbl_projectbuildercontract.PBC_Price = Convert.ToDouble(dr["PBC_Price"]);
                    tbl_projectbuildercontract.PBC_FeeType = Convert.ToString(dr["PBC_FeeType"]);
                    tbl_projectbuildercontract.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuildercontract.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuildercontract.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuildercontract.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuildercontract.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectbuildercontract;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectBuilderContract where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectBuilderContract.ProjectID) as ProjectName,(select POC_Name from tbl_projectBuilder where id=Tbl_ProjectBuilderContract.ProjectID) as POC_Name from Tbl_ProjectBuilderContract where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
