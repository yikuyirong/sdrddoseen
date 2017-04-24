using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{

    public class Tbl_DesignCorrectService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_DesignCorrect(Tbl_DesignCorrect tbl_designcorrect)
        {
            string sql="insert into [Tbl_DesignCorrect] ([UserName],[DesignTaskID],[DC_Name],[DC_File],[DC_FileInfo],[DC_FileTime],[Status]) values (@UserName,@DesignTaskID,@DC_Name,@DC_File,@DC_FileInfo,@DC_FileTime,@Status)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@UserName",tbl_designcorrect.UserName),
                new SqlParameter("@DesignTaskID",tbl_designcorrect.DesignTaskID),
                new SqlParameter("@DC_Name",tbl_designcorrect.DC_Name),
                new SqlParameter("@DC_File",tbl_designcorrect.DC_File),
                new SqlParameter("@DC_FileInfo",tbl_designcorrect.DC_FileInfo),
                new SqlParameter("@DC_FileTime",tbl_designcorrect.DC_FileTime),
                new SqlParameter("@Status",tbl_designcorrect.Status)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_DesignCorrectById(Tbl_DesignCorrect tbl_designcorrect)
        {

            string sql = "update [Tbl_DesignCorrect] set [UserName]=@UserName,[DesignTaskID]=@DesignTaskID,[DC_Name]=@DC_Name,[DC_File]=@DC_File,[DC_FileInfo]=@DC_FileInfo,[DC_FileTime]=@DC_FileTime,[DC_File1]=@DC_File1,[DC_File1Correct]=@DC_File1Correct,[DC_File1CorrectInfo]=@DC_File1CorrectInfo,[DC_File1Time]=@DC_File1Time,[DC_File2]=@DC_File2,[DC_File2Correct]=@DC_File2Correct,[DC_File2CorrectInfo]=@DC_File2CorrectInfo,[DC_File2Time]=@DC_File2Time,[DC_File3]=@DC_File3,[DC_File3Correct]=@DC_File3Correct,[DC_File3CorrectInfo]=@DC_File3CorrectInfo,[DC_File3Time]=@DC_File3Time,[DC_File4]=@DC_File4,[DC_File4Correct]=@DC_File4Correct,[DC_File4CorrectInfo]=@DC_File4CorrectInfo,[DC_File4Time]=@DC_File4Time,[ErrorNum1]=@ErrorNum1,[ErrorNum2]=@ErrorNum2,[ErrorNum3]=@ErrorNum3,[Status]=@Status,[NodeUser]=@NodeUser,[DealFlag]=@DealFlag,[DealUser]=@DealUser,[DealTime]=@DealTime where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_designcorrect.ID),
                new SqlParameter("@UserName",tbl_designcorrect.UserName),
                new SqlParameter("@DesignTaskID",tbl_designcorrect.DesignTaskID),
                new SqlParameter("@DC_Name",tbl_designcorrect.DC_Name),
                new SqlParameter("@DC_File",tbl_designcorrect.DC_File),
                new SqlParameter("@DC_FileInfo",tbl_designcorrect.DC_FileInfo),
                new SqlParameter("@DC_FileTime",tbl_designcorrect.DC_FileTime),
                new SqlParameter("@DC_File1",tbl_designcorrect.DC_File1),
                new SqlParameter("@DC_File1Correct",tbl_designcorrect.DC_File1Correct),
                new SqlParameter("@DC_File1CorrectInfo",tbl_designcorrect.DC_File1CorrectInfo),
                new SqlParameter("@DC_File1Time",tbl_designcorrect.DC_File1Time),
                new SqlParameter("@DC_File2",tbl_designcorrect.DC_File2),
                new SqlParameter("@DC_File2Correct",tbl_designcorrect.DC_File2Correct),
                new SqlParameter("@DC_File2CorrectInfo",tbl_designcorrect.DC_File2CorrectInfo),
                new SqlParameter("@DC_File2Time",tbl_designcorrect.DC_File2Time),
                new SqlParameter("@DC_File3",tbl_designcorrect.DC_File3),
                new SqlParameter("@DC_File3Correct",tbl_designcorrect.DC_File3Correct),
                new SqlParameter("@DC_File3CorrectInfo",tbl_designcorrect.DC_File3CorrectInfo),
                new SqlParameter("@DC_File3Time",tbl_designcorrect.DC_File3Time),
                new SqlParameter("@DC_File4",tbl_designcorrect.DC_File4),
                new SqlParameter("@DC_File4Correct",tbl_designcorrect.DC_File4Correct),
                new SqlParameter("@DC_File4CorrectInfo",tbl_designcorrect.DC_File4CorrectInfo),
                new SqlParameter("@DC_File4Time",tbl_designcorrect.DC_File4Time),
                new SqlParameter("@ErrorNum1",tbl_designcorrect.ErrorNum1),
                new SqlParameter("@ErrorNum2",tbl_designcorrect.ErrorNum2),
                new SqlParameter("@ErrorNum3",tbl_designcorrect.ErrorNum3),
                new SqlParameter("@NodeUser",tbl_designcorrect.NodeUser),
                new SqlParameter("@Status",tbl_designcorrect.Status),
                new SqlParameter("@DealFlag",tbl_designcorrect.DealFlag),
                new SqlParameter("@DealUser",tbl_designcorrect.DealUser),
                new SqlParameter("@DealTime",tbl_designcorrect.DealTime)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }

        public int DeleteTbl_DesignCorrectById(int ID)
        {
            
            string sql="delete from [Tbl_DesignCorrect] where [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public Tbl_DesignCorrect GetTbl_DesignCorrectById(int ID)
        {
            
            string sql="select * from [Tbl_DesignCorrect] where ID="+ID;
            return getTbl_DesignCorrectBySql(sql);
            
        }
        public IList<Tbl_DesignCorrect> GetTbl_DesignCorrectAll()
        {
            string sql="select * from [Tbl_DesignCorrect]";
            return getTbl_DesignCorrectsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_DesignCorrect> getTbl_DesignCorrectsBySql(string sql)
        {
            IList<Tbl_DesignCorrect> list = new List<Tbl_DesignCorrect>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_DesignCorrect tbl_designcorrect = new Tbl_DesignCorrect();
                    tbl_designcorrect.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designcorrect.UserName = Convert.ToString(dr["UserName"]);
                    tbl_designcorrect.DesignTaskID = Convert.ToInt32(dr["DesignTaskID"]);
                    tbl_designcorrect.DC_Name = Convert.ToString(dr["DC_Name"]);
                    tbl_designcorrect.DC_File = Convert.ToString(dr["DC_File"]);
                    tbl_designcorrect.DC_FileInfo = Convert.ToString(dr["DC_FileInfo"]);
                    tbl_designcorrect.DC_FileTime = Convert.ToDateTime(dr["DC_FileTime"]);
                    tbl_designcorrect.DC_File1 = Convert.ToString(dr["DC_File1"]);
                    tbl_designcorrect.DC_File1Correct = Convert.ToString(dr["DC_File1Correct"]);
                    tbl_designcorrect.DC_File1CorrectInfo = Convert.ToString(dr["DC_File1CorrectInfo"]);
                    tbl_designcorrect.DC_File1Time = Convert.ToDateTime(dr["DC_File1Time"]);
                    tbl_designcorrect.DC_File2 = Convert.ToString(dr["DC_File2"]);
                    tbl_designcorrect.DC_File2Correct = Convert.ToString(dr["DC_File2Correct"]);
                    tbl_designcorrect.DC_File2CorrectInfo = Convert.ToString(dr["DC_File2CorrectInfo"]);
                    tbl_designcorrect.DC_File2Time = Convert.ToDateTime(dr["DC_File2Time"]);
                    tbl_designcorrect.DC_File3 = Convert.ToString(dr["DC_File3"]);
                    tbl_designcorrect.DC_File3Correct = Convert.ToString(dr["DC_File3Correct"]);
                    tbl_designcorrect.DC_File3CorrectInfo = Convert.ToString(dr["DC_File3CorrectInfo"]);
                    tbl_designcorrect.DC_File3Time = Convert.ToDateTime(dr["DC_File3Time"]);
                    tbl_designcorrect.DC_File4 = Convert.ToString(dr["DC_File4"]);
                    tbl_designcorrect.DC_File4Correct = Convert.ToString(dr["DC_File4Correct"]);
                    tbl_designcorrect.DC_File4CorrectInfo = Convert.ToString(dr["DC_File4CorrectInfo"]);
                    tbl_designcorrect.DC_File4Time = Convert.ToDateTime(dr["DC_File4Time"]);
                    tbl_designcorrect.ErrorNum1 = Convert.ToInt32(dr["ErrorNum1"]);
                    tbl_designcorrect.ErrorNum2 = Convert.ToInt32(dr["ErrorNum2"]);
                    tbl_designcorrect.ErrorNum3 = Convert.ToInt32(dr["ErrorNum3"]);
                    tbl_designcorrect.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_designcorrect.Status = Convert.ToString(dr["Status"]);
                    tbl_designcorrect.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designcorrect.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designcorrect.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_designcorrect);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_DesignCorrect getTbl_DesignCorrectBySql(string sql)
        {
            Tbl_DesignCorrect tbl_designcorrect = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_designcorrect = new Tbl_DesignCorrect();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_designcorrect.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designcorrect.UserName = Convert.ToString(dr["UserName"]);
                    tbl_designcorrect.DesignTaskID = Convert.ToInt32(dr["DesignTaskID"]);
                    tbl_designcorrect.DC_Name = Convert.ToString(dr["DC_Name"]);
                    tbl_designcorrect.DC_File = Convert.ToString(dr["DC_File"]);
                    tbl_designcorrect.DC_FileInfo = Convert.ToString(dr["DC_FileInfo"]);
                    tbl_designcorrect.DC_FileTime = Convert.ToDateTime(dr["DC_FileTime"]);
                    tbl_designcorrect.DC_File1 = Convert.ToString(dr["DC_File1"]);
                    tbl_designcorrect.DC_File1Correct = Convert.ToString(dr["DC_File1Correct"]);
                    tbl_designcorrect.DC_File1CorrectInfo = Convert.ToString(dr["DC_File1CorrectInfo"]);
                    tbl_designcorrect.DC_File1Time = Convert.ToDateTime(dr["DC_File1Time"]);
                    tbl_designcorrect.DC_File2 = Convert.ToString(dr["DC_File2"]);
                    tbl_designcorrect.DC_File2Correct = Convert.ToString(dr["DC_File2Correct"]);
                    tbl_designcorrect.DC_File2CorrectInfo = Convert.ToString(dr["DC_File2CorrectInfo"]);
                    tbl_designcorrect.DC_File2Time = Convert.ToDateTime(dr["DC_File2Time"]);
                    tbl_designcorrect.DC_File3 = Convert.ToString(dr["DC_File3"]);
                    tbl_designcorrect.DC_File3Correct = Convert.ToString(dr["DC_File3Correct"]);
                    tbl_designcorrect.DC_File3CorrectInfo = Convert.ToString(dr["DC_File3CorrectInfo"]);
                    tbl_designcorrect.DC_File3Time = Convert.ToDateTime(dr["DC_File3Time"]);
                    tbl_designcorrect.DC_File4 = Convert.ToString(dr["DC_File4"]);
                    tbl_designcorrect.DC_File4Correct = Convert.ToString(dr["DC_File4Correct"]);
                    tbl_designcorrect.DC_File4CorrectInfo = Convert.ToString(dr["DC_File4CorrectInfo"]);
                    tbl_designcorrect.DC_File4Time = Convert.ToDateTime(dr["DC_File4Time"]);
                    tbl_designcorrect.ErrorNum1 = Convert.ToInt32(dr["ErrorNum1"]);
                    tbl_designcorrect.ErrorNum2 = Convert.ToInt32(dr["ErrorNum2"]);
                    tbl_designcorrect.ErrorNum3 = Convert.ToInt32(dr["ErrorNum3"]);
                    tbl_designcorrect.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_designcorrect.Status = Convert.ToString(dr["Status"]);
                    tbl_designcorrect.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designcorrect.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designcorrect.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_designcorrect;
        }
        /// <summary>
        /// 返回统计数据
        /// </summary>
        public System.Data.DataTable GetDataTableByStatistics(string Where)
        {
            //string sql = "select isnull((len(dc_file1correctinfo)-len(replace(dc_file1correctinfo,'原则性错误','')))/5+(len(dc_file2correctinfo)-len(replace(dc_file2correctinfo,'原则性错误','')))/5+(len(dc_file3correctinfo)-len(replace(dc_file3correctinfo,'原则性错误','')))/5,0) as ErrorNum1,isnull((len(dc_file1correctinfo)-len(replace(dc_file1correctinfo,'技术性错误','')))/5+(len(dc_file2correctinfo)-len(replace(dc_file2correctinfo,'技术性错误','')))/5+(len(dc_file3correctinfo)-len(replace(dc_file3correctinfo,'技术性错误','')))/5,0) as ErrorNum2,isnull((len(dc_file1correctinfo)-len(replace(dc_file1correctinfo,'一般性错误','')))/5+(len(dc_file2correctinfo)-len(replace(dc_file2correctinfo,'一般性错误','')))/5+(len(dc_file3correctinfo)-len(replace(dc_file3correctinfo,'一般性错误','')))/5,0) as ErrorNum3 from Tbl_DesignCorrect where DealFlag=0";
            string sql = "select sum(ErrorNum1),sum(ErrorNum2),sum(ErrorNum3) from tbl_designcorrect where 1=1";
            if (Where != "") sql += " and (" + Where + ")";
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            return ds.Tables[0];
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_DesignCorrect left join tbl_designtask on Tbl_DesignCorrect.designtaskid=tbl_designtask.id where Tbl_DesignCorrect.DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select Tbl_DesignCorrect.*,tbl_designtask.classname1,tbl_designtask.projectname,tbl_designtask.projectno,tbl_designtask.dt_xuhao,tbl_designtask.dt_tuhao,tbl_designtask.dt_jiaoduiren,tbl_designtask.dt_shenheren,tbl_designtask.dt_shendingren,isnull((len(dc_file1correctinfo)-len(replace(dc_file1correctinfo,'原则性错误','')))/5+(len(dc_file2correctinfo)-len(replace(dc_file2correctinfo,'原则性错误','')))/5+(len(dc_file3correctinfo)-len(replace(dc_file3correctinfo,'原则性错误','')))/5,0) as ErrorNum1,isnull((len(dc_file1correctinfo)-len(replace(dc_file1correctinfo,'技术性错误','')))/5+(len(dc_file2correctinfo)-len(replace(dc_file2correctinfo,'技术性错误','')))/5+(len(dc_file3correctinfo)-len(replace(dc_file3correctinfo,'技术性错误','')))/5,0) as ErrorNum2,isnull((len(dc_file1correctinfo)-len(replace(dc_file1correctinfo,'一般性错误','')))/5+(len(dc_file2correctinfo)-len(replace(dc_file2correctinfo,'一般性错误','')))/5+(len(dc_file3correctinfo)-len(replace(dc_file3correctinfo,'一般性错误','')))/5,0) as ErrorNum3 from Tbl_DesignCorrect left join tbl_designtask on Tbl_DesignCorrect.designtaskid=tbl_designtask.id where Tbl_DesignCorrect.DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}