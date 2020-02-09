using System.Collections.Generic;

namespace Randy.Responses
{
    public class GetIntegerSequencesResponse : ResponseBase
    {
        public IEnumerable<IEnumerable<int>> Data { get; set; }
    }
}