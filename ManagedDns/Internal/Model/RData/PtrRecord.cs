using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class PtrRecord : IRData
    {
        internal readonly string DomainName;

        internal PtrRecord(string domain)
        {
            DomainName = domain;
        }

        public string DataAsString()
        {
            return DomainName;
        }
    }
}
