using Binapsis.Presentacion.MVVM;
using Binapsis.Presentacion.MVVM.Mapeo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win.Vistas2
{
    public partial class VistaEnsamblado : VistaBase
    {
        public VistaEnsamblado()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            MapeoTipo mapeo = new MapeoTipo();
            mapeo.Establecer("Nombre", Nombre);

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(Estado);
        }
    }
}
