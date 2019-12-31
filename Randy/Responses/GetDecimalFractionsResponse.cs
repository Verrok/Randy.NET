using System;
using System.Collections.Generic;
using Randy.Requests.Abstractions;

namespace Randy.Requests.Responses
{
    public class GetDecimalFractionsResponse : IResponse<IEnumerable<decimal>>
    {
        public IEnumerable<decimal> Data { get; set; }
        public DateTime CompletionTime { get; set; }
        public int BitsUsed { get; set; }
        public int BitsLeft { get; set; }
        public int RequestsLeft { get; set; }
        public int AdvisoryDelay { get; set; }
        public int Id { get; set; }
    }
}