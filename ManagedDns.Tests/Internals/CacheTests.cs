using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ManagedDns.Internal;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Factory;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals
{
    public class CacheTests
    {
        [Fact]
        public void CacheResponseAddTest()
        {
            var msg = MessageFactory.FromParser(new RawByteParser(DnsResponses.TXT()));

            //Add message to cache
            var added = QueryCache.AddCache(msg);
            Assert.Equal(true, added);

            //Try to re-add but fail because its already in cache`
            var readded = QueryCache.AddCache(msg);
            Assert.Equal(false, readded);
        }

        [Fact]
        public void CacheResponseRetriveTest()
        {
            var msg = MessageFactory.FromParser(new RawByteParser(DnsResponses.NS()));

            //Add message to cache
            var added = QueryCache.AddCache(msg);
            Assert.Equal(true, added);

            //Should be same object
            var fromCache = QueryCache.CheckCache(msg.Questions.FirstOrDefault());
            Assert.NotNull(fromCache);
            Assert.Equal(msg.Answers.FirstOrDefault().Name, fromCache.Answers.FirstOrDefault().Name);
        }
    }
}
