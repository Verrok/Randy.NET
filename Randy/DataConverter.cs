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
            switch (c)
            {
                case CharSet.Lower:
                    return Lower;
                case CharSet.Upper:
                    return Upper;
                case CharSet.Digits:
                    return Digits;
                case CharSet.Symbols:
                    return Symb;
                case CharSet.Alphabet:
                    return Lower + Upper;
                case CharSet.AlphaNumeric:
                    return Lower + Upper + Digits;
                case CharSet.All:
                    return Lower + Upper + Digits + Symb;
                default:
                    return "";
            }
        }

    }
}