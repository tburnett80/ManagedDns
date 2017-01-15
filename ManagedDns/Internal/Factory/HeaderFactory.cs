using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;

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

            var bits = bytes.Skip((int)HeaderBytePosition.Flags).Take(2).ToLeUShort();

            return new Header(
                    bytes.Skip((int)HeaderBytePosition.Id).Take(2).ToLeUShort(), //id
                    (bits >> (int)Header.HeaderBitPosition.Qr) & 1, //qr
                    (bits >> (int)Header.HeaderBitPosition.OpCode) & 15, //op code
                    ((bits >> (int)Header.HeaderBitPosition.Aa) & 1) == 1, //aa
                    ((bits >> (int)Header.HeaderBitPosition.Tc) & 1) == 1, //tc
                    ((bits >> (int)Header.HeaderBitPosition.Rd) & 1) == 1, //rd
                    ((bits >> (int)Header.HeaderBitPosition.Ra) & 1) == 1, //ra
                    (ushort)((bits >> (int)Header.HeaderBitPosition.Z) & 7), //z
                    (bits >> (int)Header.HeaderBitPosition.RCode) & 15, //rcode
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
    }
}
