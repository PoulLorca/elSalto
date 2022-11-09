using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlantasGUI.Validations
{
    public class NombreComunCustomRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = value as string;
            int len = val.Length;
            int min = 3;
            int max = 10;

            if (len <= min || len >= max)
            {
                return new ValidationResult(false, "Nombre del equipo debe ser entre " + min + "  y " + max + "carácteres");
            }

            return new ValidationResult(true, null);
        }
    }
}
