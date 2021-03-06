﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ManagedDns.Tests.TestResources
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class DnsResponses
    {
        internal static IList<byte> AAAA()
        {
            return new byte[]
            {
                240, 219, 133, 0, 0, 1, 0, 1, 0, 0, 0, 0, 6, 103, 111, 111,
                103, 108, 101, 3, 99, 111, 109, 0, 0, 28, 0, 1, 192, 12, 0,
                28, 0, 1, 0, 0, 1, 44, 0, 16, 38, 7, 248, 176, 64, 9,
                8, 0, 0, 0, 0, 0, 0, 0, 16, 6
            };
        }

        internal static IList<byte> A()
        {
            return new byte[]
            {
                215, 61, 133, 0, 0, 1, 0, 3, 0, 7, 0, 7, 5, 121, 97, 104,
                111, 111, 3, 99, 111, 109, 0, 0, 1, 0, 1, 192, 12, 0, 1,
                0, 1, 0, 0, 7, 8, 0, 4, 206, 190, 36, 45, 192, 12, 0,
                1, 0, 1, 0, 0, 7, 8, 0, 4, 98, 139, 183, 24, 192, 12,
                0, 1, 0, 1, 0, 0, 7, 8, 0, 4, 98, 138, 253, 109, 192,
                12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 49,
                192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3,
                110, 115, 53, 192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163, 0,
                0, 6, 3, 110, 115, 54, 192, 12, 192, 12, 0, 2, 0, 1, 0,
                2, 163, 0, 0, 6, 3, 110, 115, 51, 192, 12, 192, 12, 0, 2,
                0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 50, 192, 12, 192,
                12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 52,
                192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3,
                110, 115, 56, 192, 12, 192, 87, 0, 1, 0, 1, 0, 18, 117, 0,
                0, 4, 68, 180, 131, 16, 192, 159, 0, 1, 0, 1, 0, 18, 117,
                0, 0, 4, 68, 142, 255, 16, 192, 141, 0, 1, 0, 1, 0, 18,
                117, 0, 0, 4, 203, 84, 221, 53, 192, 177, 0, 1, 0, 1, 0,
                18, 117, 0, 0, 4, 98, 138, 11, 157, 192, 105, 0, 1, 0, 1,
                0, 18, 117, 0, 0, 4, 119, 160, 247, 124, 192, 123, 0, 1, 0,
                1, 0, 2, 163, 0, 0, 4, 202, 43, 223, 170, 192, 195, 0, 1,
                0, 1, 0, 2, 163, 0, 0, 4, 202, 165, 104, 22
            };
        }

        internal static IList<byte> CName()
        {
            return new byte[]
            {
                138, 14, 133, 0, 0, 1, 0, 1, 0, 7, 0, 7, 3, 119, 119, 119,
                5, 121, 97, 104, 111, 111, 3, 99, 111, 109, 0, 0, 5, 0, 1,
                192, 12, 0, 5, 0, 1, 0, 0, 1, 44, 0, 15, 6, 102, 100,
                45, 102, 112, 51, 3, 119, 103, 49, 1, 98, 192, 16, 192, 16, 0,
                2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 51, 192, 16,
                192, 16, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115,
                54, 192, 16, 192, 16, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6,
                3, 110, 115, 50, 192, 16, 192, 16, 0, 2, 0, 1, 0, 2, 163,
                0, 0, 6, 3, 110, 115, 56, 192, 16, 192, 16, 0, 2, 0, 1,
                0, 2, 163, 0, 0, 6, 3, 110, 115, 53, 192, 16, 192, 16, 0,
                2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 49, 192, 16,
                192, 16, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115,
                52, 192, 16, 192, 160, 0, 1, 0, 1, 0, 18, 117, 0, 0, 4,
                68, 180, 131, 16, 192, 106, 0, 1, 0, 1, 0, 18, 117, 0, 0,
                4, 68, 142, 255, 16, 192, 70, 0, 1, 0, 1, 0, 18, 117, 0,
                0, 4, 203, 84, 221, 53, 192, 178, 0, 1, 0, 1, 0, 18, 117,
                0, 0, 4, 98, 138, 11, 157, 192, 142, 0, 1, 0, 1, 0, 18,
                117, 0, 0, 4, 119, 160, 247, 124, 192, 88, 0, 1, 0, 1, 0,
                2, 163, 0, 0, 4, 202, 43, 223, 170, 192, 124, 0, 1, 0, 1,
                0, 2, 163, 0, 0, 4, 202, 165, 104, 22
            };
        }

        internal static IList<byte> MX()
        {
            return new byte[]
            {
                41, 163, 133, 0, 0, 1, 0, 3, 0, 7, 0, 7, 5, 121, 97, 104,
                111, 111, 3, 99, 111, 109, 0, 0, 15, 0, 1, 192, 12, 0, 15,
                0, 1, 0, 0, 7, 8, 0, 25, 0, 1, 4, 109, 116, 97, 55,
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
        }

        internal static IList<byte> NS()
        {
            return new byte[]
            {
                105, 69, 133, 0, 0, 1, 0, 7, 0, 0, 0, 7, 5, 121, 97, 104,
                111, 111, 3, 99, 111, 109, 0, 0, 2, 0, 1, 192, 12, 0, 2,
                0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 53, 192, 12, 192,
                12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 49,
                192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3,
                110, 115, 52, 192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163, 0,
                0, 6, 3, 110, 115, 56, 192, 12, 192, 12, 0, 2, 0, 1, 0,
                2, 163, 0, 0, 6, 3, 110, 115, 50, 192, 12, 192, 12, 0, 2,
                0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 54, 192, 12, 192,
                12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 51,
                192, 12, 192, 57, 0, 1, 0, 1, 0, 18, 117, 0, 0, 4, 68,
                180, 131, 16, 192, 111, 0, 1, 0, 1, 0, 18, 117, 0, 0, 4,
                68, 142, 255, 16, 192, 147, 0, 1, 0, 1, 0, 18, 117, 0, 0,
                4, 203, 84, 221, 53, 192, 75, 0, 1, 0, 1, 0, 18, 117, 0,
                0, 4, 98, 138, 11, 157, 192, 39, 0, 1, 0, 1, 0, 18, 117,
                0, 0, 4, 119, 160, 247, 124, 192, 129, 0, 1, 0, 1, 0, 2,
                163, 0, 0, 4, 202, 43, 223, 170, 192, 93, 0, 1, 0, 1, 0,
                2, 163, 0, 0, 4, 202, 165, 104, 22
            };
        }

        internal static IList<byte> PTR()
        {
            return new byte[]
            {
                240, 220, 133, 0, 0, 1, 0, 1, 0, 0, 0, 0, 2, 53, 51, 3,
                49, 49, 53, 3, 49, 57, 52, 3, 49, 55, 51, 7, 105, 110, 45,
                97, 100, 100, 114, 4, 97, 114, 112, 97, 0, 0, 12, 0, 1, 192,
                12, 0, 12, 0, 1, 0, 1, 81, 128, 0, 27, 15, 100, 102, 119,
                48, 54, 115, 52, 48, 45, 105, 110, 45, 102, 50, 49, 5, 49, 101,
                49, 48, 48, 3, 110, 101, 116, 0
            };
        }

        internal static IList<byte> SOA()
        {
            return new byte[]
            {
                105, 70, 133, 0, 0, 1, 0, 1, 0, 7, 0, 7, 5, 121, 97, 104,
                111, 111, 3, 99, 111, 109, 0, 0, 6, 0, 1, 192, 12, 0, 6,
                0, 1, 0, 0, 7, 8, 0, 49, 3, 110, 115, 49, 192, 12, 10,
                104, 111, 115, 116, 109, 97, 115, 116, 101, 114, 9, 121, 97, 104, 111,
                111, 45, 105, 110, 99, 192, 18, 120, 11, 95, 66, 0, 0, 14, 16,
                0, 0, 1, 44, 0, 27, 175, 128, 0, 0, 2, 88, 192, 12, 0,
                2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 52, 192, 12,
                192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115,
                51, 192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 6,
                3, 110, 115, 50, 192, 12, 192, 12, 0, 2, 0, 1, 0, 2, 163,
                0, 0, 6, 3, 110, 115, 53, 192, 12, 192, 12, 0, 2, 0, 1,
                0, 2, 163, 0, 0, 6, 3, 110, 115, 56, 192, 12, 192, 12, 0,
                2, 0, 1, 0, 2, 163, 0, 0, 6, 3, 110, 115, 54, 192, 12,
                192, 12, 0, 2, 0, 1, 0, 2, 163, 0, 0, 2, 192, 39, 192,
                39, 0, 1, 0, 1, 0, 18, 117, 0, 0, 4, 68, 180, 131, 16,
                192, 136, 0, 1, 0, 1, 0, 18, 117, 0, 0, 4, 68, 142, 255,
                16, 192, 118, 0, 1, 0, 1, 0, 18, 117, 0, 0, 4, 203, 84,
                221, 53, 192, 100, 0, 1, 0, 1, 0, 18, 117, 0, 0, 4, 98,
                138, 11, 157, 192, 154, 0, 1, 0, 1, 0, 18, 117, 0, 0, 4,
                119, 160, 247, 124, 192, 190, 0, 1, 0, 1, 0, 2, 163, 0, 0,
                4, 202, 43, 223, 170, 192, 172, 0, 1, 0, 1, 0, 2, 163, 0,
                0, 4, 202, 165, 104, 22
            };
        }

        internal static IList<byte> TXT()
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
            //  Qr = Response                                                   //  Text = v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all
            //  RCode = NoError
            //  Aa = true
            //  Ra = false
            //  Rd = true
            //  Tc = false
            //  Z = 0

        }
    }
}