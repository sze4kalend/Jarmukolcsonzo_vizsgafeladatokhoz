using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Jarmukolcsonzo.WPF.Validators
{
    public class RendszamValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? rendszam = value.ToString();
            if (!string.IsNullOrWhiteSpace(rendszam))
            {
                string pattern = @"^[A-Z]{3,4}-\d{3}$";
                if (Regex.IsMatch(rendszam, pattern))
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false, "Nem megfelelő a rendszám formátuma.");
        }
    }
}
