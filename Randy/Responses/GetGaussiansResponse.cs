using System.Collections.Generic;

namespace Randy.Responses
{
    public class GetGaussiansResponse : ResponseBase
    {
        public IEnumerable<decimal> Data { get; set; }
    }
}