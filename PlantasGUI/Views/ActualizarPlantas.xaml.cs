using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlantasGUI.Views
{
    /// <summary>
    /// Lógica de interacción para ActualizarPlantas.xaml
    /// </summary>
    public partial class ActualizarPlantas : Window
    {
        private static Regex n_regex = new Regex("[^0-9]+");
        PlantasNegocio.Planta planta;

        public ActualizarPlantas(int id)
        {
            InitializeComponent();

            this.Title = String.Format("Actualizar planta {0}", id);

            planta = new PlantasNegocio.Planta();            

            CargarFormulario(id);
        }

        private void CargarFormulario(int id)
        {
            bool response = planta.Read(id);
            if (response)
            {                
                txtIndex.Text = id.ToString();
                txtNombreComun.Text = planta.NombreComun;
                txtNombreCientifico.Text = planta.NombreCientifico;               
                if (planta.TipoPlanta == "Herbácea")
                {
                    txtTipoPlanta.SelectedIndex = 0;
                }
                else if(planta.TipoPlanta == "Matorral")
                {
                    txtTipoPlanta.SelectedIndex = 1;
                }
                else if(planta.TipoPlanta == "Arbusto")
                {
                    txtTipoPlanta.SelectedIndex = 2;
                }
                else
                {
                    txtTipoPlanta.SelectedIndex = 3;
                }
                txtDescripcion.Text = planta.Descripcion;
                txtTiempoRiego.Text = planta.TiempoRiego.ToString();
                txtCantidadAgua.Text = planta.CantidadAgua.ToString();
                if (planta.Epoca == "Verano")
                {
                    txtTipoPlanta.SelectedIndex = 0;
                }
                else if (planta.Epoca == "Invierno")
                {
                    txtTipoPlanta.SelectedIndex = 1;
                }
                else if (planta.Epoca == "Otoño")
                {
                    txtTipoPlanta.SelectedIndex = 2;
                }
                else
                {
                    txtTipoPlanta.SelectedIndex = 3;
                }

                chkVenenosa.IsChecked = (planta.EsVenenosa) ? true : false;
                chkAutoctona.IsChecked = (planta.EsAutoctona) ? true : false;

            }
            else
            {
                MessageBox.Show(string.Format("La planta {0} no fue encotrada"), id.ToString());
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            planta.NombreComun = txtNombreComun.Text;
            planta.NombreCientifico = txtNombreCientifico.Text;
            planta.TipoPlanta = txtTipoPlanta.Text;
            planta.Descripcion = txtDescripcion.Text;
            planta.TiempoRiego = Convert.ToInt32(txtTiempoRiego.Text);
            planta.CantidadAgua = Convert.ToInt32(txtCantidadAgua.Text);
            planta.Epoca = txtEpoca.Text;
            planta.EsVenenosa = (chkVenenosa.IsChecked.Value) ? true : false;
            planta.EsAutoctona = (chkAutoctona.IsChecked.Value) ? true : false;

            bool response = planta.Update();


            if (response)
            {
                MessageBox.Show(String.Format("Planta {0} actualizada correctamente", planta.NombreComun));
            }
            else
            {
                MessageBox.Show(String.Format("No se pudo actualizar la planta {0}", planta.NombreComun));
                this.Close();
            }

        }

        private void txtOnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = n_regex.IsMatch(e.Text);
        }
    }
}
