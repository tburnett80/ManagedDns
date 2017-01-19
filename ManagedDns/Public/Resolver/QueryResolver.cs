using System.Net;
using ManagedDns.Internal;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Factory;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Public.Interfaces;
using ManagedDns.Public.Models;

namespace ManagedDns.Public.Resolver
{
    public sealed class QueryResolver : IQueryResolver
    {
        #region Constructor and private members

        private readonly IDnsTransport _transport;

        public QueryResolver()
            : this(new UdpDnsTransport())
        {
        }

        internal QueryResolver(IDnsTransport transport)
        {
            _transport = transport;
        }

        #endregion

        #region Interface Actions 

        public Message MakeDnsQuery(Question question, IPEndPoint dnsServer = null, bool recursionDesired = true)
        {
            var q = MessageFactory.FromQuery(question.Convert(), recursionDesired);
            var response = _transport.SendRequest(q, dnsServer ?? new IPEndPoint(IPAddress.Parse("208.67.222.222"), 53));

            return MessageFactory.FromRawData(response).Convert();
        }
        #endregion
    }
}
