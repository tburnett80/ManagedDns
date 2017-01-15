
using System.Collections.Generic;

namespace ManagedDns.Internal.Interfaces
{
    /// <summary>
    /// Will convert object into byte representation
    /// </summary>
    internal interface IByteConverter
    {
        IEnumerable<byte> ToBytes();
    }
}
