using System.Collections.Generic;
using System.Net;
using ManagedDns.Internal.Model;

namespace ManagedDns.Internal.Interfaces
{
    internal interface IDnsTransport
    {
        IEnumerable<byte> SendRequest(Message request, IPEndPoint dnsServer, int timeOut = 30);
    }
}
