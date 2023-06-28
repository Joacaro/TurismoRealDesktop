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
    /// Lógica de interacción para CrearServicios.xaml
    /// </summary>
    public partial class CrearServicios : Window
    {
        NegocioServicios ns;
        public CrearServicios()
        {
            InitializeComponent();
            ns = new NegocioServicios();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TipoCompaniaServicio tpc = new TipoCompaniaServicio();
            tpc.NombreComp = nombre.Text;
            tpc.TelefonoComp = tel.Text;
            tpc.CorreoComp = email.Text;
            ns.InsertServicio(tpc);
            Limpiar();
        }
        private void Limpiar()
        {
            nombre.Text = "";
            tel.Text = "";
            email.Text = "";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdministrarDepartamentos();
            ventana.Show();
            this.Close();
        }
    }
}
