using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace Binapsis.Presentacion.Editores.Win.Estilos
{
    internal class EstiloEditorBase : IEstilo
    {
        EstiloBase _estiloBase;
        BaseEdit _baseEdit;

        public EstiloEditorBase(EstiloBase estilo)
        {
            _estiloBase = estilo;
            Editor = Repositorio.CreateEditor();
        }
        
        protected virtual void EstablecerEditor(BaseEdit editor)
        {
            _baseEdit = editor;
        }

        public BaseEdit Editor
        {
            get { return _baseEdit; }
            set { EstablecerEditor(value); }
        }
        
        public virtual int MaximoAlto
        {
            get { return Editor?.Size.Height ?? 0; }
        }

        public RepositoryItem Repositorio
        {
            get { return _estiloBase.Repositorio; }
        }
    }
}
