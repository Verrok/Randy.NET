using System.Collections.Generic;

namespace Randy.Responses
{
    public class GetDecimalFractionsResponse : ResponseBase
    {
        public IEnumerable<decimal> Data { get; set; }
    }
}