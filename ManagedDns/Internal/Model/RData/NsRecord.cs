
namespace ManagedDns.Internal.Model.RData
{
    internal sealed class NsRecord
    {
        internal readonly string NsDomainName;

        internal NsRecord(string ns)
        {
            NsDomainName = ns;
        }
    }
}
