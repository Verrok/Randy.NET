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
    }
}