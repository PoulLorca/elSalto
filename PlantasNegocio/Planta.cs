using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlantasNegocio
{
    public class Planta : ObservableObjects, IPersistente
    {
        public int Id { get; set; }

        public string _NombreComun;
        public string _NombreCientifico;        
        public int _TiempoRiego;
        public int _CantidadAgua;

        public string Epoca { get; set; }
        public string Descripcion { get; set; }
        public string TipoPlanta { get; set; }         
        public bool EsVenenosa { get; set; }
        public bool EsAutoctona { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [IsValidNombreComun(ErrorMessage = "El nombre ingresado no es valido")]
        public string NombreComun
        {
            get { return _NombreComun; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new ArgumentNullException(null, "El nombre es obligatorio");

                if (value.ToString().Length <= 3 || value.ToString().Length >= 100)
                    throw new ArgumentNullException(null, "El largo no corresponde");

                //ValidateProperty(value);
                OnPropertyChanged(ref _NombreComun, value);
            }
        }

        [Required(ErrorMessage = "El campo es requerido")]
        [IsValidNombreCientifico(ErrorMessage = "El nombre ingresado no es valido")]
        public string NombreCientifico
        {
            get { return _NombreCientifico; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new ArgumentNullException(null, "El nombre es obligatorio");

                if (value.ToString().Length <= 10 || value.ToString().Length >= 150)
                    throw new ArgumentNullException(null, "El largo no corresponde");

                //ValidateProperty(value);
                OnPropertyChanged(ref _NombreCientifico, value);
            }
        }

        [Required(ErrorMessage = "El campo es requerido")]
        [IsValidTiempoRiego(ErrorMessage = "La cantidad ingresada no es valida")]
        public int TiempoRiego
        {
            get { return _TiempoRiego; }
            set
            {
                //ValidateProperty(value);
                OnPropertyChanged(ref _TiempoRiego, value);
            }
        }

        [Required(ErrorMessage = "El campo es requerido")]
        [IsValidCantidadAgua(ErrorMessage = "La cantidad ingresada no es valida")]
        public int CantidadAgua
        {
            get { return _CantidadAgua; }
            set
            {
                //ValidateProperty(value);
                OnPropertyChanged(ref _CantidadAgua, value);
            }
        }


        public bool Create()
        {
            try
            {
                CommonBC.ModeloPlantas.spPlantaSave(
                AES_Helper.EncryptString(this._NombreComun),
                AES_Helper.EncryptString(this._NombreCientifico),
                this.TipoPlanta,
                AES_Helper.EncryptString(this.Descripcion),
                this._TiempoRiego,
                this.CantidadAgua,
                this.Epoca,
                this.EsVenenosa,
                this.EsAutoctona
                );

                CommonBC.ModeloPlantas.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Read(int Id)
        {
            try
            {
                PlantasDALC.vwPlanta planta = CommonBC.ModeloPlantas.vwPlanta.First(p => p.Id == Id);

                this.NombreComun = AES_Helper.DecryptString(planta.NombreComun);
                this.NombreCientifico = AES_Helper.DecryptString(planta.NombreCientifico);
                this.TipoPlanta = planta.TipoPlanta;
                this.Descripcion = AES_Helper.DecryptString(planta.Descripcion);
                this.TiempoRiego = planta.TiempoRiego;
                this.CantidadAgua = planta.CantidadAgua;
                this.Epoca = planta.Epoca;
                this.EsVenenosa = (bool)planta.EsVenenosa;
                this.EsAutoctona = (bool)planta.EsAutoctona;


                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                CommonBC.ModeloPlantas.spPlantaUpdateById(
                    this.Id,
                    AES_Helper.EncryptString(this.NombreComun),
                    AES_Helper.EncryptString(this.NombreCientifico),
                    this.TipoPlanta,
                    AES_Helper.EncryptString(this.Descripcion),
                    this.TiempoRiego,
                    this.CantidadAgua,
                    this.Epoca,
                    this.EsVenenosa,
                    this.EsAutoctona
                    );

                CommonBC.ModeloPlantas.SaveChanges();                

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                CommonBC.ModeloPlantas.spPlantaDeleteById(Id);
                CommonBC.ModeloPlantas.SaveChanges();                
                return true;
            }
            catch
            {
                return false;
            }
        }

                
    }
}
