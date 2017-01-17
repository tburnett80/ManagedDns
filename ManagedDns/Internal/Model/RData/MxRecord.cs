

using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class MxRecord : IRData
    {
        internal readonly ushort Preference;

        internal readonly string Exchanger;

        internal MxRecord(ushort preference, string exchange)
        {
            Preference = preference;
            Exchanger = exchange;
        }

        public string DataAsString()
        {
            return $"{Preference} - {Exchanger}";
        }
    }
}
