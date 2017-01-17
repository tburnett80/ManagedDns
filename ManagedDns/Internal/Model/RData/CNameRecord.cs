using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class CNameRecord : IRData
    {
        internal readonly string CName;

        internal CNameRecord(string name)
        {
            CName = name;
        }

        public string DataAsString()
        {
            return CName;
        }
    }
}
