using Comunidades.domain;
using Org.BouncyCastle.Utilities;
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
using System.Xml.Linq;

namespace Comunidades.view
{
    /// <summary>
    /// Lógica de interacción para PaginaComunidad.xaml
    /// </summary>
    public partial class PaginaComunidad : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginaComunidad"/> class.
        /// </summary>
        public PaginaComunidad()
        {
            InitializeComponent();
            FechaCreacionDatePicker.SelectedDate = DateTime.Now;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Boolean todocorrecto = true;
                char piscina='S';

                DateTime? fechaSeleccionada = FechaCreacionDatePicker.SelectedDate;
                DateTime fecha=DateTime.Today; ;

                if (fechaSeleccionada.HasValue)
                {
                    fecha = fechaSeleccionada.Value;

                    if (!DateTime.TryParse(FechaCreacionDatePicker.Text, out fecha))
                    {
                        todocorrecto=false;
                    }
                }
                else
                {
                   todocorrecto=false;
                }

                if (PiscinaCheckBox.IsChecked != true)
                    {
                        piscina = 'N';
                    }

                if (NombreComunidadTextBox.Text == null || NombreComunidadTextBox.Text.ToString() == "" ||
                    DireccionTextBox.Text == null || DireccionTextBox.Text.ToString() == "" ||
                    MetrosCuadradosTextBox.Text == null || MetrosCuadradosTextBox.Text.ToString() == "" || 
                    NumPortales.Text == null || NumPortales.Text.ToString() == "")
                {
                    todocorrecto = false;
                }

                if (todocorrecto)
                {
                    if (MessageBox.Show("¿Quieres añadir esta comunidad?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        int NumP = Int32.Parse(NumPortales.Text.ToString());
                        Comunidad c = new Comunidad(NombreComunidadTextBox.Text.ToString(), DireccionTextBox.Text.ToString(), fecha, Int32.Parse(MetrosCuadradosTextBox.Text.ToString()), piscina);
                        Portales[] listPortales =new Portales[NumP];
                        this.NavigationService.Navigate(new Portal(c,NumP,listPortales));
                    }
                }
                else
                {
                    MessageBox.Show("Error al rellenar los datos");
                }
        }
        /// <summary>
        /// Handles the PreviewTextInput event of the MetrosCuadradosTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextCompositionEventArgs"/> instance containing the event data.</param>
        private void MetrosCuadradosTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
    }
}
