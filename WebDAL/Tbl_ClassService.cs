using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_ClassService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Class(Tbl_Class tbl_class)
        {
            string sql = "insert into [Tbl_Class] ([ClassName],[ParentID],[Remark],[OrderNum],[Status],[DealUser]) values (@ClassName,@ParentID,@Remark,@OrderNum,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ClassName",tbl_class.ClassName),
                new SqlParameter("@ParentID",tbl_class.ParentID),
                new SqlParameter("@Remark",tbl_class.Remark),
                new SqlParameter("@OrderNum",tbl_class.OrderNum),
                new SqlParameter("@Status",tbl_class.Status),
                new SqlParameter("@DealUser",tbl_class.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_ClassById(Tbl_Class tbl_class)
        {

            string sql = "update [Tbl_Class] set [ClassName]=@ClassName,[ParentID]=@ParentID,[Remark]=@Remark,[OrderNum]=@OrderNum,[Status]=@Status,[DealFlag]=@DealFlag,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                
                new SqlParameter("@ClassName",tbl_class.ClassName),
                new SqlParameter("@ParentID",tbl_class.ParentID),
                new SqlParameter("@Remark",tbl_class.Remark),
                new SqlParameter("@OrderNum",tbl_class.OrderNum),
                new SqlParameter("@Status",tbl_class.Status),
                new SqlParameter("@DealFlag",tbl_class.DealFlag),
                new SqlParameter("@DealUser",tbl_class.DealUser),
                new SqlParameter("@DealTime",tbl_class.DealTime.ToString()),               
                new SqlParameter("@ID",tbl_class.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }

        public int DeleteTbl_ClassById(int ID)
        {

            string sql = "update [Tbl_Class] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_Class GetTbl_ClassById(int ID)
        {

            string sql = "select * from [Tbl_Class] where DealFlag=0  and ID=" + ID;
            return getTbl_ClassBySql(sql);

        }
        public IList<Tbl_Class> GetTbl_ClassAll()
        {
            string sql = "select * from [Tbl_Class] where DealFlag=0 ";
            return getTbl_ClasssBySql(sql);
        }
        public Tbl_Class GetTbl_ClassRemark(string Remark)
        {
            string sql = "select * from [Tbl_Class] where DealFlag=0 and className='" + Remark + "'";
            return getTbl_ClassBySql(sql);
        }
        public IList<Tbl_Class> GetTbl_ClassByParentID(int ParentID)
        {
            string sql = "select * from [Tbl_Class] where DealFlag=0  and ParentID=" + ParentID.ToString()+" order by id asc";
            return getTbl_ClasssBySql(sql);
        }

        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_Class> getTbl_ClasssBySql(string sql)
        {
            IList<Tbl_Class> list = new List<Tbl_Class>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Class tbl_class = new Tbl_Class();
                    tbl_class.ID = Convert.ToInt32(dr["ID"]);
                    tbl_class.ClassName = Convert.ToString(dr["ClassName"]);
                    tbl_class.ParentID = Convert.ToInt32(dr["ParentID"]);
                    tbl_class.Remark = Convert.ToString(dr["Remark"]);
                    tbl_class.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                    tbl_class.Status = Convert.ToString(dr["Status"]);
                    tbl_class.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_class.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_class.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_class.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_class);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Class getTbl_ClassBySql(string sql)
        {
            Tbl_Class tbl_class = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_class = new Tbl_Class();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_class.ID = Convert.ToInt32(dr["ID"]);
                    tbl_class.ClassName = Convert.ToString(dr["ClassName"]);
                    tbl_class.ParentID = Convert.ToInt32(dr["ParentID"]);
                    tbl_class.Remark = Convert.ToString(dr["Remark"]);
                    tbl_class.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                    tbl_class.Status = Convert.ToString(dr["Status"]);
                    tbl_class.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_class.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_class.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_class.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_class;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Class where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_Class where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
