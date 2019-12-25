using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Randy.Requests.Abstractions
{
    public interface IRequest
    {
        /// <summary>
        /// An integer that contains ID of request, response will return that ID
        /// </summary>
        int Id { get; set; }
        
        /// <summary>
        /// gRPC version
        /// </summary>
        string Jsonrpc { get; set; }
        
        /// <summary>
        /// Method name that you want to invoke, e.g. "generateIntegers"
        /// </summary>
        string Method { get; set; }
        
        /// <summary>
        /// Your API key, which is used to track the true random bit usage for your client.
        /// </summary>
        string ApiKey { get; set; }
        
        /// <summary>
        /// Request parameters 
        /// </summary>
        Dictionary<string, object> Params { get; set; }

        /// <summary>
        /// Converts class to json string
        /// </summary>
        /// <param name="options">Serializer option, needs to convert names to camelCase</param>
        /// <returns>JSON string representation of class</returns>
        HttpContent ToHttpContent(JsonSerializerOptions options);

    }
}