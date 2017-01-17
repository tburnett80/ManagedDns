using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ManagedDns.Tests.TestResources
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
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

        internal static IEnumerable<byte> AaaaRdata()
        {
            //"2607:f8b0:4009:800::1006"
            return new byte[] { 38, 7, 248, 176, 64, 9, 8, 0, 0, 0, 0, 0, 0, 0, 16, 6 };
        }

        internal static IEnumerable<byte> ARData()
        {
            //206.190.36.45
            return new byte[] { 206, 190, 36, 45 };
        }

        internal static IEnumerable<byte> CNameRData()
        {
            //fd-fp3.wg1.b.
            return new byte[] { 6, 102, 100, 45, 102, 112, 51, 3, 119, 103, 49, 1, 98, 192, 16 };
        }

        internal static IEnumerable<byte> MxRData()
        {
            //"1 - mta7.am0.yahoodns.net."
            return new byte[] { 0, 1, 4, 109, 116, 97, 55, 3, 97, 109, 48, 8, 121, 97, 104, 111, 111, 100, 110, 115, 3, 110, 101, 116, 0 };
        }

        internal static IEnumerable<byte> NsRData()
        {
            //"ns5."
            return new byte[] { 3, 110, 115, 53, 192, 12 };
        }

        internal static IEnumerable<byte> PtrRData()
        {
            //"dfw06s40-in-f21.1e100.net."
            return new byte[] { 15, 100, 102, 119, 48, 54, 115, 52, 48, 45, 105, 110, 45, 102, 50, 49, 5, 49, 101, 49, 48, 48, 3, 110, 101, 116, 0 };
        }
    }
}
