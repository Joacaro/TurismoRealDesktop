using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.Vistas;

namespace TurismoReal.Negocio.ControladoresVistas
{
    public class ControladorMain
    {
        MainWindow main;
        ControladorCrear controladorCrear;
        ControladorListarCliente controladorListarCliente;
        public ControladorMain() 
        {
            main= new MainWindow();
            controladorCrear= new ControladorCrear();
            controladorListarCliente= new ControladorListarCliente();
            main.LoadCrear += Main_LoadCrear;
            main.ListarCliente += Main_ListarCliente;
        }

        private void Main_ListarCliente()
        {
            controladorListarCliente.ListarCli();
        }

        private void Main_LoadCrear()
        {
            controladorCrear.IniciarCrearCli();
        }
    }
}
