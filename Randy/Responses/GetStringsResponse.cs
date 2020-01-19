using System.Collections.Generic;

namespace Randy.Responses
{
    public class GetStringsResponse : ResponseBase
    {
        public IEnumerable<string> Data { get; set; }

    }
}