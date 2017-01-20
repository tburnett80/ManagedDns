using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;
using System.Linq;

namespace ManagedDns.Internal
{
    internal sealed class UdpDnsTransport : IDnsTransport
    {
        public IEnumerable<byte> SendRequest(Message request, IPEndPoint dnsServer, int timeOut = 30)
        {
            byte[] rawResponse;

            try
            {
                using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, timeOut * 1000);
                    sock.SendTo(request.ToBytes().ToArray(), dnsServer);

                    var buffer = new byte[512];
                    var recieved = sock.Receive(buffer);

                    rawResponse = new byte[recieved];
                    Array.Copy(buffer, rawResponse, recieved);
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

            return rawResponse;
        }
    }
}
