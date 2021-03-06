﻿using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ManagedDns.Internal.Engines;
using ManagedDns.Internal.Factory;
using ManagedDns.Public;
using ManagedDns.Tests.TestResources;
using Xunit;

namespace ManagedDns.Tests.Internals.FactoryTests
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MessageFactoryTests
    {
        [Fact]
        public void CreateGoogleTxtResponse()
        {
            var msg = MessageFactory.FromParser(new RawByteParser(DnsResponses.TXT()));

            //Header
            Assert.Equal(26951, msg.Header.Id);
            Assert.Equal(1, msg.Header.AnCount);
            Assert.Equal(0, msg.Header.ArCount);
            Assert.Equal(0, msg.Header.NsCount);
            Assert.Equal(OpCode.Query, msg.Header.OpCode);
            Assert.Equal(Qr.Response, msg.Header.Qr);
            Assert.Equal(ResponseCode.NoError, msg.Header.RCode);
            Assert.Equal(true, msg.Header.Aa);
            Assert.Equal(false, msg.Header.Ra);
            Assert.Equal(true, msg.Header.Rd);
            Assert.Equal(false, msg.Header.Tc);
            Assert.Equal(0, msg.Header.Z);

            //Question
            Assert.Equal(1, msg.Questions.Count());
            Assert.Equal("google.com.", msg.Questions.FirstOrDefault().QName);
            Assert.Equal(RecordType.TxtRecord, msg.Questions.FirstOrDefault().QType);
            Assert.Equal(RecordClass.In, msg.Questions.FirstOrDefault().QClass);

            //Answers
            Assert.Equal(1, msg.Answers.Count());
            Assert.Equal("google.com.", msg.Answers.FirstOrDefault().Name);
            Assert.Equal(RecordType.TxtRecord, msg.Answers.FirstOrDefault().Type);
            Assert.Equal(RecordClass.In, msg.Answers.FirstOrDefault().Class);
            Assert.Equal((uint)3600, msg.Answers.FirstOrDefault().Ttl);
            Assert.Equal(76, msg.Answers.FirstOrDefault().RdLength);
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", (msg.Answers.FirstOrDefault().Record as Internal.Model.RData.TxtRecord).Text);

            //Authorities
            Assert.Equal(false, msg.Authorities.Any());

            //Additionals
            Assert.Equal(false, msg.Additionals.Any());
        }

        [Fact]
        public void ParseFromYahooMxQuery()
        {
            var msg = MessageFactory.FromParser(new RawByteParser(DnsQuerries.GetYahooMxQuery()));

            Assert.Equal(10659, msg.Header.Id);
            Assert.Equal(0, msg.Header.AnCount);
            Assert.Equal(0, msg.Header.ArCount);
            Assert.Equal(0, msg.Header.NsCount);
            Assert.Equal(OpCode.Query, msg.Header.OpCode);
            Assert.Equal(Qr.Query, msg.Header.Qr);
            Assert.Equal(ResponseCode.NoError, msg.Header.RCode);
            Assert.Equal(false, msg.Header.Aa);
            Assert.Equal(false, msg.Header.Ra);
            Assert.Equal(true, msg.Header.Rd);
            Assert.Equal(false, msg.Header.Tc);
            Assert.Equal(0, msg.Header.Z);

            //Question
            Assert.Equal(1, msg.Questions.Count());
            Assert.Equal("yahoo.com.", msg.Questions.FirstOrDefault().QName);
            Assert.Equal(RecordType.MxRecord, msg.Questions.FirstOrDefault().QType);
            Assert.Equal(RecordClass.In, msg.Questions.FirstOrDefault().QClass);

            Assert.Equal(false, msg.Answers.Any());
            Assert.Equal(false, msg.Authorities.Any());
            Assert.Equal(false, msg.Additionals.Any());
        }

        [Fact]
        public void ParseTxtResponse()
        {
            var msg = MessageFactory.FromRawData(DnsResponses.TXT());

            Assert.NotNull(msg);

            //Header
            Assert.Equal(26951, msg.Header.Id);
            Assert.Equal(1, msg.Header.AnCount);
            Assert.Equal(0, msg.Header.ArCount);
            Assert.Equal(0, msg.Header.NsCount);
            Assert.Equal(OpCode.Query, msg.Header.OpCode);
            Assert.Equal(Qr.Response, msg.Header.Qr);
            Assert.Equal(ResponseCode.NoError, msg.Header.RCode);
            Assert.Equal(true, msg.Header.Aa);
            Assert.Equal(false, msg.Header.Ra);
            Assert.Equal(true, msg.Header.Rd);
            Assert.Equal(false, msg.Header.Tc);
            Assert.Equal(0, msg.Header.Z);

            //Question
            Assert.Equal(1, msg.Questions.Count());
            Assert.Equal("google.com.", msg.Questions.FirstOrDefault().QName);
            Assert.Equal(RecordType.TxtRecord, msg.Questions.FirstOrDefault().QType);
            Assert.Equal(RecordClass.In, msg.Questions.FirstOrDefault().QClass);

            //Answers
            Assert.Equal(1, msg.Answers.Count());
            Assert.Equal("google.com.", msg.Answers.FirstOrDefault().Name);
            Assert.Equal(RecordType.TxtRecord, msg.Answers.FirstOrDefault().Type);
            Assert.Equal(RecordClass.In, msg.Answers.FirstOrDefault().Class);
            Assert.Equal((uint)3600, msg.Answers.FirstOrDefault().Ttl);
            Assert.Equal(76, msg.Answers.FirstOrDefault().RdLength);
            Assert.Equal("v=spf1 include:_spf.google.com ip4:216.73.93.70/31 ip4:216.73.93.72/31 ~all", (msg.Answers.FirstOrDefault().Record as Internal.Model.RData.TxtRecord).Text);

            //Authorities
            Assert.Equal(false, msg.Authorities.Any());

            //Additionals
            Assert.Equal(false, msg.Additionals.Any());
        }

        [Fact]
        public void CreateYahooMxQuery()
        {
            var query = MessageFactory.FromQuery(QuestionFactory.FactoryQuestion(RecordType.MxRecord, "yahoo.com."));
            Assert.Equal(DnsQuerries.GetYahooMxQuery().Skip(2), query.ToBytes().Skip(2));
        }
    }
}
