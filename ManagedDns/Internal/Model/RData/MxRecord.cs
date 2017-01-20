
namespace ManagedDns.Internal.Model.RData
{
    internal sealed class MxRecord
    {
        internal readonly ushort Preference;

        internal readonly string Exchanger;

        internal MxRecord(ushort preference, string exchange)
        {
            Preference = preference;
            Exchanger = exchange;
        }
    }
}
