using System;
using System.Net;
using System.Net.Sockets;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Factory;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;
using System.Linq;

namespace ManagedDns.Internal
{
    internal sealed class UdpDnsTransport : IDnsTransport
    {
        public Message SendRequest(Message request, IPEndPoint dnsServer, int timeOut = 30)
        {
            byte[] rawResponse;

            try
            {
                using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, timeOut * 1000);
                    //sock.SendTo(request.ToBytes().ToArray(), dnsServer);
                    sock.SendTo(new byte[] { 41, 163, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 121, 97, 104, 111, 111, 3, 99, 111, 109, 0, 0, 15, 0, 1 }, dnsServer);
                    var buffer = new byte[512];
                    var recieved = sock.Receive(buffer);

                    rawResponse = new byte[recieved];
                    Array.Copy(buffer, rawResponse, recieved);

                    var copy = new byte[recieved];
                    Array.Copy(rawResponse, copy, recieved);
                    var asStr = copy.Select(b => b.ToString()).Aggregate((c, n) => c + ", " + n);
                    var stuff = asStr;
                }
            }
            catch (SocketException)
            {
                rawResponse = null;
                throw;
            }
            catch (Exception)
            {
                rawResponse = null;
                throw;
            }

            return MessageFactory.FromParser(new RawByteParser(rawResponse));
        }
    }
}
