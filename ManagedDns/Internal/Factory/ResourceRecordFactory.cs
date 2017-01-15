using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;

namespace ManagedDns.Internal.Factory
{
    internal sealed class ResourceRecordFactory
    {
        internal static ResourceRecord FromParser(IByteParser parser)
        {
            var label = parser.ReadLabels();
            var type = parser.ReadUShort();
            var _class = parser.ReadUShort();
            var ttl = parser.ReadUInt();
            var rdlen = parser.ReadUShort();

            return new ResourceRecord(label, type, _class, ttl, rdlen, parser.GetRdata(rdlen));
        }
    }
}
