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
    　 /// 执行Sql 命令的通用方法
    　 /// </summary>
    public abstract class DBHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //private static readonly string ConnectionString = @"server=123.232.119.26;database=DB_DoseenDesign;uid=DB_DoseenDesign;pwd=doseensoft";
        #region ExecuteNonQuery
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>受影响的行数</returns>
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
        /// 执行Sql Server存储过程
        /// 注意：不能执行有out 参数的存储过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>受影响的行数</returns>
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
        ///  执行sql命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>SqlDataReader 对象</returns>
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
        /// 执行Sql Server存储过程
        /// 注意：不能执行有out 参数的存储过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>受影响的行数</returns>
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
        /// 执行Sql Server存储过程
        /// 注意：不能执行有out 参数的存储过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>DataSet对象</returns>
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
        /// 执行Sql 命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataSet 对象</returns>
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
        /// 执行Sql 命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>执行结果对象</returns>
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
        /// 执行Sql Server存储过程
        /// 注意：不能执行有out 参数的存储过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>执行结果对象</returns>
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
        /// 设置一个等待执行的SqlCommand对象
        /// </summary>
        /// <param name="cmd">SqlCommand 对象，不允许空对象</param>
        /// <param name="conn">SqlConnection 对象，不允许空对象</param>
        /// <param name="commandText">Sql 语句</param>
        /// <param name="cmdParms">SqlParameters  对象,允许为空对象</param>
        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, SqlParameter[] cmdParms)
        {
            //打开连接
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //设置SqlCommand对象
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
        /// 设置一个等待执行存储过程的SqlCommand对象
        /// </summary>
        /// <param name="cmd">SqlCommand 对象，不允许空对象</param>
        /// <param name="conn">SqlConnection 对象，不允许空对象</param>
        /// <param name="spName">Sql 语句</param>
        /// <param name="parameterValues">不定个数的存储过程参数，允许为空</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, string spName, params object[] parameterValues)
        {
            //打开连接
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //设置SqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            //获取存储过程的参数
            SqlCommandBuilder.DeriveParameters(cmd);
            //移除Return_Value 参数
            cmd.Parameters.RemoveAt(0);
            //设置参数值
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
        /// 执行Sql 命令分页填充DataTable
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataSet 对象</returns>
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
