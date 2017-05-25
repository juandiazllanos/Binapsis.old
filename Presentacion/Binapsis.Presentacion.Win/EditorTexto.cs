using System.ComponentModel;
using Binapsis.Presentacion.Win.Diseñadores;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Win
{
    [ToolboxItem(true)]
    public partial class EditorTexto : EditorBase
    {
        public EditorTexto()
        {
            InitializeComponent();            
        }

        protected override void Inicializar()
        {
            Estilo = Estilo.TextSimpleEdit;
        }

        [Browsable(true)]
        [DefaultValue(Estilo.TextSimpleEdit)]
        [Editor(typeof(TypeEditorEstiloTexto), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
