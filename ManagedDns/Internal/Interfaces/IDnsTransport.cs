using System.Net;
using ManagedDns.Internal.Model;

namespace ManagedDns.Internal.Interfaces
{
    internal interface IDnsTransport
    {
        Message SendRequest(Message request, IPEndPoint dnsServer, int timeOut = 30);
    }
}
