using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantasNegocio
{
    public class CommonBC
    {
        private static PlantasDALC.PlantasEntities _modeloPlantas;

        public static PlantasDALC.PlantasEntities ModeloPlantas
        {
            get
            {
                if (_modeloPlantas == null)
                {
                    _modeloPlantas = new PlantasDALC.PlantasEntities();
                }
                return _modeloPlantas;
            }
        }

        public CommonBC() { }
        }
    }
