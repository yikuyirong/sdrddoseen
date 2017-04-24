using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectDocumentService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectDocument(Tbl_ProjectDocument tbl_projectdocument)
        {
            string sql = "insert into [Tbl_ProjectDocument] ([UserName],[ProjectID],[ParentID],[ClassName],[PD_Type],[PD_File],[PD_FileNo],[Remark],[Status],[PD_Name],[PD_Users],[DealUser]) values (@UserName,@ProjectID,@ProjectID,@ClassName,@PD_Type,@PD_File,@PD_FileNo,@Remark,@Status,@PD_Name,@PD_Users,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_projectdocument.UserName),
                new SqlParameter("@ProjectID",tbl_projectdocument.ProjectID),
                new SqlParameter("@ParentID",tbl_projectdocument.ParentID),
                new SqlParameter("@ClassName",tbl_projectdocument.ClassName),
                new SqlParameter("@PD_Type",tbl_projectdocument.PD_Type),
                new SqlParameter("@PD_File",tbl_projectdocument.PD_File),
                new SqlParameter("@PD_FileNo",tbl_projectdocument.PD_FileNo),
                new SqlParameter("@PD_Name",tbl_projectdocument.PD_Name),
                new SqlParameter("@PD_Users",tbl_projectdocument.PD_Users),
                new SqlParameter("@Remark",tbl_projectdocument.Remark),
                new SqlParameter("@Status",tbl_projectdocument.Status),
                new SqlParameter("@DealUser",tbl_projectdocument.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectDocumentById(Tbl_ProjectDocument tbl_projectdocument)
        {

            string sql = "update [Tbl_ProjectDocument] set [UserName]=@UserName,[ProjectID]=@ProjectID,[ParentID]=@ParentID,[ClassName]=@ClassName,[PD_Type]=@PD_Type,[PD_File]=@PD_File,[PD_FileNo]=@PD_FileNo,[Remark]=@Remark,[Status]=@Status,[PD_Name]=@PD_Name,[PD_Users]=@PD_Users,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectdocument.ID),
                new SqlParameter("@UserName",tbl_projectdocument.UserName),
                new SqlParameter("@ProjectID",tbl_projectdocument.ProjectID),
                new SqlParameter("@ParentID",tbl_projectdocument.ParentID),
                new SqlParameter("@ClassName",tbl_projectdocument.ClassName),
                new SqlParameter("@PD_Type",tbl_projectdocument.PD_Type),
                new SqlParameter("@PD_File",tbl_projectdocument.PD_File),
                new SqlParameter("@PD_FileNo",tbl_projectdocument.PD_FileNo),
                new SqlParameter("@Remark",tbl_projectdocument.Remark),
                new SqlParameter("@Status",tbl_projectdocument.Status),
                new SqlParameter("@PD_Name",tbl_projectdocument.PD_Name),
                new SqlParameter("@PD_Users",tbl_projectdocument.PD_Users),
                new SqlParameter("@DealUser",tbl_projectdocument.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectDocumentById(int ID)
        {

            string sql = "update from [Tbl_ProjectDocument] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectDocument GetTbl_ProjectDocumentById(int ID)
        {

            string sql = "select * from [Tbl_ProjectDocument] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectDocumentBySql(sql);

        }
        public IList<Tbl_ProjectDocument> GetTbl_ProjectDocumentAll()
        {
            string sql = "select * from [Tbl_ProjectDocument] where DealFlag=0";
            return getTbl_ProjectDocumentsBySql(sql);
        }
        public IList<Tbl_ProjectDocument> GetTbl_ProjectDocumentParent(string where)
        {
            string sql = "select * from [Tbl_ProjectDocument] where DealFlag=0 and " + where + "";
            return getTbl_ProjectDocumentsBySql(sql);
        }
        public Tbl_ProjectDocument GetTbl_ProjectDocumentParentID(string where)
        {
            string sql = "select * from [Tbl_ProjectDocument] where DealFlag=0 and className='" + where + "'";
            return getTbl_ProjectDocumentBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectDocument> getTbl_ProjectDocumentsBySql(string sql)
        {
            IList<Tbl_ProjectDocument> list = new List<Tbl_ProjectDocument>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectDocument tbl_projectdocument = new Tbl_ProjectDocument();
                    tbl_projectdocument.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectdocument.UserName = Convert.ToString(dr["UserName"]);
                    tbl_projectdocument.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectdocument.ParentID = Convert.ToInt32(dr["ParentID"]);
                    tbl_projectdocument.ClassName = Convert.ToString(dr["ClassName"]);
                    tbl_projectdocument.PD_Type = Convert.ToString(dr["PD_Type"]);
                    tbl_projectdocument.PD_File = Convert.ToString(dr["PD_File"]);
                    tbl_projectdocument.PD_FileNo = Convert.ToString(dr["PD_FileNo"]);
                    tbl_projectdocument.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectdocument.Status = Convert.ToString(dr["Status"]);
                    tbl_projectdocument.PD_Name = Convert.ToString(dr["PD_Name"]);
                    tbl_projectdocument.PD_Users = Convert.ToString(dr["PD_Users"]);
                    tbl_projectdocument.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectdocument.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectdocument.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectdocument.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectdocument);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectDocument getTbl_ProjectDocumentBySql(string sql)
        {
            Tbl_ProjectDocument tbl_projectdocument = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectdocument = new Tbl_ProjectDocument();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectdocument.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectdocument.UserName = Convert.ToString(dr["UserName"]);
                    tbl_projectdocument.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectdocument.ParentID = Convert.ToInt32(dr["ParentID"]);
                    tbl_projectdocument.ClassName = Convert.ToString(dr["ClassName"]);
                    tbl_projectdocument.PD_Type = Convert.ToString(dr["PD_Type"]);
                    tbl_projectdocument.PD_File = Convert.ToString(dr["PD_File"]);
                    tbl_projectdocument.PD_FileNo = Convert.ToString(dr["PD_FileNo"]);
                    tbl_projectdocument.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectdocument.Status = Convert.ToString(dr["Status"]);
                    tbl_projectdocument.PD_Name = Convert.ToString(dr["PD_Name"]);
                    tbl_projectdocument.PD_Users = Convert.ToString(dr["PD_Users"]);
                    tbl_projectdocument.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectdocument.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectdocument.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectdocument.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectdocument;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectDocument where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectDocument.projectID) as ProjectName from Tbl_ProjectDocument where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
