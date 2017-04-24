using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_PageService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Page(Tbl_Page tbl_page)
        {
            string sql = "insert into [Tbl_Page] ([P_Title],[P_Keyword],[P_Description],[P_Content],[DealUser]) values (@P_Title,@P_Keyword,@P_Description,@P_Content,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@P_Title",tbl_page.P_Title),
                new SqlParameter("@P_Keyword",tbl_page.P_Keyword),
                new SqlParameter("@P_Description",tbl_page.P_Description),
                new SqlParameter("@P_Content",tbl_page.P_Content),
                new SqlParameter("@DealUser",tbl_page.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_PageById(Tbl_Page tbl_page)
        {

            string sql = "update [Tbl_Page] set [P_Title]=@P_Title,[P_Keyword]=@P_Keyword,[P_Description]=@P_Description,[P_Content]=@P_Content,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@P_Title",tbl_page.P_Title),
                new SqlParameter("@P_Keyword",tbl_page.P_Keyword),
                new SqlParameter("@P_Description",tbl_page.P_Description),
                new SqlParameter("@P_Content",tbl_page.P_Content),
                new SqlParameter("@DealUser",tbl_page.DealUser),
                new SqlParameter("@DealTime",tbl_page.DealTime.ToString()),
                new SqlParameter("@ID",tbl_page.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }

        public int DeleteTbl_PageById(int ID)
        {
            
            string sql="update [Tbl_Page] set [DealFlag]=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public Tbl_Page GetTbl_PageById(int ID)
        {
            
            string sql="select * from [Tbl_Page] where DealFlag=0 and ID="+ID;
            return getTbl_PageBySql(sql);
            
        }
        public IList<Tbl_Page> GetTbl_PageAll()
        {
            string sql="select * from [Tbl_Page] where DealFlag=0 ";
            return getTbl_PagesBySql(sql);
        }
        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_Page> getTbl_PagesBySql(string sql)
        {
            IList<Tbl_Page> list = new List<Tbl_Page>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Page tbl_page = new Tbl_Page();
                    tbl_page.ID = Convert.ToInt32(dr["ID"]);
                    tbl_page.P_Title = Convert.ToString(dr["P_Title"]);
                    tbl_page.P_Keyword = Convert.ToString(dr["P_Keyword"]);
                    tbl_page.P_Description = Convert.ToString(dr["P_Description"]);
                    tbl_page.P_Content = Convert.ToString(dr["P_Content"]);
                    tbl_page.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_page.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_page.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_page.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_page);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Page getTbl_PageBySql(string sql)
        {
            Tbl_Page tbl_page = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_page = new Tbl_Page();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_page.ID = Convert.ToInt32(dr["ID"]);
                    tbl_page.P_Title = Convert.ToString(dr["P_Title"]);
                    tbl_page.P_Keyword = Convert.ToString(dr["P_Keyword"]);
                    tbl_page.P_Description = Convert.ToString(dr["P_Description"]);
                    tbl_page.P_Content = Convert.ToString(dr["P_Content"]);
                    tbl_page.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_page.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_page.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_page.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_page;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Page where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_Page where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
