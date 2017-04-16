using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.MVVM.Vista
{
	public class VistaAtributo : VistaPropiedad
    {
        NotificarHandler _notificar;
        bool _redundancia;

        public VistaAtributo(VistaObjeto vista, IPropiedad propiedad, IEditorAtributo editor) 
            : base(vista, propiedad)
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
                _vista.Notificar(this);
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
                        
        
        public IEditorAtributo Editor { get; }
    }
}