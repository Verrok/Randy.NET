using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Randy.Enums;
using Randy.Requests.Abstractions;
using Randy.Responses;

namespace Randy
{
    public interface IGeneratorClient
    {
        
        /// <summary>
        /// Makes gRPC request to Random.org server asynchronously
        /// </summary>
        /// <param name="request">Request class</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <typeparam name="T">One of the responses</typeparam>
        /// <returns>Task with certain response</returns>
        Task<ResponseBase> MakegRpcRequestAsync(IRequest request, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Generates array of random integers asynchronously
        /// </summary>
        /// <param name="count">Count of random integers. Must be in [1, 1e4] range</param>
        /// <param name="min">The lower boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="max">The upper boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <param name="base">Base to display numbers. Allowed 2, 8, 10 and 16. Default = 10</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task with response</returns>
        Task<GetIntegerResponse> GetIntegersAsync(int count, int min, int max, bool replacement = true, int @base = 10, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Generates array of random integers
        /// </summary>
        /// <param name="count">Count of random integers. Must be in [1, 1e4] range</param>
        /// <param name="min">The lower boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="max">The upper boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <param name="base">Base to display numbers. Allowed 2, 8, 10 and 16. Default = 10</param>
        /// <returns>Response</returns>
        GetIntegerResponse GetIntegers(int count, int min, int max, bool replacement = true, int @base = 10);

        /// <summary>
        /// Generates sequences of random integers asynchronously
        /// </summary>
        /// <param name="count">Count of random sequences integers. Must be in [1, 1e4] range</param>
        /// <param name="length">Length of sequences. Count of elements must equals to count param</param>
        /// <param name="min">The lower boundary for the range. Must be in [-1e9,1e9] range. Length must equals to count param</param>
        /// <param name="max">The upper boundary for the range. Must be in [-1e9,1e9] range. Length must equals to count param</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Length must equals to count param. Default = true</param>
        /// <param name="base">Base to display numbers. Length must equals to count param. Allowed 2, 8, 10 and 16. Default = 10.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task with response</returns>
        Task<GetIntegerSequencesResponse> GetIntegerSequencesAsync(int count, IEnumerable<int> length, IEnumerable<int> min, IEnumerable<int> max, IEnumerable<bool> replacement, int @base, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Generates sequences of random integers asynchronously
        /// </summary>
        /// <param name="count">Count of random sequences integers. Must be in [1, 1e4] range</param>
        /// <param name="length">Length of sequences</param>
        /// <param name="min">The lower boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="max">The upper boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Length must equals to 1 or to count. Default = true</param>
        /// <param name="base">Base to display numbers. Length must equals to 1 or to count. Allowed 2, 8, 10 and 16. Default = 10.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task with response</returns>
        Task<GetIntegerSequencesResponse> GetIntegerSequencesAsync(int count, int length, int min, int max, bool replacement = true, int @base = 10, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Generates sequences of random integers 
        /// </summary>
        /// <param name="count">Count of random sequences integers. Must be in [1, 1e4] range</param>
        /// <param name="length">Length must equals to 1 or to count</param>
        /// <param name="min">The lower boundary for the range. Must be in [-1e9,1e9] range. Length must equals to 1 or to count</param>
        /// <param name="max">The upper boundary for the range. Must be in [-1e9,1e9] range. Length must equals to 1 or to count</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Length must equals to 1 or to count. Default = true</param>
        /// <param name="base">Base to display numbers. Length must equals to 1 or to count. Allowed 2, 8, 10 and 16. Default = 10.</param>
        /// <returns>Response/></returns>
        
        GetIntegerSequencesResponse GetIntegerSequences(int count, IEnumerable<int> length, IEnumerable<int> min, IEnumerable<int> max, IEnumerable<bool> replacement, int @base);

        /// <summary>
        /// Generates sequences of random integers 
        /// </summary>
        /// <param name="count">Count of random sequences integers. Must be in [1, 1e4] range</param>
        /// <param name="length">Length of sequences</param>
        /// <param name="min">The lower boundary for the range. Must be in [-1e9,1e9] range.</param>
        /// <param name="max">The upper boundary for the range. Must be in [-1e9,1e9] range.</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Length must equals to 1 or to count. Default = true</param>
        /// <param name="base">Base to display numbers. Length must equals to 1 or to count. Allowed 2, 8, 10 and 16. Default = 10.</param>
        /// <returns>Response/></returns>
        
        GetIntegerSequencesResponse GetIntegerSequences(int count, int length, int min, int max, bool replacement = true, int @base = 10);
        
        /// <summary>
        /// Generates random <a href="https://en.wikipedia.org/wiki/Decimal#Decimal_fractions">decimal fraction</a> from a uniform distribution across the [0,1] interval with a user-defined number of decimal places asynchronously
        /// </summary>
        /// <param name="count">Count of fractions. Must be in [1, 1e4] range</param>
        /// <param name="decimalPlaces">Number are digits that carry meaningful contribution to its measurement resolution (taken from wiki). Must be in [1,14] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task with response</returns>
        Task<GetDecimalFractionsResponse> GetDecimalFractionsAsync(int count, int decimalPlaces, bool replacement = true, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Generates random <a href="https://en.wikipedia.org/wiki/Decimal#Decimal_fractions">decimal fraction</a> from a uniform distribution across the [0,1] interval with a user-defined number of decimal places asynchronously
        /// </summary>
        /// <param name="count">Count of fractions</param>
        /// <param name="decimalPlaces">Number are digits that carry meaningful contribution to its measurement resolution (taken from wiki). Must be in [1,14] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <returns>Response</returns>
        GetDecimalFractionsResponse GetDecimalFractions(int count, int decimalPlaces, bool replacement = true);

        /// <summary>
        /// Generates random numbers from a <a href="https://en.wikipedia.org/wiki/Normal_distribution">Gaussian distribution</a> asynchronously 
        /// </summary>
        /// <param name="count">Count of numbers. Must be in [1, 1e4] range</param>
        /// <param name="mean">The distribution's mean. Must be within the [-1e6,1e6] range.</param>
        /// <param name="deviation">The distribution's standard deviation. Must be within the [-1e6,1e6] range.</param>
        /// <param name="digits">The number of significant digits to use. Must be within the [2,14] range.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task with response</returns>
        Task<GetGaussiansResponse> GetGaussiansAsync(int count, int mean, int deviation, int digits, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates random numbers from a <a href="https://en.wikipedia.org/wiki/Normal_distribution">Gaussian distribution</a> 
        /// </summary>
        /// <param name="count">Count of numbers. Must be in [1, 1e4] range</param>
        /// <param name="mean">The distribution's mean. Must be within the [-1e6,1e6] range.</param>
        /// <param name="deviation">The distribution's standard deviation. Must be within the [-1e6,1e6] range.</param>
        /// <param name="digits">The number of significant digits to use. Must be within the [2,14] range.</param>
        /// <returns>Task with response</returns>
        GetGaussiansResponse GetGaussians(int count, int mean, int deviation, int digits);

        /// <summary>
        /// Generates random string from characters set
        /// </summary>
        /// <param name="count">Count of generated strings. Must be less than 10000</param>
        /// <param name="length">String length. Must be in [1, 32] range</param>
        /// <param name="characters">Character set that generated string consists of. Must be less than 32</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task with response</returns>

        Task<GetStringsResponse> GetStringsAsync(int count, int length, string characters, bool replacement = true, CancellationToken cancellationToken = default);
        /// <summary>
        /// Generates random string from characters set
        /// </summary>
        /// <param name="count">Count of generated strings. Must be less than 10000</param>
        /// <param name="length">String length. Must be in [1, 32] range</param>
        /// <param name="set">Sets of string see</param>
        /// <seealso cref="DataConverter"/>>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task with response</returns>
        Task<GetStringsResponse> GetStringsAsync(int count, int length, CharSet set, bool replacement = true, CancellationToken cancellationToken = default);
        /// <summary>
        /// Generates random string from characters set. String will contain all characters from CharSet enum
        /// </summary>
        /// <param name="count">Count of generated strings. Must be less than 10000</param>
        /// <param name="length">String length. Must be in [1, 32] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task with response</returns>
        Task<GetStringsResponse> GetStringsAsync(int count, int length, bool replacement = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates random string from characters set
        /// </summary>
        /// <param name="count">Count of generated strings. Must be less than 10000</param>
        /// <param name="length">String length. Must be in [1, 32] range</param>
        /// <param name="characters">Character set that generated string consists of. Must be less than 32</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <returns>Response</returns>
        GetStringsResponse GetStrings(int count, int length, string characters, bool replacement = true);
        /// <summary>
        /// Generates random string from characters set
        /// </summary>
        /// <param name="count">Count of generated strings. Must be less than 10000</param>
        /// <param name="length">String length. Must be in [1, 32] range</param>
        /// <param name="set">Sets of string see</param>
        /// <seealso cref="DataConverter"/>>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <returns>Response</returns>
        GetStringsResponse GetStrings(int count, int length, CharSet set, bool replacement = true);
        /// <summary>
        /// Generates random string from characters set. String will contain all characters from CharSet enum
        /// </summary>
        /// <param name="count">Count of generated strings. Must be less than 10000</param>
        /// <param name="length">String length. Must be in [1, 32] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <returns>Response</returns>
        GetStringsResponse GetStrings(int count, int length, bool replacement = true);

        /// <summary>
        /// Generates version 4 true random Universally Unique IDentifiers (UUIDs) in accordance with section 4.4 of RFC 4122 asyncly
        /// </summary>
        /// <param name="count">Count of generated GUIDs</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response</returns>
        Task<GetGuidsResponse> GetGuidsAsync(int count, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates version 4 true random Universally Unique IDentifiers (UUIDs) in accordance with section 4.4 of RFC 4122 
        /// </summary>
        /// <param name="count">Count of generated GUIDs</param>
        /// <returns>Response</returns>
        GetGuidsResponse GetGuids(int count);
        
        /// <summary>
        /// Generates Binary Large Objects (BLOBs) containing true random data. asyncly
        /// </summary>
        /// <param name="count">Count of generated blobs</param>
        /// <param name="size">Size of each blob. Must be within the [1,1048576] range and must be divisible by 8</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response</returns>
        Task<GetBlobsResponse> GetBlobsAsync(int count, int size, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates Binary Large Objects (BLOBs) containing true random data.
        /// </summary>
        /// <param name="count">Count of generated blobs</param>
        /// <param name="size">Size of each blob. Must be within the [1,1048576] range and must be divisible by 8</param>
        /// <returns>Response</returns>
        GetBlobsResponse GetBlobs(int count, int size);

        /// <summary>
        /// This method returns information related to the the usage of a given API key asyncly.  
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        Task<GetUsageResponse> GetUsageAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// This method returns information related to the the usage of a given API key. 
        /// </summary>
        /// <returns>Response</returns>
        GetUsageResponse GetUsage();

    }
}