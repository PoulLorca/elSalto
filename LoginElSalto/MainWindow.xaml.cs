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
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUsuario.Text;
                string password = txtPassword.Password;

                loginEntities login = new loginEntities();
                var response = login.spLogin(username);

                bool res = SALT_Helper.ValidateSaltyPassword(password, response.First());

                if (res)
                    lblMensaje.Content = "Sesion Iniciada correctamente";
                else
                    lblMensaje.Content = "La contraseña con coincide";

            }
            catch(Exception ex)
            {
                lblMensaje.Content=ex.Message;
            }
        }
    }
}
