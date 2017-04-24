using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace WebDAL
{

    /// <summary>
    �� /// ִ��Sql �����ͨ�÷���
    �� /// </summary>
    public abstract class DBHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //private static readonly string ConnectionString = @"server=123.232.119.26;database=DB_DoseenDesign;uid=DB_DoseenDesign;pwd=doseensoft";
        #region ExecuteNonQuery
        /// <summary>
        /// ִ��sql����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="commandType">��������</param>
        /// <param name="commandText">sql���/������sql���/�洢������</param>
        /// <param name="commandParameters">����</param>
        /// <returns>��Ӱ�������</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (commandText.ToLower().Contains("insert"))
                {
                    commandText += ";SELECT SCOPE_IDENTITY();";

                    PrepareCommand(cmd, commandType, conn, commandText, commandParameters);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    return id;
                }
                else
                {
                    PrepareCommand(cmd, commandType, conn, commandText, commandParameters);

                    int val = cmd.ExecuteNonQuery();

                    return val;
                }
            }
        }
        /// <summary>
        /// ִ��Sql Server�洢����
        /// ע�⣺����ִ����out �����Ĵ洢����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="spName">�洢������</param>
        /// <param name="parameterValues">�������</param>
        /// <returns>��Ӱ�������</returns>
        public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }
        #endregion
        #region ExecuteReader
        /// <summary>
        ///  ִ��sql����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="commandType">��������</param>
        /// <param name="commandText">sql���/������sql���/�洢������</param>
        /// <param name="commandParameters">����</param>
        /// <returns>SqlDataReader ����</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// ִ��Sql Server�洢����
        /// ע�⣺����ִ����out �����Ĵ洢����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="spName">�洢������</param>
        /// <param name="parameterValues">�������</param>
        /// <returns>��Ӱ�������</returns>
        public static SqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion
        #region ExecuteDataset
        /// <summary>
        /// ִ��Sql Server�洢����
        /// ע�⣺����ִ����out �����Ĵ洢����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="spName">�洢������</param>
        /// <param name="parameterValues">�������</param>
        /// <returns>DataSet����</returns>
        public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        /// <summary>
        /// ִ��Sql ����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="commandType">��������</param>
        /// <param name="commandText">sql���/������sql���/�洢������</param>
        /// <param name="commandParameters">����</param>
        /// <returns>DataSet ����</returns>
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        #endregion
        #region ExecuteScalar
        /// <summary>
        /// ִ��Sql ����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="commandType">��������</param>
        /// <param name="commandText">sql���/������sql���/�洢������</param>
        /// <param name="commandParameters">����</param>
        /// <returns>ִ�н������</returns>
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }
        /// <summary>
        /// ִ��Sql Server�洢����
        /// ע�⣺����ִ����out �����Ĵ洢����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="spName">�洢������</param>
        /// <param name="parameterValues">�������</param>
        /// <returns>ִ�н������</returns>
        public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, spName, parameterValues);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }
        #endregion
        #region Private Method
        /// <summary>
        /// ����һ���ȴ�ִ�е�SqlCommand����
        /// </summary>
        /// <param name="cmd">SqlCommand ���󣬲�����ն���</param>
        /// <param name="conn">SqlConnection ���󣬲�����ն���</param>
        /// <param name="commandText">Sql ���</param>
        /// <param name="cmdParms">SqlParameters  ����,����Ϊ�ն���</param>
        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, SqlParameter[] cmdParms)
        {
            //������
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //����SqlCommand����
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        /// <summary>
        /// ����һ���ȴ�ִ�д洢���̵�SqlCommand����
        /// </summary>
        /// <param name="cmd">SqlCommand ���󣬲�����ն���</param>
        /// <param name="conn">SqlConnection ���󣬲�����ն���</param>
        /// <param name="spName">Sql ���</param>
        /// <param name="parameterValues">���������Ĵ洢���̲���������Ϊ��</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, string spName, params object[] parameterValues)
        {
            //������
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //����SqlCommand����
            cmd.Connection = conn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            //��ȡ�洢���̵Ĳ���
            SqlCommandBuilder.DeriveParameters(cmd);
            //�Ƴ�Return_Value ����
            cmd.Parameters.RemoveAt(0);
            //���ò���ֵ
            if (parameterValues != null)
            {
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    cmd.Parameters[i].Value = parameterValues[i];
                }
            }
        }
        #endregion

        //internal static DataTable ExecuteDataTablePage(string p, CommandType commandType, string sql, int startRecord, int EndRecord)
        //{
        //    throw new NotImplementedException();
        //}

        #region ExecuteDataTablePage
        /// <summary>
        /// ִ��Sql �����ҳ���DataTable
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="commandType">��������</param>
        /// <param name="commandText">sql���/������sql���/�洢������</param>
        /// <param name="commandParameters">����</param>
        /// <returns>DataSet ����</returns>
        public static DataTable ExecuteDataTablePage(string connectionString, CommandType commandType, string commandText, int startRecord, int endRecord, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    int DataCount = da.Fill(new DataSet());
                    if (startRecord >= DataCount)
                    {
                        startRecord = DataCount - endRecord;
                        startRecord = startRecord >= 0 ? startRecord : 0;
                    }
                    da.Fill(startRecord, endRecord, dt);
                    return dt;
                }
            }
        }
        #endregion
    }
}
