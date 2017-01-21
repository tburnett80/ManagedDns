using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Factory;
using ManagedDns.Public;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals.FactoryTests
{
    public class HeaderFactoryTests
    {
        [Fact]
        public void HeaderGeneratedFromBytesTest()
        {
            var header = HeaderFactory.FromBytes(DnsQuerries.GetYahooMxQuery());

            Assert.Equal(new byte[] { 41, 163, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, header.ToBytes());

            Assert.Equal(10659, header.Id);
            Assert.Equal(OpCode.Query, header.OpCode);
            Assert.Equal(ResponseCode.NoError, header.RCode);
            Assert.Equal(Qr.Query, header.Qr);
            Assert.Equal(false, header.Aa);
            Assert.Equal(false, header.Ra);
            Assert.Equal(true, header.Rd);
            Assert.Equal(false, header.Tc);
            Assert.Equal(0, header.AnCount);
            Assert.Equal(0, header.ArCount);
            Assert.Equal(0, header.NsCount);
            Assert.Equal(1, header.QdCount);
            Assert.Equal(0, header.Z);
        }

        [Fact]
        public void HeaderFactoryBadBytes()
        {
            var header = HeaderFactory.FromBytes(new byte[] { 41, 163, 1 });

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
        public void HeaderFactoryFromParser()
        {
            var parser = new RawByteParser(DnsQuerries.GetYahooMxQuery());
            var header = HeaderFactory.FromParser(parser);

            Assert.Equal(new byte[] { 41, 163, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, header.ToBytes());

            Assert.Equal(10659, header.Id);
            Assert.Equal(OpCode.Query, header.OpCode);
            Assert.Equal(ResponseCode.NoError, header.RCode);
            Assert.Equal(Qr.Query, header.Qr);
            Assert.Equal(false, header.Aa);
            Assert.Equal(false, header.Ra);
            Assert.Equal(true, header.Rd);
            Assert.Equal(false, header.Tc);
            Assert.Equal(0, header.AnCount);
            Assert.Equal(0, header.ArCount);
            Assert.Equal(0, header.NsCount);
            Assert.Equal(1, header.QdCount);
            Assert.Equal(0, header.Z);
        }
    }
}
