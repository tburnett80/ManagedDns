using ManagedDns.Internal.Extensions;
using Xunit;

namespace ManagedDns.Tests.Internals.ExtensionTests
{
    public class ToBigEndianExtensions
    {
        [Fact]
        public void UShortToBeUShortArray()
        {
            Assert.Equal(new byte[] { 0, 24 }, ((ushort)24).ToBeBytes());
            Assert.Equal(new byte[] { 46, 239 }, ((ushort)12015).ToBeBytes());
        }

        [Fact]
        public void UShortToBeUShort()
        {
            Assert.Equal(6144, ((ushort)24).ToBeUshort());
            Assert.Equal(61230, ((ushort)12015).ToBeUshort());
        }

        [Fact]
        public void UIntToBeUIntArray()
        {
            Assert.Equal(new byte[] { 0, 0, 0, 24 }, ((uint)24).ToBeBytes());
            Assert.Equal(new byte[] { 0, 0, 46, 239 }, ((uint)12015).ToBeBytes());
        }
    }
}
