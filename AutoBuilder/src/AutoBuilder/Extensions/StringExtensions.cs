
namespace AutoBuilder.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string text, int maxSize)
        {
            return (text.Length > maxSize)
                ? text.Substring(0, maxSize)
                : text;
        }

        public static bool IsNullOrEmpty(this string text) => string.IsNullOrEmpty(text);
    }
}
