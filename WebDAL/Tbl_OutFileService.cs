using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_OutFileService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
		public int AddTbl_OutFile(Tbl_OutFile tbl_outfile)
        {
            string Sql = "insert into [Tbl_OutFile] ([ProjectID],[ClassName],[FileName],[FileUrl],[FileInfo],[DealUser],[DealFlag],[DealTime],[AddDate]) values (@ProjectID,@ClassName,@FileName,@FileUrl,@FileInfo,@DealUser,@DealFlag,@DealTime,@AddDate)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_outfile.ProjectID),
                new SqlParameter("@ClassName",tbl_outfile.ClassName),
                new SqlParameter("@FileName",tbl_outfile.FileName),
                new SqlParameter("@FileUrl",tbl_outfile.FileUrl),
                new SqlParameter("@FileInfo",tbl_outfile.FileInfo),
                new SqlParameter("@DealUser",tbl_outfile.DealUser),
                new SqlParameter("@DealFlag",tbl_outfile.DealFlag),
                new SqlParameter("@DealTime",tbl_outfile.DealTime),
                new SqlParameter("@AddDate",tbl_outfile.AddDate)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
        }

        public int UpdateTbl_OutFileById(Tbl_OutFile tbl_outfile)
        {

            string Sql = "update [Tbl_OutFile] set [ProjectID]=@ProjectID,[ClassName]=@ClassName,[FileName]=@FileName,[FileUrl]=@FileUrl,[FileInfo]=@FileInfo,[DealUser]=@DealUser,[DealFlag]=@DealFlag,[DealTime]=@DealTime,[AddDate]=@AddDate where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_outfile.ProjectID),
                new SqlParameter("@ClassName",tbl_outfile.ClassName),
                new SqlParameter("@FileName",tbl_outfile.FileName),
                new SqlParameter("@FileUrl",tbl_outfile.FileUrl),
                new SqlParameter("@FileInfo",tbl_outfile.FileInfo),
                new SqlParameter("@DealUser",tbl_outfile.DealUser),
                new SqlParameter("@DealFlag",tbl_outfile.DealFlag),
                new SqlParameter("@DealTime",tbl_outfile.DealTime),
                new SqlParameter("@AddDate",tbl_outfile.AddDate),
                new SqlParameter("@ID",tbl_outfile.ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
            
        }

        public int DeleteTbl_OutFileById(int ID)
        {
            
            string Sql="update [Tbl_OutFile] set [DealFlag]=1 where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
            
        }

        public Tbl_OutFile GetTbl_OutFileById(int ID)
        {
            
            string Sql="select * from [Tbl_OutFile] where [DealFlag]=0 and ID="+ID;
            return getTbl_OutFileBySql(Sql);
            
        }

        public IList<Tbl_OutFile> GetTbl_OutFileAll()
        {
            string Sql="select * from [Tbl_OutFile] where [DealFlag]=0";
            return getTbl_OutFilesBySql(Sql);
        }

		/// <summary>
        ///根据Sql语句返回集合
        /// </summary>
        private IList<Tbl_OutFile> getTbl_OutFilesBySql(string Sql)
        {
            IList<Tbl_OutFile> list = new List<Tbl_OutFile>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_OutFile tbl_outfile = new Tbl_OutFile();
                    tbl_outfile.ID = Convert.ToInt32(dr["ID"]);
                    tbl_outfile.ProjectID = Convert.ToString(dr["ProjectID"]);
                    tbl_outfile.ClassName = Convert.ToString(dr["ClassName"]);
                    tbl_outfile.FileName = Convert.ToString(dr["FileName"]);
                    tbl_outfile.FileUrl = Convert.ToString(dr["FileUrl"]);
                    tbl_outfile.FileInfo = Convert.ToString(dr["FileInfo"]);
                    tbl_outfile.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_outfile.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_outfile.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_outfile.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_outfile);
                }
            }
            return list;
        }

        /// <summary>
        ///根据Sql语句获取实体
        /// </summary>
        private Tbl_OutFile getTbl_OutFileBySql(string Sql)
        {
            Tbl_OutFile tbl_outfile = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_outfile = new Tbl_OutFile();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_outfile.ID = Convert.ToInt32(dr["ID"]);
                    tbl_outfile.ProjectID = Convert.ToString(dr["ProjectID"]);
                    tbl_outfile.ClassName = Convert.ToString(dr["ClassName"]);
                    tbl_outfile.FileName = Convert.ToString(dr["FileName"]);
                    tbl_outfile.FileUrl = Convert.ToString(dr["FileUrl"]);
                    tbl_outfile.FileInfo = Convert.ToString(dr["FileInfo"]);
                    tbl_outfile.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_outfile.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_outfile.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_outfile.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_outfile;
        }

        /// <summary>
        /// 根据条件返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string Sql = "select count(*) from Tbl_OutFile where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, Sql);
            return RecordNum;
        }

        /// <summary>
        /// 返回条件返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string Sql = "select *,(select projectname from tbl_project where id=Tbl_OutFile.projectid) as ProjectName," + GetDataTableByCount(Where) + " as RecordNum from Tbl_OutFile where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            if (Order != "") Sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, Sql, startRecord, endRecord);
            return dt;
        }

    }
}
