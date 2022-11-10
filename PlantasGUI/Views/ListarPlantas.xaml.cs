using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para ListarPlantas.xaml
    /// </summary>
    public partial class ListarPlantas : Window
    {

        PlantasNegocio.PlantaCollection plantaCollection;
        
        public ListarPlantas()
        {
            InitializeComponent();
            CargarGrilla();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            var filaSeleccionada = (PlantasNegocio.Planta)dgListaPlantas.SelectedItem;
            ActualizarPlantas actualizarPlantas = new ActualizarPlantas(filaSeleccionada);            
            actualizarPlantas.ShowDialog();

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            EliminarRegistroSeleccionado();
        }

        private void CargarGrilla()
        {
            plantaCollection = new PlantasNegocio.PlantaCollection();
            dgListaPlantas.ItemsSource = plantaCollection.ReadAll();            
        }

        private void EliminarRegistroSeleccionado()
        {
            var filaSeleccionada = (PlantasNegocio.Planta)dgListaPlantas.SelectedItem;
            int id = filaSeleccionada.Id;
            string title = "Eliminar Planta";
            string message = string.Format("¿Estas seguro de eliminar la planta {0} ?", filaSeleccionada.NombreComun);

            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, button);

            if (result == MessageBoxResult.Yes)
            {
                var res = filaSeleccionada.Delete(id) ?
                MessageBox.Show(string.Format("Planta {0} eliminada", filaSeleccionada.NombreComun)) :
                MessageBox.Show("El equipo no pudo ser eliminado");
            }

        }
    }
}
