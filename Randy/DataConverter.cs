using Randy.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Randy
{
    public static class DataConverter
    {
        public static string Lower = "abcdefghijklmnopqrstuvwxyz";
        public static string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Digits = "0123456789";
        public static string Symb = "!@#$%^&*()№;:?*{}[]'/|";

        public static T GetRandomData<T>(string jsonResult, IntConverter converter = null)
        {
            JObject obj = JObject.Parse(jsonResult);
            var prop = obj["result"]["random"]["data"];
            if (converter != null)
            {
                T data = JsonConvert.DeserializeObject<T>(prop.ToString(), converter);
                return data;
            }
            else
            {
                T data = JsonConvert.DeserializeObject<T>(prop.ToString());
                return data;
            }

        }

        public static DateTime GetCompletionTime(string jsonResult)
        {
            JObject jobj = JObject.Parse(jsonResult);
            var prop = jobj["result"]["random"]["completionTime"];
            if (prop != null)
            {
                DateTime result = DateTime.Parse(prop.ToString(), null, DateTimeStyles.RoundtripKind);
            
                return result;
            }

            return default;
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