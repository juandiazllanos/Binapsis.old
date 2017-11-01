using System.ComponentModel;
using Binapsis.Presentacion.Editores.Win.Diseñadores;
using System.Drawing.Design;
using System;

namespace Binapsis.Presentacion.Editores.Win
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
        [DefaultValue(Estilo.DecimalButtonEdit)]
        [Editor(typeof(TypeEditorEstiloNumericoBoton), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
