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

        [Fact]
        public void FactoryAaaaRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.AaaaRecord, RDataBytes.AaaaRdata());
            Assert.Equal("2607:f8b0:4009:800::1006", rec.DataAsString());
        }

        [Fact]
        public void FactoryARecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.ARecord, RDataBytes.ARData());
            Assert.Equal("206.190.36.45", rec.DataAsString());
        }

        [Fact]
        public void FactoryCNameRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.CNameRecord, RDataBytes.CNameRData());
            Assert.Equal("fd-fp3.wg1.b.", rec.DataAsString());
        }

        [Fact]
        public void FactoryMxRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.MxRecord, RDataBytes.MxRData());
            Assert.Equal("1 - mta7.am0.yahoodns.net.", rec.DataAsString());
        }

        [Fact]
        public void FactoryNsRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.NsRecord, RDataBytes.NsRData());
            Assert.Equal("ns5.", rec.DataAsString());
        }

        [Fact]
        public void FactoryPtrRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.PtrRecord, RDataBytes.PtrRData());
            Assert.Equal("dfw06s40-in-f21.1e100.net.", rec.DataAsString());
        }
    }
}
