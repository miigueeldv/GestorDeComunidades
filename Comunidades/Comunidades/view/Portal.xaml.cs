using Comunidades.domain;
using Comunidades.persistence.manager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace Comunidades.view
{
    /// <summary>
    /// Lógica de interacción para Portal.xaml
    /// </summary>
    public partial class Portal : Page
    {
        /// <summary>
        /// The numero portal actual
        /// </summary>
        private int numeroPortalActual = 1;
        /// <summary>
        /// The list portales
        /// </summary>
        Portales[] listPortales;
        /// <summary>
        /// The c
        /// </summary>
        Comunidad c;
        /// <summary>
        /// The number portales
        /// </summary>
        private int NumPortales;
        /// <summary>
        /// The random
        /// </summary>
        private Random random = new Random();
        /// <summary>
        /// The todoslospisos
        /// </summary>
        List<Pisos> todoslospisos;
        /// <summary>
        /// Initializes a new instance of the <see cref="Portal"/> class.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="NumPortales">The number portales.</param>
        /// <param name="listPortales">The list portales.</param>
        public Portal(Comunidad c, int NumPortales, Portales[] listPortales)
        {
            InitializeComponent();
            this.c = c;
            this.listPortales = listPortales;
            this.NumPortales = NumPortales;
            todoslospisos = new List<Pisos>();
        }
        /// <summary>
        /// Handles the Click event of the Next control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            //Comprobamos si los campos estan rellenados
            if (NumEscaleras.Text.ToString() == "" || NumEscaleras.Text == null ||
                Plantas.Text.ToString() == "" || Plantas.Text == null ||
                Letras.Text.Length < 1)
            {
                MessageBox.Show("Debes rellenar todos los datos");
            }
            else
            {
                Anterior.IsEnabled = true;

                //Se crea el portal y lo añadimos a la lista
                if (listPortales[numeroPortalActual - 1] == null)
                {
                    // Si el portal actual aún no ha sido creado, crea uno nuevo
                    Portales p = new Portales(numeroPortalActual, Int32.Parse(NumEscaleras.Text), Int32.Parse(Plantas.Text), char.ToUpper(Letras.Text[0]));
                    listPortales[numeroPortalActual - 1] = p;
                }
                else
                {
                    listPortales[numeroPortalActual - 1].NumEscalera = Int32.Parse(NumEscaleras.Text);
                    listPortales[numeroPortalActual - 1].Planta = Int32.Parse(Plantas.Text);
                    listPortales[numeroPortalActual - 1].Letra = char.ToUpper(Letras.Text[0]);
                }

                // Incrementar el contador del portal y actualizar el título
                numeroPortalActual++;

                if (numeroPortalActual <= this.NumPortales)
                {
                    TBText.Text = $"CREACIÓN DEL PORTAL {numeroPortalActual}";

                    if (listPortales[numeroPortalActual - 1] != null)
                    {
                        //Si existe el portal lo cargamos, para cuando volvemos al anterior y le damos al siguiente
                        Portales p = listPortales[numeroPortalActual - 1];
                        NumEscaleras.Text = p.NumEscalera.ToString();
                        Plantas.Text = p.Planta.ToString();
                        Letras.Text = p.Letra.ToString();
                    }
                    else
                    {
                        //Limpiamos
                        NumEscaleras.Text = "";
                        Plantas.Text = "";
                        Letras.Text = "";
                    }
                }
                else
                {
                    //Almaceno la lista de portales en el array que esta dentro de comunidad
                    c.portales = listPortales;
                    Random random = new Random();
                    List<int> numerosGenerados = new List<int>();
                    int numeroParking;
                    int numeroTrastero;

                    int CantidadPisos = CalcularPisosComunidad(listPortales);

                    Pisos piso = null;
                    int idComunidad = 0;
                    var query = listPortales.SelectMany(
                    portal => Enumerable.Range(0, portal.Planta),
                    (portal, planta) => new { Portal = portal, Planta = planta })
                        .SelectMany(
                            x => Enumerable.Range(1, x.Portal.NumEscalera),
                            (x, escalera) => new { x.Portal, x.Planta, Escalera = escalera })
                            .SelectMany(
                                x => Enumerable.Range(65, (int)x.Portal.Letra - 64),
                                (x, letra) => new { x.Portal, x.Planta, x.Escalera, Letra = (char)letra });

                    foreach (var item in query)
                    {
                        if (numerosGenerados.Count >= CantidadPisos)
                        {
                            // Todos los números posibles ya han sido generado
                            break;
                        }

                        do
                        {
                            numeroParking = random.Next(1, CantidadPisos + 1);
                            numeroTrastero = numeroParking;
                        } while (numerosGenerados.Contains(numeroParking));

                        numerosGenerados.Add(numeroParking);
                        piso = new Pisos(item.Portal.NumPortal, item.Escalera, item.Planta, item.Letra, idComunidad, numeroParking, numeroTrastero);
                        todoslospisos.Add(piso);
                    }
                    paginaDepedencias.Navigate(new DependenciasComunidad(c, listPortales, todoslospisos));
                }
            }
        }
        /// <summary>
        /// Calculars the pisos comunidad.
        /// </summary>
        /// <param name="portales">The portales.</param>
        /// <returns></returns>
        public int CalcularPisosComunidad(Portales[] portales)
        {
            int totalPisosComunidad = 0;

            foreach (var portal in portales)
            {
                // Calcula el número total de pisos para cada portal multiplicando el número de plantas por el número de letras.
                int totalPisosPortal = portal.Planta * ((int)(portal.Letra) - 'A' + 1) * portal.NumEscalera;

                // Suma el total de pisos del portal al total de la comunidad.
                totalPisosComunidad += totalPisosPortal;
            }

            return totalPisosComunidad;
        }
        /// <summary>
        /// Handles the Click event of the Anterior control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            numeroPortalActual--;

            TBText.Text = $"CREACIÓN DEL PORTAL {numeroPortalActual}";

            if (numeroPortalActual < 1)
            {
                Anterior.IsEnabled = false;
                numeroPortalActual = 1;
            }
            else
            {
                Next.IsEnabled = true;
                if (listPortales[numeroPortalActual - 1] != null)
                {
                    Portales p = listPortales[numeroPortalActual - 1];
                    NumEscaleras.Text = p.NumEscalera.ToString();
                    Plantas.Text = p.Planta.ToString();
                    Letras.Text = p.Letra.ToString().ToUpper();
                }
                else
                {
                    listPortales[numeroPortalActual - 1].NumEscalera = Int32.Parse(NumEscaleras.Text);
                    listPortales[numeroPortalActual - 1].Planta = Int32.Parse(Plantas.Text);
                    listPortales[numeroPortalActual - 1].Letra = Letras.Text[0];
                }
                if (numeroPortalActual == 1)
                {
                    Anterior.IsEnabled = false;
                }
            }
        }
        /// <summary>
        /// Handles the PreviewTextInput event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextCompositionEventArgs"/> instance containing the event data.</param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!SoloLetras(e.Text))
            {
                e.Handled = true; // Rechaza la entrada si no son solo letras
            }
        }
        /// <summary>
        /// Handles the PreviewTextInput event of the SoloNumeros control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextCompositionEventArgs"/> instance containing the event data.</param>
        private void SoloNumeros_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        /// Soloes the letras.
        /// </summary>
        /// <param name="entrada">The entrada.</param>
        /// <returns></returns>
        private bool SoloLetras(string entrada)
        {
            return Regex.IsMatch(entrada, @"^[a-zA-Z]+$");
        }
    }
      
}
