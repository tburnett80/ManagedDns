using ManagedDns.Internal.Extensions;
using Xunit;

namespace ManagedDns.Tests.Internals.ExtensionTests
{
    /// <summary>
    /// Unit tests for invividual string extension methods
    /// </summary>
    public class StringExtensions
    {
        /// <summary>
        /// Will trim strings
        /// </summary>
        [Fact]
        public void TrimmedString()
        {
            Assert.Equal("this is my sample value.", "  this is my sample value.   ".TryTrim());
            Assert.Equal("Another string", "  Another string".TryTrim());
            Assert.Equal(string.Empty, string.Empty.TryTrim());
        }
    }
}
