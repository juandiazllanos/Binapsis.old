using Binapsis.Presentacion.MVVM;
using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.Editores;
using System;

namespace Binapsis.Plataforma.Configuracion.Win.Comandos
{
    class ComandoSeleccionarElemento : IComando
    {
        public void Ejecutar(IObjetoDatos od)
        {
            if (ElementoRoot == null) return;
            SeleccionarElemento vista = new SeleccionarElemento();
            vista.ElementoRoot = ElementoRoot;
            ElementoSeleccionado = vista.Obtener(Type.Name, (string)Editor?.Valor);            
        }

        public IEditorAtributo Editor
        {
            get;
            set;
        }
        
        public IElemento ElementoRoot
        {
            get;
            set;
        }

        public IElemento ElementoSeleccionado
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            set;
        }
        
    }
}
