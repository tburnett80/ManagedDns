using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagedDns.Internal.Extensions
{
    /// <summary>
    /// Will convert little endian to big endian
    /// </summary>
    internal static class ToBigEndianExtensions
    {
        internal static IEnumerable<byte> ToBeBytes(this ushort value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        internal static IEnumerable<byte> ToBeBytes(this uint value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        internal static ushort ToBeUshort(this ushort value)
        {
            return BitConverter.ToUInt16(BitConverter.GetBytes(value).Reverse().ToArray(), 0);
        }
    }
}
