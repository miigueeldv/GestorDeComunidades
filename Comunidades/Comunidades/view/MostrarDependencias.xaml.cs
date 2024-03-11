using Comunidades.domain;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Comunidades.view
{
    /// <summary>
    /// Lógica de interacción para MostrarDependencias.xaml
    /// </summary>
    public partial class MostrarDependencias : Page
    {
        int idComunidad;
        /// <summary>
        /// Initializes a new instance of the <see cref="MostrarDependencias"/> class.
        /// </summary>
        /// <param name="idComunidad">The identifier comunidad.</param>
        public MostrarDependencias(int idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;

            Comunidad c = new Comunidad();
            DataTable dt = c.getInformeD(idComunidad);
            CrystalReport3 cr1 = new CrystalReport3();
            cr1.Database.Tables["DataTable3"].SetDataSource(dt);
            viewer.ViewerCore.ReportSource = cr1;
        }
    }
}
