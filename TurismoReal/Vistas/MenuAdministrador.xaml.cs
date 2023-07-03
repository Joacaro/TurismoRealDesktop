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

namespace TurismoReal.Vistas
{
    /// <summary>
    /// Lógica de interacción para MenuAdministrador.xaml
    /// </summary>
    public partial class MenuAdministrador : Window
    {
        public MenuAdministrador()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdministrarCliente();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window ventana = new MainWindow();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdministrarDepartamentos();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdministrarExtras();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdministrarInventario();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdminstrarReservas();
            ventana.Show();
            this.Close();
        }
    }
}
