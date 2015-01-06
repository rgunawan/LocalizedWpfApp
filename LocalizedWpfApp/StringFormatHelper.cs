namespace LocalizedWpfApp
{
    static class StringFormatHelper
    {
        public static string Fill(this string source, params object[] args)
        {
            return string.Format(source, args);
        }
    }
}