using System;
using System.Net.Http;
using Randy.Enums;
using Randy.Requests.Responses;

namespace Randy
{
    public class GeneratorClient : IGeneratorClient
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _requestUrl;
        private readonly string _apiVersion;
        public GeneratorClient(string apiKey, ApiVersion ver = ApiVersion.V2, HttpClient client = null)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _client = client ?? new HttpClient();

            switch (ver)
            {
                case ApiVersion.V1:
                    _apiVersion = "1.0";
                    break;
                case ApiVersion.V2:
                    _apiVersion = "2.0";
                    break;
            }
            

        }
    
    
        public void MakegRpcRequestAsync()
        {
            throw new System.NotImplementedException();
        }

        public void MakegRpcRequest()
        {
            throw new System.NotImplementedException();
        }

        public GetIntegerResponse GetIntegersAsync()
        {
            throw new System.NotImplementedException();
        }

        public GetIntegerResponse GetIntegers()
        {
            throw new System.NotImplementedException();
        }

        public GetIntegerSequencesRequest GetIntegerSequencesAsync()
        {
            throw new System.NotImplementedException();
        }

        public GetIntegerSequencesRequest GetIntegerSequences()
        {
            throw new System.NotImplementedException();
        }

        public GetDecimalFractionsResponse GetDecimalFractionsAsync()
        {
            throw new System.NotImplementedException();
        }

        public GetDecimalFractionsResponse GetDecimalFractions()
        {
            throw new System.NotImplementedException();
        }

        public GetGaussiansResponse GetGaussiansAsync()
        {
            throw new System.NotImplementedException();
        }

        public GetGaussiansResponse GetGaussians()
        {
            throw new System.NotImplementedException();
        }
    }
}