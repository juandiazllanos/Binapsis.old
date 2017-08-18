namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    public partial class VistaRelacion : VistaBase
    {
        public VistaRelacion()
        {
            InitializeComponent();
        }

        protected override void InicializarVista()
        {
            base.InicializarVista();
            Establecer("TipoAsociado", Tipo);
        }
    }
}
