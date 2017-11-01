using System.ComponentModel;
using Binapsis.Presentacion.Editores.Win.Diseñadores;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Editores.Win
{
    [ToolboxItem(true)]
    public partial class EditorFechaBoton : EditorBoton
    {
        public EditorFechaBoton()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            Estilo = Estilo.DateButtonEdit;
        }

        [Browsable(true)]
        [DefaultValue(Estilo.DateButtonEdit)]
        [Editor(typeof(TypeEditorEstiloFechaBoton), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
