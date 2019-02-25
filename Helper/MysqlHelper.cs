using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using MyConnections;
using MySql.Data.MySqlClient;

namespace XiaoBuPark.DbHelper
{
    /// <summary>
    /// mysql帮助类
    /// </summary>
    public class MysqlHelper
    {
        private static readonly string MySqlConnecttionString = ConfigurationManager.ConnectionStrings["MySqlConnecttionString"].ConnectionString;

        //IDbConnection
        private static IDbConnection GetSqlConn()
        {
            IDbConnection conn = new MySqlConnection(MySqlConnecttionString);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;
        }

        //mysql
        public static MyConnection GetConn()
        {
            return MyConnection.CreateMySqlConn(GetSqlConn());
        }
    }
}
