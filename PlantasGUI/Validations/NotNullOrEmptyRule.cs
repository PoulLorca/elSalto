using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlantasGUI.Validations
{
    public class NotNullOrEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = value as string;

            if (string.IsNullOrEmpty(val))
            {
                return new ValidationResult(false, "El campo no puede estar vacio");
            }

            return new ValidationResult(true, null);
        }

    }
}
