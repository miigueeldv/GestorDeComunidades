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
    /// 
    /// </summary>
    public class PisoPropietario
    {
        /// <summary>
        /// Gets or sets the identifier piso.
        /// </summary>
        /// <value>
        /// The identifier piso.
        /// </value>
        public int IdPiso { get; set; }
        /// <summary>
        /// Gets or sets the dni.
        /// </summary>
        /// <value>
        /// The dni.
        /// </value>
        public string DNI { get; set; }
        /// <summary>
        /// Gets or sets the PPM.
        /// </summary>
        /// <value>
        /// The PPM.
        /// </value>
        public PisosPropietariosManager ppm { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PisoPropietario"/> class.
        /// </summary>
        /// <param name="idPiso">The identifier piso.</param>
        /// <param name="DNI">The dni.</param>
        public PisoPropietario(int idPiso, String DNI) { 
            this.IdPiso = idPiso;
            this.DNI = DNI;
            ppm = new PisosPropietariosManager();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PisoPropietario"/> class.
        /// </summary>
        public PisoPropietario()
        {
            ppm = new PisosPropietariosManager();
        }
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            ppm.insertPisosPropietarios(this);
        }
        /// <summary>
        /// Gets the informe.
        /// </summary>
        /// <param name="idComunidad">The identifier comunidad.</param>
        /// <returns></returns>
        public DataTable getInforme(int idComunidad)
        {
            return ppm.getInformeFin(idComunidad);
        }
        /// <summary>
        /// Gets the informe c.
        /// </summary>
        /// <param name="idComunidad">The identifier comunidad.</param>
        /// <returns></returns>
        public DataTable getInformeC(int idComunidad)
        {
            return ppm.getInformeCantidad(idComunidad);
        }
    }
}
