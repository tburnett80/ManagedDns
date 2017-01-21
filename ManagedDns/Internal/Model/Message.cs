using System.Collections.Generic;
using ManagedDns.Internal.Interfaces;
using System.Linq;

namespace ManagedDns.Internal.Model
{
    internal sealed class Message : IByteConverter
    {
        internal Message()
        {
            Questions = new List<Question>();
            Answers = new List<ResourceRecord>();
            Authorities = new List<ResourceRecord>();
            Additionals = new List<ResourceRecord>();
        }

        public Header Header { get; set; }

        public IEnumerable<Question> Questions { get; set; }

        public IEnumerable<ResourceRecord> Answers { get; set; }

        public IEnumerable<ResourceRecord> Authorities { get; set; }

        public IEnumerable<ResourceRecord> Additionals { get; set; }

        public IEnumerable<byte> ToBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Header.ToBytes());

            if (Questions != null && Questions.Any())
                bytes.AddRange(Questions.SelectMany(qu => qu.ToBytes()));

            if (Answers != null && Answers.Any())
                bytes.AddRange(Answers.SelectMany(ans => ans.ToBytes()));

            if (Authorities != null && Authorities.Any())
                bytes.AddRange(Authorities.SelectMany(auth => auth.ToBytes()));

            if (Additionals != null && Additionals.Any())
                bytes.AddRange(Additionals.SelectMany(ads => ads.ToBytes()));

            return bytes;
        }
    }
}
