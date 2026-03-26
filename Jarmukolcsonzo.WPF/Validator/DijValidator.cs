using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Jarmukolcsonzo.WPF.Validator
{ // ValidationRule , Dijvalidator implementálása // vizsgára kell majd
    public class DijValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!int.TryParse(value.ToString(), out int dij))
            {
                return new ValidationResult(false, "A díjnak számnak kell lennie.");
            }
            if (dij < 0)
            {
                return new ValidationResult(false, "A díj nem lehet negatív érték .");
            }
            return ValidationResult.ValidResult;
        }
    }
}
