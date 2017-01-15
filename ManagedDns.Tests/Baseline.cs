using System;
using Xunit;

namespace ManagedDns.Tests
{
    /// <summary>
    /// http://xunit.github.io/docs/getting-started-dotnet-core.html
    /// Guide to getting started with xunit and .net core
    /// </summary>
    public class Baseline
    {
        [Fact]
        public void PassingTest()
        {
            Func<int, int, int> add = (i, j) => i + j; 
            Assert.Equal(4, add(2, 2));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public void MyFirstTheory(int value)
        {
            Func<int, bool> isOdd = i => i % 2 == 1; 
            Assert.True(isOdd(value));
        }
    }
}
