using System;
using System.Collections.Generic;
using Randy.Requests.Abstractions;

namespace Randy.Requests.Responses
{
    public class GetDecimalFractionsResponse : IResponse
    {
        public IEnumerable<decimal> Data { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string JsonResponse { get; set; }
    }
}