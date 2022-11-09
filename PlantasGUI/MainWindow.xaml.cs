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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlantasGUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlantasNegocio.PlantaCollection plantaCollection;
        PlantasNegocio.PlantasReporte plantaReporte;

        public MainWindow()
        {
            InitializeComponent();
            plantaCollection = new PlantasNegocio.PlantaCollection();  
            CargarGrilla();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            Views.AgregarPlantas agregarPlanta = new Views.AgregarPlantas();
            agregarPlanta.ShowDialog();
        }

        private void ListarTodas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CargarGrilla()
        {
            dgPlantas.ItemsSource = plantaCollection.ReadAll();            

            plantaReporte = new PlantasNegocio.PlantasReporte();

            int venenosas = plantaReporte.ReportePlantasVenenosas();
            int autoctonas = plantaReporte.ReportePlantasAutoctonas();
            string message = string.Format(
                "Plantas venenosas registradas: {0} || Plantas autoctonas registradas: {1}",
                venenosas,
                autoctonas
                );
            lblInfo.Content = message;
        }
    }
}
