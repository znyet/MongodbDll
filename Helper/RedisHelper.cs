using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;
using System.Configuration;

namespace XiaoBuPark.DbHelper
{
    /// <summary>
    /// redis缓存帮助类  单例模式 线程安全
    /// </summary>
    public class RedisHelper
    {
        private static readonly string RedisConnecttionString = ConfigurationManager.ConnectionStrings["RedisConnecttionString"].ConnectionString;
        private static object _locker = new object();
        private static ConnectionMultiplexer _conn;
        public static ConnectionMultiplexer conn
        {
            get
            {
                if (_conn == null || !_conn.IsConnected)
                {
                    lock (_locker)
                    {
                        if (_conn != null) return _conn;

                        _conn = ConnectionMultiplexer.Connect(RedisConnecttionString); ;
                        return _conn;
                    }
                }

                return _conn;
            }
        }
    }
}
