using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TurismoReal.Vistas;

namespace TurismoReal.Negocio.ControladoresVistas
{
    public class ControladorListarCliente
    {
        public ControladorListarCliente() 
        { }
        public void ListarCli()
        {
            Window ventana = null;
            ventana = new ListarCliente();
            ventana.Show();
        }
    }
}
