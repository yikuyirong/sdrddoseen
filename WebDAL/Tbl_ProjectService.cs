using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_Project(Tbl_Project tbl_project)
        {
            string sql = "insert into [Tbl_Project] ([UserName],[ProjectNo],[ProjectName],[ProjectMW],[ProjectCustom],[ProjectCustomContact],[ProjectCustomPhone],[ProjectManager],[ProjectTypes],[ProjectCity],[ProjectLevel],[ProjectInfo],[NodeNo],[NodeUser],[DealUser],[Status]) values (@UserName,@ProjectNo,@ProjectName,@ProjectMW,@ProjectCustom,@ProjectCustomContact,@ProjectCustomPhone,@ProjectManager,@ProjectTypes,@ProjectCity,@ProjectLevel,@ProjectInfo,@NodeNo,@NodeUser,@DealUser,@Status)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_project.DealUser),
                new SqlParameter("@ProjectNo",tbl_project.ProjectNo),
                new SqlParameter("@ProjectName",tbl_project.ProjectName),
                new SqlParameter("@ProjectMW",tbl_project.ProjectMW),
                new SqlParameter("@ProjectCustom",tbl_project.ProjectCustom),
                new SqlParameter("@ProjectCustomContact",tbl_project.ProjectCustomContact),
                new SqlParameter("@ProjectCustomPhone",tbl_project.ProjectCustomPhone),
                new SqlParameter("@ProjectManager",tbl_project.ProjectManager),
                new SqlParameter("@ProjectTypes",tbl_project.ProjectTypes),
                new SqlParameter("@ProjectCity",tbl_project.ProjectCity),
                new SqlParameter("@ProjectLevel",tbl_project.ProjectLevel),
                new SqlParameter("@ProjectInfo",tbl_project.ProjectInfo),
                new SqlParameter("@NodeNo",tbl_project.NodeNo),
                new SqlParameter("@NodeUser",tbl_project.NodeUser),
                new SqlParameter("@Status",tbl_project.Status),
                new SqlParameter("@DealUser",tbl_project.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectById(Tbl_Project tbl_project)
        {

            string sql = "update [Tbl_Project] set [ProjectNo]=@ProjectNo,[ProjectMW]=@ProjectMW,[NodeNo]=@NodeNo,[NodeUser]=@NodeUser,[Status]=@Status,[ProjectName]=@ProjectName,[ProjectCustom]=@ProjectCustom,[ProjectCustomContact]=@ProjectCustomContact,[ProjectCustomPhone]=@ProjectCustomPhone,[ProjectManager]=@ProjectManager,[ProjectMainDesigner]=@ProjectMainDesigner,[ProjectTypes]=@ProjectTypes,[ProjectCity]=@ProjectCity,[ProjectLevel]=@ProjectLevel,[ProjectInfo]=@ProjectInfo,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_project.ID),
                new SqlParameter("@ProjectNo",tbl_project.ProjectNo),
                new SqlParameter("@ProjectName",tbl_project.ProjectName),
                new SqlParameter("@ProjectMW",tbl_project.ProjectMW),
                new SqlParameter("@ProjectCustom",tbl_project.ProjectCustom),
                new SqlParameter("@ProjectCustomContact",tbl_project.ProjectCustomContact),
                new SqlParameter("@ProjectCustomPhone",tbl_project.ProjectCustomPhone),
                new SqlParameter("@ProjectManager",tbl_project.ProjectManager),
                 new SqlParameter("@ProjectMainDesigner",tbl_project.ProjectMainDesigner),
                new SqlParameter("@ProjectTypes",tbl_project.ProjectTypes),
                new SqlParameter("@ProjectCity",tbl_project.ProjectCity),
                new SqlParameter("@ProjectLevel",tbl_project.ProjectLevel),
                new SqlParameter("@ProjectInfo",tbl_project.ProjectInfo),
                new SqlParameter("@NodeNo",tbl_project.NodeNo),
                new SqlParameter("@NodeUser",tbl_project.NodeUser),
                new SqlParameter("@Status",tbl_project.Status),
                new SqlParameter("@DealUser",tbl_project.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_ProjectById(int ID)
        {

            string sql = "update from [Tbl_Project] set DealFlag=1 where DealFlag=0 and [ID]="+ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_Project GetTbl_ProjectById(int ID)
        {

            string sql = "select * from [Tbl_Project] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectBySql(sql);

        }
        public IList<Tbl_Project> GetTbl_ProjectAll()
        {
            string sql = "select * from [Tbl_Project] where DealFlag=0";
            return getTbl_ProjectsBySql(sql);
        }
        public IList<Tbl_Project> GetTbl_ProjectByProjectTypes(string ProjectTypes)
        {
            string sql = "select * from [Tbl_Project] where DealFlag=0 and ProjectTypes='" + ProjectTypes + "'";
            return getTbl_ProjectsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_Project> getTbl_ProjectsBySql(string sql)
        {
            IList<Tbl_Project> list = new List<Tbl_Project>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_Project tbl_project = new Tbl_Project();
                    tbl_project.ID = Convert.ToInt32(dr["ID"]);
                    tbl_project.UserName = Convert.ToString(dr["UserName"]);
                    tbl_project.ProjectNo = Convert.ToString(dr["ProjectNo"]);
                    tbl_project.ProjectName = Convert.ToString(dr["ProjectName"]);
                    tbl_project.ProjectMW = Convert.ToString(dr["ProjectMW"]);
                    tbl_project.ProjectCustom = Convert.ToString(dr["ProjectCustom"]);
                    tbl_project.ProjectCustomContact = Convert.ToString(dr["ProjectCustomContact"]);
                    tbl_project.ProjectCustomPhone = Convert.ToString(dr["ProjectCustomPhone"]);
                    tbl_project.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                    tbl_project.ProjectMainDesigner = Convert.ToString(dr["ProjectMainDesigner"]);
                    //tbl_project.ProjectStartTime = Convert.ToDateTime(dr["ProjectStartTime"]);
                    //tbl_project.ProjectEndTime = Convert.ToDateTime(dr["ProjectEndTime"]);
                    tbl_project.ProjectTypes = Convert.ToString(dr["ProjectTypes"]);
                    tbl_project.ProjectCity = Convert.ToString(dr["ProjectCity"]);
                    tbl_project.ProjectLevel = Convert.ToString(dr["ProjectLevel"]);
                    tbl_project.ProjectInfo = Convert.ToString(dr["ProjectInfo"]);
                    tbl_project.NodeNo = Convert.ToString(dr["NodeNo"]);
                    tbl_project.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_project.Status = Convert.ToString(dr["Status"]);
                    tbl_project.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_project.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_project.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_project.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_project);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_Project getTbl_ProjectBySql(string sql)
        {
            Tbl_Project tbl_project = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_project = new Tbl_Project();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_project.ID = Convert.ToInt32(dr["ID"]);
                    tbl_project.UserName = Convert.ToString(dr["UserName"]);
                    tbl_project.ProjectNo = Convert.ToString(dr["ProjectNo"]);
                    tbl_project.ProjectName = Convert.ToString(dr["ProjectName"]);
                    tbl_project.ProjectMW = Convert.ToString(dr["ProjectMW"]);
                    tbl_project.ProjectCustom = Convert.ToString(dr["ProjectCustom"]);
                    tbl_project.ProjectCustomContact = Convert.ToString(dr["ProjectCustomContact"]);
                    tbl_project.ProjectCustomPhone = Convert.ToString(dr["ProjectCustomPhone"]);
                    tbl_project.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                    tbl_project.ProjectMainDesigner = Convert.ToString(dr["ProjectMainDesigner"]);
                    //tbl_project.ProjectStartTime = Convert.ToDateTime(dr["ProjectStartTime"]);
                    //tbl_project.ProjectEndTime = Convert.ToDateTime(dr["ProjectEndTime"]);
                    tbl_project.ProjectTypes = Convert.ToString(dr["ProjectTypes"]);
                    tbl_project.ProjectCity = Convert.ToString(dr["ProjectCity"]);
                    tbl_project.ProjectLevel = Convert.ToString(dr["ProjectLevel"]);
                    tbl_project.ProjectInfo = Convert.ToString(dr["ProjectInfo"]);
                    tbl_project.NodeNo = Convert.ToString(dr["NodeNo"]);
                    tbl_project.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_project.Status = Convert.ToString(dr["Status"]);
                    tbl_project.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_project.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_project.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_project.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_project;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_Project where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_Project where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage2(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select sum(dt_gugong) from tbl_designtask where projectid=Tbl_Project.id) as GuGongNum1,(select sum(dt_gugong) from tbl_designtask where projectid=Tbl_Project.id and status='结束') as GuGongNum2 from Tbl_Project where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

        //工作计划
        public DataTable GetDataTableByWork(string Where, string Order)
        {
            string sql = "select * from Tbl_Project as a  LEFT JOIN tbl_flownodetask as b on a.ID=b.ProjectID where a.DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, 6, 7);
            return dt;
        }

    }
}
