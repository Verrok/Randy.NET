using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Randy.Requests.Abstractions;

namespace Randy.Requests
{
    public class Request : IRequest
    {
        
        public string Jsonrpc { get; set; }
        
        public string Method { get; set; }

        public int Id { get; set; }
        
        public Dictionary<string, object> Params { get; set; } = new Dictionary<string, object>();
        
        public HttpContent ToHttpContent(JsonSerializerSettings settings)
        {
            string json = JsonConvert.SerializeObject(this, settings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        
    }
}