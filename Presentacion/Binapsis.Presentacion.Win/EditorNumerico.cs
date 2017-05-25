using Binapsis.Presentacion.Win.Diseñadores;
using System.ComponentModel;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Win
{
    [ToolboxItem(true)]
    public partial class EditorNumerico : EditorTexto
    {
        public EditorNumerico()
            : base()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            Estilo = Estilo.DecimalEdit;
        }

        [Browsable(true)]
        [DefaultValue(Estilo.DecimalEdit)]
        [Editor(typeof(TypeEditorEstiloNumerico), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }

    }
}
