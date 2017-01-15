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
            var parser = new RawByteParser(DnsResponses.GoogleTxtResponse());

            //advance the parser past the header and question portion of the response
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In ,resourceRecord.Class);
            Assert.Equal(RecordType.TxtRecord, resourceRecord.Type);
            Assert.Equal("google.com.", resourceRecord.Name);
            Assert.Equal(76, resourceRecord.RdLength);
            //TODO: update to add record from rdata
        }
    }
}
