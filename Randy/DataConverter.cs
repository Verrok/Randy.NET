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
        
        public static byte[] StringToByteArrayFastest(string hex) {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex) {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

    }
}