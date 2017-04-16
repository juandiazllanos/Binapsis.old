using Binapsis.Presentacion.Editores;
using System.Collections.Generic;
using System.Diagnostics;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class EditorColeccion : EditorBase, IEditorColeccion
    {
        List<EditorFila> _filas;

        public EditorColeccion()
        {
            _filas = new List<EditorFila>();
        }

        public EditorFila Crear()
        {
            EditorFila fila = new EditorFila(this);
            _filas.Add(fila);
            Debug.WriteLine(string.Format("EditorColeccion.Crear = Fila[{0}]", fila.Indice));
            Debug.WriteLine(string.Format("EditorColeccion.Items = {0}", _filas.Count));
            return fila;    
        }

        public void Remover(EditorFila fila)
        {
            if (!_filas.Contains(fila)) return;
            Debug.WriteLine(string.Format("EditorColeccion.Remover = Fila[{0}]", fila.Indice));
            _filas.Remove(fila);
            Debug.WriteLine(string.Format("EditorColeccion.Items = {0}", _filas.Count));       
        }

        public void RemoverTodo()
        {
            Debug.WriteLine(string.Format("EditorColeccion.RemoverTodo"));
            _filas.Clear();
        }

        public int Indice(EditorFila fila)
        {
            return _filas.IndexOf(fila);
        }

        public IReadOnlyList<EditorFila> Items => _filas; 

        IEditorFila IEditorColeccion.Crear()
        {
            return Crear();
        }

        void IEditorColeccion.Remover(IEditorFila fila)
        {
            Remover((EditorFila)fila);
        }

        void IEditorColeccion.RemoverTodo()
        {
            RemoverTodo();
        }

        public EditorColumna ColumnaBoolean { get; } = new EditorColumna() { Nombre = "EditorBoolean", Indice = 0 };
        public EditorColumna ColumnaByte { get; } = new EditorColumna() { Nombre = "EditorByte", Indice = 1 };
        public EditorColumna ColumnaChar { get; } = new EditorColumna() { Nombre = "EditorChar", Indice = 2 };
        public EditorColumna ColumnaDateTime { get; } = new EditorColumna() { Nombre = "EditorDateTime", Indice = 3 };
        public EditorColumna ColumnaDecimal { get; } = new EditorColumna() { Nombre = "EditorDecimal", Indice = 4 };
        public EditorColumna ColumnaDouble { get; } = new EditorColumna() { Nombre = "EditorDouble", Indice = 5 };
        public EditorColumna ColumnaFloat { get; } = new EditorColumna() { Nombre = "EditorFloat", Indice = 6 };
        public EditorColumna ColumnaInteger { get; } = new EditorColumna() { Nombre = "EditorInteger", Indice = 7 };
        public EditorColumna ColumnaLong { get; } = new EditorColumna() { Nombre = "EditorLong", Indice = 8 };
        public EditorColumna ColumnaSByte { get; } = new EditorColumna() { Nombre = "EditorSByte", Indice = 9 };
        public EditorColumna ColumnaShort { get; } = new EditorColumna() { Nombre = "EditorShort", Indice = 10 };
        public EditorColumna ColumnaString { get; } = new EditorColumna() { Nombre = "EditorString", Indice = 11 };
        public EditorColumna ColumnaUInteger { get; } = new EditorColumna() { Nombre = "EditorUInteger", Indice = 12 };
        public EditorColumna ColumnaULong { get; } = new EditorColumna() { Nombre = "EditorULong", Indice = 13 };
        public EditorColumna ColumnaUShort { get; } = new EditorColumna() { Nombre = "EditorUShort", Indice = 14 };

        public EditorColeccionReferencia ColumnaReferencia { get; } = new EditorColeccionReferencia() { Nombre = "EditorColeccionReferencia" };

    }
}
