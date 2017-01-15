using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagedDns.Tests.TestResources
{
    internal static class DnsResponses
    {
        internal static IList<byte> GoogleTxtResponse()
        {
            return new byte[]
                           {
                                105, 71, 133, 0, 0, 1, 0, 1, 0, 0, 0, 0, 6, 103, 111, 111,
                                103, 108, 101, 3, 99, 111, 109, 0, 0, 16, 0, 1, 192, 12, 0,
                                16, 0, 1, 0, 0, 14, 16, 0, 76, 75, 118, 61, 115, 112, 102,
                                49, 32, 105, 110, 99, 108, 117, 100, 101, 58, 95, 115, 112, 102, 46,
                                103, 111, 111, 103, 108, 101, 46, 99, 111, 109, 32, 105, 112, 52, 58,
                                50, 49, 54, 46, 55, 51, 46, 57, 51, 46, 55, 48, 47, 51, 49,
                                32, 105, 112, 52, 58, 50, 49, 54, 46, 55, 51, 46, 57, 51, 46,
                                55, 50, 47, 51, 49, 32, 126, 97, 108, 108
                           };
            //Header details:         //Single Question details:            //Single Answer
            //  Id = 26951                  //  QName = google.com.             //  Class = IN
            //  AnCount = 1                 //  QType = TxtRecord               //  Name = google.com.
            //  ArCount = 0                 //  QClass - IN                     //  RdLength = 76
            //  NsCount = 0                                                     //  Ttl = 3600
            //  OpCode = Query                                                  //  Type = TxtRecord
            //  Qr = Response
            //  RCode = NoError
            //  Aa = true
            //  Ra = false
            //  Rd = true
            //  Tc = false
            //  Z = 0

        }
    }
}
