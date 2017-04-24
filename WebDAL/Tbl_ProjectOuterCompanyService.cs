using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebModels;
namespace WebDAL
{
    public class Tbl_ProjectOuterCompanyService
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int AddTbl_ProjectOuterCompany(Tbl_ProjectOuterCompany tbl_projectoutercompany)
        {
            string sql = "insert into [Tbl_ProjectOuterCompany] ([POC_Type1],[POC_Type2],[POC_Name],[POC_LinkMan],[POC_LinkPhone],[POC_Email],[POC_Address],[Remark],[DealUser]) values (@POC_Type1,@POC_Type2,@POC_Name,@POC_LinkMan,@POC_LinkPhone,@POC_Email,@POC_Address,@Remark,@DealUser)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@POC_Type1",tbl_projectoutercompany.POC_Type1),
                new SqlParameter("@POC_Type2",tbl_projectoutercompany.POC_Type2),
                new SqlParameter("@POC_Name",tbl_projectoutercompany.POC_Name),
                new SqlParameter("@POC_LinkMan",tbl_projectoutercompany.POC_LinkMan),
                new SqlParameter("@POC_LinkPhone",tbl_projectoutercompany.POC_LinkPhone),
                new SqlParameter("@POC_Email",tbl_projectoutercompany.POC_Email),
                new SqlParameter("@POC_Address",tbl_projectoutercompany.POC_Address),
                new SqlParameter("@Remark",tbl_projectoutercompany.Remark),
                 new SqlParameter("@DealUser",tbl_projectoutercompany.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
        }
        public int UpdateTbl_ProjectOuterCompanyById(Tbl_ProjectOuterCompany tbl_projectoutercompany)
        {

            string sql = "update [Tbl_ProjectOuterCompany] set [POC_Type1]=@POC_Type1,[POC_Type2]=@POC_Type2,[POC_Name]=@POC_Name,[POC_LinkMan]=@POC_LinkMan,[POC_LinkPhone]=@POC_LinkPhone,[POC_Email]=@POC_Email,[POC_Address]=@POC_Address,[Remark]=@Remark,[DealUser]=@DealUser where DealFlag=0 and [ID]=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tbl_projectoutercompany.ID),
                new SqlParameter("@POC_Type1",tbl_projectoutercompany.POC_Type1),
                new SqlParameter("@POC_Type2",tbl_projectoutercompany.POC_Type2),
                new SqlParameter("@POC_Name",tbl_projectoutercompany.POC_Name),
                new SqlParameter("@POC_LinkMan",tbl_projectoutercompany.POC_LinkMan),
                new SqlParameter("@POC_LinkPhone",tbl_projectoutercompany.POC_LinkPhone),
                new SqlParameter("@POC_Email",tbl_projectoutercompany.POC_Email),
                new SqlParameter("@POC_Address",tbl_projectoutercompany.POC_Address),
                new SqlParameter("@Remark",tbl_projectoutercompany.Remark),
                new SqlParameter("@DealUser",tbl_projectoutercompany.DealUser)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public int DeleteTbl_ProjectOuterCompanyById(int ID)
        {

            string sql = "update from [Tbl_ProjectOuterCompany] set DealFlag=1 where DealFlag=0 and [ID]=" + ID;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return DBHelper.ExecuteNonQuery(this.connection, CommandType.Text, sql, sp);
            
        }
        public Tbl_ProjectOuterCompany GetTbl_ProjectOuterCompanyById(int ID)
        {

            string sql = "select * from [Tbl_ProjectOuterCompany] where DealFlag=0 and ID=" + ID;
            return getTbl_ProjectOuterCompanyBySql(sql);
            
        }
        public IList<Tbl_ProjectOuterCompany> GetTbl_ProjectOuterCompanyAll()
        {
            string sql="select * from [Tbl_ProjectOuterCompany] where DealFlag=0";
            return getTbl_ProjectOuterCompanysBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        private IList<Tbl_ProjectOuterCompany> getTbl_ProjectOuterCompanysBySql(string sql)
        {
            IList<Tbl_ProjectOuterCompany> list = new List<Tbl_ProjectOuterCompany>();
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Tbl_ProjectOuterCompany tbl_projectoutercompany = new Tbl_ProjectOuterCompany();
                    tbl_projectoutercompany.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectoutercompany.POC_Type1 = Convert.ToString(dr["POC_Type1"]);
                    tbl_projectoutercompany.POC_Type2 = Convert.ToString(dr["POC_Type2"]);
                    tbl_projectoutercompany.POC_Name = Convert.ToString(dr["POC_Name"]);
                    tbl_projectoutercompany.POC_LinkMan = Convert.ToString(dr["POC_LinkMan"]);
                    tbl_projectoutercompany.POC_LinkPhone = Convert.ToString(dr["POC_LinkPhone"]);
                    tbl_projectoutercompany.POC_Email = Convert.ToString(dr["POC_Email"]);
                    tbl_projectoutercompany.POC_Address = Convert.ToString(dr["POC_Address"]);
                    tbl_projectoutercompany.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectoutercompany.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectoutercompany.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectoutercompany.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectoutercompany.DealTime = Convert.ToDateTime(dr["DealTime"]);
                    list.Add(tbl_projectoutercompany);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        private Tbl_ProjectOuterCompany getTbl_ProjectOuterCompanyBySql(string sql)
        {
            Tbl_ProjectOuterCompany tbl_projectoutercompany = null;
            DataSet ds = DBHelper.ExecuteDataset(this.connection, CommandType.Text, sql);
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                tbl_projectoutercompany = new Tbl_ProjectOuterCompany();
                foreach (DataRow dr in dt.Rows)
                {
                    tbl_projectoutercompany.ID = Convert.ToInt32(dr["ID"]);
                    tbl_projectoutercompany.POC_Type1 = Convert.ToString(dr["POC_Type1"]);
                    tbl_projectoutercompany.POC_Type2 = Convert.ToString(dr["POC_Type2"]);
                    tbl_projectoutercompany.POC_Name = Convert.ToString(dr["POC_Name"]);
                    tbl_projectoutercompany.POC_LinkMan = Convert.ToString(dr["POC_LinkMan"]);
                    tbl_projectoutercompany.POC_LinkPhone = Convert.ToString(dr["POC_LinkPhone"]);
                    tbl_projectoutercompany.POC_Email = Convert.ToString(dr["POC_Email"]);
                    tbl_projectoutercompany.POC_Address = Convert.ToString(dr["POC_Address"]);
                    tbl_projectoutercompany.Remark = Convert.ToString(dr["Remark"]);
                    tbl_projectoutercompany.AddDate = Convert.ToDateTime(dr["AddDate"]);
                    tbl_projectoutercompany.DealFlag = Convert.ToInt32(dr["DealFlag"]);
                    tbl_projectoutercompany.DealUser = Convert.ToString(dr["DealUser"]);
                    tbl_projectoutercompany.DealTime = Convert.ToDateTime(dr["DealTime"]);
                }
            }
            return tbl_projectoutercompany;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetDataTableByCount(string Where)
        {
            string sql = "select count(*) from Tbl_ProjectOuterCompany where DealFlag=0";
            if (Where != "") sql +=" and "+ Where;
            int RecordNum = (int)DBHelper.ExecuteScalar(this.connection, CommandType.Text, sql);
            return RecordNum;
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        public DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            string sql = "select * from Tbl_ProjectOuterCompany where DealFlag=0"; 
            if (Where != "") sql +=" and "+ Where;
            if (Order != "") sql += " order by " + Order;
            int startRecord = PageSize * (PageIndex - 1);
            int endRecord = PageSize;
            DataTable dt = DBHelper.ExecuteDataTablePage(this.connection, CommandType.Text, sql, startRecord, endRecord);
            return dt;
        }
    }
}
