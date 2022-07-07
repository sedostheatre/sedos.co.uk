namespace Sedos.Helpers
{
    public static class StringExtensions
    {
        public static string TrimIfStartsWith(
            this string value,
            string prefix)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            return value.StartsWith(prefix) ?
                    value.Substring(prefix.Length, value.Length - prefix.Length) :
                    value;
        }
    }
}
