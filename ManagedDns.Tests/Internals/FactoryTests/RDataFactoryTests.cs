using ManagedDns.Internal.Factory;
using ManagedDns.Public;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals.FactoryTests
{
    public class RDataFactoryTests
    {
        [Fact]
        public void FactoryTxtRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.TxtRecord, RDataBytes.TxtRdata());
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", rec.DataAsString());
        }
    }
}
