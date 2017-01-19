using System.Linq;
using ManagedDns.Internal.Factory;
using ManagedDns.Internal.Model;
using ManagedDns.Internal.Model.RData;

namespace ManagedDns.Internal.Extensions
{
    /// <summary>
    /// Extension class will convert internal model -> public facing model
    /// </summary>
    internal static class ModelMapperExtension
    {
        internal static Public.Models.Header Convert(this Header header)
        {
            if (header == null)
                return null;

            return new Public.Models.Header
            {
                Id = header.Id,
                QueryOrResponse = header.Qr,
                OperationCode = header.OpCode,
                AuthoratiativeAnswer = header.Aa,
                Truncated = header.Tc,
                RecursionDesired = header.Rd,
                RecursionAvailable = header.Ra,
                Z = header.Z,
                ResponseCode = header.RCode,
                QuestionCount = header.QdCount,
                AnswerCount = header.AnCount,
                NameServerCount = header.NsCount,
                AdditionalReccordCount = header.ArCount,
            };
        }

        internal static Public.Models.Question Convert(this Question question)
        {
            if (question == null)
                return null;

            return new Public.Models.Question
            {
                QuestionName   = question.QName,
                QuestionClass = question.QClass,
                QuestionType = question.QType
            };
        }

        internal static Public.Models.ResourceRecord Convert(this ResourceRecord rr)
        {
            if (rr == null)
                return null;

            return new Public.Models.ResourceRecord
            {
                Name = rr.Name,
                Type = rr.Type,
                Class = rr.Class,
                Ttl = rr.Ttl,
                TimeStamp = rr.TimeStamp,
                Record = RDataFactory.FactoryRecordModel(rr.Type, rr.Rdata)
            };
        }

        internal static Public.Models.Message Convert(this Message msg)
        {
            if (msg == null)
                return null;

            return new Public.Models.Message
            {
                Header = msg.Header.Convert(),
                Additionals = msg.Additionals.Select(x => x.Convert()).ToList(),
                Answers = msg.Answers.Select(x => x.Convert()).ToList(),
                Authorities = msg.Authorities.Select(x => x.Convert()).ToList(),
                Questions = msg.Questions.Select(x => x.Convert()).ToList()
            };
        }

        internal static Public.Models.RData.AaaaRecord Convert(this AaaaRecord rec)
        {
            if (rec == null)
                return null;

            return new Public.Models.RData.AaaaRecord
            {
                Address = rec.Address
            };
        }

        internal static Public.Models.RData.ARecord Convert(this ARecord rec)
        {
            if (rec == null)
                return null;

            return new Public.Models.RData.ARecord
            {
                Address = rec.Address
            };
        }

        internal static Public.Models.RData.CNameRecord Convert(this CNameRecord rec)
        {
            if (rec == null)
                return null;

            return new Public.Models.RData.CNameRecord
            {
                CName = rec.CName
            };
        }

        internal static Public.Models.RData.MxRecord Convert(this MxRecord rec)
        {
            if (rec == null)
                return null;

            return new Public.Models.RData.MxRecord
            {
                Preference = rec.Preference,
                Exchanger = rec.Exchanger
            };
        }

        internal static Public.Models.RData.NsRecord Convert(this NsRecord rec)
        {
            if (rec == null)
                return null;

            return new Public.Models.RData.NsRecord
            {
                NameServerDomainName = rec.NsDomainName
            };
        }

        internal static Public.Models.RData.PtrRecord Convert(this PtrRecord rec)
        {
            if (rec == null)
                return null;

            return new Public.Models.RData.PtrRecord
            {
                DomainName = rec.DomainName
            };
        }

        internal static Public.Models.RData.SoaRecord Convert(this SoaRecord rec)
        {
            if (rec == null)
                return null;

            return new Public.Models.RData.SoaRecord
            {
                AdministratorName = rec.RName,
                Expire = rec.Expire,
                MainNameServer = rec.MName,
                MinimumZoneTtl = rec.Minimum,
                Refresh = rec.Refresh,
                Retry = rec.Retry,
                Serial = rec.Serial
            };
        }

        internal static Public.Models.RData.TxtRecord Convert(this TxtRecord rec)
        {
            if (rec == null)
                return null;

            return new Public.Models.RData.TxtRecord
            {
                Text = rec.Text
            };
        }
    }
}

