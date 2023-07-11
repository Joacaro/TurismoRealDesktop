using System;
using System.Collections.Generic;
using System.Drawing;
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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document.
                PdfPage page = document.Pages.Add();
                //Create PDF graphics for a page.
                PdfGraphics graphics = page.Graphics;
                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                //Draw the text.
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
                //Save the document.
                document.Save("Output.pdf");
            }
        }
    }
}
