using Comunidades.domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidades.persistence.manager
{
    /// <summary>
    /// 
    /// </summary>
    public class PisosManager
    {
        /// <summary>
        /// Gets or sets the list pisos.
        /// </summary>
        /// <value>
        /// The list pisos.
        /// </value>
        public List<Pisos> listPisos { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PisosManager"/> class.
        /// </summary>
        public PisosManager()
        {

            listPisos = new List<Pisos>();
        }
        /// <summary>
        /// Inserts the piso.
        /// </summary>
        /// <param name="piso">The piso.</param>
        public void insertPiso(Pisos piso)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            dBBroker.modificar("INSERT INTO pisos (NumPortal, NumEscalera, Planta, Letra, idComunidad, Parking, Trastero) " +
                    "VALUES (" + piso.NumPortal + ", " + piso.NumEscalera + ", " + piso.Planta + ", '" + piso.Letra + "', " +
                    piso.idComunidad + ", " + piso.Parking + ", " + piso.Trastero + ")");
        }
        /// <summary>
        /// Getids the piso.
        /// </summary>
        /// <param name="piso">The piso.</param>
        /// <returns></returns>
        public int getidPiso(Pisos piso)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            List<Object> resultado = dBBroker.leer("SELECT idPiso FROM pisos WHERE NumPortal = " + piso.NumPortal +
                                                   " AND NumEscalera = " + piso.NumEscalera +
                                                   " AND Planta = " + piso.Planta +
                                                   " AND Letra = '" + piso.Letra + "'" +
                                                   " AND idComunidad = " + piso.idComunidad);

            if (resultado != null && resultado.Count > 0)
            {
                List<Object> fila = (List<Object>)resultado[0]; // Primera fila
                if (fila != null && fila.Count > 0)
                {
                    if (int.TryParse(fila[0].ToString(), out int idPiso))
                    {
                        return idPiso;
                    }
                }
            }
            return -1;
        }
    }
}
