using System.Collections.Generic;
using System.Linq;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Model;

namespace ManagedDns.Internal
{
    /// <summary>
    /// Will store the results of DNS queries for faster retrival until TTL Expires
    /// </summary>
    internal static class QueryCache
    {
        private static readonly IDictionary<string, Message> Cache = new Dictionary<string, Message>();

        private static readonly object Lock = new object();

        internal static bool AddCache(Message message)
        {
            if (message == null || !message.Questions.Any())
                return false;

            var added = false;
            lock (Lock)
            {
                var key = message.Questions.FirstOrDefault().ToString();
                if (Cache.ContainsKey(key) && Cache[key].Answers.Any(an => an.IsExpired()))
                {
                    Cache[key] = message;
                    added = true;
                }
                else if (!Cache.ContainsKey(key))
                {
                    Cache.Add(key, message);
                    added = true;
                }
            }

            return added;
        }

        internal static Message CheckCache(Question question)
        {
            lock (Lock)
            {
                var key = question.ToString(); //Get matching message if the answers arent expired
                return Cache.ContainsKey(key) && Cache[key].Answers.Any(an => !an.IsExpired())
                    ? Cache[key]
                    : null;
            }
        }
    }
}
