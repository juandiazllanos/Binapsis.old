using Binapsis.Presentacion.Win;

namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    public partial class VistaBase : EditorObjeto
    {
        public VistaBase()
        {
            InitializeComponent();
        }

        public IActividad Actividad
        {
            get;
            set;
        }
    }
}
