using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Negocio.ControladoresVistas
{
    public class ControladorMain
    {
        MainWindow main;
        ControladorCrear controladorCrear;
        public ControladorMain() 
        {
            main= new MainWindow();
            controladorCrear= new ControladorCrear();
            main.LoadCrear += Main_LoadCrear;
        }

        private void Main_LoadCrear()
        {
            controladorCrear.IniciarCrearCli();
        }
    }
}
