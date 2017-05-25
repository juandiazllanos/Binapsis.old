using System.ComponentModel;

namespace Binapsis.Presentacion.Win
{
    public class ColumnaTextoBoton : ColumnaBoton
    {
        protected override void InicializarEstilo()
        {
            Estilo = Estilo.TextButtonEdit;
        }

        [Browsable(false)]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
