﻿using System;
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

namespace TurismoReal.Vistas
{
    /// <summary>
    /// Lógica de interacción para AdminstrarReservas.xaml
    /// </summary>
    public partial class AdminstrarReservas : Window
    {
        public AdminstrarReservas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = new MenuAdministrador();
            ventana.Show();
            this.Close();
        }
    }
}
