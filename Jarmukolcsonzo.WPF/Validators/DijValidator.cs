using System.Globalization;
using System.Windows.Controls;

namespace Jarmukolcsonzo.WPF.Validators
{
    public class DijValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!int.TryParse(value.ToString(), out int dij))
            {
                return new ValidationResult(false, "A díj csak számot tartalmazhat.");
            }
            if (dij < 0)
            {
                return new ValidationResult(false, "A díj nem lehet negatív érték.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
