using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_DesignVersionService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_DesignVersion(Tbl_DesignVersion tbl_designversion)
        {
            string sql = "insert into [Tbl_DesignVersion] ([UserName],[DesignTaskID],[CadFile],[Remark],[DealUser]) values (@UserName,@DesignTaskID,@CadFile,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_designversion.UserName),
                new SqlParameter("@DesignTaskID",tbl_designversion.DesignTaskID),
                new SqlParameter("@CadFile",tbl_designversion.CadFile),
                new SqlParameter("@Remark",tbl_designversion.Remark),
                new SqlParameter("@DealUser",tbl_designversion.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_DesignVersionById(Tbl_DesignVersion tbl_designversion)
        {

            string sql = "update [Tbl_DesignVersion] set [UserName]=@UserName,[DesignTaskID]=@DesignTaskID,[CadFile]=@CadFile,[Remark]=@Remark,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_designversion.ID),
                new SqlParameter("@UserName",tbl_designversion.UserName),
                new SqlParameter("@DesignTaskID",tbl_designversion.DesignTaskID),
                new SqlParameter("@CadFile",tbl_designversion.CadFile),
                new SqlParameter("@Remark",tbl_designversion.Remark),
                new SqlParameter("@DealUser",tbl_designversion.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_DesignVersionById(int ID)
        {

            string sql = "update from [Tbl_DesignVersion] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_DesignVersion GetTbl_DesignVersionById(int ID)
        {

            string sql = "select * from [Tbl_DesignVersion] where DealFlag=0 and ID=" + ID;
            return getTbl_DesignVersionBySql(sql);

        }
        public IList<Tbl_DesignVersion> GetTbl_DesignVersionAll()
        {
            string sql = "select * from [Tbl_DesignVersion] where DealFlag=0";
            return getTbl_DesignVersionsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_DesignVersion> getTbl_DesignVersionsBySql(string sql)
        {
            IList<Tbl_DesignVersion> list = new List<Tbl_DesignVersion>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_DesignVersion tbl_designversion = new Tbl_DesignVersion();
                    tbl_designversion.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designversion.UserName = Convert.ToString(dr["UserName"]);
                    tbl_designversion.DesignTaskID = Convert.ToInt32(dr["DesignTaskID"]);
                    tbl_designversion.CadFile = Convert.ToString(dr["CadFile"]);
                    tbl_designversion.Remark = Convert.ToString(dr["Remark"]);
                    tbl_designversion.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designversion.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_designversion.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designversion.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_designversion);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_DesignVersion getTbl_DesignVersionBySql(string sql)
        {
            Tbl_DesignVersion tbl_designversion = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_designversion = new Tbl_DesignVersion();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_designversion.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designversion.UserName = Convert.ToString(dr["UserName"]);
                    tbl_designversion.DesignTaskID = Convert.ToInt32(dr["DesignTaskID"]);
                    tbl_designversion.CadFile = Convert.ToString(dr["CadFile"]);
                    tbl_designversion.Remark = Convert.ToString(dr["Remark"]);
                    tbl_designversion.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designversion.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_designversion.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designversion.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_designversion;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_DesignVersion where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_DesignVersion.DesignTaskID) as ProjectName from Tbl_DesignVersion where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
