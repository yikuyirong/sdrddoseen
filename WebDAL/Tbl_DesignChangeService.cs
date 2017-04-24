using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_DesignChangeService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_DesignChange(Tbl_DesignChange tbl_designchange)
        {
            string sql = "insert into [Tbl_DesignChange] ([UserName],[ProjectID],[Contact],[Phone],[FileNo],[ChangeTime],[ChangeInfo],[ChangeFile],[ChangeDwg],[Status],[DealUser]) values (@UserName,@ProjectID,@Contact,@Phone,@FileNo,@ChangeTime,@ChangeInfo,@ChangeFile,@ChangeDwg,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_designchange.UserName),
                new SqlParameter("@ProjectID",tbl_designchange.ProjectID),
                new SqlParameter("@Contact",tbl_designchange.Contact),
                new SqlParameter("@Phone",tbl_designchange.Phone),
                new SqlParameter("@FileNo",tbl_designchange.FileNo),
                new SqlParameter("@ChangeTime",tbl_designchange.ChangeTime),
                new SqlParameter("@ChangeInfo",tbl_designchange.ChangeInfo),
                new SqlParameter("@ChangeFile",tbl_designchange.ChangeFile),
                new SqlParameter("@ChangeDwg",tbl_designchange.ChangeDwg),
                new SqlParameter("@Status",tbl_designchange.Status),
                new SqlParameter("@DealUser",tbl_designchange.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_DesignChangeById(Tbl_DesignChange tbl_designchange)
        {

            string sql = "update [Tbl_DesignChange] set [UserName]=@UserName,[ProjectID]=@ProjectID,[Contact]=@Contact,[Phone]=@Phone,[FileNo]=@FileNo,[ChangeTime]=@ChangeTime,[ChangeInfo]=@ChangeInfo,[ChangeFile]=@ChangeFile,[ChangeDwg]=@ChangeDwg,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_designchange.ID),
                new SqlParameter("@UserName",tbl_designchange.UserName),
                new SqlParameter("@ProjectID",tbl_designchange.ProjectID),
                new SqlParameter("@Contact",tbl_designchange.Contact),
                new SqlParameter("@Phone",tbl_designchange.Phone),
                new SqlParameter("@FileNo",tbl_designchange.FileNo),
                new SqlParameter("@ChangeTime",tbl_designchange.ChangeTime),
                new SqlParameter("@ChangeInfo",tbl_designchange.ChangeInfo),
                new SqlParameter("@ChangeFile",tbl_designchange.ChangeFile),
                new SqlParameter("@ChangeDwg",tbl_designchange.ChangeDwg),
                new SqlParameter("@Status",tbl_designchange.Status),
                new SqlParameter("@DealUser",tbl_designchange.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_DesignChangeById(int ID)
        {

            string sql = "update from [Tbl_DesignChange] set DealFlag=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_DesignChange GetTbl_DesignChangeById(int ID)
        {

            string sql = "select * from [Tbl_DesignChange] where DealFlag=0 and ID=" + ID;
            return getTbl_DesignChangeBySql(sql);

        }
        public IList<Tbl_DesignChange> GetTbl_DesignChangeAll()
        {
            string sql = "select * from [Tbl_DesignChange] where DealFlag=0";
            return getTbl_DesignChangesBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_DesignChange> getTbl_DesignChangesBySql(string sql)
        {
            IList<Tbl_DesignChange> list = new List<Tbl_DesignChange>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_DesignChange tbl_designchange = new Tbl_DesignChange();
                    tbl_designchange.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designchange.UserName = Convert.ToString(dr["UserName"]);
                    tbl_designchange.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_designchange.Contact = Convert.ToString(dr["Contact"]);
                    tbl_designchange.Phone = Convert.ToString(dr["Phone"]);
                    tbl_designchange.FileNo = Convert.ToString(dr["FileNo"]);
                    tbl_designchange.ChangeTime = Convert.ToDateTime(dr["ChangeTime"]);
                    tbl_designchange.ChangeInfo = Convert.ToString(dr["ChangeInfo"]);
                    tbl_designchange.ChangeFile = Convert.ToString(dr["ChangeFile"]);
                    tbl_designchange.ChangeDwg = Convert.ToString(dr["ChangeDwg"]);
                    tbl_designchange.Status = Convert.ToString(dr["Status"]);
                    tbl_designchange.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designchange.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_designchange.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designchange.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_designchange);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_DesignChange getTbl_DesignChangeBySql(string sql)
        {
            Tbl_DesignChange tbl_designchange = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_designchange = new Tbl_DesignChange();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_designchange.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designchange.UserName = Convert.ToString(dr["UserName"]);
                    tbl_designchange.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_designchange.Contact = Convert.ToString(dr["Contact"]);
                    tbl_designchange.Phone = Convert.ToString(dr["Phone"]);
                    tbl_designchange.FileNo = Convert.ToString(dr["FileNo"]);
                    tbl_designchange.ChangeTime = Convert.ToDateTime(dr["ChangeTime"]);
                    tbl_designchange.ChangeInfo = Convert.ToString(dr["ChangeInfo"]);
                    tbl_designchange.ChangeFile = Convert.ToString(dr["ChangeFile"]);
                    tbl_designchange.ChangeDwg = Convert.ToString(dr["ChangeDwg"]);
                    tbl_designchange.Status = Convert.ToString(dr["Status"]);
                    tbl_designchange.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designchange.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_designchange.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designchange.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_designchange;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from  Tbl_DesignChange where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_Project where id=Tbl_DesignChange.projectID) as ProjectName from Tbl_DesignChange where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
