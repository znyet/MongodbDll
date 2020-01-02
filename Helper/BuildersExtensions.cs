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
    }
}

//public long Update(string id, Dictionary<string, object> dict)
//{
//    var col = GetCollection<DeviceCol>(Name);
//    var update = Builders<DeviceCol>.Update.SetFields(dict);
//    var result = col.UpdateOne(w => w.Id == id, update);
//        return result.ModifiedCount;
//}