using System.Windows.Controls;
using System.Globalization;

namespace agkik.desktopclient.Utils
{
    class DecimalValidationRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal convertedDecimal;
            if (!decimal.TryParse((string)value, out convertedDecimal))
            {
                return new ValidationResult(false, "Enter a number");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
