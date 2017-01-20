using System.Collections.Generic;

namespace ManagedDns.Public.Models
{
    public class Message
    {
        public Message()
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
    }
}
