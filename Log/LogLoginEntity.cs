using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoBuPark.Entitys
{
    public class LogLoginEntity
    {
        public ObjectId _id { get; set; }

        public string UserId { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录ip
        /// </summary>
        public string LoginIp { get; set; }

        /// <summary>
        /// 登录端口
        /// </summary>
        public string LoginPort { get; set; }

        /// <summary>
        /// 用户浏览器信息
        /// </summary>
        public string UserAgent { get; set; }
    }
}
