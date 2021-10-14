using System;
using System.Text;

namespace Profile.Challenges.CodeReview.CodeReview.Models
{
    public sealed class KeyValue
    {
        private string _base64String;
        public string Key { get; set; }

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(_base64String))
                    return "null";
                
                byte[] base64EncodedBytes = Convert.FromBase64String(_base64String);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            set => _base64String = value;
        }
    }
}