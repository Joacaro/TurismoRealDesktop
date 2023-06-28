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
using TurismoReal.Vistas;
using TurismoReal.Negocio;


namespace TurismoReal
{
    public partial class MainWindow : Window
    {
        NegocioUsuario nu;
        public MainWindow()
        {
            InitializeComponent();
            nu = new NegocioUsuario();
        }
        private void openWindow(Window ventana)
        {
            ventana.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = null;
            try
            {
                switch (nu.Validar(usu.Text, cla.Password))
                {
                    case "ADMINISTRADOR":
                        ventana = new MenuAdministrador();
                        this.openWindow(ventana);
                        break;
                    case "RECEPCIONISTA":
                        ventana = new MenuFuncionario();
                        this.openWindow(ventana);
                        break;
                    default:
                        string message = "Usuario o Contraseña Incorrectos";
                        string title = "Error";
                        MessageBox.Show(message, title);
                        break;
                }
            }
            catch (Exception)
            {
                string message = "Usuario o Contraseña Incorrectos";
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }
    }
}
