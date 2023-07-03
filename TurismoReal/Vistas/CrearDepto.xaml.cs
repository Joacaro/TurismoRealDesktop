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
using TurismoReal.Negocio;

namespace TurismoReal.Vistas
{
    /// <summary>
    /// Lógica de interacción para CrearDepto.xaml
    /// </summary>
    public partial class CrearDepto : Window
    {
        NegocioEdificio ne;
        NegocioDeptos nd;
        public CrearDepto()
        {
            InitializeComponent();
            ne = new NegocioEdificio();
            nd = new NegocioDeptos();
            LlenarEdificio();
            Limpiar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdministrarDepartamentos();
            ventana.Show();
            this.Close();
        }

        private void LlenarEdificio()
        {
            List<string> listado = ne.ObtenerEdificio().Select(x => x.DireccionEd).ToList(); ;
            cmbEd.ItemsSource = listado;
        }

        private void Limpiar()
        {
            txtBan.Text = "";
            txtNumero.Text = "";
            txtHab.Text = "";
        }

    }
}
