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
    /// Lógica de interacción para VerInforme.xaml
    /// </summary>
    public partial class VerInforme : Page
    {
        /// <summary>
        /// The c
        /// </summary>
        Comunidad c;
        /// <summary>
        /// Initializes a new instance of the <see cref="VerInforme"/> class.
        /// </summary>
        /// <param name="c">The c.</param>
        public VerInforme(Comunidad c)
        {
            InitializeComponent();
            this.c = c;
            PisoPropietario pp = new PisoPropietario();
            DataTable dt=pp.getInforme(c.id());
            CrystalReport1 cr1=new CrystalReport1();
            cr1.Database.Tables["DataTable1"].SetDataSource(dt);
            cViewer.ViewerCore.ReportSource = cr1;
        }
    }
}
