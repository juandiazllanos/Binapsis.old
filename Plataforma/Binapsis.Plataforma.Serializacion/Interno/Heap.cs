using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Interno
{
	internal class Heap
    {        
        Dictionary<IObjetoDatos, ObjetoMap> _maps;
        int _id;

		public Heap()
        {
            _maps = new Dictionary<IObjetoDatos, ObjetoMap>();
		} 

        public ObjetoMap Crear(IObjetoDatos od)
        {
            ObjetoMap omap;

            if (!_maps.ContainsKey(od))
            {
                omap = new ObjetoMap(od, ++_id);
                Agregar(omap);
            }                
            else
                omap = _maps[od];
            
            return omap;
        }

        private void Agregar(ObjetoMap oma)
        {
            _maps.Add(oma.ObjetoDatos, oma);
        }

        public ObjetoMap Obtener(IObjetoDatos od)
        {
            if (!_maps.ContainsKey(od))
                return Crear(od);
            else
                return _maps[od];
        }
	}
}