using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Datos.Heap
{
    class HeapObjetoDatos
    {
        Dictionary<string, IObjetoDatos> _heap;

        public HeapObjetoDatos()
        {
            _heap = new Dictionary<string, IObjetoDatos>();
        }

        //public void Agregar(IObjetoDatos od, IPropiedad propiedad)
        //{
        //    string clave = ObtenerClave(od.Tipo, propiedad, od.Obtener(propiedad));

        //    Agregar(od, clave);
        //}

        public void Agregar(IObjetoDatos od, string clave)
        {
            if (!_heap.ContainsKey(clave))
                _heap.Add(clave, od);
        }

        //public IObjetoDatos Obtener(ITipo tipo, IPropiedad propiedad, object valor)
        //{
        //    string clave = ObtenerClave(tipo, propiedad, valor);
        //    return Obtener(clave);            
        //}

        public IObjetoDatos Obtener(string clave)
        {
            if (_heap.ContainsKey(clave))
                return _heap[clave];
            else
                return null;
        }

        //private string ObtenerClave(ITipo tipo, IPropiedad propiedad, object valor)
        //{
        //    return $"{tipo.Uri}.{tipo.Nombre}.{propiedad.Nombre}={valor}";
        //}
        
    }
}
