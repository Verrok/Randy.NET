using System.Collections.Generic;

namespace Randy.Responses
{
    public class GetIntegerResponse : ResponseBase
    {
        public IEnumerable<int> Data { get; set; }
    }
}