using System.Net;
using ManagedDns.Internal;
using ManagedDns.Internal.Factory;
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

            //208.67.222.222 and 208.67.220.220
            var resp = sock.SendRequest(request, new IPEndPoint(IPAddress.Parse("208.67.222.222"), 53));

            // ReSharper disable once PossibleMultipleEnumeration
            var msg = MessageFactory.FromRawData(resp);

            var stuff = msg;
        }
    }
}
