using System;
using Binapsis.Presentacion.Editores;
using System.Diagnostics;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class EditorAtributo : EditorBase, IEditorAtributo
    {
        object _valor;
        EditorBase _propietario;

        public EditorAtributo(EditorBase propietario)
        {
            _propietario = propietario;
        }
        
        public object Valor
        {
            get
            {
                return _valor;
            }
            set
            {
                _valor = value;
                Debug.WriteLine(string.Format("{0}.{1}={2}", _propietario.Nombre, Nombre, value));
                OnNotificar();                
            }
        }

        public event NotificarHandler Notificar;

        private void OnNotificar()
        {            
            Notificar?.Invoke();            
        }
        
    }
}
