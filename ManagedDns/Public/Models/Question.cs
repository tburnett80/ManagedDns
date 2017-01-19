
namespace ManagedDns.Public.Models
{
    public class Question
    {
        public string QuestionName { get; set; }

        public RecordType QuestionType { get; set; }

        public RecordClass QuestionClass { get; set; }
    }
}
