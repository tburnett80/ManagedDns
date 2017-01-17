using System.Net;
using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class ARecord : IRData
    {
        internal readonly IPAddress Address;

        internal ARecord(IPAddress address)
        {
            Address = address;
        }

        public string DataAsString()
        {
            return Address.ToString();
        }
    }
}
