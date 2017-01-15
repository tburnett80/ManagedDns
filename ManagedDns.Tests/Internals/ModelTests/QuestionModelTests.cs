using ManagedDns.Internal.Model;
using ManagedDns.Public;
using Xunit;

namespace ManagedDns.Tests.Internals.ModelTests
{
    /// <summary>
    /// Test internal model construction
    /// </summary>
    public class QuestionModelTests
    {
        [Fact]
        public void ConstructQuestion()
        {
            var question = new Question("Test", 28, 1);

            Assert.Equal("Test", question.QName);
            Assert.Equal(RecordClass.In, question.QClass);
            Assert.Equal(RecordType.AaaaRecord, question.QType);
        }

        [Fact]
        public void ConstructQuestionDefault()
        { 
            var question = new Question();

            Assert.Equal(null, question.QName);
            Assert.Equal(RecordClass.Unknown, question.QClass);
            Assert.Equal(RecordType.Unknown, question.QType);
        }

        [Fact]
        public void QuestionToBytesTest()
        { 
            var question = new Question("cccg-inc.com.", 15, 1);
            Assert.Equal(new byte[] { 8, 99, 99, 99, 103, 45, 105, 110, 99, 3, 99, 111, 109, 0, 0, 15, 0, 1 }, question.ToBytes());
        }
    }
}
