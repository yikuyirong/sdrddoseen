using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectOuterDesignService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectOuterDesign(Tbl_ProjectOuterDesign tbl_projectouterdesign)
        {
            string sql = "insert into [Tbl_ProjectOuterDesign] ([ProjectID],[PO_CompanyID],[PO_Content],[PO_StartTime],[PO_File],[Remark],[PO_Price],[PO_FeeType],[Status],[DealUser]) values (@ProjectID,@PO_CompanyID,@PO_Content,@PO_StartTime,@PO_File,@Remark,@PO_Price,@PO_FeeType,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectouterdesign.ProjectID),
                new SqlParameter("@PO_CompanyID",tbl_projectouterdesign.PO_CompanyID),
                new SqlParameter("@PO_Content",tbl_projectouterdesign.PO_Content),
                new SqlParameter("@PO_StartTime",tbl_projectouterdesign.PO_StartTime),
                 new SqlParameter("@PO_File",tbl_projectouterdesign.PO_File),
                  new SqlParameter("@Remark",tbl_projectouterdesign.Remark),
                new SqlParameter("@PO_Price",tbl_projectouterdesign.PO_Price),
                new SqlParameter("@PO_FeeType",tbl_projectouterdesign.PO_FeeType),
                new SqlParameter("@Status",tbl_projectouterdesign.Status),
                new SqlParameter("@DealUser",tbl_projectouterdesign.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectOuterDesignById(Tbl_ProjectOuterDesign tbl_projectouterdesign)
        {

            string sql = "update [Tbl_ProjectOuterDesign] set [ProjectID]=@ProjectID,[PO_CompanyID]=@PO_CompanyID,[PO_Content]=@PO_Content,[PO_StartTime]=@PO_StartTime,[PO_Price]=@PO_Price,[PO_FeeType]=@PO_FeeType,[Remark]=@Remark,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectouterdesign.ID),
                new SqlParameter("@ProjectID",tbl_projectouterdesign.ProjectID),
                new SqlParameter("@PO_CompanyID",tbl_projectouterdesign.PO_CompanyID),
                new SqlParameter("@PO_Content",tbl_projectouterdesign.PO_Content),
                new SqlParameter("@PO_StartTime",tbl_projectouterdesign.PO_StartTime),
                 new SqlParameter("@PO_File",tbl_projectouterdesign.PO_File),
                  new SqlParameter("@Remark",tbl_projectouterdesign.Remark),
                new SqlParameter("@PO_Price",tbl_projectouterdesign.PO_Price),
                new SqlParameter("@PO_FeeType",tbl_projectouterdesign.PO_FeeType),
                new SqlParameter("@Status",tbl_projectouterdesign.Status),
                new SqlParameter("@DealUser",tbl_projectouterdesign.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectOuterDesignById(int ID)
        {

            string sql = "update from [Tbl_ProjectOuterDesign] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectOuterDesign GetTbl_ProjectOuterDesignById(int ID)
        {

            string sql = "select * from [Tbl_ProjectOuterDesign] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectOuterDesignBySql(sql);

        }
        public IList<Tbl_ProjectOuterDesign> GetTbl_ProjectOuterDesignAll()
        {
            string sql = "select * from [Tbl_ProjectOuterDesign] where DealFlag=0";
            return getTbl_ProjectOuterDesignsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectOuterDesign> getTbl_ProjectOuterDesignsBySql(string sql)
        {
            IList<Tbl_ProjectOuterDesign> list = new List<Tbl_ProjectOuterDesign>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectOuterDesign tbl_projectouterdesign = new Tbl_ProjectOuterDesign();
                    tbl_projectouterdesign.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectouterdesign.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectouterdesign.PO_CompanyID = Convert.ToInt32(dr["PO_CompanyID"]);
                    tbl_projectouterdesign.PO_Content = Convert.ToString(dr["PO_Content"]);
                    tbl_projectouterdesign.PO_StartTime = Convert.ToDateTime(dr["PO_StartTime"]);
                    tbl_projectouterdesign.PO_File = Convert.ToString(dr["PO_File"]);
                    tbl_projectouterdesign.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectouterdesign.PO_Price = Convert.ToDouble(dr["PO_Price"]);
                    tbl_projectouterdesign.PO_FeeType = Convert.ToString(dr["PO_FeeType"]);
                    tbl_projectouterdesign.Status = Convert.ToString(dr["Status"]);
                    tbl_projectouterdesign.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectouterdesign.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectouterdesign.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectouterdesign.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectouterdesign);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectOuterDesign getTbl_ProjectOuterDesignBySql(string sql)
        {
            Tbl_ProjectOuterDesign tbl_projectouterdesign = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectouterdesign = new Tbl_ProjectOuterDesign();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectouterdesign.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectouterdesign.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectouterdesign.PO_CompanyID = Convert.ToInt32(dr["PO_CompanyID"]);
                    tbl_projectouterdesign.PO_Content = Convert.ToString(dr["PO_Content"]);
                    tbl_projectouterdesign.PO_StartTime = Convert.ToDateTime(dr["PO_StartTime"]);
                    tbl_projectouterdesign.PO_File = Convert.ToString(dr["PO_File"]);
                    tbl_projectouterdesign.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectouterdesign.PO_Price = Convert.ToDouble(dr["PO_Price"]);
                    tbl_projectouterdesign.PO_FeeType = Convert.ToString(dr["PO_FeeType"]);
                    tbl_projectouterdesign.Status = Convert.ToString(dr["Status"]);
                    tbl_projectouterdesign.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectouterdesign.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectouterdesign.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectouterdesign.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectouterdesign;
        }


        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectOuterDesign where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectOuterDesign.ProjectID) as ProjectName from Tbl_ProjectOuterDesign where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
