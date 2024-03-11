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
    public class Portales
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
        /// Initializes a new instance of the <see cref="Portales"/> class.
        /// </summary>
        /// <param name="NumPortal">The number portal.</param>
        /// <param name="NumEscalera">The number escalera.</param>
        /// <param name="Planta">The planta.</param>
        /// <param name="Letra">The letra.</param>
        public Portales(int NumPortal, int NumEscalera, int Planta, char Letra)
        {
            this.NumPortal = NumPortal;
            this.NumEscalera = NumEscalera;
            this.Planta = Planta;
            this.Letra = Letra;
        }
    }
}