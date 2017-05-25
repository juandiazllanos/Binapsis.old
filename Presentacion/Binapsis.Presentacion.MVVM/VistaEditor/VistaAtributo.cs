using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.MVVM.Definicion;
using System;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM.VistaEditor
{
    internal class VistaAtributo : VistaPropiedad
    {
        NotificarHandler _notificar;
        bool _redundancia;

        public VistaAtributo(VistaTipo vistaTipo, IEditorAtributo editor) 
            : base(vistaTipo)
        {
            _notificar = new NotificarHandler(Notificar);

            Editor = editor;
            Editor.Notificar += _notificar;
        }
                
        public void Establecer(object valor)
        {
            if (_redundancia || Editor == null) return;

            _redundancia = true;

            try
            {
                Editor.Valor = valor;
            }
            finally
            {
                _redundancia = false;
            }            
        }

        internal override void Liberar()
        {
            Editor.Valor = null;
            Editor.Notificar -= _notificar;
        }

        private void Notificar()
        {
            if (_redundancia) return;

            _redundancia = true;

            try
            {
                VistaTipo.Notificar(this);
            }
            finally
            {
                _redundancia = false;
            }            
        }

        public object Obtener()
        {
            return Editor?.Valor;
        }

        private void ResolverEnumeracion()
        {
            IEditorEnumeracion editor = (Editor as IEditorEnumeracion);
            Type enumType = Propiedad?.Property?.PropertyType;

            if (editor == null || enumType == null || !enumType.GetTypeInfo().IsEnum) return;
                        
            Array valores = Enum.GetValues(enumType);
            
            foreach (object valor in valores)
                editor.Agregar(valor, Enum.GetName(enumType, valor));
        }

        public override PropiedadInfo Propiedad
        {
            get => base.Propiedad;
            set
            {
                base.Propiedad = value;
                ResolverEnumeracion();
            }
        }

        public IEditorAtributo Editor
        {
            get;
        }
    }
}