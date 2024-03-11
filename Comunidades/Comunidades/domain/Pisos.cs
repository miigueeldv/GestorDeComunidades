using Comunidades.persistence.manager;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidades.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Pisos
    {
        /// <summary>
        /// Gets or sets the number portal.
        /// </summary>
        /// <value>
        /// The number portal.
        /// </value>
        public int NumPortal { get; set; }
        /// <summary>
        /// Gets or sets the number escalera.
        /// </summary>
        /// <value>
        /// The number escalera.
        /// </value>
        public int NumEscalera { get; set; }
        /// <summary>
        /// Gets or sets the planta.
        /// </summary>
        /// <value>
        /// The planta.
        /// </value>
        public int Planta { get; set; }
        /// <summary>
        /// Gets or sets the letra.
        /// </summary>
        /// <value>
        /// The letra.
        /// </value>
        public char Letra { get; set; }
        /// <summary>
        /// Gets or sets the identifier comunidad.
        /// </summary>
        /// <value>
        /// The identifier comunidad.
        /// </value>
        public int idComunidad { get; set; }
        /// <summary>
        /// Gets or sets the parking.
        /// </summary>
        /// <value>
        /// The parking.
        /// </value>
        public int Parking { get; set; }
        /// <summary>
        /// Gets or sets the trastero.
        /// </summary>
        /// <value>
        /// The trastero.
        /// </value>
        public int Trastero { get; set; }
        /// <summary>
        /// Gets or sets the pm.
        /// </summary>
        /// <value>
        /// The pm.
        /// </value>
        public PisosManager pm { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Pisos"/> class.
        /// </summary>
        public Pisos()
        {
            pm = new PisosManager();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Pisos"/> class.
        /// </summary>
        /// <param name="numPortal">The number portal.</param>
        /// <param name="numEscalera">The number escalera.</param>
        /// <param name="planta">The planta.</param>
        /// <param name="letra">The letra.</param>
        /// <param name="idComunidad">The identifier comunidad.</param>
        /// <param name="parking">The parking.</param>
        /// <param name="trastero">The trastero.</param>
        public Pisos(int numPortal, int numEscalera, int planta, char letra, int idComunidad, int parking, int trastero)
        {
            this.NumPortal = numPortal;
            this.NumEscalera = numEscalera;
            this.Planta = planta;
            this.Letra = letra;
            this.idComunidad = idComunidad;
            this.Parking = parking;
            this.Trastero = trastero;
            pm = new PisosManager();
        }
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            pm.insertPiso(this);
        }
        /// <summary>
        /// Identifiers this instance.
        /// </summary>
        /// <returns></returns>
        public int id()
        {
            return pm.getidPiso(this);
        }
    }
}
