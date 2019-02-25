using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nest;
using System.Configuration;

namespace XiaoBuPark.DbHelper
{
    /// <summary>
    /// elasticsearch搜索引擎
    /// </summary>
    public class EsHelper
    {
        private static readonly string EsConnecttionString = ConfigurationManager.ConnectionStrings["EsConnecttionString"].ConnectionString;

        /// <summary>
        /// 没有默认索引 用于创建索引(Mapping索引)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ElasticClient GetClient()
        {
            var node = new Uri(EsConnecttionString);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            return client;
        }

        /// <summary>
        /// 默认索引 NEST > 1.9.2
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ElasticClient GetClient(string index)
        {
            var node = new Uri(EsConnecttionString);
            var settings = new ConnectionSettings(node).DefaultIndex(index);
            var client = new ElasticClient(settings);
            return client;
        }


        /// <summary>
        /// 默认索引 NETS 1.9.2
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        //public static ElasticClient GetClient(string index)
        //{
        //    var node = new Uri(EsConnecttionString);
        //    var settings = new ConnectionSettings(node, index);
        //    var client = new ElasticClient(settings);
        //    return client;
        //}

    }
}
