using System.Text.Json;

namespace Randy
{
    public static class DataConverter
    {
        public static T GetRandomData<T>(string jsonResult)
        {
            using JsonDocument document = JsonDocument.Parse(jsonResult);
            var prop = document.RootElement.GetProperty("result").GetProperty("random").GetProperty("data");
            T data = JsonSerializer.Deserialize<T>(prop.ToString());
            return data;
        }
    }
}