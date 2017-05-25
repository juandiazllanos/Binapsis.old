using Binapsis.Plataforma.Configuracion.Win.Comandos;
using Binapsis.Presentacion.MVVM;
using Binapsis.Presentacion.MVVM.Mapeo;

namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    public partial class VistaUri : VistaBase
    {
        public VistaUri()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {   
            MapeoTipo mapeoEnsamblado = new MapeoTipo();
            mapeoEnsamblado.Establecer("Nombre", Ensamblado);
            
            MapeoTipo mapeo = new MapeoTipo();
            mapeo.Establecer("Ensamblado", mapeoEnsamblado);
            mapeo.Establecer("Nombre", Nombre);
            mapeo.EstablecerComando(Ensamblado.Botones[0], new ComandoEstablecerElemento("Ensamblado", Ensamblado, Actividad.Controlador.Contexto));

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(Estado);
        }
    }
}
