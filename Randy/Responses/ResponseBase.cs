using System;
using Newtonsoft.Json;
using Randy.Responses.Abstractions;

namespace Randy.Responses
{
    public class ResponseBase : IResponse
    {
        [JsonProperty("result")]
        public ResultInfo ResultInfo { get; set; } = new ResultInfo();
        public string JsonResponse { get; set; }
        public int Id { get; set; }
        public DateTime CompletionTime { get; set; }
    }
}