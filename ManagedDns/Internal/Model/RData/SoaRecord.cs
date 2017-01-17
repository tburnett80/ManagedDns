using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class SoaRecord : IRData
    {
        internal readonly string MName;

        internal readonly string RName;

        internal readonly uint Serial;

        internal readonly uint Refresh;

        internal readonly uint Retry;

        internal readonly uint Expire;

        internal readonly uint Minimum;

        internal SoaRecord(string mname, string rname, uint serial, uint refresh, uint retry, uint expire, uint min)
        {
            MName = mname;
            RName = rname;
            Serial = serial;
            Refresh = refresh;
            Retry = retry;
            Expire = expire;
            Minimum = min;
        }

        public string DataAsString()
        {
            //TODO: impliment standard format
            throw new System.NotImplementedException();
        }
    }
}
