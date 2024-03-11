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
    /// Lógica de interacción para CajaBlancaTest.xaml
    /// </summary>
    public partial class CajaBlancaTest : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CajaBlancaTest"/> class.
        /// </summary>
        public CajaBlancaTest()
        {
            InitializeComponent();
            Comunidad c=new Comunidad();
            DataTable dt = c.getCajaBlanca();
            CrystalReport4 cr4 = new CrystalReport4();
            cr4.Database.Tables["DataTable4"].SetDataSource(dt);
            WBViewer.ViewerCore.ReportSource = cr4;

        }
    }
}
