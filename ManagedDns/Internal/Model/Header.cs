using System.Collections.Generic;
using ManagedDns.Internal.Extensions;
using ManagedDns.Internal.Interfaces;
using ManagedDns.Public;

namespace ManagedDns.Internal.Model
{
    internal sealed class Header : IByteConverter
    {
        internal enum HeaderBitPosition
        {
            RCode = 0,
            Z = 4,
            Ra = 7,
            Rd = 8,
            Tc = 9,
            Aa = 10,
            OpCode = 11,
            Qr = 15,
        }

        public ushort Id { get; set; }

        public Qr Qr { get; set; }

        public OpCode OpCode { get; set; }

        public bool Aa { get; set; }

        public bool Tc { get; set; }

        public bool Rd { get; set; }

        public bool Ra { get; set; }

        public ushort Z { get; set; }

        public ResponseCode RCode { get; set; }

        public ushort QdCount { get; set; }

        public ushort AnCount { get; set; }

        public ushort NsCount { get; set; }

        public ushort ArCount { get; set; }

        internal Header() {  }

        internal Header(ushort id, int qr, int opcode, bool aa, bool tc, bool rd, bool ra, ushort z, int rcode,
            ushort qdcount, ushort ancount, ushort nscount, ushort arcount)
        {
            Id = id;
            Qr = (Qr) qr;
            OpCode = (OpCode) opcode;
            Aa = aa;
            Tc = tc;
            Rd = rd;
            Ra = ra;
            Z = z;
            RCode = (ResponseCode) rcode;
            QdCount = qdcount;
            AnCount = ancount;
            NsCount = nscount;
            ArCount = arcount;
        }

        public IEnumerable<byte> ToBytes()
        {
            ushort bits = 0;
            bits |= (ushort)(((ushort)RCode & 15) << (int) HeaderBitPosition.RCode);
            bits |= (ushort)((Z & 7) << (int) HeaderBitPosition.Z);
            bits |= (ushort)(((Ra ? 1 : 0) & 1) << (int) HeaderBitPosition.Ra);
            bits |= (ushort)(((Rd ? 1 : 0) & 1) << (int) HeaderBitPosition.Rd);
            bits |= (ushort)(((Tc ? 1 : 0) & 1) << (int) HeaderBitPosition.Tc);
            bits |= (ushort)(((Aa ? 1 : 0) & 1) << (int) HeaderBitPosition.Aa);
            bits |= (ushort)(((ushort)OpCode & 15) << (int) HeaderBitPosition.OpCode);
            bits |= (ushort)(((ushort)Qr & 1) << (int) HeaderBitPosition.Qr);

            var bytes = new List<byte>();
            bytes.AddRange(Id.ToBeBytes());
            bytes.AddRange(bits.ToBeBytes());
            bytes.AddRange(QdCount.ToBeBytes());
            bytes.AddRange(AnCount.ToBeBytes());
            bytes.AddRange(NsCount.ToBeBytes());
            bytes.AddRange(ArCount.ToBeBytes());

            return bytes;
        }
    }
}
/*  4.1.1. Header section format
 * 
	The header contains the following fields:

										1  1  1  1  1  1
		  0  1  2  3  4  5  6  7  8  9  0  1  2  3  4  5
		+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
		|                      ID                       |
		+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
		|QR|   Opcode  |AA|TC|RD|RA|   Z    |   RCODE   |
		+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
		|                    QDCOUNT                    |
		+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
		|                    ANCOUNT                    |
		+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
		|                    NSCOUNT                    |
		+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
		|                    ARCOUNT                    |
		+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

		where:

		ID              A 16 bit identifier assigned by the program that
						generates any kind of query.  This identifier is copied
						the corresponding reply and can be used by the requester
						to match up replies to outstanding queries.

		QR              A one bit field that specifies whether this message is a
						query (0), or a response (1).

		OPCODE          A four bit field that specifies kind of query in this
						message.  This value is set by the originator of a query
						and copied into the response.  The values are:

						0               a standard query (QUERY)

						1               an inverse query (IQUERY)

						2               a server status request (STATUS)

						3-15            reserved for future use

		AA              Authoritative Answer - this bit is valid in responses,
						and specifies that the responding name server is an
						authority for the domain name in question section.

						Note that the contents of the answer section may have
						multiple owner names because of aliases.  The AA bit
						corresponds to the name which matches the query name, or
						the first owner name in the answer section.

		TC              TrunCation - specifies that this message was truncated
						due to length greater than that permitted on the
						transmission channel.

		RD              Recursion Desired - this bit may be set in a query and
						is copied into the response.  If RD is set, it directs
						the name server to pursue the query recursively.
						Recursive query support is optional.

		RA              Recursion Available - this be is set or cleared in a
						response, and denotes whether recursive query support is
						available in the name server.

		Z               Reserved for future use.  Must be zero in all queries
						and responses.

		RCODE           Response code - this 4 bit field is set as part of
						responses.  The values have the following
						interpretation:

						0               No error condition

						1               Format error - The name server was
										unable to interpret the query.

						2               Server failure - The name server was
										unable to process this query due to a
										problem with the name server.

						3               Name Error - Meaningful only for
										responses from an authoritative name
										server, this code signifies that the
										domain name referenced in the query does
										not exist.

						4               Not Implemented - The name server does
										not support the requested kind of query.

						5               Refused - The name server refuses to
										perform the specified operation for
										policy reasons.  For example, a name
										server may not wish to provide the
										information to the particular requester,
										or a name server may not wish to perform
										a particular operation (e.g., zone
										transfer) for particular data.

						6-15            Reserved for future use.

		QDCOUNT         an unsigned 16 bit integer specifying the number of
						entries in the question section.

		ANCOUNT         an unsigned 16 bit integer specifying the number of
						resource records in the answer section.

		NSCOUNT         an unsigned 16 bit integer specifying the number of name
						server resource records in the authority records
						section.

		ARCOUNT         an unsigned 16 bit integer specifying the number of
						resource records in the additional records section.  
 */
