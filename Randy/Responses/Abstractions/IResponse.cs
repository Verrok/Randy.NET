using System;
using System.Text.Json.Serialization;

namespace Randy.Responses.Abstractions
{
    public interface IResponse
    {

        /// <summary>
        /// Additional information about response
        /// </summary>
        public ResultInfo ResultInfo { get; set; }

        
        /// <summary>
        /// JSON string of response
        /// </summary>
        public string JsonResponse { get; set; }
        
        
        /// <summary>
        /// An integer containing ID of request
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// A string containing the timestamp in <a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601</a> format at which the request was completed.
        /// </summary>
        public DateTime CompletionTime { get; set; }
    }
}