using System;
using Newtonsoft.Json;

namespace Randy
{
    public class IntConverter : JsonConverter<int>
    {

        private readonly int _base;


        public IntConverter(int @base)
        {
            _base = @base;
        }

        public override void WriteJson(JsonWriter writer, int value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }

        public override int ReadJson(JsonReader reader, Type objectType, int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = reader.ReadAsString();
            return Convert.ToInt32(s, _base);
        }
    }
}