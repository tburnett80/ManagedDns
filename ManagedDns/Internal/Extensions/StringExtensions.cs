
namespace ManagedDns.Internal.Extensions
{
    internal static class StringExtensions
    {
        internal static string TryTrim(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
        }
    }
}
