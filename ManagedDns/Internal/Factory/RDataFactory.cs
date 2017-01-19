using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Linq;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Extensions;
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

        internal static object FactoryRecordModel(RecordType type, IEnumerable<byte> data)
        {
            var parser = new RawByteParser(data.ToArray(), 0);
            switch (type)
            {
                case RecordType.ARecord:
                    return new ARecord(new IPAddress(new[] { parser.NextByte(), parser.NextByte(), parser.NextByte(), parser.NextByte() })).Convert();
                case RecordType.AaaaRecord:
                    return new AaaaRecord(new IPAddress(parser.GetRdata(16).ToArray())).Convert();
                case RecordType.CNameRecord:
                    return new CNameRecord(parser.ReadLabels()).Convert();
                case RecordType.MxRecord:
                    return new MxRecord(parser.ReadUShort(), parser.ReadLabels()).Convert();
                case RecordType.NsRecord:
                    return new NsRecord(parser.ReadLabels()).Convert();
                case RecordType.PtrRecord:
                    return new PtrRecord(parser.ReadLabels()).Convert();
                case RecordType.SoaRecord:
                    return new SoaRecord(parser.ReadLabels(), parser.ReadLabels(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt()).Convert();
                case RecordType.TxtRecord:
                    return new TxtRecord(parser.ReadText()).Convert();
                default:
                    throw new InvalidDataException($"Unsupoorted record type: {type}");
            }
        }
    }
}
