using System.Linq;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Factory;
using ManagedDns.Public;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals.FactoryTests
{
    public class QuestionFactoryTests
    {
        [Fact]
        public void CreateQuestionTest()
        {
            var question = QuestionFactory.FactoryQuestion("test", RecordType.ARecord, RecordClass.Hs);

            Assert.Equal("test", question.QName);
            Assert.Equal(RecordType.ARecord, question.QType);
            Assert.Equal(RecordClass.Hs, question.QClass);
        }

        [Fact]
        public void ParseQuestionTest()
        {
            var question = QuestionFactory.FromParser(new RawByteParser(DnsQuerries.GetYahooMxQuery()));

            Assert.Equal("yahoo.com.", question.QName);
            Assert.Equal(RecordType.MxRecord, question.QType);
            Assert.Equal(RecordClass.In, question.QClass);
        }
    }
}
