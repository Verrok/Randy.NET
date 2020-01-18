
using System;
using Randy.Requests.Abstractions;

namespace Randy.Requests.Responses
{
    public class ResponseBase : IResponse
    {
        public ResultInfo ResultInfo { get; set; }
        public string JsonResponse { get; set; }
    }
}