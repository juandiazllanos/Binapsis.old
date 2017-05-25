using DevExpress.XtraEditors.Repository;

namespace Binapsis.Presentacion.Win.Estilos
{
    internal class EstiloBase : IEstilo
    {
        RepositoryItem _repositoryItem;
        
        public EstiloBase(RepositoryItem repositorio)
        {
            Repositorio = repositorio;
        }

        protected virtual void EstablecerRepositorio(RepositoryItem repositorio)
        {
            _repositoryItem = repositorio;
        }
        
        public RepositoryItem Repositorio
        {
            get { return _repositoryItem; }
            set { EstablecerRepositorio(value); }
        }
        
    }
}
