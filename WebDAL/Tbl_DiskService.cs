using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_DiskService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public int AddTbl_Disk(Tbl_Disk tbl_disk)
        {
            string Sql = "insert into [Tbl_Disk] ([D_Class],[D_Title],[D_File],[Remark],[DealUser],[DealFlag],[DealTime],[AddDate]) values (@D_Class,@D_Title,@D_File,@Remark,@DealUser,@DealFlag,@DealTime,@AddDate)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@D_Class",tbl_disk.D_Class),
                new SqlParameter("@D_Title",tbl_disk.D_Title),
                new SqlParameter("@D_File",tbl_disk.D_File),
                new SqlParameter("@Remark",tbl_disk.Remark),
                new SqlParameter("@DealUser",tbl_disk.DealUser),
                new SqlParameter("@DealFlag",tbl_disk.DealFlag),
                new SqlParameter("@DealTime",tbl_disk.DealTime),
                new SqlParameter("@AddDate",tbl_disk.AddDate)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);
        }

        public int UpdateTbl_DiskById(Tbl_Disk tbl_disk)
        {

            string Sql = "update [Tbl_Disk] set [D_Class]=@D_Class,[D_Title]=@D_Title,[D_File]=@D_File,[Remark]=@Remark,[DealUser]=@DealUser,[DealFlag]=@DealFlag,[DealTime]=@DealTime,[AddDate]=@AddDate where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@D_Class",tbl_disk.D_Class),
                new SqlParameter("@D_Title",tbl_disk.D_Title),
                new SqlParameter("@D_File",tbl_disk.D_File),
                new SqlParameter("@Remark",tbl_disk.Remark),
                new SqlParameter("@DealUser",tbl_disk.DealUser),
                new SqlParameter("@DealFlag",tbl_disk.DealFlag),
                new SqlParameter("@DealTime",tbl_disk.DealTime),
                new SqlParameter("@AddDate",tbl_disk.AddDate),
                new SqlParameter("@ID",tbl_disk.ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);

        }

        public int DeleteTbl_DiskById(int ID)
        {

            string Sql = "update [Tbl_Disk] set [DealFlag]=1 where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, Sql, sp);

        }

        public Tbl_Disk GetTbl_DiskById(int ID)
        {

            string Sql = "select * from [Tbl_Disk] where [DealFlag]=0 and ID=" + ID;
            return getTbl_DiskBySql(Sql);

        }

        public IList<Tbl_Disk> GetTbl_DiskAll()
        {
            string Sql = "select * from [Tbl_Disk] where [DealFlag]=0";
            return getTbl_DisksBySql(Sql);
        }

        /// <summary>
        ///根据Sql语句返回集合
        /// </summary>
        private IList<Tbl_Disk> getTbl_DisksBySql(string Sql)
        {
            IList<Tbl_Disk> list = new List<Tbl_Disk>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Disk tbl_disk = new Tbl_Disk();
                    tbl_disk.ID = Convert.ToInt32(dr["ID"]);
                    tbl_disk.D_Class = Convert.ToString(dr["D_Class"]);
                    tbl_disk.D_Title = Convert.ToString(dr["D_Title"]);
                    tbl_disk.D_File = Convert.ToString(dr["D_File"]);
                    tbl_disk.Remark = Convert.ToString(dr["Remark"]);
                    tbl_disk.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_disk.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_disk.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_disk.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_disk);
                }
            }
            return list;
        }

        /// <summary>
        ///根据Sql语句获取实体
        /// </summary>
        private Tbl_Disk getTbl_DiskBySql(string Sql)
        {
            Tbl_Disk tbl_disk = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, Sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_disk = new Tbl_Disk();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_disk.ID = Convert.ToInt32(dr["ID"]);
                    tbl_disk.D_Class = Convert.ToString(dr["D_Class"]);
                    tbl_disk.D_Title = Convert.ToString(dr["D_Title"]);
                    tbl_disk.D_File = Convert.ToString(dr["D_File"]);
                    tbl_disk.Remark = Convert.ToString(dr["Remark"]);
                    tbl_disk.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_disk.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_disk.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_disk.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_disk;
        }

        /// <summary>
        /// 根据条件返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string Sql = "select count(*) from Tbl_Disk where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, Sql);
            return RecordNum;
        }

        /// <summary>
        /// 返回条件返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string Sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_Disk where [DealFlag]=0";
            if (Where != "") Sql += " and " + Where;
            if (Order != "") Sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, Sql, startRecord, endRecord);
            return dt;
        }

    }
}
