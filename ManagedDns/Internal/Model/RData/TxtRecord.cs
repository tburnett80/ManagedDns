using ManagedDns.Internal.Interfaces;

namespace ManagedDns.Internal.Model.RData
{
    internal sealed class TxtRecord : IRData
    {
        internal readonly string Text;

        internal TxtRecord(string text)
        {
            Text = text;
        }

        public string DataAsString()
        {
            return Text;
        }
    }
}
