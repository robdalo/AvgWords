using Newtonsoft.Json;

namespace AvgWords.SDK.Consumers
{
    public static class Serializer
    {
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
