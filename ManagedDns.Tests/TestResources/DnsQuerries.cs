using System.Collections.Generic;

namespace ManagedDns.Tests.TestResources
{
    /// <summary>
    /// Reusable dns queries for unit test data
    /// </summary>
    internal static class DnsQuerries
    {
        internal static IList<byte> GetYahooMxQuery()
        {
            return new byte[] { 41, 163, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 121, 97, 104, 111, 111, 3, 99, 111, 109, 0, 0, 15, 0, 1 };
            //Header details:           Single Question details:
            //  Id = 10659                  //  QName = yahoo.com.
            //  AnCount = 0                 //  QType = MxRecord
            //  ArCount = 0                 //  QClass - IN
            //  NsCount = 0
            //  OpCode = Query
            //  Qr = Query
            //  RCode = NoError
            //  Aa = false
            //  Ra = false
            //  Rd = true
            //  Tc = false
            //  Z = 0
        }
    }
}