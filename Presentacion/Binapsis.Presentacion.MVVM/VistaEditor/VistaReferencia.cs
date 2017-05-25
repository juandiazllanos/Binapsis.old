using Binapsis.Presentacion.MVVM.Mapeo;

namespace Binapsis.Presentacion.MVVM.VistaEditor
{
    internal class VistaReferencia : VistaPropiedad
    {        
        public VistaReferencia(VistaTipo vistaTipo) 
            : base(vistaTipo)
        {            
        }
        
        public Vista Vista
        {
            get;
            set;
        }

        public MapeoTipo MapeoReferencia
        {
            get;
            set;
        }
    }

}