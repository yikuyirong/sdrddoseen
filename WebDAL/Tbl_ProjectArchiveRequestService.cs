using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectArchiveRequestService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectArchiveRequest(Tbl_ProjectArchiveRequest tbl_projectarchiverequest)
        {
            string sql = "insert into [Tbl_ProjectArchiveRequest] ([ProjectID],[ClassName1],[ClassName2],[ClassName3],[NodeNo],[NodeUser],[PA_Type1],[PA_Type2],[ProjectArchiveID],[Remark],[RequestType],[Status],[UserName],[DealUser]) values (@ProjectID,@ClassName1,@ClassName2,@ClassName3,@NodeNo,@NodeUser,@PA_Type1,@PA_Type2,@ProjectArchiveID,@Remark,@RequestType,@Status,@UserName,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectarchiverequest.ProjectID),
                new SqlParameter("@ClassName1",tbl_projectarchiverequest.ClassName1),
                new SqlParameter("@ClassName2",tbl_projectarchiverequest.ClassName2),
                new SqlParameter("@ClassName3",tbl_projectarchiverequest.ClassName3),
                new SqlParameter("@PA_Type1",tbl_projectarchiverequest.PA_Type1),
                new SqlParameter("@PA_Type2",tbl_projectarchiverequest.PA_Type2),
                new SqlParameter("@NodeNo",tbl_projectarchiverequest.NodeNo),
                new SqlParameter("@NodeUser",tbl_projectarchiverequest.NodeUser),
                new SqlParameter("@ProjectArchiveID",tbl_projectarchiverequest.ProjectArchiveID),
                new SqlParameter("@Remark",tbl_projectarchiverequest.Remark),
                new SqlParameter("@RequestType",tbl_projectarchiverequest.RequestType),
                new SqlParameter("@Status",tbl_projectarchiverequest.Status),
                new SqlParameter("@UserName",tbl_projectarchiverequest.UserName),
                new SqlParameter("@DealUser",tbl_projectarchiverequest.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectArchiveRequestById(Tbl_ProjectArchiveRequest tbl_projectarchiverequest)
        {

            string sql = "update [Tbl_ProjectArchiveRequest] set [ProjectID]=@ProjectID,[ClassName1]=@ClassName1,[ClassName2]=@ClassName2,[ClassName3]=@ClassName3,[NodeNo]=@NodeNo,[NodeUser]=@NodeUser,[PA_Type1]=@PA_Type1,[PA_Type2]=@PA_Type2,[ProjectArchiveID]=@ProjectArchiveID,[Remark]=@Remark,[RequestType]=@RequestType,[UserName]=@UserName,[Status]=@Status,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectarchiverequest.ID),
                new SqlParameter("@ProjectID",tbl_projectarchiverequest.ProjectID),
                new SqlParameter("@ClassName1",tbl_projectarchiverequest.ClassName1),
                new SqlParameter("@ClassName2",tbl_projectarchiverequest.ClassName2),
                new SqlParameter("@ClassName3",tbl_projectarchiverequest.ClassName3),
                new SqlParameter("@PA_Type1",tbl_projectarchiverequest.PA_Type1),
                new SqlParameter("@PA_Type2",tbl_projectarchiverequest.PA_Type2),
                new SqlParameter("@NodeNo",tbl_projectarchiverequest.NodeNo),
                new SqlParameter("@NodeUser",tbl_projectarchiverequest.NodeUser),
                new SqlParameter("@ProjectArchiveID",tbl_projectarchiverequest.ProjectArchiveID),
                new SqlParameter("@Remark",tbl_projectarchiverequest.Remark),
                new SqlParameter("@RequestType",tbl_projectarchiverequest.RequestType),
                new SqlParameter("@Status",tbl_projectarchiverequest.Status),
                new SqlParameter("@UserName",tbl_projectarchiverequest.UserName),
                new SqlParameter("@DealUser",tbl_projectarchiverequest.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectArchiveRequestById(int ID)
        {

            string sql = "update from [Tbl_ProjectArchiveRequest] set [DealFlag]=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_ProjectArchiveRequest GetTbl_ProjectArchiveRequestById(int ID)
        {

            string sql = "select * from [Tbl_ProjectArchiveRequest] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectArchiveRequestBySql(sql);

        }
        public IList<Tbl_ProjectArchiveRequest> GetTbl_ProjectArchiveRequestAll()
        {
            string sql = "select * from [Tbl_ProjectArchiveRequest] where DealFlag=0";
            return getTbl_ProjectArchiveRequestsBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectArchiveRequest> getTbl_ProjectArchiveRequestsBySql(string sql)
        {
            IList<Tbl_ProjectArchiveRequest> list = new List<Tbl_ProjectArchiveRequest>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectArchiveRequest tbl_projectarchiverequest = new Tbl_ProjectArchiveRequest();
                    tbl_projectarchiverequest.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectarchiverequest.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectarchiverequest.ClassName1 = Convert.ToString(dr["ClassName1"]);
                    tbl_projectarchiverequest.ClassName2 = Convert.ToString(dr["ClassName2"]);
                    tbl_projectarchiverequest.ClassName3 = Convert.ToString(dr["ClassName3"]);
                    tbl_projectarchiverequest.PA_Type1 = Convert.ToString(dr["PA_Type1"]);
                    tbl_projectarchiverequest.PA_Type2 = Convert.ToString(dr["PA_Type2"]);
                    tbl_projectarchiverequest.NodeNo = Convert.ToString(dr["NodeNo"]);
                    tbl_projectarchiverequest.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_projectarchiverequest.ProjectArchiveID = Convert.ToInt32(dr["ProjectArchiveID"]);
                    tbl_projectarchiverequest.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectarchiverequest.RequestType = Convert.ToString(dr["RequestType"]);
                    tbl_projectarchiverequest.Status = Convert.ToString(dr["Status"]);
                    tbl_projectarchiverequest.UserName = Convert.ToString(dr["UserName"]);
                    tbl_projectarchiverequest.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectarchiverequest.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectarchiverequest.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectarchiverequest.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_projectarchiverequest);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectArchiveRequest getTbl_ProjectArchiveRequestBySql(string sql)
        {
            Tbl_ProjectArchiveRequest tbl_projectarchiverequest = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectarchiverequest = new Tbl_ProjectArchiveRequest();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectarchiverequest.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectarchiverequest.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectarchiverequest.ClassName1 = Convert.ToString(dr["ClassName1"]);
                    tbl_projectarchiverequest.ClassName2 = Convert.ToString(dr["ClassName2"]);
                    tbl_projectarchiverequest.ClassName3 = Convert.ToString(dr["ClassName3"]);
                    tbl_projectarchiverequest.PA_Type1 = Convert.ToString(dr["PA_Type1"]);
                    tbl_projectarchiverequest.PA_Type2 = Convert.ToString(dr["PA_Type2"]);
                    tbl_projectarchiverequest.NodeNo = Convert.ToString(dr["NodeNo"]);
                    tbl_projectarchiverequest.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_projectarchiverequest.ProjectArchiveID = Convert.ToInt32(dr["ProjectArchiveID"]);
                    tbl_projectarchiverequest.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectarchiverequest.RequestType = Convert.ToString(dr["RequestType"]);
                    tbl_projectarchiverequest.Status = Convert.ToString(dr["Status"]);
                    tbl_projectarchiverequest.UserName = Convert.ToString(dr["UserName"]);
                    tbl_projectarchiverequest.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectarchiverequest.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_projectarchiverequest.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectarchiverequest.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_projectarchiverequest;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectArchiveRequest where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select ProjectName from tbl_project where id=Tbl_ProjectArchiveRequest.ProjectID) as ProjectName,(select PA_Name from Tbl_ProjectArchive where ID=Tbl_ProjectArchiveRequest.ProjectArchiveID) as ProjectArchiveName,(select PA_File from Tbl_ProjectArchive where ID=Tbl_ProjectArchiveRequest.ProjectArchiveID) as ProjectArchiveFile from Tbl_ProjectArchiveRequest where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
