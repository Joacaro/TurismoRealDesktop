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
    /// Lógica de interacción para CrearInventario.xaml
    /// </summary>
    public partial class CrearInventario : Window
    {
        NegocioInventario ni;
        public CrearInventario()
        {
            InitializeComponent();
            ni = new NegocioInventario();
            Limpiar();
            LlenarTipo();
        }
        private void Limpiar()
        {
            txtName.Text = "";
            txtStock.Text = "";
            cmbTipo.SelectedItem = -1;
        }
        private void Message()
        {
            string message = "Item almacenado correctamente";
            string title = "Exito";
            MessageBox.Show(message, title);
        }
        private void LlenarTipo()
        {
            List<string> listado = ni.ObtenerTipo().Select(x => x.Tipo).ToList(); ;
            cmbTipo.ItemsSource = listado;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.NombreItem = txtName.Text;
            inventario.Cantidad = Int32.Parse(txtStock.Text);
            decimal Tipoid = ni.ObtenerTipo().FirstOrDefault().IdTipo;
            inventario.TipoItemId = Tipoid;
            ni.InsertInv(inventario);
            Message();
            Limpiar();
        }
    }

}
