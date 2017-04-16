using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.MVVM.Mapeo;

namespace Binapsis.Presentacion.MVVM.Vista
{
	public class VistaFila : VistaObjeto
    {
		public VistaFila(ITipo tipo, MapeoTipo mapeo, IEditorFila editor)
            : base(tipo, mapeo)
        {
            Editor = editor;
            Construir();
		}

        protected override void Construir()
        {
            if (Editor == null) return;
            base.Construir();
        }

        protected override VistaPropiedad Crear(IPropiedad propiedad, IEditorColumna editor)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                return new VistaAtributo(this, propiedad, Editor.Crear(editor));
            else
                return null;
        }

        protected override VistaPropiedad Crear(IPropiedad propiedad, MapeoTipo mapeo)
        {
            if (propiedad.Tipo.EsTipoDeDato || propiedad.EsColeccion) return null;
            return new VistaReferenciaFila(this, propiedad, mapeo, Editor);
        }

        public IEditorFila Editor { get; }

    }

}