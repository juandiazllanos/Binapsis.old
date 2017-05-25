using System.ComponentModel;
using Binapsis.Presentacion.Win.Diseñadores;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Win
{
    [ToolboxItem(true)]
    public partial class EditorNumericoBoton : EditorBoton
    {
        public EditorNumericoBoton()
            : base()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            Estilo = Estilo.DecimalButtonEdit;
        }

        [Browsable(true)]
        [DefaultValue(Estilo.DecimalButtonEdit)]
        [Editor(typeof(TypeEditorEstiloNumericoBoton), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
