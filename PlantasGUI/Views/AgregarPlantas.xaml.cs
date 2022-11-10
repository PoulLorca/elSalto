using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para AgregarPlantas.xaml
    /// </summary>
    public partial class AgregarPlantas : Window
    {
        private static Regex n_regex = new Regex("[^0-9]+");
        PlantasNegocio.Planta planta;

        public AgregarPlantas()
        {
            InitializeComponent();
            planta = new PlantasNegocio.Planta();
            this.DataContext = planta;                
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
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

                bool response = planta.Create();                

                if (response)
                {
                    MessageBox.Show("Planta agregada correctamente");                   
                    AgregarOtroEquipo();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error intente más tarde");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AgregarOtroEquipo()
        {
            string title = "Agregar otro equipo";
            string message = "¿Desea agregar otro equipo";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, buttons);

            if (result == MessageBoxResult.No)
            {
                this.Close();
            }
        }

        private void LimpiarCampos()
        {
            txtNombreComun.Text = String.Empty;
            txtNombreCientifico.Text = String.Empty;
            txtTipoPlanta.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtTiempoRiego.Text = String.Empty;
            txtCantidadAgua.Text = String.Empty;
            txtEpoca.Text = String.Empty;
            chkVenenosa.IsChecked = false;
            chkAutoctona.IsChecked = false;

        }

        private void txtOnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = n_regex.IsMatch(e.Text);
        }
    }
}
