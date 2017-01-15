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

        internal static Question FactoryQuestion(string name, RecordType rtype, RecordClass rclass = RecordClass.In)
        {
            return new Question(name, (ushort)rtype, (ushort)rclass);
        }
    }
}
