using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Text.Json.Serialization;

namespace Randy.Requests.Abstractions
{
    public interface IRequest
    {
        [JsonPropertyName("jsonrpc")]
        string JsonRpc { get; set; }
        
        [JsonPropertyName("method")]
        string Method { get; set; }
        
        [JsonPropertyName("id")]
        int Id { get; set; }
        
        [JsonPropertyName("params")]
        Dictionary<string, object> Params { get; set; }
        
        [JsonIgnore]
        HttpContent HttpContent { get; set; }
    }
}