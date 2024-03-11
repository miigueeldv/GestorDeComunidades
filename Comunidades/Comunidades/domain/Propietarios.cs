using Comunidades.persistence.manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Comunidades.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Propietarios
    {
        /// <summary>
        /// The random
        /// </summary>
        private static Random random = new Random();
        /// <summary>
        /// The nombres
        /// </summary>
        private static string[] nombres = { "Juan", "María", "Carlos", "Ana", "Pedro", "Laura", "Diego", "Elena", "Manuel", "Isabel" };
        /// <summary>
        /// The apellidos
        /// </summary>
        private static string[] apellidos = { "García", "López", "Martínez", "Fernández", "Rodríguez", "Sánchez", "Pérez", "González", "Torres", "Ramírez" };
        /// <summary>
        /// The direcciones
        /// </summary>
        private static string[] direcciones = { "Calle Real 24", "Avenida Libertad 56", "Plaza Mayor 78", "Carrera Norte 90", "Ronda Sur 12", "Calle Estación 34", "Paseo del Prado 56", "Camino Viejo 23", "Avenida de la Paz 45", "Calle Nueva 67" };
        /// <summary>
        /// The localidades
        /// </summary>
        private static string[] localidades = { "Sevilla", "Valencia", "Barcelona", "Bilbao", "Málaga", "Zaragoza", "A Coruña", "Las Palmas", "Tenerife", "Granada" };
        /// <summary>
        /// The codigos postales
        /// </summary>
        private static int[] codigosPostales = { 41001, 46002, 08001, 48001, 29001, 50001, 15001, 35001, 38001, 18002 };
        /// <summary>
        /// The provincias
        /// </summary>
        private static string[] provincias = { "Sevilla", "Valencia", "Barcelona", "Bizkaia", "Málaga", "Zaragoza", "A Coruña", "Las Palmas", "Santa Cruz de Tenerife", "Granada" };

        /// <summary>
        /// Gets or sets the dni.
        /// </summary>
        /// <value>
        /// The dni.
        /// </value>
        public string DNI { get; set; }
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; }
        /// <summary>
        /// Gets or sets the apellidos.
        /// </summary>
        /// <value>
        /// The apellidos.
        /// </value>
        public string Apellidos { get; set; }
        /// <summary>
        /// Gets or sets the direccion residencia.
        /// </summary>
        /// <value>
        /// The direccion residencia.
        /// </value>
        public string DireccionResidencia { get; set; }
        /// <summary>
        /// Gets or sets the localidad.
        /// </summary>
        /// <value>
        /// The localidad.
        /// </value>
        public string Localidad { get; set; }
        /// <summary>
        /// Gets or sets the cp.
        /// </summary>
        /// <value>
        /// The cp.
        /// </value>
        public int CP { get; set; }
        /// <summary>
        /// Gets or sets the provincia.
        /// </summary>
        /// <value>
        /// The provincia.
        /// </value>
        public string Provincia { get; set; }

        /// <summary>
        /// Gets or sets the pm.
        /// </summary>
        /// <value>
        /// The pm.
        /// </value>
        public PropietariosManager pm {  get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Propietarios"/> class.
        /// </summary>
        public Propietarios()
        {
            pm = new PropietariosManager();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Propietarios"/> class.
        /// </summary>
        /// <param name="dni">The dni.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="apellidos">The apellidos.</param>
        /// <param name="direccionResidencia">The direccion residencia.</param>
        /// <param name="localidad">The localidad.</param>
        /// <param name="cp">The cp.</param>
        /// <param name="provincia">The provincia.</param>
        public Propietarios(string dni, string nombre, string apellidos, string direccionResidencia, string localidad, int cp, string provincia)
        {
            this.DNI = dni;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.DireccionResidencia = direccionResidencia;
            this.Localidad = localidad;
            this.CP = cp;
            this.Provincia = provincia;
            pm = new PropietariosManager();
        }
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            pm.insertPropietarios(this);
        }

    }
}
