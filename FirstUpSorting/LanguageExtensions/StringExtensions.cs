using System;
using System.Text.RegularExpressions;

namespace FirstUpSorting.LanguageExtensions
{
    public static class StringExtensions
    {
        public static string SplitCamelCase(this string sender)
        {
            return Regex.Replace(Regex.Replace(sender, "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), "(\\p{Ll})(\\P{Ll})", "$1 $2");
        }
        public static bool ContainsIgnoreCase(this string source, string substring)
        {
            return source?.IndexOf(substring ?? "", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
