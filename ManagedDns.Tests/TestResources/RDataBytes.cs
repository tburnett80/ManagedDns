using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagedDns.Tests.TestResources
{
    internal static class RDataBytes
    {
        internal static IEnumerable<byte> TxtRdata()
        {
            return new byte[] //v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all
                {
                    75, 118, 61, 115, 112, 102, 49, 32, 105, 110, 99, 108, 117, 100, 101, 58, 95, 115, 112,
                    102, 46, 103, 111, 111, 103, 108, 101, 46, 99, 111, 109, 32, 105, 112, 52, 58, 50, 49, 54, 46, 55, 51,
                    46, 57, 51, 46, 55, 48, 47, 51, 49, 32, 105, 112, 52, 58, 50, 49, 54, 46, 55, 51, 46, 57, 51, 46, 55, 50,
                    47, 51, 49, 32, 126, 97, 108, 108
                };
        }
    }
}
