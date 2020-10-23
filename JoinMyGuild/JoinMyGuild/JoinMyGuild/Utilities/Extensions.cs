using System.Globalization;

namespace JoinMyGuild.Utilities
{
    public static class Extensions
    {
        public static string Format(this string source, params object[] values)
        {
            return string.Format(CultureInfo.InvariantCulture, source, values);
        }
    }
}
