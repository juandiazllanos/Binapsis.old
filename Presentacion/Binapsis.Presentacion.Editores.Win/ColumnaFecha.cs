using Binapsis.Presentacion.Editores.Win.Diseñadores;
using System.ComponentModel;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Editores.Win
{
    public class ColumnaFecha : ColumnaTexto
    {
        protected override void InicializarEstilo()
        {
            Estilo = Estilo.DateEdit;
        }

        [DefaultValue(Estilo.DateEdit)]
        [Editor(typeof(TypeEditorEstiloFecha), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
