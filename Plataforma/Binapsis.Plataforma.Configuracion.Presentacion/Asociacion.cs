using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class Asociacion
    {
        Dictionary<string, string> _items;

        public Asociacion()
        {
            _items = new Dictionary<string, string>();
        }

        public void Agregar(string clave, string valor)
        {
            if (!_items.ContainsKey(clave))
                _items.Add(clave, valor);
        }

        public string Obtener(string clave)
        {
            if (_items.ContainsKey(clave))
                return _items[clave];
            else
                return null;
        }
    }
}
