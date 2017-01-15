using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagedDns.Internal.Extensions
{
    /// <summary>
    /// Will convert Big Endian to Little Endian
    /// </summary>
    internal static class ToLittleEndianExtensions
    {
        internal static ushort ToLeUShort(this IEnumerable<byte> value)
        {
            return BitConverter.ToUInt16(value.Reverse().ToArray(), 0);
        }

        internal static uint ToLeUInt(this IEnumerable<byte> value)
        {
            return BitConverter.ToUInt32(value.Reverse().ToArray(), 0);
        }
    }
}
