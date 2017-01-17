using System.Collections.Generic;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Public;

namespace ManagedDns.Internal.Model
{
    internal sealed class Question : IByteConverter
    {
        public string QName { get; set; }

        public RecordType QType { get; set; }

        public RecordClass QClass { get; set; }

        internal Question() { }

        internal Question(string qname, ushort qtype, ushort qclass)
        {
            QName = qname;
            QType = (RecordType) qtype;
            QClass = (RecordClass) qclass;
        }

        public IEnumerable<byte> ToBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(QName.ToLabelBytes());
            bytes.AddRange(((ushort)QType).ToBeBytes());
            bytes.AddRange(((ushort)QClass).ToBeBytes());

            return bytes;
        }

        public override string ToString()
        {
            return $"{QName.ToLower()}-{QClass}-{QType}";
        }
    }
}

/*
4.1.2. Question section format

The question section is used to carry the "question" in most queries,
i.e., the parameters that define what is being asked.  The section
contains QDCOUNT (usually 1) entries, each of the following format:

                                    1  1  1  1  1  1
      0  1  2  3  4  5  6  7  8  9  0  1  2  3  4  5
    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    |                                               |
    /                     QNAME                     /
    /                                               /
    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    |                     QTYPE                     |
    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    |                     QCLASS                    |
    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

where:

QNAME           a domain name represented as a sequence of labels, where
                each label consists of a length octet followed by that
                number of octets.  The domain name terminates with the
                zero length octet for the null label of the root.  Note
                that this field may be an odd number of octets; no
                padding is used.

QTYPE           a two octet code which specifies the type of the query.
                The values for this field include all codes valid for a
                TYPE field, together with some more general codes which
                can match more than one type of RR.

QCLASS          a two octet code that specifies the class of the query.
                For example, the QCLASS field is IN for the Internet.
*/
