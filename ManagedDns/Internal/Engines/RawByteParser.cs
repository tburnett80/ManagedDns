using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Engines
{
    /// <summary>
    /// Class will read structures sequentially from byte stream
    /// </summary>
    internal sealed class RawByteParser : IByteParser
    {
        #region Constructor and Private Members
        private readonly IList<byte> _rawMessage;

        internal RawByteParser(IList<byte> rawMessage, int pos = 12) //first 12 are header bytes
        {
            _rawMessage = rawMessage;
            Position = pos;
        }

        private byte NextByte()
        {
            var result = (byte)0;
            if (Position >= _rawMessage.Count)
                return result;

            result = _rawMessage.Skip(Position).FirstOrDefault();
            Position++;

            return result;
        }
        #endregion

        #region Methods

        [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
        public IList<byte> RawMessage => _rawMessage;

        public int Position { get; private set; }

        public string ReadLabels()
        {
            var sb = new StringBuilder();
            byte len;

            while ((len = NextByte()) != 0)
            {
                if ((len & 0xc0) == 0xc0) //Compression
                {
                    var subReader = new RawByteParser(_rawMessage, (len & 0x3f) | NextByte());
                    sb.Append(subReader.ReadLabels());
                    return sb.ToString();
                }

                for (var ndx = len; ndx > 0; --ndx)
                    sb.Append((char)NextByte());
                sb.Append('.');
            }

            return sb.ToString();
        }

        public string ReadText()
        {
            var len = NextByte();
            var sb = new StringBuilder();

            for (var ndx = 0; ndx < len; ++ndx)
                sb.Append((char)NextByte());

            return sb.ToString();
        }

        public ushort ReadUShort()
        {
            var result = _rawMessage.Skip(Position).Take(2).ToLeUShort();
            Position += 2;
            return result;
        }

        public uint ReadUInt()
        {
            var result = _rawMessage.Skip(Position).Take(4).ToLeUInt();
            Position += 4;
            return result;
        }

        public IEnumerable<byte> GetRdata(ushort len)
        {
            return _rawMessage.Skip(Position).Take(len);
        }

        public IEnumerable<byte> GetByteRange(int start, int length)
        {
            return _rawMessage.Skip(start).Take(length);
        }

        #endregion
    }
}
