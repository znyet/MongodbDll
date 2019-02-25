using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using System.Configuration;

namespace XiaoBuPark.DbHelper
{
    /// <summary>
    /// mongodb帮助类  单例模式 线程安全
    /// </summary>
    public class MongoHelper
    {
        private static readonly string MongodbConnecttionString = ConfigurationManager.ConnectionStrings["MongodbConnecttionString"].ConnectionString;
        private static object _locker = new object();
        private static MongoClient _client;
        public static MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    lock (_locker)
                    {
                        if (_client == null)
                            _client = new MongoClient(MongodbConnecttionString);
                    }
                }
                return _client;
            }
        }

        public static IMongoDatabase GetDatabase(string dbname = "test")
        {
            return Client.GetDatabase(dbname);
        }

        public static IMongoCollection<T> GetCollection<T>(string name, string dbname = "test")
        {
            return GetDatabase(dbname).GetCollection<T>(name);
        }


    }
}
