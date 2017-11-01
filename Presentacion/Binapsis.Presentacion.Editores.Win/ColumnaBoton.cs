using DevExpress.XtraEditors.Repository;
using System.ComponentModel;

namespace Binapsis.Presentacion.Editores.Win
{
    public class ColumnaBoton : ColumnaTexto
    {
        Botones _botones = new Botones();
        RepositoryItemButtonEdit _repositorio;

        protected override void InicializarEstilo()
        {
            Estilo = Estilo.ButtonEdit;
        }

        protected override void EstablecerRepositorio(RepositoryItem repositorio)
        {
            _botones.Clear();

            base.EstablecerRepositorio(repositorio);

            if (repositorio.GetType().IsSubclassOf(typeof(RepositoryItemButtonEdit)) || repositorio.GetType() == typeof(RepositoryItemButtonEdit))
                _repositorio = (RepositoryItemButtonEdit)repositorio;

            if (_repositorio == null) return;

            _botones.ButtonCollection = _repositorio.Buttons;
        }

        public Botones Botones
        {
            get { return _botones; }
        }

        [Browsable(false)]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
