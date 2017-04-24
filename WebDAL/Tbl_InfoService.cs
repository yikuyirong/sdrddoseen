using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_InfoService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Info(Tbl_Info tbl_info)
        {
            string sql = "insert into [Tbl_Info] ([UserName],[ClassID],[I_Title],[I_Keyword],[I_Description],[I_Content],[I_Pic],[I_File],[I_Type],[OrderNum],[UserNameTo],[NodeStatus],[NodeUser],[Status],[DealUser]) values (@UserName,@ClassID,@I_Title,@I_Keyword,@I_Description,@I_Content,@I_Pic,@I_File,@I_Type,@OrderNum,@UserNameTo,@NodeStatus,@NodeUser,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_info.UserName), 
                new SqlParameter("@ClassID",tbl_info.ClassID),
                new SqlParameter("@I_Title",tbl_info.I_Title),
                new SqlParameter("@I_Keyword",tbl_info.I_Keyword),
                new SqlParameter("@I_Description",tbl_info.I_Description),
                new SqlParameter("@I_Content",tbl_info.I_Content),
                new SqlParameter("@I_Pic",tbl_info.I_Pic),
                new SqlParameter("@I_File",tbl_info.I_File),
                new SqlParameter("@I_Type",tbl_info.I_Type),
                new SqlParameter("@OrderNum",tbl_info.OrderNum),
                new SqlParameter("@UserNameTo",tbl_info.UserNameTo),
                new SqlParameter("@NodeStatus",tbl_info.NodeStatus),
                new SqlParameter("@NodeUser",tbl_info.NodeUser),
                new SqlParameter("@Status",tbl_info.Status),
                new SqlParameter("@DealUser",tbl_info.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_InfoById(Tbl_Info tbl_info)
        {

            string sql = "update [Tbl_Info] set [UserName]=@UserName,[ClassID]=@ClassID,[I_Title]=@I_Title,[I_Keyword]=@I_Keyword,[I_Description]=@I_Description,[I_Content]=@I_Content,[I_Pic]=@I_Pic,[I_File]=@I_File,[I_Type]=@I_Type,[OrderNum]=@OrderNum,[UserNameTo]=@UserNameTo,[NodeStatus]=@NodeStatus,[NodeUser]=@NodeUser,[Status]=@Status,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_info.UserName),
                new SqlParameter("@ClassID",tbl_info.ClassID),
                new SqlParameter("@I_Title",tbl_info.I_Title),
                new SqlParameter("@I_Keyword",tbl_info.I_Keyword),
                new SqlParameter("@I_Description",tbl_info.I_Description),
                new SqlParameter("@I_Content",tbl_info.I_Content),
                new SqlParameter("@I_Pic",tbl_info.I_Pic),
                new SqlParameter("@I_File",tbl_info.I_File),
                new SqlParameter("@I_Type",tbl_info.I_Type),
                new SqlParameter("@OrderNum",tbl_info.OrderNum),
                new SqlParameter("@UserNameTo",tbl_info.UserNameTo),
                new SqlParameter("@NodeStatus",tbl_info.NodeStatus),
                new SqlParameter("@NodeUser",tbl_info.NodeUser),
                new SqlParameter("@Status",tbl_info.Status),
                new SqlParameter("@DealUser",tbl_info.DealUser),
                new SqlParameter("@DealTime",tbl_info.DealTime.ToString()),
                new SqlParameter("@ID",tbl_info.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }

        public int DeleteTbl_InfoById(int ID)
        {

            string sql = "update [Tbl_Info] set [DealFlag]=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_Info GetTbl_InfoById(int ID)
        {

            string sql = "select * from [Tbl_Info] where DealFlag=0 and ID=" + ID;
            return getTbl_InfoBySql(sql);

        }
        public IList<Tbl_Info> GetTbl_InfoAll()
        {
            string sql = "select * from [Tbl_Info] where DealFlag=0 ";
            return getTbl_InfosBySql(sql);
        }
        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_Info> getTbl_InfosBySql(string sql)
        {
            IList<Tbl_Info> list = new List<Tbl_Info>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Info tbl_info = new Tbl_Info();
                    tbl_info.ID = Convert.ToInt32(dr["ID"]);
                    tbl_info.UserName = Convert.ToString(dr["UserName"]);
                    tbl_info.ClassID = Convert.ToString(dr["ClassID"]);
                    tbl_info.I_Title = Convert.ToString(dr["I_Title"]);
                    tbl_info.I_Keyword = Convert.ToString(dr["I_Keyword"]);
                    tbl_info.I_Description = Convert.ToString(dr["I_Description"]);
                    tbl_info.I_Content = Convert.ToString(dr["I_Content"]);
                    tbl_info.I_Pic = Convert.ToString(dr["I_Pic"]);
                    tbl_info.I_File = Convert.ToString(dr["I_File"]);
                    tbl_info.I_Type = Convert.ToString(dr["I_Type"]);
                    tbl_info.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                    tbl_info.UserNameTo = Convert.ToString(dr["UserNameTo"]);
                    tbl_info.NodeStatus = Convert.ToString(dr["NodeStatus"]);
                    tbl_info.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_info.Status = Convert.ToString(dr["Status"]);
                    tbl_info.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_info.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_info.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_info.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_info);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Info getTbl_InfoBySql(string sql)
        {
            Tbl_Info tbl_info = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_info = new Tbl_Info();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_info.ID = Convert.ToInt32(dr["ID"]);
                    tbl_info.UserName = Convert.ToString(dr["UserName"]);
                    tbl_info.ClassID = Convert.ToString(dr["ClassID"]);
                    tbl_info.I_Title = Convert.ToString(dr["I_Title"]);
                    tbl_info.I_Keyword = Convert.ToString(dr["I_Keyword"]);
                    tbl_info.I_Description = Convert.ToString(dr["I_Description"]);
                    tbl_info.I_Content = Convert.ToString(dr["I_Content"]);
                    tbl_info.I_Pic = Convert.ToString(dr["I_Pic"]);
                    tbl_info.I_File = Convert.ToString(dr["I_File"]);
                    tbl_info.I_Type = Convert.ToString(dr["I_Type"]);
                    tbl_info.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                    tbl_info.UserNameTo = Convert.ToString(dr["UserNameTo"]);
                    tbl_info.NodeStatus = Convert.ToString(dr["NodeStatus"]);
                    tbl_info.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_info.Status = Convert.ToString(dr["Status"]);
                    tbl_info.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_info.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_info.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_info.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_info;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Info where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_Info where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
