using System;
using System.Collections.Generic;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Public;

namespace ManagedDns.Internal.Model
{
    internal sealed class ResourceRecord : IByteConverter
    {
        internal readonly string Name;

        internal readonly RecordType Type;

        internal readonly RecordClass Class;

        internal readonly uint Ttl;

        internal readonly ushort RdLength;

        internal readonly IEnumerable<byte> Rdata;

        internal readonly object Record;

        internal readonly DateTimeOffset TimeStamp;

        internal ResourceRecord() { TimeStamp = DateTimeOffset.UtcNow; }

        internal ResourceRecord(string name, ushort rtype, ushort rclass, uint ttl, ushort rdlen, IEnumerable<byte> rawRdata, object rdata)
        {
            TimeStamp = DateTimeOffset.UtcNow;
            Name = name;
            Type = (RecordType)rtype;
            Class = (RecordClass)rclass;
            Ttl = ttl;
            RdLength = rdlen;
            Rdata = rawRdata;
            Record = rdata;
        }

        public IEnumerable<byte> ToBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(Name.ToLabelBytes());
            bytes.AddRange(((ushort)Type).ToBeBytes());
            bytes.AddRange(((ushort)Class).ToBeBytes());
            bytes.AddRange(Ttl.ToBeBytes());
            bytes.AddRange(RdLength.ToBeBytes());
            bytes.AddRange(Rdata);

            return bytes;
        }
    }
}
