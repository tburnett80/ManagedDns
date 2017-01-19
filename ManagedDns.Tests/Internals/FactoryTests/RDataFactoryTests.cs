using System.Linq;
using ManagedDns.Internal.Engines;
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
            var rec = RDataFactory.FactoryRecord(RecordType.TxtRecord, new RawByteParser(RDataBytes.TxtRdata().ToArray(), 0));
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", rec.DataAsString());
        }

        [Fact]
        public void FactoryAaaaRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.AaaaRecord, new RawByteParser(RDataBytes.AaaaRdata().ToArray(), 0));
            Assert.Equal("2607:f8b0:4009:800::1006", rec.DataAsString());
        }

        [Fact]
        public void FactoryARecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.ARecord, new RawByteParser(RDataBytes.ARData().ToArray(), 0));
            Assert.Equal("206.190.36.45", rec.DataAsString());
        }

        [Fact]
        public void FactoryCNameRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.CNameRecord, new RawByteParser(RDataBytes.CNameRData().ToArray(), 0));
            Assert.Equal("fd-fp3.wg1.b.", rec.DataAsString());
        }

        [Fact]
        public void FactoryMxRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.MxRecord, new RawByteParser(RDataBytes.MxRData().ToArray(), 0));
            Assert.Equal("1 - mta7.am0.yahoodns.net.", rec.DataAsString());
        }

        [Fact]
        public void FactoryNsRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.NsRecord, new RawByteParser(RDataBytes.NsRData().ToArray(), 0));
            Assert.Equal("ns5.", rec.DataAsString());
        }

        [Fact]
        public void FactoryPtrRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.PtrRecord, new RawByteParser(RDataBytes.PtrRData().ToArray(), 0));
            Assert.Equal("dfw06s40-in-f21.1e100.net.", rec.DataAsString());
        }
    }
}
