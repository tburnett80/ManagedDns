using ManagedDns.Internal.Model;
using ManagedDns.Public;
using Xunit;

namespace ManagedDns.Tests.Internals.ModelTests
{
    public class HeaderModelTests
    {
        [Fact]
        public void ConstructHeader()
        {
            var header = new Header(12, 1, 1, true, true, true, true, 234, 1, 2, 2, 2, 2);

            Assert.Equal(12, header.Id);
            Assert.Equal(OpCode.Iquery, header.OpCode);
            Assert.Equal(ResponseCode.FormErr, header.RCode);
            Assert.Equal(Qr.Response, header.Qr);
            Assert.Equal(true, header.Aa);
            Assert.Equal(true, header.Ra);
            Assert.Equal(true, header.Rd);
            Assert.Equal(true, header.Tc);
            Assert.Equal(2, header.AnCount);
            Assert.Equal(2, header.ArCount);
            Assert.Equal(2, header.NsCount);
            Assert.Equal(2, header.QdCount);
            Assert.Equal(234, header.Z);
        }

        [Fact]
        public void ConstructHeaderDefault()
        {
            var header = new Header();

            Assert.Equal(0, header.Id);
            Assert.Equal(OpCode.Query, header.OpCode);
            Assert.Equal(ResponseCode.NoError, header.RCode);
            Assert.Equal(Qr.Query, header.Qr);
            Assert.Equal(false, header.Aa);
            Assert.Equal(false, header.Ra);
            Assert.Equal(false, header.Rd);
            Assert.Equal(false, header.Tc);
            Assert.Equal(0, header.AnCount);
            Assert.Equal(0, header.ArCount);
            Assert.Equal(0, header.NsCount);
            Assert.Equal(0, header.QdCount);
            Assert.Equal(0, header.Z);
        }

        [Fact]
        public void HeaderToBytesTest()
        {
            var header = new Header(10659, 0, 0, false, false, true, false, 0, 0, 1, 0, 0, 0);
            Assert.Equal(new byte[] { 41, 163, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, header.ToBytes());
        }
    }
}