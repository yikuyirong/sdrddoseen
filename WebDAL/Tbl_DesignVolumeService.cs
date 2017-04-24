using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_DesignVolumeService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_DesignVolume(Tbl_DesignVolume tbl_designvolume)
        {
            string sql = "insert into [Tbl_DesignVolume] ([ClassName1],[ClassName2],[ClassName3],[VolumeNo],[VolumeName],[Volume25MW],[Volume50MW],[VolumeLevel],[Remark],[DealUser]) values (@ClassName1,@ClassName2,@ClassName3,@VolumeNo,@VolumeName,@Volume25MW,@Volume50MW,@VolumeLevel,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ClassName1",tbl_designvolume.ClassName1),
                new SqlParameter("@ClassName2",tbl_designvolume.ClassName2),
                new SqlParameter("@ClassName3",tbl_designvolume.ClassName3),
                new SqlParameter("@VolumeNo",tbl_designvolume.VolumeNo),
                new SqlParameter("@VolumeName",tbl_designvolume.VolumeName),
                new SqlParameter("@Volume25MW",tbl_designvolume.Volume25MW),
                new SqlParameter("@Volume50MW",tbl_designvolume.Volume50MW),
                new SqlParameter("@VolumeLevel",tbl_designvolume.VolumeLevel),
                new SqlParameter("@Remark",tbl_designvolume.Remark),
                new SqlParameter("@DealUser",tbl_designvolume.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_DesignVolumeById(Tbl_DesignVolume tbl_designvolume)
        {

            string sql = "update [Tbl_DesignVolume] set [ClassName1]=@ClassName1,[ClassName2]=@ClassName2,[ClassName3]=@ClassName3,[VolumeNo]=@VolumeNo,[VolumeName]=@VolumeName,[Volume25MW]=@Volume25MW,[Volume50MW]=@Volume50MW,[VolumeLevel]=@VolumeLevel,[Remark]=@Remark,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_designvolume.ID),
                new SqlParameter("@ClassName1",tbl_designvolume.ClassName1),
                new SqlParameter("@ClassName2",tbl_designvolume.ClassName2),
                new SqlParameter("@ClassName3",tbl_designvolume.ClassName3),
                new SqlParameter("@VolumeNo",tbl_designvolume.VolumeNo),
                new SqlParameter("@VolumeName",tbl_designvolume.VolumeName),
                new SqlParameter("@Volume25MW",tbl_designvolume.Volume25MW),
                new SqlParameter("@Volume50MW",tbl_designvolume.Volume50MW),
                new SqlParameter("@VolumeLevel",tbl_designvolume.VolumeLevel),
                new SqlParameter("@Remark",tbl_designvolume.Remark),
                new SqlParameter("@DealUser",tbl_designvolume.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public int DeleteTbl_DesignVolumeById(int ID)
        {

            string sql = "update from [Tbl_DesignVolume] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);

        }
        public Tbl_DesignVolume GetTbl_DesignVolumeById(int ID)
        {

            string sql = "select * from [Tbl_DesignVolume] where DealFlag=0 and ID=" + ID;
            return getTbl_DesignVolumeBySql(sql);

        }
        public IList<Tbl_DesignVolume> GetTbl_DesignVolumeAll()
        {
            string sql = "select * from [Tbl_DesignVolume] where DealFlag=0";
            return geTbl_DesignVolumesBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_DesignVolume> geTbl_DesignVolumesBySql(string sql)
        {
            IList<Tbl_DesignVolume> list = new List<Tbl_DesignVolume>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_DesignVolume tbl_designvolume = new Tbl_DesignVolume();
                    tbl_designvolume.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designvolume.ClassName1 = Convert.ToString(dr["ClassName1"]);
                    tbl_designvolume.ClassName2 = Convert.ToString(dr["ClassName2"]);
                    tbl_designvolume.ClassName3 = Convert.ToString(dr["ClassName3"]);
                    tbl_designvolume.VolumeNo = Convert.ToString(dr["VolumeNo"]);
                    tbl_designvolume.VolumeName = Convert.ToString(dr["VolumeName"]);
                    tbl_designvolume.Volume25MW = Convert.ToInt32(dr["Volume25MW"]);
                    tbl_designvolume.Volume50MW = Convert.ToInt32(dr["Volume50MW"]);
                    tbl_designvolume.VolumeLevel = Convert.ToString(dr["VolumeLevel"]);
                    tbl_designvolume.Remark = Convert.ToString(dr["Remark"]);
                    tbl_designvolume.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designvolume.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_designvolume.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designvolume.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    list.Add(tbl_designvolume);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_DesignVolume getTbl_DesignVolumeBySql(string sql)
        {
            Tbl_DesignVolume tbl_designvolume = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_designvolume = new Tbl_DesignVolume();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_designvolume.ID = Convert.ToInt32(dr["ID"]);
                    tbl_designvolume.ClassName1 = Convert.ToString(dr["ClassName1"]);
                    tbl_designvolume.ClassName2 = Convert.ToString(dr["ClassName2"]);
                    tbl_designvolume.ClassName3 = Convert.ToString(dr["ClassName3"]);
                    tbl_designvolume.VolumeNo = Convert.ToString(dr["VolumeNo"]);
                    tbl_designvolume.VolumeName = Convert.ToString(dr["VolumeName"]);
                    tbl_designvolume.Volume25MW = Convert.ToInt32(dr["Volume25MW"]);
                    tbl_designvolume.Volume50MW = Convert.ToInt32(dr["Volume50MW"]);
                    tbl_designvolume.VolumeLevel = Convert.ToString(dr["VolumeLevel"]);
                    tbl_designvolume.Remark = Convert.ToString(dr["Remark"]);
                    tbl_designvolume.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_designvolume.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    tbl_designvolume.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_designvolume.AddDate = Convert.ToDateTime(dr["AddDate"]);
                }
            }
            return tbl_designvolume;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_DesignVolume where DealFlag=0 ";
            if (Where != "") sql += " and (" + Where + ")";
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_DesignVolume where DealFlag=0";
            if (Where != "") sql += " and (" + Where + ")";
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
