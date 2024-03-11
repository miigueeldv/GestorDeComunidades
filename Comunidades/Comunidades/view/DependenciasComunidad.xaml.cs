using Comunidades.domain;
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
using static System.Net.Mime.MediaTypeNames;

namespace Comunidades.view
{
    /// <summary>
    /// Lógica de interacción para DependenciasComunidad.xaml
    /// </summary>
    public partial class DependenciasComunidad : Page
    {
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
        private List<Pisos> todoslospisos;
        /// <summary>
        /// Initializes a new instance of the <see cref="DependenciasComunidad"/> class.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="listPortales">The list portales.</param>
        /// <param name="todoslospisos">The todoslospisos.</param>
        public DependenciasComunidad(Comunidad c, Portales[] listPortales, List<Pisos> todoslospisos) {
        
            InitializeComponent();
            this.c = c;
            this.listPortales = listPortales;
            this.todoslospisos=todoslospisos;
        }
        /// <summary>
        /// Handles the 1 event of the Finalizar_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Finalizar_Click_1(object sender, RoutedEventArgs e)
        {
            //Actualizamos la comunidad para ponerle los datos dependiendo de lo que hemos marcado
            char PisoPortero='N';
            if (CHPisoPortero.IsChecked == true)
            {
                PisoPortero = 'S';
            }
            if (CHZonaDuchas.IsChecked == true)
            {
                c.ZonaDuchas = 'S';
            }
            if (CHZonaInfantil.IsChecked == true)
            {
                c.ZonaParque = 'S';
            };
            if (CHGym.IsChecked == true)
            {
                c.ZonaGym = 'S';
            }
            if (CHSalaReuniones.IsChecked == true)
            {
                c.ZonaReuniones = 'S';
            }
            if (CHPistaTenis.IsChecked == true)
            {
                c.PistaTenis = 'S';
            }
            if (CHPisoPadel.IsChecked == true)
            {
                c.PistaPadel = 'S'; 
            }

            c.portales = listPortales;
            MessageBox.Show("CREANDO TODO... " + CalcularPisosComunidad(listPortales) + " Pisos");

            //Lista de propietarios
            List<Propietarios> propietarios = CrearPropietarios(CalcularPisosComunidad(listPortales));

            foreach (Propietarios propietario in propietarios)
            {
                propietario.insert();
            }
            //Inserto la comunidad
            c.insert();
            //Saco el ID  dela comunidad
            int idComunidad = c.id();
            PisoPropietario pp = null;
            int i = 0;
            foreach (var item in todoslospisos)
            {
                item.idComunidad = idComunidad;
                item.insert();
                
                if (PisoPortero == 'S' && i == 0)
                {
                    c.actualizarPisoPortero(item.id(), idComunidad);
                }

                //Le asignamos un piso a cada propietario
                pp = new PisoPropietario(item.id(), propietarios[i].DNI);
                pp.insert();
                i++;
            }
            MessageBox.Show("TODO HA FINALIZADO CORRECTAMENTE");
            Finalizar.Visibility = Visibility.Hidden;
            VerInforme.Visibility = Visibility.Visible;
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
        /// Crears the propietarios.
        /// </summary>
        /// <param name="cantidad">The cantidad.</param>
        /// <returns></returns>
        public List<Propietarios> CrearPropietarios(int cantidad)
        {
            List<string> nombres = new List<string> { "Juan", "María", "Carlos", "Ana", "Luis", "Sofía", "José", "Elena", "Pablo", "Carmen" };
            List<string> apellidos = new List<string> { "García Pérez", "López Martínez", "González Rodríguez", "Fernández Gómez", "Martínez Sánchez", "Sánchez Díaz", "Pérez Jiménez", "Gómez Ruiz", "Ruiz López", "Díaz Morales" };
            List<string> direcciones = new List<string> { "Calle Mayor 1", "Avenida Libertad 23", "Plaza del Sol 45", "Calle Nueva 12", "Ronda de Toledo 5", "Calle del Prado 8", "Avenida de la Paz 16", "Paseo de la Castellana 30", "Calle de Alcalá 21", "Gran Vía 56" };
            List<string> localidades = new List<string> { "Madrid", "Barcelona", "Valencia", "Sevilla", "Zaragoza", "Málaga", "Murcia", "Palma", "Las Palmas", "Bilbao" };
            List<int> codigosPostales = new List<int> { 28001, 08001, 46001, 41001, 50001, 29001, 30001, 07001, 35001, 48001 };
            List<string> provincias = new List<string> { "Madrid", "Barcelona", "Valencia", "Sevilla", "Zaragoza", "Málaga", "Murcia", "Islas Baleares", "Las Palmas", "Vizcaya" };
            List<Propietarios> propietarios = new List<Propietarios>();
            GeneradorDNI generador = new GeneradorDNI();
            for (int i = 0; i < cantidad; i++)
            {
                propietarios.Add(new Propietarios
                (
                    generador.GenerarDNINuevo(),
                    ObtenerElementoAleatorio(nombres),
                    ObtenerElementoAleatorio(apellidos),
                    ObtenerElementoAleatorio(direcciones),
                    ObtenerElementoAleatorio(localidades),
                    ObtenerElementoAleatorio(codigosPostales),
                    ObtenerElementoAleatorio(provincias)
                ));
            }

            return propietarios;
        }
        /// <summary>
        /// Obteners the elemento aleatorio.
        /// </summary>
        /// <param name="lista">The lista.</param>
        /// <returns></returns>
        private string ObtenerElementoAleatorio(List<string> lista)
        {
            return lista[random.Next(lista.Count)];
        }
        /// <summary>
        /// Obteners the elemento aleatorio.
        /// </summary>
        /// <param name="lista">The lista.</param>
        /// <returns></returns>
        private int ObtenerElementoAleatorio(List<int> lista)
        {
            return lista[random.Next(lista.Count)];
        }
        /// <summary>
        /// Handles the Click event of the VerInforme control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void VerInforme_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VerInforme(this.c));
        }
    }
}
