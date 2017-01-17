using System.Collections.Generic;
using System.Net;
using ManagedDns.Internal.Model;
using ManagedDns.Internal.Model.RData;
using ManagedDns.Public;
using Xunit;

namespace ManagedDns.Tests.Internals.ModelTests
{
    public class ResourceRecordModelTests
    {
        [Fact]
        public void ConstructResourceRecord()
        {
            var rr = new ResourceRecord("Test record", 1, 1, 225, 65, new List<byte> { 1, 2, 3 }, new ARecord(IPAddress.Parse("127.0.0.1")));

            Assert.Equal("Test record", rr.Name);
            Assert.Equal(RecordType.ARecord, rr.Type);
            Assert.Equal(RecordClass.In, rr.Class);
            Assert.Equal((uint)225, rr.Ttl);
            Assert.Equal(65, rr.RdLength);
            Assert.Equal(new List<byte> { 1, 2, 3 }, rr.Rdata);
            Assert.Equal("127.0.0.1", rr.Record.DataAsString());
        }

        [Fact]
        public void ConstructDefaultResourceRecord()
        {
            var rr = new ResourceRecord();

            Assert.Equal(null, rr.Name);
            Assert.Equal(RecordType.Unknown, rr.Type);
            Assert.Equal(RecordClass.Unknown, rr.Class);
            Assert.Equal((uint)0, rr.Ttl);
            Assert.Equal(0, rr.RdLength);
            Assert.Equal(null, rr.Rdata);
            Assert.Equal(null, rr.Record);
        }

        [Fact]
        public void ResourceRecordToBytesTest()
        {
            var rr = new ResourceRecord("Test record", 1, 1, 225, 65, new List<byte> { 1, 2, 3 }, new ARecord(IPAddress.Parse("127.0.0.1")));
            Assert.Equal(new byte[] { 11, 84, 101, 115, 116, 32, 114, 101, 99, 111, 114, 100, 0, 0, 1, 0, 1, 0, 0, 0, 225, 0, 65, 1, 2, 3 }, rr.ToBytes());
        }
    }
}
