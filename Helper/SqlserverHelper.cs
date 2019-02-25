using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyConnections;

namespace XiaoBuPark.DbHelper
{
    /// <summary>
    /// SqlServer帮助类
    /// </summary>
    public class SqlserverHelper
    {
        private static readonly string SqlServerConnecttionString = ConfigurationManager.ConnectionStrings["SqlServerConnecttionString"].ConnectionString;

        /// <summary>
        /// 获取SqlConnection
        /// </summary>
        /// <returns></returns>
        private static IDbConnection GetSqlConn()
        {
            IDbConnection conn = new SqlConnection(SqlServerConnecttionString);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;
        }

        /// <summary>
        /// 获取MyConnection
        /// </summary>
        /// <returns></returns>
        public static MyConnection GetConn()
        {
            return MyConnection.CreateSqlServerConn(GetSqlConn());
        }


    }
}
