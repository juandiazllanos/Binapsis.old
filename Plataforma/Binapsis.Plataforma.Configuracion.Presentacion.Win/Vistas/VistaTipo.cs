using Binapsis.Plataforma.Configuracion.Presentacion.Win.Comandos;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    public partial class VistaTipo : VistaBase
    {
        public VistaTipo()
        {
            InitializeComponent();
        }

        protected override void InicializarVista()
        {
            Establecer("Base.Nombre", Base);
            Establecer("Uri.Nombre", Uri);
            Establecer("Nombre", Nombre);
            Establecer("Alias", Alias);
            Establecer("EsTipoDeDato", EsTipoDeDato);
        }

        protected override void InicializarComando()
        {
            EstablecerComando(Base.Botones[0], new SeleccionarReferencia("Base", Base, "listarTipoPorNombre"));
            EstablecerComando(Uri.Botones[0], new SeleccionarReferencia("Uri", Uri, "listarUriPorNombre"));
        }
    }
}
