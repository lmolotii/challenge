using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Profile.Challenges.CodeReview.CodeReview.Models;

namespace Profile.Challenges.CodeReview.CodeReview
{
    public static class KeyValueMapper
    {
        public static KeyValuePair<string, string> Map(string rootKey, KeyValue keyValue)
        {
            return new KeyValuePair<string, string>(ConfigurationPath.Combine(keyValue.Key.Substring(rootKey.Length + 1).Split('/')), keyValue.Value);
        }
    }
}