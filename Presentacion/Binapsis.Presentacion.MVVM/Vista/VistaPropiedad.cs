using Binapsis.Plataforma.Estructura;

namespace Binapsis.Presentacion.MVVM.Vista
{
	public class VistaPropiedad 
    {
        protected VistaObjeto _vista;
		IPropiedad _propiedad;

		public VistaPropiedad(VistaObjeto vista, IPropiedad propiedad)
        {
            _vista = vista;
            _propiedad = propiedad;
		}
 
        public IPropiedad Propiedad
        {
            get { return _propiedad; }
        }
        
        internal virtual void Liberar()
        {

        }
                
    }

}