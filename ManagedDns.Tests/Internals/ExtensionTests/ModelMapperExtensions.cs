using System.Linq;
using System.Net;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Factory;
using ManagedDns.Internal.Model;
using ManagedDns.Public.Models.RData;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals.ExtensionTests
{
    public class ModelMapperExtensions
    {
        [Fact]
        public void TestHeaderConversion()
        {
            var header = HeaderFactory.FromBytes(DnsQuerries.GetYahooMxQuery());
            var model = header.Convert();

            Assert.NotNull(header);
            Assert.NotNull(model);

            Assert.Equal(header.Id, model.Id);
            Assert.Equal(header.Qr, model.QueryOrResponse);
            Assert.Equal(header.OpCode, model.OperationCode);
            Assert.Equal(header.Aa, model.AuthoratiativeAnswer);
            Assert.Equal(header.Tc, model.Truncated);
            Assert.Equal(header.Rd, model.RecursionDesired);
            Assert.Equal(header.Ra, model.RecursionAvailable);
            Assert.Equal(header.Z, model.Z);
            Assert.Equal(header.RCode, model.ResponseCode);
            Assert.Equal(header.QdCount, model.QuestionCount);
            Assert.Equal(header.AnCount, model.AnswerCount);
            Assert.Equal(header.NsCount, model.NameServerCount);
            Assert.Equal(header.ArCount, model.AdditionalReccordCount);
        }

        [Fact]
        public void TestNullHeaderConversion()
        {
            Header test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestQuestionConversion()
        {
            var question = QuestionFactory.FromParser(new RawByteParser(DnsQuerries.GetYahooMxQuery()));
            var model = question.Convert();

            Assert.NotNull(question);
            Assert.NotNull(model);

            Assert.Equal(question.QName, model.QuestionName);
            Assert.Equal(question.QType, model.QuestionType);
            Assert.Equal(question.QClass, model.QuestionClass);
        }

        [Fact]
        public void TestNullQuestionConversion()
        {
            Question test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestResourceRecordConversion()
        {
            var parser = new RawByteParser(DnsResponses.TXT());
            QuestionFactory.FromParser(parser);

            var msg = ResourceRecordFactory.FromParser(parser);
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);

            Assert.Equal(msg.Class, model.Class);
            Assert.Equal(msg.Name, model.Name);
            Assert.Equal(msg.TimeStamp, model.TimeStamp);
            Assert.Equal(msg.Ttl, model.Ttl);
            Assert.Equal(msg.Type, model.Type);
            // ReSharper disable once PossibleNullReferenceException
            Assert.Equal(msg.Record.DataAsString(), (model.Record as TxtRecord).Text);

        }

        [Fact]
        public void TestNullResourceRecordConversion()
        {
            ResourceRecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestMessageConversion()
        {
            var msg = MessageFactory.FromParser(new RawByteParser(DnsResponses.TXT()));
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);

            Assert.Equal(msg.Answers.FirstOrDefault().Class, model.Answers.FirstOrDefault().Class);
            Assert.Equal(msg.Answers.FirstOrDefault().Name, model.Answers.FirstOrDefault().Name);
            Assert.Equal(msg.Answers.FirstOrDefault().TimeStamp, model.Answers.FirstOrDefault().TimeStamp);
            Assert.Equal(msg.Answers.FirstOrDefault().Ttl, model.Answers.FirstOrDefault().Ttl);
            Assert.Equal(msg.Answers.FirstOrDefault().Type, model.Answers.FirstOrDefault().Type);
            // ReSharper disable once PossibleNullReferenceException
            Assert.Equal(msg.Answers.FirstOrDefault().Record.DataAsString(), (model.Answers.FirstOrDefault().Record as TxtRecord).Text);

            Assert.Equal(msg.Questions.Count(), model.Questions.Count());
            Assert.Equal(msg.Answers.Count(), model.Answers.Count());
            Assert.Equal(msg.Authorities.Count(), model.Authorities.Count());
            Assert.Equal(msg.Additionals.Count(), model.Additionals.Count());
        }

        [Fact]
        public void TestMessageRecordConversion()
        {
            Message test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestAaaaConversion()
        {
            var msg = new Internal.Model.RData.AaaaRecord(IPAddress.Parse("::1"));
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);
            Assert.Equal(msg.Address, model.Address);
        }

        [Fact]
        public void TestAaaaRecordConversion()
        {
            Internal.Model.RData.AaaaRecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestAConversion()
        {
            var msg = new Internal.Model.RData.ARecord(IPAddress.Parse("127.0.0.1"));
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);
            Assert.Equal(msg.Address, model.Address);
        }

        [Fact]
        public void TestARecordConversion()
        {
            Internal.Model.RData.ARecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestCNameConversion()
        {
            var msg = new Internal.Model.RData.CNameRecord("test");
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);
            Assert.Equal(msg.CName, model.CName);
        }

        [Fact]
        public void TestCNameRecordConversion()
        {
            Internal.Model.RData.CNameRecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestMxConversion()
        {
            var msg = new Internal.Model.RData.MxRecord(1, "test");
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);
            Assert.Equal(msg.Exchanger, model.Exchanger);
            Assert.Equal(msg.Preference, model.Preference);
        }

        [Fact]
        public void TestMxRecordConversion()
        {
            Internal.Model.RData.MxRecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestNsConversion()
        {
            var msg = new Internal.Model.RData.NsRecord("test");
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);
            Assert.Equal(msg.NsDomainName, model.NameServerDomainName);
        }

        [Fact]
        public void TestNsRecordConversion()
        {
            Internal.Model.RData.NsRecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestPtrConversion()
        {
            var msg = new Internal.Model.RData.PtrRecord("test");
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);
            Assert.Equal(msg.DomainName, model.DomainName);
        }

        [Fact]
        public void TestPtrRecordConversion()
        {
            Internal.Model.RData.PtrRecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestSoaConversion()
        {
            var msg = new Internal.Model.RData.SoaRecord("test", "test1", 125, 126, 127, 128, 129);
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);
            Assert.Equal(msg.Expire, model.Expire);
            Assert.Equal(msg.MName, model.MainNameServer);
            Assert.Equal(msg.Minimum, model.MinimumZoneTtl);
            Assert.Equal(msg.RName, model.AdministratorName);
            Assert.Equal(msg.Refresh, model.Refresh);
            Assert.Equal(msg.Retry, model.Retry);
            Assert.Equal(msg.Serial, model.Serial);
        }

        [Fact]
        public void TestSoaRecordConversion()
        {
            Internal.Model.RData.SoaRecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }

        [Fact]
        public void TestTxtConversion()
        {
            var msg = new Internal.Model.RData.TxtRecord("test");
            var model = msg.Convert();

            Assert.NotNull(msg);
            Assert.NotNull(model);
            Assert.Equal(msg.Text, model.Text);
        }

        [Fact]
        public void TestTxtRecordConversion()
        {
            Internal.Model.RData.TxtRecord test = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var model = test.Convert();

            Assert.Null(test);
            Assert.Null(model);
        }
    }
}
