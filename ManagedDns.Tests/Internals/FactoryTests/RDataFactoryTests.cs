using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Factory;
using ManagedDns.Public;
using ManagedDns.Public.Models.RData;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals.FactoryTests
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class RDataFactoryTests
    {
        [Fact]
        public void FactoryTxtRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.TxtRecord, new RawByteParser(RDataBytes.TxtRdata().ToArray(), 0));
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", (rec as Internal.Model.RData.TxtRecord).Text);

            var rec2 = RDataFactory.FactoryRecordModel(RecordType.TxtRecord, RDataBytes.TxtRdata());
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", (rec2 as TxtRecord).Text);
        }

        [Fact]
        public void FactoryAaaaRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.AaaaRecord, new RawByteParser(RDataBytes.AaaaRdata().ToArray(), 0));
            Assert.Equal("2607:f8b0:4009:800::1006", (rec as Internal.Model.RData.AaaaRecord).Address.ToString());

            var rec2 = RDataFactory.FactoryRecordModel(RecordType.AaaaRecord, RDataBytes.AaaaRdata());
            Assert.Equal("2607:f8b0:4009:800::1006", (rec2 as AaaaRecord).Address.ToString());
        }

        [Fact]
        public void FactoryARecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.ARecord, new RawByteParser(RDataBytes.ARData().ToArray(), 0));
            Assert.Equal("206.190.36.45", (rec as Internal.Model.RData.ARecord).Address.ToString());

            var rec2 = RDataFactory.FactoryRecordModel(RecordType.ARecord, RDataBytes.ARData());
            Assert.Equal("206.190.36.45", (rec2 as ARecord).Address.ToString());
        }

        [Fact]
        public void FactoryCNameRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.CNameRecord, new RawByteParser(RDataBytes.CNameRData().ToArray(), 0));
            Assert.Equal("fd-fp3.wg1.b.", (rec as Internal.Model.RData.CNameRecord).CName);

            var rec2 = RDataFactory.FactoryRecordModel(RecordType.CNameRecord, RDataBytes.CNameRData());
            Assert.Equal("fd-fp3.wg1.b.", (rec2 as CNameRecord).CName);
        }

        [Fact]
        public void FactoryMxRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.MxRecord, new RawByteParser(RDataBytes.MxRData().ToArray(), 0));
            Assert.Equal("mta7.am0.yahoodns.net.", (rec as Internal.Model.RData.MxRecord).Exchanger);
            Assert.Equal(1, (rec as Internal.Model.RData.MxRecord).Preference);

            var rec2 = RDataFactory.FactoryRecordModel(RecordType.MxRecord, RDataBytes.MxRData());
            Assert.Equal("mta7.am0.yahoodns.net.", (rec2 as MxRecord).Exchanger);
            Assert.Equal(1, (rec2 as MxRecord).Preference);
        }

        [Fact]
        public void FactoryNsRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.NsRecord, new RawByteParser(RDataBytes.NsRData().ToArray(), 0));
            Assert.Equal("ns5.", (rec as Internal.Model.RData.NsRecord).NsDomainName);

            var rec2 = RDataFactory.FactoryRecordModel(RecordType.NsRecord, RDataBytes.NsRData());
            Assert.Equal("ns5.", (rec2 as NsRecord).NameServerDomainName);
        }

        [Fact]
        public void FactoryPtrRecordTest()
        {
            var rec = RDataFactory.FactoryRecord(RecordType.PtrRecord, new RawByteParser(RDataBytes.PtrRData().ToArray(), 0));
            Assert.Equal("dfw06s40-in-f21.1e100.net.", (rec as Internal.Model.RData.PtrRecord).DomainName);

            var rec2 = RDataFactory.FactoryRecordModel(RecordType.PtrRecord, RDataBytes.PtrRData());
            Assert.Equal("dfw06s40-in-f21.1e100.net.", (rec2 as PtrRecord).DomainName);
        }
    }
}
