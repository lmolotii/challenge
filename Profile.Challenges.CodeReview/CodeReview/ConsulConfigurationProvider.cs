using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Profile.Challenges.CodeReview.CodeReview
{
    /// <summary>
    /// Please provide the code review for the current class. 
    /// </summary>
    internal class ConsulConfigurationProvider : ConfigurationProvider
    {
        private readonly IEnumerable<string> _rootKeys;

        private readonly IConsulSettings _consulSettings;

        public ConsulConfigurationProvider(IEnumerable<string> rootKeys, IConsulSettings consulSettings)
        {
            _rootKeys = rootKeys;
            _consulSettings = consulSettings;
        }

        public bool TryGet(string key, out string value)
        {
            return base.TryGet(key, out value);
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
        {
            return base.GetChildKeys(earlierKeys, parentPath);
        }

        public override void Load() => LoadAsync().ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task LoadAsync()
        {
            IDictionary<string, string> keyValues = new Dictionary<string, string>();
            foreach (var rootKey in _rootKeys)
            {
                try
                {
                    var response = await _consulSettings.GetKeyValuesAsync(rootKey);
                    foreach (var keyValue in response)
                    {
                        keyValues.Add(KeyValueMapper.Map(rootKey, keyValue));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Key not found {rootKey}");
                }
            }

            Data = keyValues;
        }
    }
}