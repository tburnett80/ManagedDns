using System.Net;
using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class AaaaRecord : IRData
    {
        internal readonly IPAddress Address;

        internal AaaaRecord(IPAddress address)
        {
            Address = address;
        }

        public string DataAsString()
        {
            return Address.ToString();
        }
    }
}
