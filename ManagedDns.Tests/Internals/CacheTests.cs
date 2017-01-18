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

        [Fact]
        public void ParseTest()
        {
            var response = new byte[]
                               {
                                    41, 163, 133, 0, 0, 1, 0, 3, 0, 7, 0, 7, //Header
                                    5, 121, 97, 104, 111, 111, 3, 99, 111, 109, 0, 0, 15, 0, 1, //Question

                                    192, 12, 0, 15, 0, 1, 0, 0, 7, 8, 0, 25, 0, 1, 4, 109, 116, 97, 55,
                                    3, 97, 109, 48, 8, 121, 97, 104, 111, 111, 100, 110, 115, 3, 110,
                                    101, 116, 0, 192, 12, 0, 15, 0, 1, 0, 0, 7, 8, 0, 9,
                                    0, 1, 4, 109, 116, 97, 54, 192, 46, 192, 12, 0, 15, 0, 1,
                                    0, 0, 7, 8, 0, 9, 0, 1, 4, 109, 116, 97, 53, 192, 46,
                                    192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115,
                                    50, 192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6,
                                    3, 110, 115, 51, 192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163,
                                    0, 0, 6, 3, 110, 115, 52, 192, 12, 192, 12, 0, 2, 0, 1,
                                    0, 2, 163, 0, 0, 6, 3, 110, 115, 49, 192, 12, 192, 12, 0,
                                    2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 54, 192, 12,
                                    192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115,
                                    53, 192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6,
                                    3, 110, 115, 56, 192, 12, 192, 172, 0, 1, 0, 1, 0, 18, 117,
                                    0, 0, 4, 68, 180, 131, 16, 192, 118, 0, 1, 0, 1, 0, 18,
                                    117, 0, 0, 4, 68, 142, 255, 16, 192, 136, 0, 1, 0, 1, 0,
                                    18, 117, 0, 0, 4, 203, 84, 221, 53, 192, 154, 0, 1, 0, 1,
                                    0, 18, 117, 0, 0, 4, 98, 138, 11, 157, 192, 208, 0, 1, 0,
                                    1, 0, 18, 117, 0, 0, 4, 119, 160, 247, 124, 192, 190, 0, 1,
                                    0, 1, 0, 2, 163, 0, 0, 4, 202, 43, 223, 170, 192, 226, 0,
                                    1, 0, 1, 0, 2, 163, 0, 0, 4, 202, 165, 104, 22
                               };

            //Aa = true,
            //AnCount = 3,   
            //ArCount = 7,
            //Id = 10659,
            //NsCount = 7,
            //OpCode = OpCode.Query,
            //QdCount = 1,
            //Qr = Qr.Response,
            //Ra = false,
            //RCode = ResponseCode.NoError,
            //Rd = true,
            //Tc = false,
            //Z = 0,

            //var msg = MessageFactory.FromParser(new RawByteParser(response));

            var parser = new RawByteParser(response);
            QuestionFactory.FromParser(parser);

            var rr1 = ResourceRecordFactory.FromParser(parser);
            var rr2 = ResourceRecordFactory.FromParser(parser);
            var rr3 = ResourceRecordFactory.FromParser(parser);


            Assert.NotNull(parser);
        }
    }
}
