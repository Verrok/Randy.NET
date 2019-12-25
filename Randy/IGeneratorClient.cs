using System.Collections.Generic;
using Randy.Requests.Abstractions;
using Randy.Requests.Responses;

namespace Randy
{
    public interface IGeneratorClient
    {
        void MakegRpcRequestAsync();

        void MakegRpcRequest();

        GetIntegerResponse GetIntegersAsync();
        
        GetIntegerResponse GetIntegers();

        GetIntegerSequencesRequest GetIntegerSequencesAsync();
        
        GetIntegerSequencesRequest GetIntegerSequences();

        GetDecimalFractionsResponse GetDecimalFractionsAsync();
        
        GetDecimalFractionsResponse GetDecimalFractions();

        GetGaussiansResponse GetGaussiansAsync();

        GetGaussiansResponse GetGaussians();
        
     


    }
}