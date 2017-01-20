using System.Diagnostics.CodeAnalysis;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Factory;
using ManagedDns.Public;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals.FactoryTests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ResourceFactoryTests
    {
        [Fact]
        public void FactoryResourceRecordTxt()
        {
            var parser = new RawByteParser(DnsResponses.TXT());

            //advance the parser past the header and question portion of the response
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In, resourceRecord.Class);
            Assert.Equal(RecordType.TxtRecord, resourceRecord.Type);
            Assert.Equal("google.com.", resourceRecord.Name);
            Assert.Equal(76, resourceRecord.RdLength);
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", (resourceRecord.Record as Internal.Model.RData.TxtRecord).Text);
            Assert.Equal(new byte[] { 75, 118, 61, 115, 112, 102, 49, 32, 105, 110, 99, 108, 117, 100, 101, 58, 95, 115, 112,
                    102, 46, 103, 111, 111, 103, 108, 101, 46, 99, 111, 109, 32, 105, 112, 52, 58, 50, 49, 54, 46, 55, 51,
                    46, 57, 51, 46, 55, 48, 47, 51, 49, 32, 105, 112, 52, 58, 50, 49, 54, 46, 55, 51, 46, 57, 51, 46, 55, 50,
                    47, 51, 49, 32, 126, 97, 108, 108 }, resourceRecord.Rdata);
        }

        [Fact]
        public void FactoryResourceRecordAAAA()
        {
            var parser = new RawByteParser(DnsResponses.AAAA());

            //advance the parser past the header and question portion of the response
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In, resourceRecord.Class);
            Assert.Equal(RecordType.AaaaRecord, resourceRecord.Type);
            Assert.Equal("google.com.", resourceRecord.Name);
            Assert.Equal(16, resourceRecord.RdLength);
            Assert.Equal((uint)300, resourceRecord.Ttl);
            Assert.Equal("2607:f8b0:4009:800::1006", (resourceRecord.Record as Internal.Model.RData.AaaaRecord).Address.ToString());
            Assert.Equal(new byte[] { 38, 7, 248, 176, 64, 9, 8, 0, 0, 0, 0, 0, 0, 0, 16, 6 }, resourceRecord.Rdata);
        }

        [Fact]
        public void FactoryResouceRecordA()
        {
            var parser = new RawByteParser(DnsResponses.A());
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In, resourceRecord.Class);
            Assert.Equal(RecordType.ARecord, resourceRecord.Type);
            Assert.Equal("yahoo.com.", resourceRecord.Name);
            Assert.Equal(4, resourceRecord.RdLength);
            Assert.Equal((uint)1800, resourceRecord.Ttl);
            Assert.Equal("206.190.36.45", (resourceRecord.Record as Internal.Model.RData.ARecord).Address.ToString());
            Assert.Equal(new byte[] { 206, 190, 36, 45 }, resourceRecord.Rdata);
        }

        [Fact]
        public void FactoryResouceRecordCName()
        {
            var parser = new RawByteParser(DnsResponses.CName());
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In, resourceRecord.Class);
            Assert.Equal(RecordType.CNameRecord, resourceRecord.Type);
            Assert.Equal("www.yahoo.com.", resourceRecord.Name);
            Assert.Equal(15, resourceRecord.RdLength);
            Assert.Equal((uint)300, resourceRecord.Ttl);
            Assert.Equal("fd-fp3.wg1.b.yahoo.com.", (resourceRecord.Record as Internal.Model.RData.CNameRecord).CName);
            Assert.Equal(new byte[] { 6, 102, 100, 45, 102, 112, 51, 3, 119, 103, 49, 1, 98, 192, 16 }, resourceRecord.Rdata);
        }

        [Fact]
        public void FactoryResouceRecordMx()
        {
            var parser = new RawByteParser(DnsResponses.MX());
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In, resourceRecord.Class);
            Assert.Equal(RecordType.MxRecord, resourceRecord.Type);
            Assert.Equal("yahoo.com.", resourceRecord.Name);
            Assert.Equal(25, resourceRecord.RdLength);
            Assert.Equal((uint)1800, resourceRecord.Ttl);
            Assert.Equal(1, (resourceRecord.Record as Internal.Model.RData.MxRecord).Preference);
            Assert.Equal("mta7.am0.yahoodns.net.", (resourceRecord.Record as Internal.Model.RData.MxRecord).Exchanger);
            Assert.Equal(new byte[] { 0, 1, 4, 109, 116, 97, 55, 3, 97, 109, 48, 8, 121, 97, 104, 111, 111, 100, 110, 115, 3, 110, 101, 116, 0 }, resourceRecord.Rdata);
        }

        [Fact]
        public void FactoryResouceRecordNs()
        {
            var parser = new RawByteParser(DnsResponses.NS());
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In, resourceRecord.Class);
            Assert.Equal(RecordType.NsRecord, resourceRecord.Type);
            Assert.Equal("yahoo.com.", resourceRecord.Name);
            Assert.Equal(6, resourceRecord.RdLength);
            Assert.Equal((uint)172800, resourceRecord.Ttl);
            Assert.Equal("ns5.yahoo.com.", (resourceRecord.Record as Internal.Model.RData.NsRecord).NsDomainName);
            Assert.Equal(new byte[] { 3, 110, 115, 53, 192, 12 }, resourceRecord.Rdata);
        }

        [Fact]
        public void FactoryResouceRecordPtr()
        {
            var parser = new RawByteParser(DnsResponses.PTR());
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In, resourceRecord.Class);
            Assert.Equal(RecordType.PtrRecord, resourceRecord.Type);
            Assert.Equal("53.115.194.173.in-addr.arpa.", resourceRecord.Name);
            Assert.Equal(27, resourceRecord.RdLength);
            Assert.Equal((uint)86400, resourceRecord.Ttl);
            Assert.Equal("dfw06s40-in-f21.1e100.net.", (resourceRecord.Record as Internal.Model.RData.PtrRecord).DomainName);
            Assert.Equal(new byte[] { 15, 100, 102, 119, 48, 54, 115, 52, 48, 45, 105, 110, 45, 102, 50, 49, 5, 49, 101, 49, 48, 48, 3, 110, 101, 116, 0 }, resourceRecord.Rdata);
        }

        [Fact]
        public void FactoryResouceRecordSoa()
        {
            var parser = new RawByteParser(DnsResponses.SOA());
            QuestionFactory.FromParser(parser);

            var resourceRecord = ResourceRecordFactory.FromParser(parser);

            Assert.Equal(RecordClass.In, resourceRecord.Class);
            Assert.Equal(RecordType.SoaRecord, resourceRecord.Type);
            Assert.Equal("yahoo.com.", resourceRecord.Name);
            Assert.Equal(49, resourceRecord.RdLength);
            Assert.Equal((uint)1800, resourceRecord.Ttl);
            Assert.Equal(new byte[] { 3, 110, 115, 49, 192, 12, 10, 104, 111, 115, 116, 109, 97, 115, 116, 101, 114, 9, 121, 97, 104, 111, 111, 45, 105, 110, 99, 192, 18, 120, 11, 95, 66, 0, 0, 14, 16, 0, 0, 1, 44, 0, 27, 175, 128, 0, 0, 2, 88 }, resourceRecord.Rdata);
        }
    }
}
