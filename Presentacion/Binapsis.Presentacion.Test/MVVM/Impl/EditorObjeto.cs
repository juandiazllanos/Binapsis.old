using Binapsis.Presentacion.Editores;
using System.Linq;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class EditorObjeto : EditorObjetoBase
    {
        

        public EditorObjeto()
        {
            _editores.Add(EditorBoolean = new EditorAtributo(this) { Nombre = "EditorBoolean" });
            _editores.Add(EditorByte = new EditorAtributo(this) { Nombre = "EditorByte" });
            _editores.Add(EditorChar = new EditorAtributo(this) { Nombre = "EditorChar" });
            _editores.Add(EditorDateTime = new EditorAtributo(this) { Nombre = "EditorDateTime" });
            _editores.Add(EditorDecimal = new EditorAtributo(this) { Nombre = "EditorDecimal" });
            _editores.Add(EditorDouble = new EditorAtributo(this) { Nombre = "EditorDouble" });
            _editores.Add(EditorFloat = new EditorAtributo(this) { Nombre = "EditorFloat" });
            _editores.Add(EditorInteger = new EditorAtributo(this) { Nombre = "EditorInteger" });
            _editores.Add(EditorLong = new EditorAtributo(this) { Nombre = "EditorLong" });
            _editores.Add(EditorSByte = new EditorAtributo(this) { Nombre = "EditorSByte" });
            _editores.Add(EditorShort = new EditorAtributo(this) { Nombre = "EditorShort" });
            _editores.Add(EditorString = new EditorAtributo(this) { Nombre = "EditorString" });
            _editores.Add(EditorUInteger = new EditorAtributo(this) { Nombre = "EditorUInteger" });
            _editores.Add(EditorULong = new EditorAtributo(this) { Nombre = "EditorULong" });
            _editores.Add(EditorUShort = new EditorAtributo(this) { Nombre = "EditorUShort" });
        }
        
        public EditorAtributo EditorBoolean { get; }
        public EditorAtributo EditorByte { get; } 
        public EditorAtributo EditorChar { get; } 
        public EditorAtributo EditorDateTime { get; } 
        public EditorAtributo EditorDecimal { get; } 
        public EditorAtributo EditorDouble { get; } 
        public EditorAtributo EditorFloat { get; } 
        public EditorAtributo EditorInteger { get; } 
        public EditorAtributo EditorLong { get; } 
        public EditorAtributo EditorSByte { get; }
        public EditorAtributo EditorShort { get; }
        public EditorAtributo EditorString { get; } 
        public EditorAtributo EditorUInteger { get; } 
        public EditorAtributo EditorULong { get; } 
        public EditorAtributo EditorUShort { get; }

    }
}
