using System;

namespace ManagedDns.Public.Models
{
    public class ResourceRecord
    {
        public string Name { get; set; }

        public RecordType Type { get; set; }

        public RecordClass Class { get; set; }

        public uint Ttl { get; set; }

        public object Record { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
    }
}
