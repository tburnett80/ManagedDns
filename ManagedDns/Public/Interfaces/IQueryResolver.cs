using System.Net;
using ManagedDns.Public.Models;

namespace ManagedDns.Public.Interfaces
{
    public interface IQueryResolver
    {
        /// <summary>
        /// Will query for a dns record
        /// </summary>
        /// <param name="question">Dns Query to make</param>
        /// <param name="dnsServer">Optional Dns Server to use, will default to Open DNS</param>
        /// <param name="recursionDesired">Optional flag to use Recursion for an authoratative answer</param>
        /// <returns></returns>
        Message MakeDnsQuery(Question question, IPEndPoint dnsServer = null, bool recursionDesired = true);
    }
}
