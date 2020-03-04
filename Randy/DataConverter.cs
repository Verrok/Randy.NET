using Randy.Enums;
using System;
using System.Globalization;
using System.Text.Json;

namespace Randy
{
    public static class DataConverter
    {
        public static string Lower = "abcdefghijklmnopqrstuvwxyz";
        public static string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Digits = "0123456789";
        public static string Symb = "!@#$%^&*()№;:?*{}[]'/|";

        public static T GetRandomData<T>(string jsonResult, JsonSerializerOptions options = null)
        {
            using JsonDocument document = JsonDocument.Parse(jsonResult);
            Console.WriteLine(jsonResult);
            var prop = document.RootElement.GetProperty("result").GetProperty("random").GetProperty("data");
            T data = JsonSerializer.Deserialize<T>(prop.ToString(), options);
            return data;
        }

        public static DateTime GetCompletionTime(string jsonResult)
        {
            using JsonDocument document = JsonDocument.Parse(jsonResult);
            var prop = document.RootElement.GetProperty("result").GetProperty("random").GetProperty("completionTime");

            DateTime result = DateTime.Parse(prop.ToString(), null, DateTimeStyles.RoundtripKind);
            
            return result;
        }

        public static string GetStringFromCharSet(CharSet c)
        {

            string result = String.Empty;

            if (c.HasFlag(CharSet.Lower))
            {
                result += Lower;
            }
            if (c.HasFlag(CharSet.Upper))
            {
                result += Upper;
            }
            if (c.HasFlag(CharSet.Digits))
            {
                result += Digits;
            }
            if (c.HasFlag(CharSet.Symbols))
            {
                result += Symb;
            }

            return result;

        }

    }
}