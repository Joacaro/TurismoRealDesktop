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
    /// Lógica de interacción para AdministrarDepartamentos.xaml
    /// </summary>
    public partial class AdministrarDepartamentos : Window
    {
        public AdministrarDepartamentos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = new MenuAdministrador();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window ventana = new CrearDepto();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window ventana = new ListServicio();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window ventana = new CrearServicios();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window ventana = new EditServicio();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window ventana = new CrearEdificio();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }
    }
}
