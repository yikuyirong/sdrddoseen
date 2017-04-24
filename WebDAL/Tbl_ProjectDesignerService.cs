using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_ProjectDesignerService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectDesigner(Tbl_ProjectDesigner tbl_projectdesigner)
        {
            string sql = "insert into [Tbl_ProjectDesigner] ([ProjectID],[ClassName],[UserName],[DesignerType],[DealUser]) values (@ProjectID,@ClassName,@UserName,@DesignerType,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectdesigner.ProjectID),
                new SqlParameter("@ClassName",tbl_projectdesigner.ClassName),
                new SqlParameter("@UserName",tbl_projectdesigner.UserName),
                new SqlParameter("@DesignerType",tbl_projectdesigner.DesignerType),
                new SqlParameter("@DealUser",tbl_projectdesigner.DealUser),
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_ProjectDesignerById(Tbl_ProjectDesigner tbl_projectdesigner)
        {

            string sql = "update [Tbl_ProjectDesigner] set [ClassName]=@ClassName,[UserName]=@UserName,[DesignerType]=@DesignerType,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ClassName",tbl_projectdesigner.ClassName),
                new SqlParameter("@UserName",tbl_projectdesigner.UserName),
                new SqlParameter("@DesignerType",tbl_projectdesigner.DesignerType),
                new SqlParameter("@DealUser",tbl_projectdesigner.DealUser),
                new SqlParameter("@DealTime",tbl_projectdesigner.DealTime.ToString()),
                new SqlParameter("@Tbl_ProjectDesigner",tbl_projectdesigner.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectDesignerById()
        {

            string sql = "update [Tbl_ProjectDesigner] where DealFlag=0 and [DealFlag]=1";
            SqlParameter[] sp = new SqlParameter[]
            {
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectDesignerById(int ID)
        {

            string sql = "update [Tbl_ProjectDesigner] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectDesigner GetTbl_ProjectDesignerById(int ID)
        {
            string sql = "select * from [Tbl_ProjectDesigner] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectDesignerBySql(sql);

        }
        public IList<Tbl_ProjectDesigner> GetTbl_ProjectDesignerByProjectId(int ProjectID)
        {
            string sql = "select * from [Tbl_ProjectDesigner] where DealFlag=0 and ProjectID=" + ProjectID;
            return getTbl_ProjectDesignersBySql(sql);

        }
        public IList<Tbl_ProjectDesigner> GetTbl_ProjectDesignerAll()
        {
            string sql = "select * from [Tbl_ProjectDesigner] where DealFlag=0 ";
            return getTbl_ProjectDesignersBySql(sql);
        }
        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_ProjectDesigner> getTbl_ProjectDesignersBySql(string sql)
        {
            IList<Tbl_ProjectDesigner> list = new List<Tbl_ProjectDesigner>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectDesigner tbl_projectdesigner = new Tbl_ProjectDesigner();
                    tbl_projectdesigner.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectdesigner.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectdesigner.ClassName = Convert.ToString(dr["ClassName"]);
                    tbl_projectdesigner.UserName = Convert.ToString(dr["UserName"]);
                    tbl_projectdesigner.DesignerType = Convert.ToString(dr["DesignerType"]);
                    tbl_projectdesigner.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectdesigner.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectdesigner.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectdesigner.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_projectdesigner);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectDesigner getTbl_ProjectDesignerBySql(string sql)
        {
            Tbl_ProjectDesigner tbl_projectdesigner = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectdesigner = new Tbl_ProjectDesigner();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectdesigner.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectdesigner.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectdesigner.ClassName = Convert.ToString(dr["ClassName"]);
                    tbl_projectdesigner.UserName = Convert.ToString(dr["UserName"]);
                    tbl_projectdesigner.DesignerType = Convert.ToString(dr["DesignerType"]);
                    tbl_projectdesigner.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectdesigner.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectdesigner.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectdesigner.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_projectdesigner;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectDesigner where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_ProjectDesigner where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
