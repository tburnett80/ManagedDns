using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Factory;
using ManagedDns.Public;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals.FactoryTests
{
    public class ResourceFactoryTests
    {
        [Fact]
        public void FactoryResourceRecord()
        {
            var parser = new RawByteParser(DnsResponses.TXT());

            //advance the parser past the header and question portion of the response
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In ,resourceRecord.Class);
            Assert.Equal(RecordType.TxtRecord, resourceRecord.Type);
            Assert.Equal("google.com.", resourceRecord.Name);
            Assert.Equal(76, resourceRecord.RdLength);
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", resourceRecord.Record.DataAsString());
        }
    }
}
