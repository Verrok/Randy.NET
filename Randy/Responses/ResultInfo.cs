using System;

namespace Randy.Responses
{
    public class ResultInfo
    {
        /// <summary>
        /// A string containing the timestamp in <a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601</a> format at which the request was completed.
        /// </summary>
        public DateTime CompletionTime { get; set; }
        
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
        
        /// <summary>
        /// An integer containing ID of request
        /// </summary>
        public int Id { get; set; }
    }
}