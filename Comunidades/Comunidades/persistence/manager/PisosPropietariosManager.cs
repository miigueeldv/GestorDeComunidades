using Comunidades.domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Comunidades.persistence.manager
{
    /// <summary>
    /// 
    /// </summary>
    public class PisosPropietariosManager
    {
        /// <summary>
        /// Gets or sets the list piso propietarios.
        /// </summary>
        /// <value>
        /// The list piso propietarios.
        /// </value>
        public List<PisoPropietario> listPisoPropietarios { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PisosPropietariosManager"/> class.
        /// </summary>
        public PisosPropietariosManager()
        {

            listPisoPropietarios = new List<PisoPropietario>();
        }
        /// <summary>
        /// Inserts the pisos propietarios.
        /// </summary>
        /// <param name="p">The p.</param>
        public void insertPisosPropietarios(PisoPropietario p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            dBBroker.modificar("INSERT INTO piso_propietario (idPiso, DNI) " +
                "VALUES (" + p.IdPiso + ", '" + p.DNI + "')");
        }
        /// <summary>
        /// Gets the informe fin.
        /// </summary>
        /// <param name="idComunidad">The identifier comunidad.</param>
        /// <returns></returns>
        public DataTable getInformeFin(int idComunidad)
        {

            List<Object> col = DBBroker.obtenerAgente().leer("SELECT CONCAT(ps.planta,'º',ps.letra) AS planta_letra, CONCAT( pr.nombre,' ',pr.apellidos) AS nombreapellidos " +
                "FROM pisos ps JOIN piso_propietario pp ON ps.idpiso = pp.idpiso JOIN propietarios pr ON pp.dni = pr.dni " +
                "WHERE ps.idComunidad = '"+idComunidad+"';");

            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("Piso");
            DataColumn c2 = new DataColumn("Propietario");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);

            DataRow row = null;
            foreach (List<Object> aux in col)
            {
                row = dt.NewRow();
                row[0] = aux[0];
                row[1] = aux[1];
                dt.Rows.Add(row);
            }

            return dt;
        }
        /// <summary>
        /// Gets the informe cantidad.
        /// </summary>
        /// <param name="idComunidad">The identifier comunidad.</param>
        /// <returns></returns>
        public DataTable getInformeCantidad(int idComunidad) {
            List<Object> col = DBBroker.obtenerAgente().leer("SELECT ps.NumPortal, ps.NumEscalera, ps.Planta, ps.Letra, COUNT(*) AS NumPropietarios " +
                "FROM pisos ps " +
                "JOIN piso_propietario pp ON ps.idpiso = pp.idpiso " +
                "JOIN propietarios pr ON pp.dni = pr.dni " +
                "WHERE ps.idComunidad = '" + idComunidad + "' " +
                "GROUP BY ps.NumPortal, ps.NumEscalera, ps.Planta, ps.Letra;");

            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("Portal");
            DataColumn c2 = new DataColumn("Escalera");
            DataColumn c3 = new DataColumn("Planta");
            DataColumn c4 = new DataColumn("Letra");
            DataColumn c5 = new DataColumn("Propietarios");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);

            DataRow row = null;
            foreach (List<Object> aux in col)
            {
                row = dt.NewRow();
                row[0] = aux[0];
                row[1] = aux[1];
                row[2] = aux[2];
                row[3] = aux[3];
                row[4] = aux[4];
                dt.Rows.Add(row);
            }

            return dt;
        }


    }
}
