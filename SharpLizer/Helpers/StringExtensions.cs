using System.Text;

namespace SharpLizer.Helpers
{
    public static class StringExtensions
    {
        public static string SpliByCapitalLetters(this string theString)
        {
            if (string.IsNullOrWhiteSpace(theString)) return string.Empty;

            StringBuilder builder = new StringBuilder();
            foreach (char c in theString)
            {
                if (char.IsUpper(c) && builder.Length > 0) builder.Append(' ');
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}