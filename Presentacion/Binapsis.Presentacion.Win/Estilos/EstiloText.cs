using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;

namespace Binapsis.Presentacion.Win.Estilos
{
    internal class EstiloText : EstiloBase
    {
        RepositoryItemTextEdit _repositorio;
        MaskProperties _mask;

        public EstiloText(RepositoryItem repositorio) 
            : base(repositorio)
        {
        }

        protected override void EstablecerRepositorio(RepositoryItem repositorio)
        {
            base.EstablecerRepositorio(repositorio);
            _repositorio = (RepositoryItemTextEdit)repositorio;
            _mask = Repositorio.Mask;
            _mask.UseMaskAsDisplayFormat = true;
        }

        public new RepositoryItemTextEdit Repositorio
        {
            get { return _repositorio; }
        }


        public MaskType MaskType
        {
            get { return _mask.MaskType; }
            set { _mask.MaskType = value; }
        }

        public string EditMask
        {
            get { return _mask.EditMask; }
            set { _mask.EditMask = value; }
        }
    }
}
