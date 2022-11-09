using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Timer = System.Timers.Timer;

namespace LoginElSalto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();  
            ProgressBarLoading.Visibility = Visibility.Hidden;            
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            
            
            ProgressBarLoading.Visibility=Visibility.Visible;
            ProgressBarLoading.IsIndeterminate = true;

            try
            {
                string username = txtUsuario.Text;
                string password = txtPassword.Password;

                loginEntities login = new loginEntities();
                var response = login.spLogin(username);

                bool res = SALT_Helper.ValidateSaltyPassword(password, response.First());
                

                if (res) { 
                    lblMensaje.Content = "Bienvenido " + username;

                    PlantasGUI.MainWindow ventana = new PlantasGUI.MainWindow();
                    ventana.Show();
                    this.Close();
                }
                else { 
                    lblMensaje.Content = "La contraseña con coincide";
                }

            }
            catch(Exception ex)
            {
                lblMensaje.Content=ex.Message;
            }            
        }
        
    }
}
