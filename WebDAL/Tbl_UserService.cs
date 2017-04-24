using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_UserService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_User(Tbl_User tbl_user)
        {
            string sql = "insert into [Tbl_User] ([UserName],[LimitID],[U_DesignLimit],[UserPwd],[U_DepartID],[U_JobID],[U_Specialty],[U_Name],[U_Sex],[U_Degrees],[U_GraduateTime],[U_EntryTime],[U_Professional],[U_Phone],[U_Mobile],[U_Email],[Status],[U_Sign],[U_SignDxf],[U_JobRank],[U_JobTitle],[U_ContractStartTime],[U_ContractEndTime],[U_DocumentTime],[U_CardID],[Remark],[DealUser]) values (@UserName,@LimitID,@U_DesignLimit,@UserPwd,@U_DepartID,@U_JobID,@U_Specialty,@U_Name,@U_Sex,@U_Degrees,@U_GraduateTime,@U_EntryTime,@U_Professional,@U_Phone,@U_Mobile,@U_Email,@Status,@U_Sign,@U_SignDxf,@U_JobRank,@U_JobTitle,@U_ContractStartTime,@U_ContractEndTime,@U_DocumentTime,@U_CardID,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_user.UserName),
                new SqlParameter("@LimitID",tbl_user.LimitID),
                new SqlParameter("@U_DesignLimit",tbl_user.U_DesignLimit),
                new SqlParameter("@UserPwd",tbl_user.UserPwd),
                new SqlParameter("@U_DepartID",tbl_user.U_DepartID),
                new SqlParameter("@U_JobID",tbl_user.U_JobID),
                new SqlParameter("@U_Specialty",tbl_user.U_Specialty),
                new SqlParameter("@U_Name",tbl_user.U_Name),
                new SqlParameter("@U_Sex",tbl_user.U_Sex),
                new SqlParameter("@U_Degrees",tbl_user.U_Degrees),
                new SqlParameter("@U_GraduateTime",tbl_user.U_GraduateTime),
                new SqlParameter("@U_EntryTime",tbl_user.U_EntryTime),
                new SqlParameter("@U_Professional",tbl_user.U_Professional),
                new SqlParameter("@U_Phone",tbl_user.U_Phone),
                new SqlParameter("@U_Mobile",tbl_user.U_Mobile),
                new SqlParameter("@U_Email",tbl_user.U_Email),
                new SqlParameter("@Status",tbl_user.Status),
                new SqlParameter("@U_Sign",tbl_user.U_Sign),
                new SqlParameter("@U_SignDxf",tbl_user.U_SignDxf),
                new SqlParameter("@U_JobRank",tbl_user.U_JobRank),
                new SqlParameter("@U_JobTitle",tbl_user.U_JobTitle),
                new SqlParameter("@U_ContractStartTime",tbl_user.U_ContractStartTime),
                new SqlParameter("@U_ContractEndTime",tbl_user.U_ContractEndTime),
                new SqlParameter("@U_DocumentTime",tbl_user.U_DocumentTime),
                new SqlParameter("@U_CardID",tbl_user.U_CardID),
                new SqlParameter("@Remark",tbl_user.Remark),
                new SqlParameter("@DealUser",tbl_user.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_UserById(Tbl_User tbl_user)
        {

            string sql = "update [Tbl_User] set [UserName]=@UserName,[LimitID]=@LimitID,[U_DesignLimit]=@U_DesignLimit,[UserPwd]=@UserPwd,[U_DepartID]=@U_DepartID,[U_JobID]=@U_JobID,[U_Specialty]=@U_Specialty,[U_Name]=@U_Name,[U_Sex]=@U_Sex,[U_Degrees]=@U_Degrees,[U_GraduateTime]=@U_GraduateTime,[U_EntryTime]=@U_EntryTime,[U_Professional]=@U_Professional,[U_Phone]=@U_Phone,[U_Mobile]=@U_Mobile,[U_Email]=@U_Email,[Status]=@Status,[U_Sign]=@U_Sign,[U_SignDxf]=@U_SignDxf,[U_JobRank]=@U_JobRank,[U_JobTitle]=@U_JobTitle,[U_ContractStartTime]=@U_ContractStartTime,[U_ContractEndTime]=@U_ContractEndTime,[U_DocumentTime]=@U_DocumentTime,[U_CardID]=@U_CardID,[Remark]=@Remark,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_user.UserName),
                new SqlParameter("@LimitID",tbl_user.LimitID),
                new SqlParameter("@U_DesignLimit",tbl_user.U_DesignLimit),
                new SqlParameter("@UserPwd",tbl_user.UserPwd),
                new SqlParameter("@U_DepartID",tbl_user.U_DepartID),
                new SqlParameter("@U_JobID",tbl_user.U_JobID),
                new SqlParameter("@U_Specialty",tbl_user.U_Specialty),
                new SqlParameter("@U_Name",tbl_user.U_Name),
                new SqlParameter("@U_Sex",tbl_user.U_Sex),
                new SqlParameter("@U_Degrees",tbl_user.U_Degrees),
                new SqlParameter("@U_GraduateTime",tbl_user.U_GraduateTime),
                new SqlParameter("@U_EntryTime",tbl_user.U_EntryTime),
                new SqlParameter("@U_Professional",tbl_user.U_Professional),
                new SqlParameter("@U_Phone",tbl_user.U_Phone),
                new SqlParameter("@U_Mobile",tbl_user.U_Mobile),
                new SqlParameter("@U_Email",tbl_user.U_Email),
                new SqlParameter("@Status",tbl_user.Status),
                new SqlParameter("@U_Sign",tbl_user.U_Sign),
                new SqlParameter("@U_SignDxf",tbl_user.U_SignDxf),
                new SqlParameter("@U_JobRank",tbl_user.U_JobRank),
                new SqlParameter("@U_JobTitle",tbl_user.U_JobTitle),
                new SqlParameter("@U_ContractStartTime",tbl_user.U_ContractStartTime),
                new SqlParameter("@U_ContractEndTime",tbl_user.U_ContractEndTime),
                new SqlParameter("@U_DocumentTime",tbl_user.U_DocumentTime),
                new SqlParameter("@U_CardID",tbl_user.U_CardID),
                new SqlParameter("@Remark",tbl_user.Remark),
                new SqlParameter("@DealUser",tbl_user.DealUser),
                new SqlParameter("@ID",tbl_user.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }

        public int DeleteTbl_UserById(int ID)
        {

            string sql = "update [Tbl_User] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_User GetTbl_UserById(int ID)
        {
            string sql = "select * from [Tbl_User] where  DealFlag=0 and  ID=" + ID;
            return getTbl_UserBySql(sql);
        }
        public IList<Tbl_User> GetTbl_UserByDepartID(string DepartID)
        {
            string sql = "select * from [Tbl_User] where  DealFlag=0 and  U_DepartID like '%" + DepartID + "%'";
            return getTbl_UsersBySql(sql);
        }
        public IList<Tbl_User> GetTbl_UserByJob(string Job)
        {
            string sql = "select * from [Tbl_User] where  DealFlag=0 and  U_JobID='" + Job + "'";
            return getTbl_UsersBySql(sql);
        }
        public Tbl_User GetTbl_UserByUserName(string UserName)
        {

            string sql = "select top 1 * from [Tbl_User] where  DealFlag=0 and  UserName='" + UserName + "'";
            return getTbl_UserBySql(sql);

        }
        public IList<Tbl_User> GetTbl_UserBySpecialty(string specialty)
        {
            string sql = "select * from [Tbl_User] where DealFlag=0 and u_specialty like '%" + specialty + "%'";
            return getTbl_UsersBySql(sql);
        }

        public IList<Tbl_User> GetTbl_UserAll()
        {
            string sql = "select * from [Tbl_User] where  DealFlag=0";
            return getTbl_UsersBySql(sql);
        }
        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_User> getTbl_UsersBySql(string sql)
        {
            IList<Tbl_User> list = new List<Tbl_User>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_User tbl_user = new Tbl_User();
                    tbl_user.ID = Convert.ToInt32(dr["ID"]);
                    tbl_user.UserName = Convert.ToString(dr["UserName"]);
                    tbl_user.UserPwd = Convert.ToString(dr["UserPwd"]);
                    tbl_user.LimitID = Convert.ToString(dr["LimitID"]);
                    tbl_user.U_DesignLimit = Convert.ToString(dr["U_DesignLimit"]);
                    tbl_user.U_DepartID = Convert.ToString(dr["U_DepartID"]);
                    tbl_user.U_JobID = Convert.ToString(dr["U_JobID"]);
                    tbl_user.U_Specialty = Convert.ToString(dr["U_Specialty"]);
                    tbl_user.U_Name = Convert.ToString(dr["U_Name"]);
                    tbl_user.U_Sex = Convert.ToString(dr["U_Sex"]);
                    tbl_user.U_Degrees = Convert.ToString(dr["U_Degrees"]);
                    tbl_user.U_GraduateTime = Convert.ToDateTime(dr["U_GraduateTime"]);
                    tbl_user.U_EntryTime = Convert.ToDateTime(dr["U_EntryTime"]);
                    tbl_user.U_Professional = Convert.ToString(dr["U_Professional"]);
                    tbl_user.U_Phone = Convert.ToString(dr["U_Phone"]);
                    tbl_user.U_Mobile = Convert.ToString(dr["U_Mobile"]);
                    tbl_user.U_Sign = Convert.ToString(dr["U_Sign"]);
                    tbl_user.U_SignDxf = Convert.ToString(dr["U_SignDxf"]);
                    tbl_user.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_user.U_Email = Convert.ToString(dr["U_Email"]);
                    tbl_user.U_JobRank = Convert.ToString(dr["U_JobRank"]);
                    tbl_user.U_JobTitle = Convert.ToString(dr["U_JobTitle"]);
                    tbl_user.U_ContractStartTime = Convert.ToDateTime(dr["U_ContractStartTime"]);
                    tbl_user.U_ContractEndTime = Convert.ToDateTime(dr["U_ContractEndTime"]);
                    tbl_user.U_DocumentTime = Convert.ToDateTime(dr["U_DocumentTime"]);
                    tbl_user.U_CardID = Convert.ToString(dr["U_CardID"]);
                    tbl_user.Remark = Convert.ToString(dr["Remark"]);
                    tbl_user.Status = Convert.ToString(dr["Status"]);
                    tbl_user.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_user.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_user.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_user);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_User getTbl_UserBySql(string sql)
        {
            Tbl_User tbl_user = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_user = new Tbl_User();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_user.ID = Convert.ToInt32(dr["ID"]);
                    tbl_user.UserName = Convert.ToString(dr["UserName"]);
                    tbl_user.UserPwd = Convert.ToString(dr["UserPwd"]);
                    tbl_user.LimitID = Convert.ToString(dr["LimitID"]);
                    tbl_user.U_DesignLimit = Convert.ToString(dr["U_DesignLimit"]);
                    tbl_user.U_DepartID = Convert.ToString(dr["U_DepartID"]);
                    tbl_user.U_JobID = Convert.ToString(dr["U_JobID"]);
                    tbl_user.U_Specialty = Convert.ToString(dr["U_Specialty"]);
                    tbl_user.U_Name = Convert.ToString(dr["U_Name"]);
                    tbl_user.U_Sex = Convert.ToString(dr["U_Sex"]);
                    tbl_user.U_Degrees = Convert.ToString(dr["U_Degrees"]);
                    tbl_user.U_GraduateTime = Convert.ToDateTime(dr["U_GraduateTime"]);
                    tbl_user.U_EntryTime = Convert.ToDateTime(dr["U_EntryTime"]);
                    tbl_user.U_Professional = Convert.ToString(dr["U_Professional"]);
                    tbl_user.U_Phone = Convert.ToString(dr["U_Phone"]);
                    tbl_user.U_Mobile = Convert.ToString(dr["U_Mobile"]);
                    tbl_user.U_Sign = Convert.ToString(dr["U_Sign"]);
                    tbl_user.U_SignDxf = Convert.ToString(dr["U_SignDxf"]);
                    tbl_user.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_user.U_Email = Convert.ToString(dr["U_Email"]);
                    tbl_user.U_JobRank = Convert.ToString(dr["U_JobRank"]);
                    tbl_user.U_JobTitle = Convert.ToString(dr["U_JobTitle"]);
                    tbl_user.U_ContractStartTime = Convert.ToDateTime(dr["U_ContractStartTime"]);
                    tbl_user.U_ContractEndTime = Convert.ToDateTime(dr["U_ContractEndTime"]);
                    tbl_user.U_DocumentTime = Convert.ToDateTime(dr["U_DocumentTime"]);
                    tbl_user.U_CardID = Convert.ToString(dr["U_CardID"]);
                    tbl_user.Remark = Convert.ToString(dr["Remark"]);
                    tbl_user.Status = Convert.ToString(dr["Status"]);
                    tbl_user.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_user.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_user.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_user;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_User where DealFlag=0";
            if (Where != "") sql += " and "+Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *," + GetDataTableByCount(Where) + " as RecordNum from Tbl_User  where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
