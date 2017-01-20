using ManagedDns.Internal.Extensions;
using Xunit;

namespace ManagedDns.Tests.Internals.ExtensionTests
{
    public class ToLittleEndianExtensions
    {
        [Fact]
        public void BeUShortToLeUShort()
        {
            Assert.Equal((ushort)24, new byte[] { 0, 24 }.ToLeUShort());
            Assert.Equal((ushort)12015, new byte[] { 46, 239 }.ToLeUShort());
        }

        [Fact]
        public void BeUIntToLeUInt()
        {
            Assert.Equal((uint)24, new byte[] { 0, 0, 0, 24 }.ToLeUInt());
            Assert.Equal((uint)12015, new byte[] { 0, 0, 46, 239 }.ToLeUInt());
        }
    }
}

