using Binapsis.Presentacion.Editores.Win.Diseñadores;
using DevExpress.XtraEditors.Repository;
using System.ComponentModel;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Editores.Win
{
    public class ColumnaTexto : Columna
    {
        RepositoryItemTextEdit _repositorio;

        protected override void InicializarEstilo()
        {
            Estilo = Estilo.TextSimpleEdit;
        }

        protected override void EstablecerRepositorio(RepositoryItem repositorio)
        {
            base.EstablecerRepositorio(repositorio);

            if (repositorio.GetType().IsSubclassOf(typeof(RepositoryItemTextEdit)) || repositorio.GetType() == typeof(RepositoryItemTextEdit))
                _repositorio = (RepositoryItemTextEdit)repositorio;
        }

        protected new RepositoryItemTextEdit Repositorio
        {
            get { return _repositorio; }
        }

        [DefaultValue(Estilo.TextSimpleEdit)]
        [Editor(typeof(TypeEditorEstiloTexto), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}
