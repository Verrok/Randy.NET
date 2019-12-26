using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Randy.Requests.Abstractions;

namespace Randy.Requests
{
    public class Request : IRequest
    {
        
        public string Jsonrpc { get; set; }
        
        public string Method { get; set; }

        public int Id { get; set; }
        
        public Dictionary<string, object> Params { get; set; } = new Dictionary<string, object>();
        
        public HttpContent ToHttpContent(JsonSerializerOptions options)
        {
            string json = JsonSerializer.Serialize(this, options);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        
    }
}