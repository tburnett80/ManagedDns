using System;
using System.Collections.Generic;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Public;

namespace ManagedDns.Internal.Model
{
    internal sealed class ResourceRecord : IByteConverter
    {
        public string Name { get; set; }

        public RecordType Type { get; set; }

        public RecordClass Class { get; set; }

        public uint Ttl { get; set; }

        public ushort RdLength { get; set; }

        public IEnumerable<byte> Rdata { get; set; }

        public IRData Record { get; set; }

        public DateTimeOffset TimeStamp { get; private set; }

        internal ResourceRecord() { TimeStamp = DateTimeOffset.UtcNow; }

        internal ResourceRecord(string name, ushort rtype, ushort rclass, uint ttl, ushort rdlen, IEnumerable<byte> rawRdata, IRData rdata)
        {
            TimeStamp = DateTimeOffset.UtcNow;
            Name = name;
            Type = (RecordType) rtype;
            Class = (RecordClass) rclass;
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
