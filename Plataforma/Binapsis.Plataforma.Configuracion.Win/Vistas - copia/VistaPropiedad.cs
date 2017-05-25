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
    public partial class VistaPropiedad : VistaBase
    {
        public VistaPropiedad()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            MapeoTipo mapeoTipo = new MapeoTipo();
            mapeoTipo.Establecer("Nombre", TipoAsociado);

            MapeoTipo mapeo = new MapeoTipo();
            mapeo.Establecer("Tipo", mapeoTipo);
            mapeo.Establecer("Nombre", Nombre);
            mapeo.Establecer("Alias", Alias);
            mapeo.Establecer("ValorInicial", ValorInicial);
            mapeo.Establecer("Indice", Indice);

            mapeo.EstablecerComando(TipoAsociado.Botones[0], new ComandoEstablecerElemento("TipoAsociado", TipoAsociado, Actividad.Controlador.Contexto));

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(Estado);
        }
    }
}
