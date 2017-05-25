using System.ComponentModel;

namespace Binapsis.Presentacion.Win
{
    public class ColumnaBoolean : Columna
    {
        protected override void InicializarEstilo()
        {
            Estilo = Estilo.CheckEdit;
        }

        [Browsable(false)]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
