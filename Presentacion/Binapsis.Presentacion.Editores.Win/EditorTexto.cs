using System.ComponentModel;
using Binapsis.Presentacion.Editores.Win.Diseñadores;
using System.Drawing.Design;
using System;

namespace Binapsis.Presentacion.Editores.Win
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
