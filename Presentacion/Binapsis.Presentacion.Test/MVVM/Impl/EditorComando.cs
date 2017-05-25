using Binapsis.Presentacion.Editores;
using System;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class EditorComando : IEditorComando
    {
        public EditorComando(string nombre)
        {
            Nombre = nombre;
        }
        
        public void Invocar()
        {
            Notificar?.Invoke();
        }

        void IEditorComando.Habilitar()
        {
            throw new NotImplementedException();
        }

        void IEditorComando.Deshabilitar()
        {
            throw new NotImplementedException();
        }

        public string Nombre { get; }
        
        public event NotificarHandler Notificar;

        //public void Deshabilitar()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Habilitar()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
