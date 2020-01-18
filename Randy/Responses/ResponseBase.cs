using System.Text.Json.Serialization;
using Randy.Responses.Abstractions;

namespace Randy.Responses
{
    public class ResponseBase : IResponse
    {
        [JsonPropertyName("result")]
        public ResultInfo ResultInfo { get; set; } = new ResultInfo();
        public string JsonResponse { get; set; }
    }
}