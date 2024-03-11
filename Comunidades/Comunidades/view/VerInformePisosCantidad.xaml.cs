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
    /// Lógica de interacción para VerInformePisosCantidad.xaml
    /// </summary>
    public partial class VerInformePisosCantidad : Page
    {
        /// <summary>
        /// The identifier comunidad
        /// </summary>
        int idComunidad;
        /// <summary>
        /// Initializes a new instance of the <see cref="VerInformePisosCantidad"/> class.
        /// </summary>
        /// <param name="idComunidad">The identifier comunidad.</param>
        public VerInformePisosCantidad(int idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            PisoPropietario pp = new PisoPropietario();
            DataTable dt = pp.getInformeC(idComunidad);
            CrystalReport2 cr1 = new CrystalReport2();
            cr1.Database.Tables["DataTable2"].SetDataSource(dt);
            viewer.ViewerCore.ReportSource = cr1;
        }


    }
}
