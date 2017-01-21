using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;
using ManagedDns.Public;

namespace ManagedDns.Internal.Factory
{
    internal sealed class QuestionFactory
    {
        internal static Question FromParser(IByteParser parser)
        {
            return new Question(parser.ReadLabels(), parser.ReadUShort(), parser.ReadUShort());
        }

        internal static Question FactoryQuestion(RecordType rtype, string name = null, RecordClass rclass = RecordClass.In)
        {
            if (!string.IsNullOrEmpty(name) && !name.Substring(name.Length - 1).Equals("."))
                name = $"{name}.";

            return new Question(name, (ushort)rtype, (ushort)rclass);
        }
    }
}
