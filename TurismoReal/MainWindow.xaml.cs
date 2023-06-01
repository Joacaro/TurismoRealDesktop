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
using TurismoReal.Negocio.ControladoresVistas;

namespace TurismoReal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate void EventoCrear();
    public partial class MainWindow : Window
    {
        public event EventoCrear LoadCrear;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = null;
            ventana = new ListarCliente();
            ventana.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            LoadCrear();
        }
    }
}
