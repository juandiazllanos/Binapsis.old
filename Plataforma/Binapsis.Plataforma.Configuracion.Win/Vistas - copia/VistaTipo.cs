using Binapsis.Plataforma.Configuracion.Win.Comandos;
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

namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    public partial class VistaTipo : VistaBase
    {
        public VistaTipo()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            MapeoTipo mapeoUri = new MapeoTipo();
            mapeoUri.Establecer("Nombre", Uri);

            MapeoTipo mapeoBase = new MapeoTipo();
            mapeoBase.Establecer("Nombre", BaseNombre);

            MapeoTipo mapeo = new MapeoTipo();
            mapeo.Establecer("Uri", mapeoUri);
            mapeo.Establecer("Base", mapeoBase);
            mapeo.Establecer("Nombre", Nombre);
            mapeo.Establecer("Alias", Alias);
            mapeo.Establecer("EsTipoDeDato", EsTipoDeDato);
                        
            mapeo.EstablecerComando(Uri.Botones[0], new ComandoEstablecerElemento("Uri", Uri, Actividad.Controlador.Contexto));
            mapeo.EstablecerComando(BaseNombre.Botones[0], new ComandoEstablecerElemento("Base", BaseNombre, Actividad.Controlador.Contexto));

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(Estado);
        }
    }
}
