using System.Collections.Generic;

namespace Randy.Responses
{
    public class GetIntegerSequencesRequest : ResponseBase
    {
        public IEnumerable<IEnumerable<int>> Data { get; set; }
    }
}