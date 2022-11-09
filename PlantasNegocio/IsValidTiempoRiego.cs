using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantasNegocio
{
    public class IsValidTiempoRiego : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool res = true;
            int len = int.Parse(value.ToString());            

            if (!string.IsNullOrEmpty(value.ToString()))
            {
                if (len % 1 != 0)
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
