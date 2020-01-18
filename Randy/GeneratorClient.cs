using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Randy.Enums;
using Randy.Requests;
using Randy.Requests.Abstractions;
using Randy.Responses;

namespace Randy
{
    public class GeneratorClient : IGeneratorClient
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _requestUrl = "https://api.random.org/json-rpc/2/invoke";
        private readonly string _apiVersion;
        private readonly JsonSerializerOptions _options;
        private readonly Random _rnd;
        private IMapper _mapper;
        public GeneratorClient(string apiKey, ApiVersion ver = ApiVersion.V2, HttpClient client = null)
        {
            _rnd = new Random();
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _client = client ?? new HttpClient();
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            switch (ver)
            {
                case ApiVersion.V2:
                    _apiVersion = "2.0";
                    break;
            }
            
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ResponseBase, GetIntegerResponse>();
                cfg.CreateMap<ResponseBase, GetGaussiansResponse>();
                cfg.CreateMap<ResponseBase, GetDecimalFractionsResponse>();
                cfg.CreateMap<ResponseBase, GetIntegerSequencesRequest>();
            });

            _mapper = config.CreateMapper();


        }


        public async Task<ResponseBase> MakegRpcRequestAsync(IRequest request, CancellationToken cancellationToken = default)
        {

            string jsonString;
            
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, _requestUrl)
            {
                Content = request.ToHttpContent(_options),
            };

            HttpResponseMessage response = null;
            
            
            try
            {
                response = await _client.SendAsync(httpRequest, cancellationToken);
            }
            catch (TaskCanceledException e)
            {
                if (cancellationToken.IsCancellationRequested)
                    throw;
            }

            if (response != null)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception("Response is null");
            }

            ResponseBase resp = JsonSerializer.Deserialize<ResponseBase>(jsonString, _options);
            resp.JsonResponse = jsonString;
            
            return resp;
        }

        public ResponseBase MakegRpcRequest(IRequest request)
        {
            throw new NotImplementedException();
        }
        public T GetRandomData<T>(string jsonResult)
        {
            throw new NotImplementedException();
        }

        public async Task<GetIntegerResponse> GetIntegersAsync(int count, int min, int max, bool replacement = true, int @base = 10,
            CancellationToken cancellationToken = default)
        {
            Request request = new Request();
            request.Jsonrpc = _apiVersion;
            request.Method = "generateIntegers";
            request.Id = _rnd.Next(1, 1000);
            
            request.Params.Add("apiKey", _apiKey);
            request.Params.Add("n", count);
            request.Params.Add("min", min);
            request.Params.Add("max", max);
            request.Params.Add("replacement", replacement);
            request.Params.Add("base", @base);

            ResponseBase responseBase = await MakegRpcRequestAsync(request, cancellationToken);

            GetIntegerResponse response = _mapper.Map<GetIntegerResponse>(responseBase);

            // response.Data = GetRandomData<IEnumerable<int>>(responseBase.JsonResponse);
            
            return response;
        }

        public GetIntegerResponse GetIntegers(int count, int min, int max, bool replacement = true, int @base = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<GetIntegerSequencesRequest> GetIntegerSequencesAsync(int count, IEnumerable<int> length, IEnumerable<int> min, IEnumerable<int> max, IEnumerable<bool> replacement,
            IEnumerable<int> @base, CancellationToken cancellationToken = default)
        {
            // Request request = new Request();
            // request.Jsonrpc = _apiVersion;
            // request.Method = "generateIntegerSequences";
            // request.Id = _rnd.Next(1, 1000);
            //
            // request.Params.Add("apiKey", _apiKey);
            // request.Params.Add("n", count);
            // request.Params.Add("length", length);
            // request.Params.Add("min", min);
            // request.Params.Add("max", max);
            // request.Params.Add("replacement", replacement);
            // request.Params.Add("base", @base);
            return null;
            //return MakegRpcRequestAsync<GetIntegerSequencesRequest>(request, cancellationToken);
        }

        public async Task<GetIntegerSequencesRequest> GetIntegerSequencesAsync(int count, int length, int min, int max, bool replacement = true, int @base = 10,
            CancellationToken cancellationToken = default)
        {
            // Request request = new Request();
            // request.Jsonrpc = _apiVersion;
            // request.Method = "generateIntegerSequences";
            // request.Id = _rnd.Next(1, 1000);
            //
            // request.Params.Add("apiKey", _apiKey);
            // request.Params.Add("n", count);
            // request.Params.Add("length", length);
            // request.Params.Add("min", min);
            // request.Params.Add("max", max);
            // request.Params.Add("replacement", replacement);
            // request.Params.Add("base", @base);

            return null;
            //return MakegRpcRequestAsync<GetIntegerSequencesRequest>(request, cancellationToken);
        }

        public GetIntegerSequencesRequest GetIntegerSequences(int count, IEnumerable<int> length, IEnumerable<int> min, IEnumerable<int> max,
            IEnumerable<bool> replacement, IEnumerable<int> @base)
        {
            throw new NotImplementedException();
        }

        public async Task<GetDecimalFractionsResponse> GetDecimalFractionsAsync(int count, int decimalPlaces, bool replacement = true,
            CancellationToken cancellationToken = default)
        {
            // Request request = new Request();
            // request.Jsonrpc = _apiVersion;
            // request.Method = "generateDecimalFractions";
            // request.Id = _rnd.Next(1, 1000);
            //
            // request.Params.Add("apiKey", _apiKey);
            // request.Params.Add("n", count);
            // request.Params.Add("decimalPlaces", decimalPlaces);
            // request.Params.Add("replacement", replacement);

            return null;
            //return MakegRpcRequestAsync<GetDecimalFractionsResponse>(request, cancellationToken);
        }

        public GetDecimalFractionsResponse GetDecimalFractions(int count, int decimalPlaces, bool replacement = true)
        {
            throw new NotImplementedException();
        }

        public async Task<GetGaussiansResponse> GetGaussiansAsync(int count, int mean, int deviation, int digits, CancellationToken cancellationToken = default)
        {
            // Request request = new Request();
            // request.Jsonrpc = _apiVersion;
            // request.Method = "generateGaussians";
            // request.Id = _rnd.Next(1, 1000);
            //
            // request.Params.Add("apiKey", _apiKey);
            // request.Params.Add("n", count);
            // request.Params.Add("mean", mean);
            // request.Params.Add("standardDeviation", deviation);
            // request.Params.Add("significantDigits", digits);

            return null;
            //return MakegRpcRequestAsync<GetGaussiansResponse>(request, cancellationToken);
        }

        public GetGaussiansResponse GetGaussians(int count, int mean, int deviation, int digits)
        {
            throw new NotImplementedException();
        }
    }
}