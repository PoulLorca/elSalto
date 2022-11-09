using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantasNegocio
{
    public class IsValidNombreComun : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool res = true;
            int len = value.ToString().Length;
            int min = 3;
            int max = 100;

            if (!string.IsNullOrEmpty(value.ToString()))
            {
                if (len <= min || len >= max)
                {
                    res = false;
                }
                else
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
