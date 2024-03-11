using Comunidades.domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Comunidades.persistence.manager
{
    /// <summary>
    /// 
    /// </summary>
    public class PropietariosManager
    {
        /// <summary>
        /// Gets or sets the list propietarios.
        /// </summary>
        /// <value>
        /// The list propietarios.
        /// </value>
        public List<Propietarios> listPropietarios { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropietariosManager"/> class.
        /// </summary>
        public PropietariosManager()
        {

            listPropietarios = new List<Propietarios>();
        }
        /// <summary>
        /// Inserts the propietarios.
        /// </summary>
        /// <param name="p">The p.</param>
        public void insertPropietarios(Propietarios p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            dBBroker.modificar("INSERT INTO propietarios (DNI, Nombre, Apellidos, DireccionResidencia, Localidad, CP, Provincia) " +
                "VALUES ('" + p.DNI + "', '" + p.Nombre + "', '" + p.Apellidos + "', '" + p.DireccionResidencia + "', '" +
                p.Localidad + "', '" + p.CP + "', '" + p.Provincia + "')");
        }
    }
}
