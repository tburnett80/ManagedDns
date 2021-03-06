﻿using System.Diagnostics.CodeAnalysis;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;
using ManagedDns.Public;

namespace ManagedDns.Internal.Factory
{
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    internal sealed class ResourceRecordFactory
    {
        internal static ResourceRecord FromParser(IByteParser parser)
        {
            if (parser == null)
                return new ResourceRecord();

            var label = parser.ReadLabels();
            var type = parser.ReadUShort();
            var _class = parser.ReadUShort();
            var ttl = parser.ReadUInt();
            var rdlen = parser.ReadUShort();
            var rdata = parser.GetRdata(rdlen);

            return new ResourceRecord(label, type, _class, ttl, rdlen, rdata, RDataFactory.FactoryRecord((RecordType)type, parser));
        }
    }
}
