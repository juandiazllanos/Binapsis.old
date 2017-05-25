using Binapsis.Presentacion.MVVM.Definicion;

namespace Binapsis.Presentacion.MVVM.VistaEditor
{
    internal class VistaPropiedad 
    {
        public VistaPropiedad(VistaTipo vistaTipo)
        {
            VistaTipo = vistaTipo;
        }

        internal virtual void Liberar()
        {

        }

        public virtual PropiedadInfo Propiedad
        {
            get;
            set;
        }

        public VistaTipo VistaTipo
        {
            get;
        }
                
    }

}