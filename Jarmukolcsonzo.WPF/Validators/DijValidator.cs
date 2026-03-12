using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Jarmukolcsonzo.WPF.Validators
{
    public class DijValidator : ValidationRule //Vizsgán validálás
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int.TryParse(value.ToString(), out int dij);

            if(dij < 0)
            {
                return new ValidationResult(false, "A díj nem lehet negatív érték");  
            }
            return ValidationResult.ValidResult;
        }
    }
}
