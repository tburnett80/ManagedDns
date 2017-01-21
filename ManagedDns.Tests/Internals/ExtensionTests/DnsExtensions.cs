using ManagedDns.Internal.Extensions;
using Xunit;

namespace ManagedDns.Tests.Internals.ExtensionTests
{
    public class DnsExtensions
    {
        [Fact]
        public void ToLabelBytesTest()
        {
            Assert.Equal(new byte[] { 8, 99, 99, 99, 103, 45, 105, 110, 99, 3, 99, 111, 109, 0 }, "cccg-inc.com.".ToLabelBytes());
        }
    }
}
