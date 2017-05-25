using Binapsis.Presentacion.Win.Diseñadores;
using System.ComponentModel;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Win
{
    public class ColumnaNumericoBoton : ColumnaBoton
    {
        protected override void InicializarEstilo()
        {
            Estilo = Estilo.DecimalButtonEdit;
        }

        [DefaultValue(Estilo.DecimalButtonEdit)]
        [Editor(typeof(TypeEditorEstiloNumericoBoton), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
