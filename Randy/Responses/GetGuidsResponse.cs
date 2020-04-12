using System;
using System.Collections.Generic;

namespace Randy.Responses
{
    public class GetGuidsResponse : ResponseBase
    {
        public IEnumerable<Guid> Data { get; set; }
    }
}