using System;

namespace DynamicSortByPropertyName.LanguageExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Perform string contain ignoring case
        /// </summary>
        /// <param name="source"></param>
        /// <param name="subString">string to find</param>
        /// <returns>
        /// true if substring is in source string, false if substring is not in source
        /// </returns>
        public static bool ContainsIgnoreCase(this string source, string subString) => 
            source?.IndexOf(subString ?? "", StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
