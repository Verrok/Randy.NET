using System;
using System.Text.Json.Serialization;
using Randy.Enums;

namespace Randy.Responses
{
    public class ResultInfo
    {

        /// <summary>
        /// An integer containing the number of true random bits used to complete this request.
        /// </summary>
        public int BitsUsed { get; set; }
        
        /// <summary>
        /// An integer containing the (estimated) number of remaining true random bits available to the client.
        /// </summary>
        public int BitsLeft { get; set; }
        
        /// <summary>
        /// An integer containing the (estimated) number of remaining API requests available to the client.
        /// </summary>
        public int RequestsLeft { get; set; }
        
        /// <summary>
        /// An integer containing the recommended number of milliseconds that the client should delay before issuing another request.
        /// </summary>
        public int AdvisoryDelay { get; set; }
        
        
        [JsonPropertyName("status")]
        public string StringStatus { get; set; }
        
        [JsonPropertyName("creationTime")]
        public string StringCreationTime { get; set; }
        
        [JsonIgnore]
        public Status Status { get; set; }
        
        [JsonIgnore]
        public DateTime CreationTime { get; set; }
        
        public int TotalBits { get; set; }
        
        public int TotalRequests { get; set; }
        
        
    }
}