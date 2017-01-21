using System.Net;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class AaaaRecord
    {
        internal readonly IPAddress Address;

        internal AaaaRecord(IPAddress address)
        {
            Address = address;
        }
    }
}
