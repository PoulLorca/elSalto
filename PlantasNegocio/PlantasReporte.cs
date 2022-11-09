using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantasNegocio
{
    public class PlantasReporte
    {
        public int ReportePlantasVenenosas()
        {
            return Convert.ToInt32(CommonBC.ModeloPlantas.spObtenerCantidadVenenosas().First().Value);
        }

        public int ReportePlantasAutoctonas()
        {
            return Convert.ToInt32(CommonBC.ModeloPlantas.spObtenerCantidadAutoctonas().First().Value);
        }
    }
}
