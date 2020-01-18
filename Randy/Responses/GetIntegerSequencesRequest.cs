using System;
using System.Collections.Generic;
using Randy.Requests.Abstractions;

namespace Randy.Requests.Responses
{
    public class GetIntegerSequencesRequest : IResponse
    {
        public IEnumerable<IEnumerable<int>> Data { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string JsonResponse { get; set; }
    }
}