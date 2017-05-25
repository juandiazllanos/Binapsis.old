using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Binapsis.Presentacion.Win.Estilos
{
    internal  class EstiloButton : EstiloText
    {
        RepositoryItemButtonEdit _repositorio;

        public EstiloButton(RepositoryItem repositorio) 
            : base(repositorio)
        {
        }

        protected override void EstablecerRepositorio(RepositoryItem repositorio)
        {
            base.EstablecerRepositorio(repositorio);
            _repositorio = (RepositoryItemButtonEdit)repositorio;
        }

        public new RepositoryItemButtonEdit Repositorio
        {
            get { return _repositorio; }
        }

        //public bool ShowTextEditor
        //{
        //    get { return _repositorio.TextEditStyle == TextEditStyles.Standard; }
        //    set { _repositorio.TextEditStyle = value ? TextEditStyles.Standard : TextEditStyles.HideTextEditor; }
        //}
    }
}
