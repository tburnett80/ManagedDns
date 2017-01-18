using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;
using ManagedDns.Public;

namespace ManagedDns.Internal.Factory
{
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    internal sealed class HeaderFactory
    {
        private enum HeaderBytePosition
        {
            Id = 0,
            Flags = 2,
            QdCount = 4,
            AnCount = 6,
            NsCount = 8,
            ArCount = 10,
        }

        internal static Header FromBytes(IEnumerable<byte> bytes)
        {
            if (bytes == null || bytes.Count() < 6)
                return new Header();

            var bits = Convert.ToString(bytes.Skip((int)HeaderBytePosition.Flags).Take(2).ToLeUShort(), 2).PadLeft(16, '0');

            return new Header(
                    bytes.Skip((int)HeaderBytePosition.Id).Take(2).ToLeUShort(), //id
                    Convert.ToInt32(bits.Substring(0, 1), 2), //Qr
                    Convert.ToInt32(bits.Substring(1, 4), 2), //OpCode
                    Convert.ToInt32(bits.Substring(5, 1), 2) == 1, //Aa
                    Convert.ToInt32(bits.Substring(6, 1), 2) == 1, //Tc
                    Convert.ToInt32(bits.Substring(7, 1), 2) == 1, //Rd
                    Convert.ToInt32(bits.Substring(8, 1), 2) == 1, //Ra
                    (ushort)Convert.ToInt32(bits.Substring(9, 3), 2),//Z
                    Convert.ToInt32(bits.Substring(12, 4), 2), //RCode
                    bytes.Skip((int)HeaderBytePosition.QdCount).Take(2).ToLeUShort(), //qdcount
                    bytes.Skip((int)HeaderBytePosition.AnCount).Take(2).ToLeUShort(), //ancount
                    bytes.Skip((int)HeaderBytePosition.NsCount).Take(2).ToLeUShort(), //nscount
                    bytes.Skip((int)HeaderBytePosition.ArCount).Take(2).ToLeUShort()  //arcount
                );
        }
        
        internal static Header FromParser(IByteParser parser)
        {
            if(parser == null)
                throw new NullReferenceException("Cannot parse header from null parser reference. Error 301");

            if(parser.RawMessage == null || parser.RawMessage.Count < 12)
                return new Header();

            return FromBytes(parser.GetByteRange(0, 12));
        }

        internal static Header ForQuery(bool recrusion = false)
        {
            return new Header(
                    (ushort) new Random().Next(),
                    0, (int)OpCode.Query,
                    false, false, recrusion, false, 0,0,1,0,0,0
                );
        }
    }
}
