using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_GbookService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Gbook(Tbl_Gbook tbl_gbook)
        {
            string sql = "insert into [Tbl_Gbook] ([G_Title],[UserName],[G_Content],[UserPwd],[G_Reply],[G_Name],[G_Phone],[G_Mobile],[G_QQ],[G_Email],[Status],[DealUser]) values (@G_Title,@UserName,@G_Content,@UserPwd,@G_Reply,@G_Name,@G_Phone,@G_Mobile,@G_QQ,@G_Email,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@G_Title",tbl_gbook.G_Title),
                new SqlParameter("@UserName",tbl_gbook.UserName),
                new SqlParameter("@G_Content",tbl_gbook.G_Content),
                new SqlParameter("@UserPwd",tbl_gbook.UserPwd),
                new SqlParameter("@G_Reply",tbl_gbook.G_Reply),
                new SqlParameter("@G_Name",tbl_gbook.G_Name),
                new SqlParameter("@G_Phone",tbl_gbook.G_Phone),
                new SqlParameter("@G_Mobile",tbl_gbook.G_Mobile),
                new SqlParameter("@G_QQ",tbl_gbook.G_QQ),
                new SqlParameter("@G_Email",tbl_gbook.G_Email),
                new SqlParameter("@Status",tbl_gbook.Status),
                new SqlParameter("@DealUser",tbl_gbook.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_GbookById(Tbl_Gbook tbl_gbook)
        {

            string sql = "update [Tbl_Gbook] set [G_Title]=@G_Title,[UserName]=@UserName,[G_Content]=@G_Content,[UserPwd]=@UserPwd,[G_Reply]=@G_Reply,[G_Name]=@G_Name,[G_Phone]=@G_Phone,[G_Mobile]=@G_Mobile,[G_QQ]=@G_QQ,[G_Email]=@G_Email,[Status]=@Status,[DealFlag]=@DealFlag,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@G_Title",tbl_gbook.G_Title),
                new SqlParameter("@UserName",tbl_gbook.UserName),
                new SqlParameter("@G_Content",tbl_gbook.G_Content),
                new SqlParameter("@UserPwd",tbl_gbook.UserPwd),
                new SqlParameter("@G_Reply",tbl_gbook.G_Reply),
                new SqlParameter("@G_Name",tbl_gbook.G_Name),
                new SqlParameter("@G_Phone",tbl_gbook.G_Phone),
                new SqlParameter("@G_Mobile",tbl_gbook.G_Mobile),
                new SqlParameter("@G_QQ",tbl_gbook.G_QQ),
                new SqlParameter("@G_Email",tbl_gbook.G_Email),
                new SqlParameter("@Status",tbl_gbook.Status),
                new SqlParameter("@DealFlag",tbl_gbook.DealFlag),
                new SqlParameter("@DealUser",tbl_gbook.DealUser),
                new SqlParameter("@DealTime",tbl_gbook.DealTime.ToString()),
                new SqlParameter("@ID",tbl_gbook.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }

        public int DeleteTbl_GbookById(int ID)
        {
            
            string sql="update [Tbl_Gbook] set [DealFlag]=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public Tbl_Gbook GetTbl_GbookById(int ID)
        {
            
            string sql="select * from [Tbl_Gbook] where DealFlag=0 and ID="+ID;
            return getTbl_GbookBySql(sql);
            
        }
        public IList<Tbl_Gbook> GetTbl_GbookAll()
        {
            string sql="select * from [Tbl_Gbook] where DealFlag=0 ";
            return getTbl_GbooksBySql(sql);
        }
        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_Gbook> getTbl_GbooksBySql(string sql)
        {
            IList<Tbl_Gbook> list = new List<Tbl_Gbook>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Gbook tbl_gbook = new Tbl_Gbook();
                    tbl_gbook.ID = Convert.ToInt32(dr["ID"]);
                    tbl_gbook.G_Title = Convert.ToString(dr["G_Title"]);
                    tbl_gbook.UserName = Convert.ToString(dr["UserName"]);
                    tbl_gbook.G_Content = Convert.ToString(dr["G_Content"]);
                    tbl_gbook.UserPwd = Convert.ToString(dr["UserPwd"]);
                    tbl_gbook.G_Reply = Convert.ToString(dr["G_Reply"]);
                    tbl_gbook.G_Name = Convert.ToString(dr["G_Name"]);
                    tbl_gbook.G_Phone = Convert.ToString(dr["G_Phone"]);
                    tbl_gbook.G_Mobile = Convert.ToString(dr["G_Mobile"]);
                    tbl_gbook.G_QQ = Convert.ToString(dr["G_QQ"]);
                    tbl_gbook.G_Email = Convert.ToString(dr["G_Email"]);
                    tbl_gbook.Status = Convert.ToString(dr["Status"]);
                    tbl_gbook.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_gbook.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_gbook.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_gbook.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_gbook);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Gbook getTbl_GbookBySql(string sql)
        {
            Tbl_Gbook tbl_gbook = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_gbook = new Tbl_Gbook();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_gbook.ID = Convert.ToInt32(dr["ID"]);
                    tbl_gbook.G_Title = Convert.ToString(dr["G_Title"]);
                    tbl_gbook.UserName = Convert.ToString(dr["UserName"]);
                    tbl_gbook.G_Content = Convert.ToString(dr["G_Content"]);
                    tbl_gbook.UserPwd = Convert.ToString(dr["UserPwd"]);
                    tbl_gbook.G_Reply = Convert.ToString(dr["G_Reply"]);
                    tbl_gbook.G_Name = Convert.ToString(dr["G_Name"]);
                    tbl_gbook.G_Phone = Convert.ToString(dr["G_Phone"]);
                    tbl_gbook.G_Mobile = Convert.ToString(dr["G_Mobile"]);
                    tbl_gbook.G_QQ = Convert.ToString(dr["G_QQ"]);
                    tbl_gbook.G_Email = Convert.ToString(dr["G_Email"]);
                    tbl_gbook.Status = Convert.ToString(dr["Status"]);
                    tbl_gbook.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_gbook.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_gbook.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_gbook.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_gbook;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Gbook where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_Gbook where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
