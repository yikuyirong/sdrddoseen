using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectBuyAcountService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectBuyAcount(Tbl_ProjectBuyAcount tbl_projectbuyacount)
        {
            string sql = "insert into [Tbl_ProjectBuyAcount] ([ProjectID],[PO_CompanyID],[PO_Content],[PO_StartTime],[PO_Time1],[PO_Time2],[PO_Link],[PO_File],[Remark],[PO_Price],[PO_FeeType],[Status],[DealUser]) values (@ProjectID,@PO_CompanyID,@PO_Content,@PO_StartTime,@PO_Time1,@PO_Time2,@PO_Link,@PO_File,@Remark,@PO_Price,@PO_FeeType,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectbuyacount.ProjectID),
                new SqlParameter("@PO_CompanyID",tbl_projectbuyacount.PO_CompanyID),
                new SqlParameter("@PO_Content",tbl_projectbuyacount.PO_Content),
                new SqlParameter("@PO_StartTime",tbl_projectbuyacount.PO_StartTime),
                new SqlParameter("@PO_Time1",tbl_projectbuyacount.PO_Time1),
                new SqlParameter("@PO_Time2",tbl_projectbuyacount.PO_Time2),
                new SqlParameter("@PO_Link",tbl_projectbuyacount.PO_Link),
                 new SqlParameter("@PO_File",tbl_projectbuyacount.PO_File),
                  new SqlParameter("@Remark",tbl_projectbuyacount.Remark),
                new SqlParameter("@PO_Price",tbl_projectbuyacount.PO_Price),
                new SqlParameter("@PO_FeeType",tbl_projectbuyacount.PO_FeeType),
                new SqlParameter("@Status",tbl_projectbuyacount.Status),
                new SqlParameter("@DealUser",tbl_projectbuyacount.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectBuyAcountById(Tbl_ProjectBuyAcount tbl_projectbuyacount)
        {
            string sql = "update [Tbl_ProjectBuyAcount] set [ProjectID]=@ProjectID,[PO_CompanyID]=@PO_CompanyID,[PO_Content]=@PO_Content,[PO_StartTime]=@PO_StartTime,[PO_Time1]=@PO_Time1,[PO_Time2]=@PO_Time2,[PO_Link]=@PO_Link,[PO_Price]=@PO_Price,[PO_FeeType]=@PO_FeeType,[Remark]=@Remark,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectbuyacount.ID),
                new SqlParameter("@ProjectID",tbl_projectbuyacount.ProjectID),
                new SqlParameter("@PO_CompanyID",tbl_projectbuyacount.PO_CompanyID),
                new SqlParameter("@PO_Content",tbl_projectbuyacount.PO_Content),
                new SqlParameter("@PO_StartTime",tbl_projectbuyacount.PO_StartTime),
                new SqlParameter("@PO_Time1",tbl_projectbuyacount.PO_Time1),
                new SqlParameter("@PO_Time2",tbl_projectbuyacount.PO_Time2),
                new SqlParameter("@PO_Link",tbl_projectbuyacount.PO_Link),
                 new SqlParameter("@PO_File",tbl_projectbuyacount.PO_File),
                  new SqlParameter("@Remark",tbl_projectbuyacount.Remark),
                new SqlParameter("@PO_Price",tbl_projectbuyacount.PO_Price),
                new SqlParameter("@PO_FeeType",tbl_projectbuyacount.PO_FeeType),
                new SqlParameter("@Status",tbl_projectbuyacount.Status),
                new SqlParameter("@DealUser",tbl_projectbuyacount.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectBuyAcountById(int ID)
        {

            string sql = "update from [Tbl_ProjectBuyAcount] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectBuyAcount GetTbl_ProjectBuyAcountById(int ID)
        {

            string sql = "select * from [Tbl_ProjectBuyAcount] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectBuyAcountBySql(sql);

        }
        public IList<Tbl_ProjectBuyAcount> GetTbl_ProjectBuyAcountAll()
        {
            string sql = "select * from [Tbl_ProjectBuyAcount] where DealFlag=0";
            return getTbl_ProjectBuyAcountsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectBuyAcount> getTbl_ProjectBuyAcountsBySql(string sql)
        {
            IList<Tbl_ProjectBuyAcount> list = new List<Tbl_ProjectBuyAcount>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectBuyAcount tbl_projectbuyacount = new Tbl_ProjectBuyAcount();
                    tbl_projectbuyacount.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuyacount.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuyacount.PO_CompanyID = Convert.ToInt32(dr["PO_CompanyID"]);
                    tbl_projectbuyacount.PO_Content = Convert.ToString(dr["PO_Content"]);
                    tbl_projectbuyacount.PO_StartTime = Convert.ToDateTime(dr["PO_StartTime"]);
                    tbl_projectbuyacount.PO_Time1 = Convert.ToDateTime(dr["PO_Time1"]);
                    tbl_projectbuyacount.PO_Time2 = Convert.ToDateTime(dr["PO_Time2"]);
                    tbl_projectbuyacount.PO_Link = Convert.ToString(dr["PO_Link"]);
                    tbl_projectbuyacount.PO_File = Convert.ToString(dr["PO_File"]);
                    tbl_projectbuyacount.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectbuyacount.PO_Price = Convert.ToDouble(dr["PO_Price"]);
                    tbl_projectbuyacount.PO_FeeType = Convert.ToString(dr["PO_FeeType"]);
                    tbl_projectbuyacount.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuyacount.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuyacount.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuyacount.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuyacount.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectbuyacount);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectBuyAcount getTbl_ProjectBuyAcountBySql(string sql)
        {
            Tbl_ProjectBuyAcount tbl_projectbuyacount = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectbuyacount = new Tbl_ProjectBuyAcount();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectbuyacount.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuyacount.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuyacount.PO_CompanyID = Convert.ToInt32(dr["PO_CompanyID"]);
                    tbl_projectbuyacount.PO_Content = Convert.ToString(dr["PO_Content"]);
                    tbl_projectbuyacount.PO_StartTime = Convert.ToDateTime(dr["PO_StartTime"]);
                    tbl_projectbuyacount.PO_Time1 = Convert.ToDateTime(dr["PO_Time1"]);
                    tbl_projectbuyacount.PO_Time2 = Convert.ToDateTime(dr["PO_Time2"]);
                    tbl_projectbuyacount.PO_Link = Convert.ToString(dr["PO_Link"]);
                    tbl_projectbuyacount.PO_File = Convert.ToString(dr["PO_File"]);
                    tbl_projectbuyacount.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectbuyacount.PO_Price = Convert.ToDouble(dr["PO_Price"]);
                    tbl_projectbuyacount.PO_FeeType = Convert.ToString(dr["PO_FeeType"]);
                    tbl_projectbuyacount.Status = Convert.ToString(dr["Status"]);
                    tbl_projectbuyacount.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuyacount.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuyacount.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuyacount.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectbuyacount;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectBuyAcount where DealFlag=0";
            if (Where != "") sql += " and "+Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectBuyAcount.ProjectID) as ProjectName from Tbl_ProjectBuyAcount where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
