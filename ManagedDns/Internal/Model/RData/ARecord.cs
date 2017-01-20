using System.Net;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class ARecord
    {
        internal readonly IPAddress Address;

        internal ARecord(IPAddress address)
        {
            Address = address;
        }
    }
}
