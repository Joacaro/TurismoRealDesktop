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
    /// Lógica de interacción para CrearEdificio.xaml
    /// </summary>
    public partial class CrearEdificio : Window
    {
        NegocioLocalizacion nl;
        NegocioEdificio ne;
        public CrearEdificio()
        {
            InitializeComponent();
            nl = new NegocioLocalizacion();
            ne = new NegocioEdificio();
            LlenarRegion();
            LlenarComuna();
            LlenarCiudad();
            Limpiar();
        }
        private void LlenarRegion()
        {
            List<string> listado = nl.ObtenerRegion().Select(x => x.NombreReg).ToList(); ;
            cmbReg.ItemsSource = listado;
        }
        private void LlenarCiudad()
        {
            List<string> listado = nl.ObtenerCiudad().Select(x => x.NombreCiudad).ToList(); ;
            cmbCiudad.ItemsSource = listado;
        }

        private void LlenarComuna()
        {
            List<string> listado = nl.ObtenerComuna().Select(x => x.NombreCom).ToList(); ;
            cmbComuna.ItemsSource = listado;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Edificio edificio = new Edificio();
            edificio.DireccionEd = txtDir.Text;
            edificio.TelefonoEd = txtTel.Text;
            edificio.CantPisos = Int32.Parse(txtCant.Text);
            decimal idComuna = nl.ObtenerComuna().FirstOrDefault().IdComuna;
            edificio.ComunaIdCom = idComuna;
            edificio.NombreAdm = txtAdm.Text;
            ne.InsertEdificio(edificio);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Limpiar()
        {
            txtAdm.Text = "";
            txtCant.Text = "";
            txtDir.Text = "";
            txtTel.Text = "";
            cmbCiudad.SelectedItem = -1;
            cmbComuna.SelectedItem = -1;
            cmbReg.SelectedItem= -1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdministrarDepartamentos();
            ventana.Show();
            this.Close();
        }
    }
}
