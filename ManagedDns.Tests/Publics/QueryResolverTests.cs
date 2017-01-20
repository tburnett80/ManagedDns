using System.Net;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;
using ManagedDns.Public;
using ManagedDns.Public.Resolver;
using ManagedDns.Tests.TestResources;
using Moq;
using Xunit;
using System.Linq;
using ManagedDns.Public.Models.RData;

namespace ManagedDns.Tests.Publics
{
    public class QueryResolverTests
    {
        [Fact]
        public void QueryTxtRecord()
        {
            //Arrange
            var mockedTransport = new Mock<IDnsTransport>();

            mockedTransport
                .Setup(tx => tx.SendRequest(It.IsAny<Message>(), It.IsAny<IPEndPoint>(), It.IsAny<int>()))
                .Returns(DnsResponses.TXT());

            var question = new Public.Models.Question
            {
                QuestionClass = RecordClass.In,
                QuestionType = RecordType.TxtRecord,
                QuestionName = "google.com"
            };


            //Act
            var resolver = new QueryResolver(mockedTransport.Object);
            var result = resolver.MakeDnsQuery(question);


            //Assert
            Assert.NotNull(result);

            //Header
            Assert.Equal(26951, result.Header.Id);
            Assert.Equal(1, result.Header.AnswerCount);
            Assert.Equal(0, result.Header.AdditionalReccordCount);
            Assert.Equal(0, result.Header.NameServerCount);
            Assert.Equal(OpCode.Query, result.Header.OperationCode);
            Assert.Equal(Qr.Response, result.Header.QueryOrResponse);
            Assert.Equal(ResponseCode.NoError, result.Header.ResponseCode);
            Assert.Equal(true, result.Header.AuthoratiativeAnswer);
            Assert.Equal(false, result.Header.RecursionAvailable);
            Assert.Equal(true, result.Header.RecursionDesired);
            Assert.Equal(false, result.Header.Truncated);
            Assert.Equal(0, result.Header.Z);

            //Question
            Assert.Equal(1, result.Questions.Count());
            Assert.Equal("google.com.", result.Questions.FirstOrDefault().QuestionName);
            Assert.Equal(RecordType.TxtRecord, result.Questions.FirstOrDefault().QuestionType);
            Assert.Equal(RecordClass.In, result.Questions.FirstOrDefault().QuestionClass);

            //Answers
            Assert.Equal(1, result.Answers.Count());
            Assert.Equal("google.com.", result.Answers.FirstOrDefault().Name);
            Assert.Equal(RecordType.TxtRecord, result.Answers.FirstOrDefault().Type);
            Assert.Equal(RecordClass.In, result.Answers.FirstOrDefault().Class);
            Assert.Equal((uint)3600, result.Answers.FirstOrDefault().Ttl);
            // ReSharper disable once PossibleNullReferenceException
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", (result.Answers.FirstOrDefault().Record as TxtRecord).Text);

            //Authorities
            Assert.Equal(false, result.Authorities.Any());

            //Additionals
            Assert.Equal(false, result.Additionals.Any());
        }
    }
}
