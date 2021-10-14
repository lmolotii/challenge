using System.Collections.Generic;
using System.Threading.Tasks;
using Profile.Challenges.CodeReview.CodeReview.Models;

namespace Profile.Challenges.CodeReview.CodeReview
{
    public interface IConsulSettings
    {
        Task<string> GetValue(string key);

        /// <summary>
        /// Suppose to send the request to the server, to get all keys. 
        /// </summary>
        /// <param name="key">Root key.</param>
        /// <returns>The set of key/value pairs</returns>
        Task<IEnumerable<KeyValue>> GetKeyValuesAsync(string key);
    }
}