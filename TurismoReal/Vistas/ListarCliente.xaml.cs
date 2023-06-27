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
    /// Lógica de interacción para ListarCliente.xaml
    /// </summary>
    public partial class ListarCliente : Window
    {
        NegocioCliente nc;
        public ListarCliente()
        {
            InitializeComponent();
            nc = new NegocioCliente();
            LoadGrid();
        }
        public void LoadGrid()
        {
            DataTable dt = nc.GetCursor();
            GridCli.DataContext = dt.DefaultView;
            GridCli.AutoGenerateColumns = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window admin = new AdministrarCliente();
            admin.Show();
            this.Close();
        }
    }
}
