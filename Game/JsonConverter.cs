using System;
using System.Reflection;
using Newtonsoft.Json;

namespace Game{
    static class JsonConverter{
        public static object Deserialize(string str){
            return JsonConvert.DeserializeObject(str);
        }
    }

    static class JsonConverter<T>{
        public static T Deserialize(string str){
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}