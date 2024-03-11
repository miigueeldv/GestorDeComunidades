using Comunidades.domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Comunidades.persistence.manager
{
    /// <summary>
    /// 
    /// </summary>
    public class ComunidadManager
    {
        /// <summary>
        /// Gets or sets the list comunidad.
        /// </summary>
        /// <value>
        /// The list comunidad.
        /// </value>
        public List<Comunidad> listComunidad { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComunidadManager"/> class.
        /// </summary>
        public ComunidadManager()
        {

            listComunidad = new List<Comunidad>();
        }
        /// <summary>
        /// Inserts the comunidad.
        /// </summary>
        /// <param name="comunidad">The comunidad.</param>
        public void insertComunidad(Comunidad comunidad)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            dBBroker.modificar("INSERT INTO comunidades (Nombre, Direccion, FechaCreacion, MetrosCuadrados, Piscina,PisoPortero,ZonaDuchas,ZonaParque,ZonaGym,ZonaReuniones,PistaTenis,PistaPadel) " +
                     "VALUES ('" + comunidad.Nombre +
                     "', '" + comunidad.Direccion +
                     "', '" + comunidad.FechaCreacion.ToString("yyyy-MM-dd") +
                     "', " + comunidad.MetrosCuadrados +
                     ", '" + comunidad.TienePiscina +
                     "', " + comunidad.idPisoPortero +
                     ", '" + comunidad.ZonaDuchas +
                     "', '" + comunidad.ZonaParque +
                     "', '" + comunidad.ZonaGym +
                     "', '" + comunidad.ZonaReuniones +
                     "', '" + comunidad.PistaTenis +
                     "','" + comunidad.PistaPadel + "')"
                     );
        }
        /// <summary>
        /// Devolvers the identifier comunidad.
        /// </summary>
        /// <param name="comunidad">The comunidad.</param>
        /// <returns></returns>
        public int DevolverIdComunidad(Comunidad comunidad)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            int id = -1;
            string consulta = "SELECT idComunidad FROM comunidades WHERE " +
                             "Nombre = '" + comunidad.Nombre + "' AND " +
                             "Direccion = '" + comunidad.Direccion + "' AND " +
                             "FechaCreacion = '" + comunidad.FechaCreacion.ToString("yyyy-MM-dd") + "' AND " +
                             "MetrosCuadrados = " + comunidad.MetrosCuadrados + " AND " +
                             "Piscina = '" + comunidad.TienePiscina + "'";

            List<object> resultados = dBBroker.leer(consulta);

            if (resultados != null && resultados.Count > 0)
            {
                // Obteniendo la primera fila (que es una lista)
                List<object> fila = resultados[0] as List<object>;
                if (fila != null && fila.Count > 0)
                {
                    // Intentar convertir el primer elemento de la fila a un entero
                    if (int.TryParse(fila[0].ToString(), out id))
                    {
                        return id;
                    }
                }
            }

            return id;
        }
        /// <summary>
        /// Actualizars the piso portero.
        /// </summary>
        /// <param name="idPiso">The identifier piso.</param>
        /// <param name="idcomunidad">The idcomunidad.</param>
        public void actualizarPisoPortero(int idPiso, int idcomunidad)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            dBBroker.modificar("UPDATE comunidades " +
                             "SET PisoPortero = " + idPiso +
                             " WHERE idComunidad = " + idcomunidad);
        }
        /// <summary>
        /// Gets the dependecias.
        /// </summary>
        /// <param name="idComunidad">The identifier comunidad.</param>
        /// <returns></returns>
        public DataTable getDependecias(int idComunidad)
        {

            List<Object> col = DBBroker.obtenerAgente().leer("SELECT Piscina,ZonaDuchas,ZonaParque,ZonaGym,ZonaReuniones,PistaTenis,PistaPadel FROM comunidades WHERE idComunidad = '" + idComunidad + "';");

            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("Dependencias");
            dt.Columns.Add(c1);

            DataRow row = null;
            foreach (List<Object> aux in col)
            {
                if (Char.Parse(aux[0].ToString()) == 'S' && aux[0] != null)
                {
                    row = dt.NewRow();
                    row[0] = "Piscina";
                    dt.Rows.Add(row);
                }
                if (Char.Parse(aux[1].ToString()) == 'S' && aux[1] != null)
                {
                    row = dt.NewRow();
                    row[0] = "Zona Duchas";
                    dt.Rows.Add(row);
                }
                if (Char.Parse(aux[2].ToString()) == 'S' && aux[2] != null)
                {
                    row = dt.NewRow();
                    row[0] = "Zona Parque";
                    dt.Rows.Add(row);
                }
                if (Char.Parse(aux[3].ToString()) == 'S' && aux[3] != null)
                {
                    row = dt.NewRow();
                    row[0] = "Zona Gym";
                    dt.Rows.Add(row);
                }
                if (Char.Parse(aux[4].ToString()) == 'S' && aux[4] != null)
                {
                    row = dt.NewRow();
                    row[0] = "Zona Reuniones";
                    dt.Rows.Add(row);
                }
                if (Char.Parse(aux[5].ToString()) == 'S' && aux[5] != null)
                {
                    row = dt.NewRow();
                    row[0] = "Zona Tenis";
                    dt.Rows.Add(row);
                }
                if (Char.Parse(aux[6].ToString()) == 'S' && aux[6] != null)
                {
                    row = dt.NewRow();
                    row[0] = "Zona Padel";
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        /// <summary>
        /// Gets the wb test.
        /// </summary>
        /// <returns></returns>
        public DataTable getWBTest()
        {
            List<Object> col = DBBroker.obtenerAgente().leer("SELECT SUBSTRING_INDEX(Apellidos, ' ', 1) AS PrimerApellido, COUNT(*) AS Cantidad FROM mydb.propietarios GROUP BY PrimerApellido;");

            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("Apellido");
            DataColumn c2 = new DataColumn("Cantidad");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            DataRow row = null;
            foreach (List<Object> aux in col)
            {
                row=dt.NewRow();
                row[0] = aux[0];
                row[1] = aux[1];
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
