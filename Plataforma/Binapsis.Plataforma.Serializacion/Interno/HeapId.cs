using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal class HeapId
    {
        Dictionary<int, IObjetoDatos> _ids;

        public HeapId()
        {
            _ids = new Dictionary<int, IObjetoDatos>();
        }

        public void Agregar(IObjetoDatos od, int id)
        {
            if (_ids.ContainsKey(id)) return;
            _ids.Add(id, od);
        }

        public IObjetoDatos Obtener(int id)
        {
            if (!_ids.ContainsKey(id)) return null;
            return _ids[id];
        }

        public bool Existe(int id)
        {
            return _ids.ContainsKey(id);
        }
    }
}
