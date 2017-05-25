using Binapsis.Presentacion.Win.Diseñadores;
using System.ComponentModel;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Win
{
    public class ColumnaFechaBoton : ColumnaBoton
    {
        protected override void InicializarEstilo()
        {
            Estilo = Estilo.DateButtonEdit;
        }

        [DefaultValue(Estilo.DateButtonEdit)]
        [Editor(typeof(TypeEditorEstiloFechaBoton), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
