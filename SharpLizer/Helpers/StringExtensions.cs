using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLizer.Helpers
{
    public static class StringExtensions
    {
        public static string SpliByCapitalLetters(this string theString)
        {
            if (string.IsNullOrWhiteSpace(theString)) return string.Empty;

            var builder = new StringBuilder();
            foreach(char c in theString) {
                if (Char.IsUpper(c) && builder.Length > 0) builder.Append(' ');
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}
