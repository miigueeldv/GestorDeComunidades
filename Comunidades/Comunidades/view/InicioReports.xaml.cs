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

namespace Comunidades.view
{
    /// <summary>
    /// Lógica de interacción para InicioReports.xaml
    /// </summary>
    public partial class InicioReports : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InicioReports"/> class.
        /// </summary>
        public InicioReports()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Handles the PreviewTextInput event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextCompositionEventArgs"/> instance containing the event data.</param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permite solo la entrada de numeros 
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
        /// <summary>
        /// Handles the Click event of the informe control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void informe_Click(object sender, RoutedEventArgs e)
        {
            if (comunidad.Text.Length > 0)
            {
                int idComunidad = Int32.Parse(comunidad.Text.ToString());
                VerInformePisos.Navigate(new VerInformePisosCantidad(idComunidad));
            }
        }
        /// <summary>
        /// Handles the Click event of the dependecias control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void dependecias_Click(object sender, RoutedEventArgs e)
        {
            int idComunidad = Int32.Parse(comunidad.Text.ToString());
            VerInformePisos.Navigate(new MostrarDependencias(idComunidad));
        }
    }
}
