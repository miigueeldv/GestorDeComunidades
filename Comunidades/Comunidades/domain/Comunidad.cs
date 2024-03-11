using Comunidades.persistence.manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidades.domain
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class Comunidad
    {
        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        public string Nombre { get; set; }
        /// <summary>Gets or sets the direccion.</summary>
        /// <value>The direccion.</value>
        public string Direccion { get; set; }
        /// <summary>Gets or sets the fecha creacion.</summary>
        /// <value>The fecha creacion.</value>
        public DateTime FechaCreacion { get; set; }
        /// <summary>Gets or sets the metros cuadrados.</summary>
        /// <value>The metros cuadrados.</value>
        public Int32 MetrosCuadrados { get; set; }
        /// <summary>Gets or sets the tiene piscina.</summary>
        /// <value>The tiene piscina.</value>
        public char TienePiscina { get; set; }

        /// <summary>Gets or sets the portales.</summary>
        /// <value>The portales.</value>
        public Portales[] portales { get; set; }
        /// <summary>Gets or sets the cm.</summary>
        /// <value>The cm.</value>
        public ComunidadManager cm { get; set; }

        /// <summary>Gets or sets the identifier piso portero.</summary>
        /// <value>The identifier piso portero.</value>
        public Int32 idPisoPortero { get; set; }
        /// <summary>Gets or sets the zona duchas.</summary>
        /// <value>The zona duchas.</value>
        public char ZonaDuchas { get; set; }
        /// <summary>Gets or sets the zona parque.</summary>
        /// <value>The zona parque.</value>
        public char ZonaParque { get; set; }
        /// <summary>Gets or sets the zona gym.</summary>
        /// <value>The zona gym.</value>
        public char ZonaGym { get; set; }
        /// <summary>Gets or sets the zona reuniones.</summary>
        /// <value>The zona reuniones.</value>
        public char ZonaReuniones { get; set; }
        /// <summary>Gets or sets the pista tenis.</summary>
        /// <value>The pista tenis.</value>
        public char PistaTenis { get; set; }
        /// <summary>Gets or sets the pista padel.</summary>
        /// <value>The pista padel.</value>
        public char PistaPadel { get; set; }
        /// <summary>Initializes a new instance of the <see cref="Comunidad" /> class.</summary>
        public Comunidad()
        {
            cm = new ComunidadManager();
        }
        /// <summary>Initializes a new instance of the <see cref="Comunidad" /> class.</summary>
        /// <param name="nombre">The nombre.</param>
        /// <param name="direccion">The direccion.</param>
        /// <param name="fechaCreacion">The fecha creacion.</param>
        /// <param name="metrosCuadrados">The metros cuadrados.</param>
        /// <param name="tienePiscina">The tiene piscina.</param>
        public Comunidad(string nombre, string direccion, DateTime fechaCreacion, Int32 metrosCuadrados, char tienePiscina)
        {
            Nombre = nombre;
            Direccion = direccion;
            FechaCreacion = fechaCreacion;
            MetrosCuadrados = metrosCuadrados;
            TienePiscina = tienePiscina;
            cm = new ComunidadManager();
            idPisoPortero = 0;
            ZonaDuchas = 'N';
            ZonaParque = 'N';
            ZonaGym = 'N';
            ZonaReuniones = 'N';
            PistaTenis = 'N';
            PistaPadel = 'N';

        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            cm.insertComunidad(this);
        }

        /// <summary>
        /// Identifiers this instance.
        /// </summary>
        /// <returns></returns>
        public int id()
        {
            return cm.DevolverIdComunidad(this);
        }
        /// <summary>
        /// Actualizars the piso portero.
        /// </summary>
        /// <param name="idPiso">The identifier piso.</param>
        /// <param name="idcomunidad">The idcomunidad.</param>
        public void actualizarPisoPortero(int idPiso, int idcomunidad)
        {
            cm.actualizarPisoPortero(idPiso,idcomunidad);
        }
        /// <summary>
        /// Gets the informe d.
        /// </summary>
        /// <param name="idComunidad">The identifier comunidad.</param>
        /// <returns></returns>
        public DataTable getInformeD(int idComunidad)
        {
            return cm.getDependecias(idComunidad);
        }
        /// <summary>
        /// Gets the caja blanca.
        /// </summary>
        /// <returns></returns>
        public DataTable getCajaBlanca()
        {
            return cm.getWBTest();
        }
    }
}
