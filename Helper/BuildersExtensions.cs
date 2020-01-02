using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ZLink.Elc.Mogo.Service
{
    public static class BuildersExtensions
    {
        public static UpdateDefinition<T> SetFields<T>(this UpdateDefinitionBuilder<T> builder, Dictionary<string, object> dict)
        {
            UpdateDefinition<T> update = null;
            foreach (var item in dict)
            {
                update = builder.Set(item.Key, item.Value);
            }
            return update;
        }

        public static ProjectionDefinition<T> IncludeFields<T>(this ProjectionDefinitionBuilder<T> builder, string[] fields)
        {
            ProjectionDefinition<T> project = null;
            foreach (var item in fields)
            {
                project = builder.Include(item);
            }
            return project;
        }

        public static ProjectionDefinition<T> ExcludeFields<T>(this ProjectionDefinitionBuilder<T> builder, string[] fields)
        {
            ProjectionDefinition<T> project = null;
            foreach (var item in fields)
            {
                project = builder.Exclude(item);
            }
            return project;
        }

       

    }
}

//public long Update(string id, Dictionary<string, object> dict)
//{
//    var col = GetCollection<DeviceCol>(Name);
//    var update = Builders<DeviceCol>.Update.SetFields(dict);
//    var result = col.UpdateOne(w => w.Id == id, update);
//        return result.ModifiedCount;
//}  


//public PageEntity<DeviceCol> GetPage(int page, int limit, DeviceCol queryModel)
//{
//    var where = new List<FilterDefinition<DeviceCol>>() { Builders<DeviceCol>.Filter.Empty };
//        if (!string.IsNullOrEmpty(queryModel.Id)) //设备id
//    {
//        where.Add(Builders<DeviceCol>.Filter.Where(w => w.Id == queryModel.Id));
//    }

//    if (!string.IsNullOrEmpty(queryModel.Name))
//    {
//        where.Add(Builders<DeviceCol>.Filter.Where(w => w.Name.Contains(queryModel.Name)));
//    }

//    var filter = Builders<DeviceCol>.Filter.And(where);

//    var col = GetCollection<DeviceCol>(Name);

//    var total = col.CountDocuments(filter);
//    var skip = GetSkip(page, limit);
//    var pro = Builders<DeviceCol>.Projection.IncludeFields(new string[] { "Id" });
//    var data = col.Find(filter).Project<DeviceCol>(pro).Skip(skip).Limit(limit).ToList();
//    var pageEntity = new PageEntity<DeviceCol> { Total = total, Data = data };
//    return pageEntity;
//}