using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantasNegocio
{
    public class PlantaCollection
    {
        public List<Planta> ReadAll()
        {
            var plantas = CommonBC.ModeloPlantas.vwPlanta;            
            return ObtenerPlantas(plantas.ToList());
        }

        private List<Planta> ObtenerPlantas(List<PlantasDALC.vwPlanta> plantasDALC)
        {
            List<Planta> plantasList = new List<Planta>();
            foreach (PlantasDALC.vwPlanta planta in plantasDALC)            
            {
                Planta p = new Planta();
                p.Id = planta.Id;
                p.NombreComun = AES_Helper.DecryptString(planta.NombreComun);
                p.NombreCientifico = AES_Helper.DecryptString(planta.NombreCientifico);
                p.TipoPlanta = planta.TipoPlanta;
                p.Descripcion = AES_Helper.DecryptString(planta.Descripcion);
                p.TiempoRiego = planta.TiempoRiego;
                p.CantidadAgua = planta.CantidadAgua;
                p.Epoca = planta.Epoca;
                p.EsVenenosa = (bool)planta.EsVenenosa;
                p.EsAutoctona = (bool)planta.EsAutoctona;

                plantasList.Add(p);
            }
            return plantasList;
        }
    }
}
