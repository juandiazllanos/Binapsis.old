using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class EditorCelda : EditorAtributo
    {
        public EditorCelda(EditorBase propietario, IEditorFila fila, IEditorColumna columna)
            : base(propietario)
        {
            Fila = fila;
            Columna = columna;
        }

        public IEditorColumna Columna { get; }

        public IEditorFila Fila { get; }
    }
}
