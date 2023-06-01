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
using TurismoReal.Datos;
using TurismoReal.Negocio;

namespace TurismoReal.Vistas
{
    /// <summary>
    /// Lógica de interacción para CrearCliente.xaml
    /// </summary>
    public partial class CrearCliente : Window
    {
        NegocioCliente nc;
        public CrearCliente()
        {
            InitializeComponent();
            nc = new NegocioCliente();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edad_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
