
namespace ManagedDns.Public.Models.RData
{
    public class SoaRecord
    {
        public string MainNameServer { get; set; }

        public string AdministratorName { get; set; }

        public uint Serial { get; set; }

        public uint Refresh { get; set; }

        public uint Retry { get; set; }

        public uint Expire { get; set; }

        public uint MinimumZoneTtl { get; set; }
    }
}
