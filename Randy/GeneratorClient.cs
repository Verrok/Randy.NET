﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
        private readonly JsonSerializerSettings _settings;
        private readonly Random _rnd;
        private readonly IMapper _mapper;
        public GeneratorClient(string apiKey, ApiVersion ver = ApiVersion.V2, HttpClient client = null)
        {
            _rnd = new Random();
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _client = client ?? new HttpClient();
            
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            };
            
            _settings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
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
                cfg.CreateMap<ResponseBase, GetIntegerSequencesResponse>();
                cfg.CreateMap<ResponseBase, GetStringsResponse>();
            });

            _mapper = config.CreateMapper();
            
        }


        public async Task<ResponseBase> MakegRpcRequestAsync(IRequest request, CancellationToken cancellationToken = default)
        {

            string jsonString;

            
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, _requestUrl)
            {
                Content = request.ToHttpContent(_settings),
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
            
            ResponseBase resp = JsonConvert.DeserializeObject<ResponseBase>(jsonString, _settings);
            resp.JsonResponse = jsonString;
            return resp;
        }

        public async Task<GetIntegerResponse> GetIntegersAsync(int count, int min, int max, bool replacement = true, int @base = 10,
            CancellationToken cancellationToken = default)
        {
            var request = InitRequest("generateIntegers");
            
            request.Params.Add("apiKey", _apiKey);
            request.Params.Add("n", count);
            request.Params.Add("min", min);
            request.Params.Add("max", max);
            request.Params.Add("replacement", replacement);
            request.Params.Add("base", @base);

            ResponseBase responseBase = await MakegRpcRequestAsync(request, cancellationToken);
            GetIntegerResponse response = _mapper.Map<GetIntegerResponse>(responseBase);
            IntConverter converter = new IntConverter(@base);
            response.Data = DataConverter.GetRandomData<IEnumerable<int>>(responseBase.JsonResponse, converter);
            response.CompletionTime = DataConverter.GetCompletionTime(responseBase.JsonResponse);

            return response;
        }

        public GetIntegerResponse GetIntegers(int count, int min, int max, bool replacement = true, int @base = 10)
        {
            return AsyncHelper.RunSync(() => GetIntegersAsync(count, min, max, replacement, @base));
        }

        public async Task<GetIntegerSequencesResponse> GetIntegerSequencesAsync(int count, IEnumerable<int> length, IEnumerable<int> min, IEnumerable<int> max, IEnumerable<bool> replacement,
            int @base, CancellationToken cancellationToken = default)
        {
            var request = InitRequest("generateIntegerSequences");
            
            request.Params.Add("apiKey", _apiKey);
            request.Params.Add("n", count);
            request.Params.Add("length", length);
            request.Params.Add("min", min);
            request.Params.Add("max", max);
            request.Params.Add("replacement", replacement);
            request.Params.Add("base", @base);
            
            ResponseBase responseBase = await MakegRpcRequestAsync(request, cancellationToken);

            GetIntegerSequencesResponse response = _mapper.Map<GetIntegerSequencesResponse>(responseBase);

            response.Data = DataConverter.GetRandomData<IEnumerable<IEnumerable<int>>>(responseBase.JsonResponse);
            response.CompletionTime = DataConverter.GetCompletionTime(responseBase.JsonResponse);

            return response;
        }

        public async Task<GetIntegerSequencesResponse> GetIntegerSequencesAsync(int count, int length, int min, int max, bool replacement = true, int @base = 10,
            CancellationToken cancellationToken = default)
        {
            var request = InitRequest("generateIntegerSequences");
            
            request.Params.Add("apiKey", _apiKey);
            request.Params.Add("n", count);
            request.Params.Add("length", length);
            request.Params.Add("min", min);
            request.Params.Add("max", max);
            request.Params.Add("replacement", replacement);
            request.Params.Add("base", @base);

            ResponseBase responseBase = await MakegRpcRequestAsync(request, cancellationToken);
            GetIntegerSequencesResponse response = _mapper.Map<GetIntegerSequencesResponse>(responseBase);
            
            response.Data = DataConverter.GetRandomData<IEnumerable<IEnumerable<int>>>(responseBase.JsonResponse);
            response.CompletionTime = DataConverter.GetCompletionTime(responseBase.JsonResponse);

            return response;
        }

        public GetIntegerSequencesResponse GetIntegerSequences(int count, IEnumerable<int> length, IEnumerable<int> min, IEnumerable<int> max,
            IEnumerable<bool> replacement, int @base)
        {
            return AsyncHelper.RunSync(() => GetIntegerSequencesAsync(count, length, min, max, replacement, @base));
        }
        
        public GetIntegerSequencesResponse GetIntegerSequences(int count, int length, int min, int max, bool replacement = true, int @base = 10)
        {
            return AsyncHelper.RunSync(() => GetIntegerSequencesAsync(count, length, min, max, replacement, @base));
        }
        

        public async Task<GetDecimalFractionsResponse> GetDecimalFractionsAsync(int count, int decimalPlaces, bool replacement = true,
            CancellationToken cancellationToken = default)
        {
            var request = InitRequest("generateDecimalFractions");
            
            request.Params.Add("apiKey", _apiKey);
            request.Params.Add("n", count);
            request.Params.Add("decimalPlaces", decimalPlaces);
            request.Params.Add("replacement", replacement);

            ResponseBase responseBase = await MakegRpcRequestAsync(request, cancellationToken);

            GetDecimalFractionsResponse response = _mapper.Map<GetDecimalFractionsResponse>(responseBase);

            response.Data = DataConverter.GetRandomData<IEnumerable<decimal> >(responseBase.JsonResponse);
            response.CompletionTime = DataConverter.GetCompletionTime(responseBase.JsonResponse);
            return response;
        }

        public GetDecimalFractionsResponse GetDecimalFractions(int count, int decimalPlaces, bool replacement = true)
        {
            return AsyncHelper.RunSync(() => GetDecimalFractionsAsync(count, decimalPlaces, replacement));
        }

        public async Task<GetGaussiansResponse> GetGaussiansAsync(int count, int mean, int deviation, int digits, CancellationToken cancellationToken = default)
        {
            var request = InitRequest("generateGaussians");
            
            request.Params.Add("apiKey", _apiKey);
            request.Params.Add("n", count);
            request.Params.Add("mean", mean);
            request.Params.Add("standardDeviation", deviation);
            request.Params.Add("significantDigits", digits);
            

            ResponseBase responseBase = await MakegRpcRequestAsync(request, cancellationToken);
            GetGaussiansResponse response = _mapper.Map<GetGaussiansResponse>(responseBase);
            response.Data = DataConverter.GetRandomData<IEnumerable<decimal> >(responseBase.JsonResponse);
            response.CompletionTime = DataConverter.GetCompletionTime(responseBase.JsonResponse);
            return response;
        }

        public GetGaussiansResponse GetGaussians(int count, int mean, int deviation, int digits)
        {
            return AsyncHelper.RunSync(() => GetGaussiansAsync(count, mean, deviation, digits));
        }
        
        

        public async Task<GetStringsResponse> GetStringsAsync(int count, int length, string characters, bool replacement = true,
            CancellationToken cancellationToken = default)
        {
            var request = InitRequest("generateStrings");
            request.Params.Add("apiKey", _apiKey);
            request.Params.Add("n", count);
            request.Params.Add("length", length);
            request.Params.Add("characters", characters);
            request.Params.Add("replacement", replacement);



            
            ResponseBase responseBase = await MakegRpcRequestAsync(request, cancellationToken);

            GetStringsResponse response = _mapper.Map<GetStringsResponse>(responseBase);

            response.Data = DataConverter.GetRandomData<IEnumerable<string> >(responseBase.JsonResponse);
            response.CompletionTime = DataConverter.GetCompletionTime(responseBase.JsonResponse);
            return response;
        }

        public async Task<GetStringsResponse> GetStringsAsync(int count, int length, CharSet set, bool replacement = true,
            CancellationToken cancellationToken = default)
        {
            string res = DataConverter.GetStringFromCharSet(set);
            return await GetStringsAsync(count, length, res, replacement, cancellationToken);
        }

        public async Task<GetStringsResponse> GetStringsAsync(int count, int length, bool replacement = true,
            CancellationToken cancellationToken = default)
        {
            return await GetStringsAsync(count, length, DataConverter.GetStringFromCharSet(CharSet.All), replacement, cancellationToken);
        }


        public GetStringsResponse GetStrings(int count, int length, string characters, bool replacement = true)
        {
            return AsyncHelper.RunSync(() => GetStringsAsync(count, length, characters, replacement));
        }
        
        public GetStringsResponse GetStrings(int count, int length, CharSet set, bool replacement = true)
        {
            return AsyncHelper.RunSync(() => GetStringsAsync(count, length, set, replacement));

        }
        
        public GetStringsResponse GetStrings(int count, int length, bool replacement = true)
        {
            return AsyncHelper.RunSync(() => GetStringsAsync(count, length, replacement));
        }

        #region Private method

        private Request InitRequest(string method)
        {
            Request request = new Request();
            request.Jsonrpc = _apiVersion;
            request.Method = method;
            request.Id = _rnd.Next(1, 1000);
            return request;
        }

        #endregion
        
    }
}