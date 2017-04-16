using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.MVVM.Mapeo;

namespace Binapsis.Presentacion.MVVM.Vista
{
    internal class VistaReferenciaFila : VistaReferencia
    {
        IEditorFila _fila;

        public VistaReferenciaFila(VistaObjeto vista, IPropiedad propiedad, MapeoTipo mapeo, IEditorFila fila) 
            : base(vista, propiedad, mapeo)
        {
            _fila = fila;
        }

        protected override VistaObjeto Crear(ITipo tipo, MapeoTipo mapeo)
        {
            return new VistaFila(tipo, mapeo, _fila);
        }
    }
}
