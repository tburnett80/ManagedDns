
namespace ManagedDns.Internal.Model.RData
{
    internal sealed class CNameRecord
    {
        internal readonly string CName;

        internal CNameRecord(string name)
        {
            CName = name;
        }
    }
}
