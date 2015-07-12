namespace agkik.desktopclient.Utils
{
    internal class ValidationUtils
    {
        public static string validateString(string input, string propName)
        {
            if (string.IsNullOrWhiteSpace(input))
                return propName + " is mandatory";
            return string.Empty;
        }

        internal static string validateString(int input, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(input.ToString()))
                return propertyName + " is mandatory";
            return string.Empty;
        }
    }
}
