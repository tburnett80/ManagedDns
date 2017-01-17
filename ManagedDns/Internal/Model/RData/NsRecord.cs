using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Model.RData
{
    internal class NsRecord : IRData
    {
        internal readonly string NsDomainName;

        internal NsRecord(string ns)
        {
            NsDomainName = ns;
        }

        public string DataAsString()
        {
            return NsDomainName;
        }
    }
}
