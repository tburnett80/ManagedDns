using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Linq;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model.RData;
using ManagedDns.Public;

namespace ManagedDns.Internal.Factory
{
    internal sealed class RDataFactory
    {
        [SuppressMessage("ReSharper", "SwitchStatementMissingSomeCases")]
        internal static IRData FactoryRecord(RecordType type, IByteParser parser)
        {
            switch (type)
            {
                case RecordType.ARecord:
                    return new ARecord(new IPAddress(new [] { parser.NextByte(), parser.NextByte(), parser.NextByte(), parser.NextByte() }));
                case RecordType.AaaaRecord:
                    return new AaaaRecord(new IPAddress(parser.GetRdata(16).ToArray()));
                case RecordType.CNameRecord:
                    return new CNameRecord(parser.ReadLabels());
                case RecordType.MxRecord:
                    return new MxRecord(parser.ReadUShort(), parser.ReadLabels());
                case RecordType.NsRecord:
                    return new NsRecord(parser.ReadLabels());
                case RecordType.PtrRecord:
                    return new PtrRecord(parser.ReadLabels());
                case RecordType.SoaRecord:
                    return new SoaRecord(parser.ReadLabels(), parser.ReadLabels(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt());
                case RecordType.TxtRecord:
                    return new TxtRecord(parser.ReadText());
                default:
                    throw new InvalidDataException($"Unsupoorted record type: {type}");
            }
        }
    }
}
