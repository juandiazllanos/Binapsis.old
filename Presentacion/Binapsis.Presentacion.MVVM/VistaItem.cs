using Binapsis.Presentacion.MVVM.VistaEditor;
using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.MVVM
{
    public class VistaItem : Vista
    {
        internal VistaItem(VistaTipo vistaTipo, IEditorFila item) 
            : base(vistaTipo)
        {
            Item = item;
        }

        internal override Vista CrearVista(VistaReferencia vistaPropiedad)
        {
            VistaTipo vistaTipo = new VistaTipo(vistaPropiedad.MapeoReferencia);
            vistaTipo.Establecer(vistaPropiedad.Propiedad.TipoInfo, Item);

            // asignar la misma fila de la vista contenedora
            Vista vista = new VistaItem(vistaTipo, Item);
            vistaPropiedad.Vista = vista;

            return vista;
        }

        internal override Vista CrearVista(VistaColeccion vistaPropiedad)
        {
            return base.CrearVista(vistaPropiedad);
        }

        public IEditorFila Item
        {
            get;
        }
    }
}
