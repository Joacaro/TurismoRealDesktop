using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TurismoReal.Vistas;

namespace TurismoReal.Negocio.ControladoresVistas
{
    public class ControladorCrear
    {
        public ControladorCrear()
        {
        }
        public void IniciarCrearCli()
        {
            Window ventana = null;
            ventana = new CrearCliente();
            ventana.Show();
        }
    }
}
