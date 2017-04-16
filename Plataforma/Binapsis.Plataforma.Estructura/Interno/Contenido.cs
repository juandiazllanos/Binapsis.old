using System.Collections.Generic;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class Contenido
    {
        protected Dictionary<IPropiedad, Caracteristica> _caracteristicas;
                
		public Contenido(ITipo tipo)
        {
            Tipo = tipo;
            _caracteristicas = new Dictionary<IPropiedad, Caracteristica>(tipo.Propiedades.Count);
            Construir();
		}
        
        private void Construir()
        {
            foreach(IPropiedad propiedad in Tipo.Propiedades)
            {
                _caracteristicas.Add(propiedad, FabricaCaracteristica.Crear(propiedad));
            }
        }
        
        internal Caracteristica ObtenerCaracteristica(IPropiedad propiedad)
        {
            return _caracteristicas[propiedad];
        }


        public ITipo Tipo { get; }
    }
}