using Binapsis.Plataforma.Configuracion.Win.Comandos;

namespace Binapsis.Plataforma.Configuracion.Win.Vistas
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
            EstablecerComando(Base.Botones[0], new ComandoEstablecerElemento("Base", Base, Actividad.Controlador.Contexto));
            EstablecerComando(Uri.Botones[0], new ComandoEstablecerElemento("Uri", Uri, Actividad.Controlador.Contexto));
        }
    }
}
