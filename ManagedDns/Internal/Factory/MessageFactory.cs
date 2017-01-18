using System.Collections.Generic;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Internal.Model;

namespace ManagedDns.Internal.Factory
{
    internal sealed class MessageFactory
    {
        internal static Message FromParser(IByteParser parser)
        {
            var msg = new Message { Header = HeaderFactory.FromParser(parser) };

            var questions = new List<Question>();
            for(var ndx = 0; ndx < msg.Header.QdCount; ++ndx)
                questions.Add(QuestionFactory.FromParser(parser));

            msg.Questions = questions;

            var answers = new List<ResourceRecord>();
            for (var ndx = 0; ndx < msg.Header.AnCount; ++ndx)
                answers.Add(ResourceRecordFactory.FromParser(parser));

            msg.Answers = answers;

            var authorities = new List<ResourceRecord>();
            for (var ndx = 0; ndx < msg.Header.NsCount; ++ndx)
                authorities.Add(ResourceRecordFactory.FromParser(parser));

            msg.Authorities = authorities;

            var additional = new List<ResourceRecord>();
            for (var ndx = 0; ndx < msg.Header.ArCount; ++ndx)
                additional.Add(ResourceRecordFactory.FromParser(parser));

            msg.Additionals = additional;

            return msg;
        }

        internal static Message FromQuery(Question question, bool recursion = false)
        {
            return new Message
                {
                    Header = HeaderFactory.ForQuery(recursion),
                    Questions = new List<Question> { question }
                };
        }
    }
}
