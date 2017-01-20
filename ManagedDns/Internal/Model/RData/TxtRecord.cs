
namespace ManagedDns.Internal.Model.RData
{
    internal sealed class TxtRecord
    {
        internal readonly string Text;

        internal TxtRecord(string text)
        {
            Text = text;
        }
    }
}
