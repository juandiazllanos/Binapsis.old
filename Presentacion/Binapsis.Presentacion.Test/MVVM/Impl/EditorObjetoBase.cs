using Binapsis.Presentacion.Editores;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class EditorObjetoBase : EditorBase
    {
        protected List<IEditorAtributo> _editores;

        public EditorObjetoBase()
        {
            _editores = new List<IEditorAtributo>();
        }

        public IEditorAtributo this[string nombre]
        {
            get
            {
                return _editores.Where((item) => item.Nombre == nombre).FirstOrDefault();
            }
        }

    }
}
