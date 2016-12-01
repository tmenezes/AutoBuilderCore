
namespace AutoBuilder.Extensions
{
    public static class StringExtensions
    {
        public static string SafeSubstring(this string text, int maxSize)
        {
            return (text.Length > maxSize)
                ? text.Substring(0, maxSize)
                : text;
        }
    }
}
