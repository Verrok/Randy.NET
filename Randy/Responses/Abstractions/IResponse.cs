using System;
using System.Text.Json.Serialization;
using Randy.Requests.Responses;

namespace Randy.Requests.Abstractions
{
    public interface IResponse
    {

        /// <summary>
        /// Additional information about response
        /// </summary>
        [JsonPropertyName("result")]
        public ResultInfo ResultInfo { get; set; }

        
        /// <summary>
        /// JSON string of response
        /// </summary>
        public string JsonResponse { get; set; }
    }
}