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
        internal static IRData FactoryRecord(RecordType type, IEnumerable<byte> rdata)
        {
            IByteParser parser = null;
            switch (type)
            {
                case RecordType.ARecord:
                    return new ARecord(new IPAddress(rdata.ToArray()));
                case RecordType.AaaaRecord:
                    return new AaaaRecord(new IPAddress(rdata.ToArray()));
                case RecordType.CNameRecord:
                    return new CNameRecord(new RawByteParser(rdata.ToArray(), 0).ReadLabels());
                case RecordType.MxRecord:
                    parser = new RawByteParser(rdata.ToArray(), 0);
                    return new MxRecord(parser.ReadUShort(), parser.ReadLabels());
                case RecordType.NsRecord:
                    return new NsRecord(new RawByteParser(rdata.ToArray(), 0).ReadLabels());
                case RecordType.PtrRecord:
                    return new PtrRecord(new RawByteParser(rdata.ToArray(), 0).ReadLabels());
                case RecordType.SoaRecord:
                    parser = new RawByteParser(rdata.ToArray(), 0);
                    return new SoaRecord(parser.ReadLabels(), parser.ReadLabels(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt(), parser.ReadUInt());
                case RecordType.TxtRecord:
                    return new TxtRecord(new RawByteParser(rdata.ToArray(), 0).ReadText());
                default:
                    throw new InvalidDataException($"Unsupoorted record type: {type}");
            }
        }
    }
}
