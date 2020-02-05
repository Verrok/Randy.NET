using System;
using System.Globalization;
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

        public static DateTime GetCompletionTime(string jsonResult)
        {
            using JsonDocument document = JsonDocument.Parse(jsonResult);
            var prop = document.RootElement.GetProperty("result").GetProperty("random").GetProperty("completionTime");

            DateTime result = DateTime.Parse(prop.ToString(), null, DateTimeStyles.RoundtripKind);
            
            return result;
        }
    }
}