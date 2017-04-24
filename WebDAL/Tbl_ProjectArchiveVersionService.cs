using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectArchiveVersionService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectArchiveVersion(Tbl_ProjectArchiveVersion tbl_projectarchiveversion)
        {
            string sql = "insert into [Tbl_ProjectArchiveVersion] ([ProjectID],[ProjectArchiveID],[PAV_File],[PAV_Info],[DealUser]) values (@ProjectID,@ProjectArchiveID,@PAV_File,@PAV_Info,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectarchiveversion.ProjectID),
                new SqlParameter("@ProjectArchiveID",tbl_projectarchiveversion.ProjectArchiveID),
                new SqlParameter("@PAV_File",tbl_projectarchiveversion.PAV_File),
                new SqlParameter("@PAV_Info",tbl_projectarchiveversion.PAV_Info),
                new SqlParameter("@DealUser",tbl_projectarchiveversion.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectArchiveVersionById(Tbl_ProjectArchiveVersion tbl_projectarchiveversion)
        {

            string sql = "update [Tbl_ProjectArchiveVersion] set [ProjectID]=@ProjectID,[ProjectArchiveID]=@ProjectArchiveID,[PAV_File]=@PAV_File,[PAV_Info]=@PAV_Info,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectarchiveversion.ID),
                new SqlParameter("@ProjectID",tbl_projectarchiveversion.ProjectID),
                new SqlParameter("@ProjectArchiveID",tbl_projectarchiveversion.ProjectArchiveID),
                new SqlParameter("@PAV_File",tbl_projectarchiveversion.PAV_File),
                new SqlParameter("@PAV_Info",tbl_projectarchiveversion.PAV_Info),
                new SqlParameter("@DealUser",tbl_projectarchiveversion.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectArchiveVersionById(int ID)
        {

            string sql = "update from [Tbl_ProjectArchiveVersion] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectArchiveVersion GetTbl_ProjectArchiveVersionById(int ID)
        {

            string sql = "select * from [Tbl_ProjectArchiveVersion] where DealFlag=0 and [DealFlag]=0 and ID=" + ID;
            return getTbl_ProjectArchiveVersionBySql(sql);

        }
        public IList<Tbl_ProjectArchiveVersion> GetTbl_ProjectArchiveVersionAll()
        {
            string sql = "select * from [Tbl_ProjectArchiveVersion] where DealFlag=0";
            return getTbl_ProjectArchiveVersionsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectArchiveVersion> getTbl_ProjectArchiveVersionsBySql(string sql)
        {
            IList<Tbl_ProjectArchiveVersion> list = new List<Tbl_ProjectArchiveVersion>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectArchiveVersion tbl_projectarchiveversion = new Tbl_ProjectArchiveVersion();
                    tbl_projectarchiveversion.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectarchiveversion.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectarchiveversion.ProjectArchiveID = Convert.ToInt32(dr["ProjectArchiveID"]);
                    tbl_projectarchiveversion.PAV_File = Convert.ToString(dr["PAV_File"]);
                    tbl_projectarchiveversion.PAV_Info = Convert.ToString(dr["PAV_Info"]);
                    tbl_projectarchiveversion.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectarchiveversion.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectarchiveversion.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectarchiveversion.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_projectarchiveversion);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectArchiveVersion getTbl_ProjectArchiveVersionBySql(string sql)
        {
            Tbl_ProjectArchiveVersion tbl_projectarchiveversion = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectarchiveversion = new Tbl_ProjectArchiveVersion();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectarchiveversion.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectarchiveversion.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectarchiveversion.ProjectArchiveID = Convert.ToInt32(dr["ProjectArchiveID"]);
                    tbl_projectarchiveversion.PAV_File = Convert.ToString(dr["PAV_File"]);
                    tbl_projectarchiveversion.PAV_Info = Convert.ToString(dr["PAV_Info"]);
                    tbl_projectarchiveversion.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectarchiveversion.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectarchiveversion.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectarchiveversion.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_projectarchiveversion;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectArchiveVersion where DealFlag=0 and [DealFlag]=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "SELECT   *,(select ProjectName from tbl_project where id=a.ProjectiD) as ProjectName FROM Tbl_ProjectArchive as a WHERE DealFlag = 0 ORDER BY PA_Name DESC, ParentID, ID";
            if (Where != "") sql += " and (" + Where + ")";
            //if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
