using System.Collections.Generic;

namespace ManagedDns.Internal.Interfaces
{
    internal interface IByteParser
    {
        IList<byte> RawMessage { get; }

        int Position { get; }

        string ReadLabels();

        string ReadText();

        ushort ReadUShort();

        uint ReadUInt();

        IEnumerable<byte> GetRdata(ushort len);

        IEnumerable<byte> GetByteRange(int start, int length);
    }
}
