using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using WebModels;
using System.Data.SqlClient;
namespace WebDAL
{
    public class Tbl_DesignTaskService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_DesignTask(Tbl_DesignTask tbl_designtask)
        {
            string sql = "insert into [Tbl_DesignTask] ([ClassName1],[ClassName2],[ClassName3],[ProjectID],[ProjectName],[ProjectNo],[DesignManager],[DesignMain],[DT_XuHao],[DT_TuHao],[DT_GuGong],[DT_SheJiRen],[DT_SheJiTime],[DT_JiaoDuiRen],[DT_JiaoDuiTime],[DT_ShenHeRen],[DT_ShenHeTime],[DT_ShenDingRen],[DT_ShenDingTime],[DT_HeZhunRen],[DT_HeZhunTime],[DT_PublishTime],[CorrectLevel],[NodeUser],[Status],[Remark],[DealUser]) values (@ClassName1,@ClassName2,@ClassName3,@ProjectID,@ProjectName,@ProjectNo,@DesignManager,@DesignMain,@DT_XuHao,@DT_TuHao,@DT_GuGong,@DT_SheJiRen,@DT_SheJiTime,@DT_JiaoDuiRen,@DT_JiaoDuiTime,@DT_ShenHeRen,@DT_ShenHeTime,@DT_ShenDingRen,@DT_ShenDingTime,@DT_HeZhunRen,@DT_HeZhunTime,@DT_PublishTime,@CorrectLevel,@NodeUser,@Status,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ClassName1",tbl_designtask.ClassName1),
                new SqlParameter("@ClassName2",tbl_designtask.ClassName2),
                new SqlParameter("@ClassName3",tbl_designtask.ClassName3),
                new SqlParameter("@ProjectID",tbl_designtask.ProjectID),
                new SqlParameter("@ProjectName",tbl_designtask.ProjectName),
                new SqlParameter("@ProjectNo",tbl_designtask.ProjectNo),
                new SqlParameter("@DesignManager",tbl_designtask.DesignManager),
                new SqlParameter("@DesignMain",tbl_designtask.DesignMain),
                new SqlParameter("@DT_XuHao",tbl_designtask.DT_XuHao),
                new SqlParameter("@DT_TuHao",tbl_designtask.DT_TuHao),
                new SqlParameter("@DT_GuGong",tbl_designtask.DT_GuGong),
                new SqlParameter("@DT_SheJiRen",tbl_designtask.DT_SheJiRen),
                new SqlParameter("@DT_SheJiTime",tbl_designtask.DT_SheJiTime.ToString()),
                new SqlParameter("@DT_JiaoDuiRen",tbl_designtask.DT_JiaoDuiRen),
                new SqlParameter("@DT_JiaoDuiTime",tbl_designtask.DT_JiaoDuiTime.ToString()),
                new SqlParameter("@DT_ShenHeRen",tbl_designtask.DT_ShenHeRen),
                new SqlParameter("@DT_ShenHeTime",tbl_designtask.DT_ShenHeTime.ToString()),
                new SqlParameter("@DT_ShenDingRen",tbl_designtask.DT_ShenDingRen),
                new SqlParameter("@DT_ShenDingTime",tbl_designtask.DT_ShenDingTime.ToString()),
                new SqlParameter("@DT_HeZhunRen",tbl_designtask.DT_HeZhunRen),
                new SqlParameter("@DT_HeZhunTime",tbl_designtask.DT_HeZhunTime.ToString()),
                new SqlParameter("@DT_PublishTime",tbl_designtask.DT_PublishTime.ToString()),
                new SqlParameter("@CorrectLevel",tbl_designtask.CorrectLevel.ToString()),
                new SqlParameter("@NodeUser",tbl_designtask.NodeUser),
                new SqlParameter("@Status",tbl_designtask.Status),
                new SqlParameter("@Remark",tbl_designtask.Remark),
                new SqlParameter("@DealUser",tbl_designtask.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }

        public int UpdateTbl_DesignTaskById(Tbl_DesignTask tbl_designtask)
        {

            string sql = "update [Tbl_DesignTask] set [NodeUser]=@NodeUser,[StatusLast]=@StatusLast,[Status]=@Status,[ClassName1]=@ClassName1,[ClassName2]=@ClassName2,[ClassName3]=@ClassName3,[ProjectID]=@ProjectID,[ProjectName]=@ProjectName,[ProjectNo]=@ProjectNo,[DesignManager]=@DesignManager,[DesignMain]=@DesignMain,[DT_XuHao]=@DT_XuHao,[DT_TuHao]=@DT_TuHao,[DT_GuGong]=@DT_GuGong,[DT_SheJiRen]=@DT_SheJiRen,[DT_SheJiTime]=@DT_SheJiTime,[DT_JiaoDuiRen]=@DT_JiaoDuiRen,[DT_JiaoDuiTime]=@DT_JiaoDuiTime,[DT_ShenHeRen]=@DT_ShenHeRen,[DT_ShenHeTime]=@DT_ShenHeTime,[DT_ShenDingRen]=@DT_ShenDingRen,[DT_ShenDingTime]=@DT_ShenDingTime,[DT_HeZhunRen]=@DT_HeZhunRen,[DT_HeZhunTime]=@DT_HeZhunTime,[DT_PublishTime]=@DT_PublishTime,[Remark]=@Remark,[DealUser]=@DealUser,[DealTime]=@DealTime where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ClassName1",tbl_designtask.ClassName1),
                new SqlParameter("@ClassName2",tbl_designtask.ClassName2),
                new SqlParameter("@ClassName3",tbl_designtask.ClassName3),
                new SqlParameter("@ProjectID",tbl_designtask.ProjectID),
                new SqlParameter("@ProjectName",tbl_designtask.ProjectName),
                new SqlParameter("@ProjectNo",tbl_designtask.ProjectNo),
                new SqlParameter("@DesignManager",tbl_designtask.DesignManager),
                new SqlParameter("@DesignMain",tbl_designtask.DesignMain),
                new SqlParameter("@DT_XuHao",tbl_designtask.DT_XuHao),
                new SqlParameter("@DT_TuHao",tbl_designtask.DT_TuHao),
                new SqlParameter("@DT_GuGong",tbl_designtask.DT_GuGong),
                new SqlParameter("@DT_SheJiRen",tbl_designtask.DT_SheJiRen),
                new SqlParameter("@DT_SheJiTime",tbl_designtask.DT_SheJiTime.ToString()),
                new SqlParameter("@DT_JiaoDuiRen",tbl_designtask.DT_JiaoDuiRen),
                new SqlParameter("@DT_JiaoDuiTime",tbl_designtask.DT_JiaoDuiTime.ToString()),
                new SqlParameter("@DT_ShenHeRen",tbl_designtask.DT_ShenHeRen),
                new SqlParameter("@DT_ShenHeTime",tbl_designtask.DT_ShenHeTime.ToString()),
                new SqlParameter("@DT_ShenDingRen",tbl_designtask.DT_ShenDingRen),
                new SqlParameter("@DT_ShenDingTime",tbl_designtask.DT_ShenDingTime.ToString()),
                new SqlParameter("@DT_HeZhunRen",tbl_designtask.DT_HeZhunRen),
                new SqlParameter("@DT_HeZhunTime",tbl_designtask.DT_HeZhunTime.ToString()),
                new SqlParameter("@DT_PublishTime",tbl_designtask.DT_PublishTime.ToString()),
                new SqlParameter("@NodeUser",tbl_designtask.NodeUser),
                new SqlParameter("@StatusLast",tbl_designtask.StatusLast),
                new SqlParameter("@Status",tbl_designtask.Status),
                new SqlParameter("@Remark",tbl_designtask.Remark),
                new SqlParameter("@DealUser",tbl_designtask.DealUser),
                new SqlParameter("@DealTime",tbl_designtask.DealTime.ToString()),               
                new SqlParameter("@ID",tbl_designtask.ID)

            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }

        public int DeleteTbl_DesignTaskById(int ID)
        {

            string sql = "update [Tbl_DesignTask] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_DesignTask GetTbl_DesignTaskById(int ID)
        {
            string sql = "select * from [Tbl_DesignTask] where DealFlag=0  and ID=" + ID;
            return getTbl_DesignTaskBySql(sql);

        }
        public IList<Tbl_DesignTask> GetTbl_DesignTaskAll()
        {
            string sql = "select * from [Tbl_DesignTask] where DealFlag=0 ";
            return getTbl_DesignTasksBySql(sql);
        }
        public IList<Tbl_DesignTask> GetTbl_DesignTaskByProjectID(int ProjectID)
        {
            string sql = "select * from [Tbl_DesignTask] where DealFlag=0  and ProjectID=" + ProjectID.ToString();
            return getTbl_DesignTasksBySql(sql);
        }

        /// <summary>
        ///根据SQL语句返回集合
        /// </summary>
        private IList<Tbl_DesignTask> getTbl_DesignTasksBySql(string sql)
        {
            IList<Tbl_DesignTask> list = new List<Tbl_DesignTask>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_DesignTask tbl_designtask = new Tbl_DesignTask();
                    tbl_designtask.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designtask.ClassName1 = Convert.ToString(dr["ClassName1"]);
                    tbl_designtask.ClassName2 = Convert.ToString(dr["ClassName2"]);
                    tbl_designtask.ClassName3 = Convert.ToString(dr["ClassName3"]);
                    tbl_designtask.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_designtask.ProjectName = Convert.ToString(dr["ProjectName"]);
                    tbl_designtask.ProjectNo = Convert.ToString(dr["ProjectNo"]);
                    tbl_designtask.DesignManager = Convert.ToString(dr["DesignManager"]);
                    tbl_designtask.DesignMain = Convert.ToString(dr["DesignMain"]);
                    tbl_designtask.DT_XuHao = Convert.ToString(dr["DT_XuHao"]);
                    tbl_designtask.DT_TuHao = Convert.ToString(dr["DT_TuHao"]);
                    tbl_designtask.DT_GuGong = Convert.ToInt32(dr["DT_GuGong"]);
                    tbl_designtask.DT_SheJiRen = Convert.ToString(dr["DT_SheJiRen"]);
                    tbl_designtask.DT_SheJiTime = Convert.ToDateTime(dr["DT_SheJiTime"]);
                    tbl_designtask.DT_JiaoDuiRen = Convert.ToString(dr["DT_JiaoDuiRen"]);
                    tbl_designtask.DT_JiaoDuiTime = Convert.ToDateTime(dr["DT_JiaoDuiTime"]);
                    tbl_designtask.DT_ShenHeRen = Convert.ToString(dr["DT_ShenHeRen"]);
                    tbl_designtask.DT_ShenHeTime = Convert.ToDateTime(dr["DT_ShenHeTime"]);
                    tbl_designtask.DT_ShenDingRen = Convert.ToString(dr["DT_ShenDingRen"]);
                    tbl_designtask.DT_ShenDingTime = Convert.ToDateTime(dr["DT_ShenDingTime"]);
                    tbl_designtask.DT_HeZhunRen = Convert.ToString(dr["DT_HeZhunRen"]);
                    tbl_designtask.DT_HeZhunTime = Convert.ToDateTime(dr["DT_HeZhunTime"]);
                    tbl_designtask.DT_PublishTime = Convert.ToDateTime(dr["DT_PublishTime"]);
                    tbl_designtask.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_designtask.StatusLast = Convert.ToString(dr["StatusLast"]);
                    tbl_designtask.Status = Convert.ToString(dr["Status"]);
                    tbl_designtask.PaperNum1 = Convert.ToDouble(dr["PaperNum1"]);
                    tbl_designtask.PaperNum2 = Convert.ToDouble(dr["PaperNum2"]);
                    tbl_designtask.PaperNum3 = Convert.ToDouble(dr["PaperNum3"]);
                    tbl_designtask.CorrectLevel = Convert.ToString(dr["CorrectLevel"]);
                    tbl_designtask.Remark = Convert.ToString(dr["Remark"]);                    
                    tbl_designtask.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designtask.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designtask.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_designtask.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_designtask);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_DesignTask getTbl_DesignTaskBySql(string sql)
        {
            Tbl_DesignTask tbl_designtask = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_designtask = new Tbl_DesignTask();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_designtask.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designtask.ClassName1 = Convert.ToString(dr["ClassName1"]);
                    tbl_designtask.ClassName2 = Convert.ToString(dr["ClassName2"]);
                    tbl_designtask.ClassName3 = Convert.ToString(dr["ClassName3"]);
                    tbl_designtask.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_designtask.ProjectName = Convert.ToString(dr["ProjectName"]);
                    tbl_designtask.ProjectNo = Convert.ToString(dr["ProjectNo"]);
                    tbl_designtask.DesignManager = Convert.ToString(dr["DesignManager"]);
                    tbl_designtask.DesignMain = Convert.ToString(dr["DesignMain"]);
                    tbl_designtask.DT_XuHao = Convert.ToString(dr["DT_XuHao"]);
                    tbl_designtask.DT_TuHao = Convert.ToString(dr["DT_TuHao"]);
                    tbl_designtask.DT_GuGong = Convert.ToDouble(dr["DT_GuGong"]);
                    tbl_designtask.DT_SheJiRen = Convert.ToString(dr["DT_SheJiRen"]);
                    tbl_designtask.DT_SheJiTime = Convert.ToDateTime(dr["DT_SheJiTime"]);
                    tbl_designtask.DT_JiaoDuiRen = Convert.ToString(dr["DT_JiaoDuiRen"]);
                    tbl_designtask.DT_JiaoDuiTime = Convert.ToDateTime(dr["DT_JiaoDuiTime"]);
                    tbl_designtask.DT_ShenHeRen = Convert.ToString(dr["DT_ShenHeRen"]);
                    tbl_designtask.DT_ShenHeTime = Convert.ToDateTime(dr["DT_ShenHeTime"]);
                    tbl_designtask.DT_ShenDingRen = Convert.ToString(dr["DT_ShenDingRen"]);
                    tbl_designtask.DT_ShenDingTime = Convert.ToDateTime(dr["DT_ShenDingTime"]);
                    tbl_designtask.DT_HeZhunRen = Convert.ToString(dr["DT_HeZhunRen"]);
                    tbl_designtask.DT_HeZhunTime = Convert.ToDateTime(dr["DT_HeZhunTime"]);
                    tbl_designtask.DT_PublishTime = Convert.ToDateTime(dr["DT_PublishTime"]);
                    tbl_designtask.NodeUser = Convert.ToString(dr["NodeUser"]);
                    tbl_designtask.StatusLast = Convert.ToString(dr["StatusLast"]);
                    tbl_designtask.Status = Convert.ToString(dr["Status"]);
                    tbl_designtask.PaperNum1 = Convert.ToDouble(dr["PaperNum1"]);
                    tbl_designtask.PaperNum2 = Convert.ToDouble(dr["PaperNum2"]);
                    tbl_designtask.Remark = Convert.ToString(dr["Remark"]);
                    tbl_designtask.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designtask.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designtask.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_designtask.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_designtask;
        }
        /// <summary>
        /// 返回工作量统计
        /// </summary>
        public System.Data.DataTable GetDataTableByStatistics(string Where)
        {
            string sql = "select sum(papernum1),sum(papernum2),sum(dt_gugong) from Tbl_DesignTask where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            return ds.Tables[0];
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_DesignTask where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select *,(select DT_XuHao+'_'+DT_XuHao+'_'+DT_SheJiRen) as TaskName from Tbl_DesignTask where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }

    }
}
