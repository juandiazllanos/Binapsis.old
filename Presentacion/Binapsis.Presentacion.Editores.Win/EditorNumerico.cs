using Binapsis.Presentacion.Editores.Win.Diseñadores;
using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Editores.Win
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

        protected override object Obtener()
        {
            if (Estilo == Estilo.IntegerEdit || Estilo == Estilo.IntegerButtonEdit)
                return Convert.ToInt32(base.Obtener());
            if (Estilo == Estilo.DecimalEdit || Estilo == Estilo.DecimalButtonEdit)
                return Convert.ToDecimal(base.Obtener());
            else
                return base.Obtener();
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
