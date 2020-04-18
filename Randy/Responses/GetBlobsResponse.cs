using System.Collections.Generic;

namespace Randy.Responses
{
    public class GetBlobsResponse : ResponseBase
    {
        public IEnumerable<string> Data { get; set; }
        public IEnumerable<byte[]> DataBinary { get; set; }

    }
}