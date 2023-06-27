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
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = null;
            try
            {
                switch (nu.Validar(usu.Text))
                {
                    case "ADMINISTRADOR":
                        ventana = new MenuAdministrador();
                        break;
                    case "RECEPCIONISTA":
                        ventana = new MenuFuncionario();
                        break;
                    default:
                        break;
                }
                ventana.Show();
                this.Close();
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
