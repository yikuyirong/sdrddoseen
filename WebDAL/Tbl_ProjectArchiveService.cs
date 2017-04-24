using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectArchiveService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectArchive(Tbl_ProjectArchive tbl_projectarchive)
        {
            string sql = "insert into [Tbl_ProjectArchive] ([ProjectID],[ClassName1],[ClassName2],[ClassName3],[PA_Type1],[PA_Type2],[ParentID],[PA_Limit],[PA_Name],[PA_File],[PA_FileNo],[PA_Info],[Status],[DealUser]) values (@ProjectID,@ClassName1,@ClassName2,@ClassName3,@PA_Type1,@PA_Type2,@ParentID,@PA_Limit,@PA_Name,@PA_File,@PA_FileNo,@PA_Info,@Status,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectarchive.ProjectID),
                new SqlParameter("@ClassName1",tbl_projectarchive.ClassName1),
                new SqlParameter("@ClassName2",tbl_projectarchive.ClassName2),
                new SqlParameter("@ClassName3",tbl_projectarchive.ClassName3),
                new SqlParameter("@PA_Type1",tbl_projectarchive.PA_Type1),
                new SqlParameter("@PA_Type2",tbl_projectarchive.PA_Type2),
                new SqlParameter("@ParentID",tbl_projectarchive.ParentID),
                new SqlParameter("@PA_Limit",tbl_projectarchive.PA_Limit),
                new SqlParameter("@PA_Name",tbl_projectarchive.PA_Name),
                new SqlParameter("@PA_File",tbl_projectarchive.PA_File),
                new SqlParameter("@PA_FileNo",tbl_projectarchive.PA_FileNo),
                new SqlParameter("@PA_Info",tbl_projectarchive.PA_Info),
                new SqlParameter("@Status",tbl_projectarchive.Status),
                new SqlParameter("@DealUser",tbl_projectarchive.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectArchiveById(Tbl_ProjectArchive tbl_projectarchive)
        {

            string sql = "update [Tbl_ProjectArchive] set [ProjectID]=@ProjectID,[ClassName1]=@ClassName1,[ClassName2]=@ClassName2,[ClassName3]=@ClassName3,[PA_Type1]=@PA_Type1,[PA_Type2]=@PA_Type2,[ParentID]=@ParentID,[PA_Limit]=@PA_Limit,[PA_Name]=@PA_Name,[PA_File]=@PA_File,[PA_FileNo]=@PA_FileNo,[PA_Info]=@PA_Info,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@ID",tbl_projectarchive.ID),
                new SqlParameter("@ProjectID",tbl_projectarchive.ProjectID),
                new SqlParameter("@ClassName1",tbl_projectarchive.ClassName1),
                new SqlParameter("@ClassName2",tbl_projectarchive.ClassName2),
                new SqlParameter("@ClassName3",tbl_projectarchive.ClassName3),
                new SqlParameter("@PA_Type1",tbl_projectarchive.PA_Type1),
                new SqlParameter("@PA_Type2",tbl_projectarchive.PA_Type2),
                new SqlParameter("@ParentID",tbl_projectarchive.ParentID),
                 new SqlParameter("@PA_Limit",tbl_projectarchive.PA_Limit),
                new SqlParameter("@PA_Name",tbl_projectarchive.PA_Name),
                new SqlParameter("@PA_File",tbl_projectarchive.PA_File),
                new SqlParameter("@PA_FileNo",tbl_projectarchive.PA_FileNo),
                new SqlParameter("@PA_Info",tbl_projectarchive.PA_Info),
                new SqlParameter("@Status",tbl_projectarchive.Status),
                new SqlParameter("@DealUser",tbl_projectarchive.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectArchiveById(int ID)
        {

            string sql = "update from [Tbl_ProjectArchive] set [DealFlag]=1  where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectArchive GetTbl_ProjectArchiveById(int ID)
        {

            string sql = "select * from [Tbl_ProjectArchive] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectArchiveBySql(sql);

        }
        public IList<Tbl_ProjectArchive> GetTbl_ProjectArchiveAll()
        {
            string sql = "select * from [Tbl_ProjectArchive] where DealFlag=0";
            return getTbl_ProjectArchivesBySql(sql);
        }
        public IList<Tbl_ProjectArchive> GetTbl_ProjectArchiveParentName(string where)
        {
            string sql = "select * from [Tbl_ProjectArchive] where DealFlag=0 and " + where;
            return getTbl_ProjectArchivesBySql(sql);
        }
        
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectArchive> getTbl_ProjectArchivesBySql(string sql)
        {
            IList<Tbl_ProjectArchive> list = new List<Tbl_ProjectArchive>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectArchive tbl_projectarchive = new Tbl_ProjectArchive();
                    tbl_projectarchive.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectarchive.ProjectID = Convert.ToInt32(dr["ProjectID"]); 
                    tbl_projectarchive.ClassName1 = Convert.ToString(dr["ClassName1"]);
                    tbl_projectarchive.ClassName2 = Convert.ToString(dr["ClassName2"]);
                    tbl_projectarchive.ClassName3 = Convert.ToString(dr["ClassName3"]);
                    tbl_projectarchive.PA_Type1 = Convert.ToString(dr["PA_Type1"]);
                    tbl_projectarchive.PA_Type2 = Convert.ToString(dr["PA_Type2"]);
                    tbl_projectarchive.ParentID = Convert.ToInt32(dr["ParentID"]);
                    tbl_projectarchive.PA_Limit = Convert.ToString(dr["PA_Limit"]);
                    tbl_projectarchive.PA_Name = Convert.ToString(dr["PA_Name"]);
                    tbl_projectarchive.PA_File = Convert.ToString(dr["PA_File"]);
                    tbl_projectarchive.PA_FileNo = Convert.ToString(dr["PA_FileNo"]);
                    tbl_projectarchive.PA_Info = Convert.ToString(dr["PA_Info"]);    
                    tbl_projectarchive.Status = Convert.ToString(dr["Status"]);      
                    tbl_projectarchive.DealFlag = Convert.ToInt32(dr["DealFlag"]);   
                    tbl_projectarchive.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectarchive.DealUser = Convert.ToString(dr["DealUser"]);  
                    tbl_projectarchive.AddDate = Convert.ToDateTime(dr["AddDate"]);  
                    list.Add(tbl_projectarchive);                                    
                }                                                                    
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectArchive getTbl_ProjectArchiveBySql(string sql)
        {
            Tbl_ProjectArchive tbl_projectarchive = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectarchive = new Tbl_ProjectArchive();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectarchive.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectarchive.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectarchive.ClassName1 = Convert.ToString(dr["ClassName1"]);
                    tbl_projectarchive.ClassName2 = Convert.ToString(dr["ClassName2"]);
                    tbl_projectarchive.ClassName3 = Convert.ToString(dr["ClassName3"]);
                    tbl_projectarchive.PA_Type1 = Convert.ToString(dr["PA_Type1"]);
                    tbl_projectarchive.PA_Type2 = Convert.ToString(dr["PA_Type2"]);
                    tbl_projectarchive.ParentID = Convert.ToInt32(dr["ParentID"]);
                    tbl_projectarchive.PA_Limit = Convert.ToString(dr["PA_Limit"]);
                    tbl_projectarchive.PA_Name = Convert.ToString(dr["PA_Name"]);
                    tbl_projectarchive.PA_File = Convert.ToString(dr["PA_File"]);
                    tbl_projectarchive.PA_FileNo = Convert.ToString(dr["PA_FileNo"]);
                    tbl_projectarchive.PA_Info = Convert.ToString(dr["PA_Info"]);
                    tbl_projectarchive.Status = Convert.ToString(dr["Status"]);
                    tbl_projectarchive.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectarchive.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectarchive.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectarchive.AddDate = Convert.ToDateTime(dr["AddDate"]);  
                }
            }
            return tbl_projectarchive;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectArchive where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "SELECT   *,(SELECT   TOP 1 PA_FileNo  FROM Tbl_ProjectArchive WHERE (ParentID = a.ID) AND (Status = '已审核') OR (Status = '已审核') AND (ID = a.ID) ORDER BY ID DESC) AS NewFileVersion,(SELECT   TOP 1 PA_File FROM  Tbl_ProjectArchive AS b WHERE (ParentID = a.ID) AND (Status = '已审核') OR  (Status = '已审核') AND (ID = a.ID) ORDER BY ID DESC) AS NewFile,(select ProjectName from tbl_Project where id=a.ProjectID) as ProjectName FROM  Tbl_ProjectArchive AS a WHERE   (ParentID = 0) AND (DealFlag = 0)";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
