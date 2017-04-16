using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class EditorBase : IEditor
    {
        public virtual string Nombre { get; set; }
    }
}
