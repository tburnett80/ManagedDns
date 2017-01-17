using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ManagedDns.Internal.Model;

namespace ManagedDns.Internal.Extensions
{
    internal static class DnsExtensions
    {
        internal static IEnumerable<byte> ToLabelBytes(this string value)
        {
            var temp = new List<byte>();
            value = value.TryTrim().TrimEnd('.');

            foreach (var peice in value.Split('.'))
            {
                temp.Add((byte)peice.Length);
                temp.AddRange(Encoding.ASCII.GetBytes(peice.TryTrim()));
            }

            temp.Add(0);
            return temp;
        }

        internal static bool IsExpired(this ResourceRecord value)
        {
            var expired = true;

            if (value != null)
                expired = value.TimeStamp.AddSeconds(value.Ttl).CompareTo(DateTime.Now) < 0;

            return expired;
        }

        internal static string ToArpa(this string ip)
        {
            IPAddress scratch;
            if (!IPAddress.TryParse(ip.TrimEnd('.'), out scratch))
                return string.Empty;

            var sb = new StringBuilder();
            switch (scratch.AddressFamily)
            {
                case AddressFamily.InterNetwork:
                    sb.Append("in-addr.arpa.");
                    foreach (var block in scratch.GetAddressBytes())
                        sb.Insert(0, string.Format("{0}.", block));
                    break;
                case AddressFamily.InterNetworkV6:
                    sb.Append("ip6.arpa.");
                    foreach (var block in scratch.GetAddressBytes())
                    {
                        sb.Insert(0, string.Format("{0:x}.", (block >> 4) & 0xf));
                        sb.Insert(0, string.Format("{0:x}.", (block >> 0) & 0xf));
                    }
                    break;
            }

            return sb.ToString();
        }
    }
}
