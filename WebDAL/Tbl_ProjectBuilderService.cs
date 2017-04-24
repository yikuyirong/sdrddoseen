using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectBuilderService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectBuilder(Tbl_ProjectBuilder tbl_projectbuilder)
        {
            string sql = "insert into [Tbl_ProjectBuilder] ([ProjectID],[ProjectBuilderContractID],[POC_Name],[POC_LinkMan],[POC_LinkPhone],[POC_Email],[Remark],[DealUser]) values (@ProjectID,@ProjectBuilderContractID,@POC_Name,@POC_LinkMan,@POC_LinkPhone,@POC_Email,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",tbl_projectbuilder.ProjectID),
                new SqlParameter("@ProjectBuilderContractID",tbl_projectbuilder.ProjectBuilderContractID),
                new SqlParameter("@POC_Name",tbl_projectbuilder.POC_Name),
                new SqlParameter("@POC_LinkMan",tbl_projectbuilder.POC_LinkMan),
                new SqlParameter("@POC_LinkPhone",tbl_projectbuilder.POC_LinkPhone),
                new SqlParameter("@POC_Email",tbl_projectbuilder.POC_Email),
                new SqlParameter("@Remark",tbl_projectbuilder.Remark),
                new SqlParameter("@DealUser",tbl_projectbuilder.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectBuilderById(Tbl_ProjectBuilder tbl_projectbuilder)
        {

            string sql = "update [Tbl_ProjectBuilder] set [ProjectID]=@ProjectID,[ProjectBuilderContractID]=@ProjectBuilderContractID,[POC_Name]=@POC_Name,[POC_LinkMan]=@POC_LinkMan,[POC_LinkPhone]=@POC_LinkPhone,[POC_Email]=@POC_Email,[Remark]=@Remark,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectbuilder.ID),
                new SqlParameter("@ProjectID",tbl_projectbuilder.ProjectID),
                new SqlParameter("@ProjectBuilderContractID",tbl_projectbuilder.ProjectBuilderContractID),
                new SqlParameter("@POC_Name",tbl_projectbuilder.POC_Name),
                new SqlParameter("@POC_LinkMan",tbl_projectbuilder.POC_LinkMan),
                new SqlParameter("@POC_LinkPhone",tbl_projectbuilder.POC_LinkPhone),
                new SqlParameter("@POC_Email",tbl_projectbuilder.POC_Email),
                new SqlParameter("@Remark",tbl_projectbuilder.Remark),
                new SqlParameter("@DealUser",tbl_projectbuilder.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public int DeleteTbl_ProjectBuilderById(int ID)
        {

            string sql = "update from [Tbl_ProjectBuilder] set [DealFlag]=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public Tbl_ProjectBuilder GetTbl_ProjectBuilderById(int ID)
        {

            string sql = "select * from [Tbl_ProjectBuilder] where DealFlag=0 ID=" + ID;
            return getTbl_ProjectBuilderBySql(sql);
            
        }
        public IList<Tbl_ProjectBuilder> GetTbl_ProjectBuilderAll()
        {
            string sql="select * from [Tbl_ProjectBuilder] where DealFlag=0";
            return getTbl_ProjectBuildersBySql(sql);
        }

        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectBuilder> getTbl_ProjectBuildersBySql(string sql)
        {
            IList<Tbl_ProjectBuilder> list = new List<Tbl_ProjectBuilder>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectBuilder tbl_projectbuilder = new Tbl_ProjectBuilder();
                    tbl_projectbuilder.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuilder.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuilder.ProjectBuilderContractID = Convert.ToInt32(dr["ProjectBuilderContractID"]);
                    tbl_projectbuilder.POC_Name = Convert.ToString(dr["POC_Name"]);
                    tbl_projectbuilder.POC_LinkMan = Convert.ToString(dr["POC_LinkMan"]);
                    tbl_projectbuilder.POC_LinkPhone = Convert.ToString(dr["POC_LinkPhone"]);
                    tbl_projectbuilder.POC_Email = Convert.ToString(dr["POC_Email"]);
                    tbl_projectbuilder.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectbuilder.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuilder.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuilder.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuilder.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectbuilder);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectBuilder getTbl_ProjectBuilderBySql(string sql)
        {
            Tbl_ProjectBuilder tbl_projectbuilder = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectbuilder = new Tbl_ProjectBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectbuilder.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectbuilder.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    tbl_projectbuilder.ProjectBuilderContractID = Convert.ToInt32(dr["ProjectBuilderContractID"]);
                    tbl_projectbuilder.POC_Name = Convert.ToString(dr["POC_Name"]);
                    tbl_projectbuilder.POC_LinkMan = Convert.ToString(dr["POC_LinkMan"]);
                    tbl_projectbuilder.POC_LinkPhone = Convert.ToString(dr["POC_LinkPhone"]);
                    tbl_projectbuilder.POC_Email = Convert.ToString(dr["POC_Email"]);
                    tbl_projectbuilder.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectbuilder.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectbuilder.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectbuilder.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectbuilder.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectbuilder;
        }
    }
}
