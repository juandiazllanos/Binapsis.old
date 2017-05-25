using Binapsis.Plataforma.Configuracion.Win.Comandos;

namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    public partial class VistaUri : VistaBase
    {
        public VistaUri()
        {
            InitializeComponent();
        }

        protected override void InicializarVista()
        {
            Establecer("Ensamblado.Nombre", Ensamblado);
            Establecer("Nombre", Nombre);
        }

        protected override void InicializarComando()
        {
            EstablecerComando(Ensamblado.Botones[0], new ComandoEstablecerElemento("Ensamblado", Ensamblado, Actividad.Controlador.Contexto));
        }
    }
}
