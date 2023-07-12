using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para ListServicio.xaml
    /// </summary>
    public partial class ListServicio : Window
    {
        NegocioServicios ns;
        public ListServicio()
        {
            InitializeComponent();
            ns = new NegocioServicios();
            LoadGrid();
        }
        public void LoadGrid()
        {
            DataTable dt = ns.ListServicios();
            GridServ.DataContext = dt.DefaultView;
            GridServ.AutoGenerateColumns = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = new AdministrarDepartamentos();
            ventana.Show();
            this.Close();
        }
    }
}
