using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ManagedDns.Internal;
using ManagedDns.Internal.Factory;
using ManagedDns.Internal.Model;
using ManagedDns.Public;
using Xunit;

namespace ManagedDns.Tests.Internals
{
    public class SocketTester
    {
        //[Fact]
        public void TestSocket()
        {
            var sock = new UdpDnsTransport();

            var request = MessageFactory.FromQuery(QuestionFactory.FactoryQuestion(RecordType.TxtRecord, "google.com."));

            var resp = sock.SendRequest(request, new IPEndPoint(IPAddress.Parse("8.8.8.8"), 53));

            var stuff = resp;
        }
    }
}
