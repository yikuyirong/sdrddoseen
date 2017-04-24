using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectOuterService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectOuter(Tbl_ProjectOuter Tbl_ProjectOuter)
        {
            string sql = "insert into [Tbl_ProjectOuter] ([ProjectID],[PO_CompanyID],[PO_StartTime],[PO_Time1],[PO_Time2],[PO_Link],[PO_LinkPhone],[PO_Name],[PO_Content],[Remark],[PO_File],[PO_Price],[PO_PricePay],[PO_PriceBill],[PO_FeeType],[PO_Type],[Status],[DealUser]) values (@ProjectID,@PO_CompanyID,@PO_StartTime,@PO_Time1,@PO_Time2,@PO_Link,@PO_LinkPhone,@PO_Name,@PO_Content,@Remark,@PO_File,@PO_Price,@PO_PricePay,@PO_PriceBill,@PO_FeeType,@PO_Type,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",Tbl_ProjectOuter.ProjectID),
                new SqlParameter("@PO_CompanyID",Tbl_ProjectOuter.PO_CompanyID),
                 new SqlParameter("@PO_StartTime",Tbl_ProjectOuter.PO_StartTime),
                  new SqlParameter("@PO_Time1",Tbl_ProjectOuter.PO_Time1),
                   new SqlParameter("@PO_Time2",Tbl_ProjectOuter.PO_Time2),
                    new SqlParameter("@PO_Link",Tbl_ProjectOuter.PO_Link),
                    new SqlParameter("@PO_LinkPhone",Tbl_ProjectOuter.PO_LinkPhone),
                     new SqlParameter("@PO_Name",Tbl_ProjectOuter.PO_Name),
                     new SqlParameter("@PO_Content",Tbl_ProjectOuter.PO_Content),
                      new SqlParameter("@Remark",Tbl_ProjectOuter.Remark),
                new SqlParameter("@PO_File",Tbl_ProjectOuter.PO_File),
                new SqlParameter("@PO_Price",Tbl_ProjectOuter.PO_Price),
                new SqlParameter("@PO_PricePay",Tbl_ProjectOuter.PO_PricePay),
                new SqlParameter("@PO_PriceBill",Tbl_ProjectOuter.PO_PriceBill),
                new SqlParameter("@PO_FeeType",Tbl_ProjectOuter.PO_FeeType),
                new SqlParameter("@PO_Type",Tbl_ProjectOuter.PO_Type),
                new SqlParameter("@Status",Tbl_ProjectOuter.Status),
                new SqlParameter("@DealUser",Tbl_ProjectOuter.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectOuterById(Tbl_ProjectOuter Tbl_ProjectOuter)
        {

            string sql = "update [Tbl_ProjectOuter] set [ProjectID]=@ProjectID,[PO_CompanyID]=@PO_CompanyID,[PO_StartTime]=@PO_StartTime,[PO_Time1]=@PO_Time1,[PO_Time2]=@PO_Time2,[PO_Link]=@PO_Link,[PO_LinkPhone]=@PO_LinkPhone,[PO_Content]=@PO_Content,[PO_Name]=@PO_Name,[Remark]=@Remark,[PO_File]=@PO_File,[PO_Price]=@PO_Price,[PO_FeeType]=@PO_FeeType,[PO_Type]=@PO_Type,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",Tbl_ProjectOuter.ID),
                new SqlParameter("@ProjectID",Tbl_ProjectOuter.ProjectID),
                new SqlParameter("@PO_CompanyID",Tbl_ProjectOuter.PO_CompanyID),
                 new SqlParameter("@PO_StartTime",Tbl_ProjectOuter.PO_StartTime),
                  new SqlParameter("@PO_Time1",Tbl_ProjectOuter.PO_Time1),
                   new SqlParameter("@PO_Time2",Tbl_ProjectOuter.PO_Time2),
                    new SqlParameter("@PO_Link",Tbl_ProjectOuter.PO_Link),
                    new SqlParameter("@PO_LinkPhone",Tbl_ProjectOuter.PO_LinkPhone),
                     new SqlParameter("@PO_Name",Tbl_ProjectOuter.PO_Name),
                     new SqlParameter("@PO_Content",Tbl_ProjectOuter.PO_Content),
                      new SqlParameter("@Remark",Tbl_ProjectOuter.Remark),
                new SqlParameter("@PO_File",Tbl_ProjectOuter.PO_File),
                new SqlParameter("@PO_Price",Tbl_ProjectOuter.PO_Price),
                new SqlParameter("@PO_PricePay",Tbl_ProjectOuter.PO_PricePay),
                new SqlParameter("@PO_PriceBill",Tbl_ProjectOuter.PO_PriceBill),
                new SqlParameter("@PO_FeeType",Tbl_ProjectOuter.PO_FeeType),
                new SqlParameter("@PO_Type",Tbl_ProjectOuter.PO_Type),
                new SqlParameter("@Status",Tbl_ProjectOuter.Status),
                new SqlParameter("@DealUser",Tbl_ProjectOuter.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectOuterById(int ID)
        {

            string sql = "update from [Tbl_ProjectOuter] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectOuter GetTbl_ProjectOuterById(int ID)
        {

            string sql = "select * from [Tbl_ProjectOuter] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectOuterBySql(sql);

        }
        public IList<Tbl_ProjectOuter> GetTbl_ProjectOuterAll()
        {
            string sql = "select * from [Tbl_ProjectOuter] where DealFlag=0";
            return getTbl_ProjectOutersBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectOuter> getTbl_ProjectOutersBySql(string sql)
        {
            IList<Tbl_ProjectOuter> list = new List<Tbl_ProjectOuter>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectOuter Tbl_ProjectOuter = new Tbl_ProjectOuter();
                    Tbl_ProjectOuter.ID = Convert.ToInt32(dr["ID"]);
                    Tbl_ProjectOuter.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    Tbl_ProjectOuter.PO_CompanyID = Convert.ToInt32(dr["PO_CompanyID"]);
                    Tbl_ProjectOuter.PO_StartTime = Convert.ToDateTime(dr["PO_StartTime"]);
                    Tbl_ProjectOuter.PO_Time1 = Convert.ToDateTime(dr["PO_Time1"]);
                    Tbl_ProjectOuter.PO_Time2 = Convert.ToDateTime(dr["PO_Time2"]);
                    Tbl_ProjectOuter.PO_Link = Convert.ToString(dr["PO_Link"]);
                    Tbl_ProjectOuter.PO_LinkPhone = Convert.ToString(dr["PO_LinkPhone"]);
                    Tbl_ProjectOuter.PO_Name = Convert.ToString(dr["PO_Name"]);
                    Tbl_ProjectOuter.PO_Content = Convert.ToString(dr["PO_Content"]);
                    Tbl_ProjectOuter.Remark = Convert.ToString(dr["Remark"]);
                    Tbl_ProjectOuter.PO_File = Convert.ToString(dr["PO_File"]);
                    Tbl_ProjectOuter.PO_Price = Convert.ToDouble(dr["PO_Price"]);
                    Tbl_ProjectOuter.PO_PricePay = Convert.ToDouble(dr["PO_PricePay"]);
                    Tbl_ProjectOuter.PO_PriceBill = Convert.ToDouble(dr["PO_PriceBill"]);
                    Tbl_ProjectOuter.PO_FeeType = Convert.ToString(dr["PO_FeeType"]);
                    Tbl_ProjectOuter.PO_Type = Convert.ToString(dr["PO_Type"]);
                    Tbl_ProjectOuter.Status = Convert.ToString(dr["Status"]);
                    Tbl_ProjectOuter.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    Tbl_ProjectOuter.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    Tbl_ProjectOuter.DealUser = Convert.ToString(dr["DealUser"]);
                    Tbl_ProjectOuter.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(Tbl_ProjectOuter);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectOuter getTbl_ProjectOuterBySql(string sql)
        {
            Tbl_ProjectOuter Tbl_ProjectOuter = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                Tbl_ProjectOuter = new Tbl_ProjectOuter();
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectOuter.ID = Convert.ToInt32(dr["ID"]);
                    Tbl_ProjectOuter.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    Tbl_ProjectOuter.PO_CompanyID = Convert.ToInt32(dr["PO_CompanyID"]);
                    Tbl_ProjectOuter.PO_StartTime = Convert.ToDateTime(dr["PO_StartTime"]);
                    Tbl_ProjectOuter.PO_Time1 = Convert.ToDateTime(dr["PO_Time1"]);
                    Tbl_ProjectOuter.PO_Time2 = Convert.ToDateTime(dr["PO_Time2"]);
                    Tbl_ProjectOuter.PO_Link = Convert.ToString(dr["PO_Link"]);
                    Tbl_ProjectOuter.PO_LinkPhone = Convert.ToString(dr["PO_LinkPhone"]);
                    Tbl_ProjectOuter.PO_Name = Convert.ToString(dr["PO_Name"]);
                    Tbl_ProjectOuter.PO_Content = Convert.ToString(dr["PO_Content"]);
                    Tbl_ProjectOuter.Remark = Convert.ToString(dr["Remark"]);
                    Tbl_ProjectOuter.PO_File = Convert.ToString(dr["PO_File"]);
                    Tbl_ProjectOuter.PO_Price = Convert.ToDouble(dr["PO_Price"]);
                    Tbl_ProjectOuter.PO_PricePay = Convert.ToDouble(dr["PO_PricePay"]);
                    Tbl_ProjectOuter.PO_PriceBill = Convert.ToDouble(dr["PO_PriceBill"]);
                    Tbl_ProjectOuter.PO_FeeType = Convert.ToString(dr["PO_FeeType"]);
                    Tbl_ProjectOuter.PO_Type = Convert.ToString(dr["PO_Type"]);
                    Tbl_ProjectOuter.Status = Convert.ToString(dr["Status"]);
                    Tbl_ProjectOuter.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    Tbl_ProjectOuter.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    Tbl_ProjectOuter.DealUser = Convert.ToString(dr["DealUser"]);
                    Tbl_ProjectOuter.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return Tbl_ProjectOuter;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectOuter where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectOuter.ProjectID) as ProjectName,(select POC_Name from tbl_projectBuilder where id=Tbl_ProjectOuter.ProjectID) as POC_Name from Tbl_ProjectOuter where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
