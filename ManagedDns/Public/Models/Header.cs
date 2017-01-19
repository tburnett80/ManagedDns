
namespace ManagedDns.Public.Models
{
    public class Header
    {
        public ushort Id { get; set; }

        public Qr QueryOrResponse { get; set; }

        public OpCode OperationCode { get; set; }

        public bool AuthoratiativeAnswer { get; set; }

        public bool Truncated { get; set; }

        public bool RecursionDesired { get; set; }

        public bool RecursionAvailable { get; set; }

        public ushort Z { get; set; }

        public ResponseCode ResponseCode { get; set; }

        public ushort QuestionCount { get; set; }

        public ushort AnswerCount { get; set; }

        public ushort NameServerCount { get; set; }

        public ushort AdditionalReccordCount { get; set; }
    }
}
