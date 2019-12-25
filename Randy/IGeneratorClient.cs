using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Randy.Requests.Abstractions;
using Randy.Requests.Responses;

namespace Randy
{
    public interface IGeneratorClient
    {
        Task<T> MakegRpcRequestAsync<T>(IRequest request, CancellationToken cancellationToken = default);

        T MakegRpcRequest<T>(IRequest request);

        /// <summary>
        /// Generates array of random integers asynchronously
        /// </summary>
        /// <param name="count">Count of random integers. Must be in [1, 1e4] range</param>
        /// <param name="min">The lower boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="max">The upper boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <param name="base">Base to display numbers. Allowed 2, 8, 10 and 16. Default = 10</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        GetIntegerResponse GetIntegersAsync(int count, int min, int max, bool replacement = true, int @base = 10, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Generates array of random integers
        /// </summary>
        /// <param name="count">Count of random integers. Must be in [1, 1e4] range</param>
        /// <param name="min">The lower boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="max">The upper boundary for the range. Must be in [-1e9,1e9] range</param>
        /// <param name="replacement">If true array can contains duplicate values, else contains unique. Default = true</param>
        /// <param name="base">Base to display numbers. Allowed 2, 8, 10 and 16. Default = 10</param>
        /// <returns>Response </returns>
        GetIntegerResponse GetIntegers(int count, int min, int max, bool replacement = true, int @base = 10);

        GetIntegerSequencesRequest GetIntegerSequencesAsync();
        
        GetIntegerSequencesRequest GetIntegerSequences();

        GetDecimalFractionsResponse GetDecimalFractionsAsync();
        
        GetDecimalFractionsResponse GetDecimalFractions();

        GetGaussiansResponse GetGaussiansAsync();

        GetGaussiansResponse GetGaussians();
        
     


    }
}