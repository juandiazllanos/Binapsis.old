using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno
{
	internal class HistorialEstado
    {
        protected IImplementacion _impl;
        protected IPropiedad _propiedad;
        
		public HistorialEstado(IImplementacion impl, IPropiedad propiedad)
        {
            _impl = impl;
            _propiedad = propiedad;
		}

        public virtual void Deshacer(HistorialComando comando)
        {
            
        } 
        
	}

}