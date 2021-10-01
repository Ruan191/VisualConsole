using Newtonsoft.Json;

namespace VisualConsole{
    static class JsonConverter{
        public static object Deserialize(string str) => JsonConvert.DeserializeObject(str);
    }

    static class JsonConverter<T>{
        public static T Deserialize(string str) => JsonConvert.DeserializeObject<T>(str);
    }
}