using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoBuPark.Entitys
{
    /// <summary>
    /// log错误日志类(Web用)
    /// </summary>
    public class LogWebErrorEntity
    {
        public ObjectId _id { get; set; }

        /// <summary>
        /// 请求网页地址
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 请求网页地址包括queryString
        /// </summary>
        public string RawUrl { get; set; }

        /// <summary>
        /// http请求方式 Get  Post
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Http请求状态码
        /// </summary>
        public int HttpCode { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// url请求参数
        /// </summary>
        public string QueryString { get; set; }

        /// <summary>
        /// post参数
        /// </summary>
        public string PostData { get; set; }

        /// <summary>
        /// 上传文件参数
        /// </summary>
        public string PostFiles { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 请求文件物理路径
        /// </summary>
        public string PhysicalPath { get; set; }

        /// <summary>
        /// 源错误
        /// </summary>
        public string SourceError { get; set; }

        /// <summary>
        /// 堆栈跟踪
        /// </summary>
        public string TargetSite { get; set; }

        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// 用户浏览器信息
        /// </summary>
        public string UserAgent { get; set; }
    }
}
