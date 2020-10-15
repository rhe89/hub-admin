namespace Admin.Web.Ui.Helpers
{
    public static class StringHelpers
    {
        public static string MaxLengthDisplayed(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            if (text.Length <= 50)
            {
                return text;
            }

            return text.Substring(0, 50) + "...";
        }
    }
}