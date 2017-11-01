using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Consola.Definicion
{
    public class Asociaciones : IEnumerable<AsociacionInfo>
    {
        List<AsociacionInfo> _items = new List<AsociacionInfo>();
        TrabajoInfo _trabajoInfo;

        public Asociaciones(TrabajoInfo trabajoInfo)
        {
            _trabajoInfo = trabajoInfo;
        }
        
        public AsociacionInfo Crear(string nombre, string actividadOrigen, string actividadDestino)
        {
            AsociacionInfo asociacionInfo = Obtener(nombre, actividadOrigen, actividadDestino);

            if (asociacionInfo == null)
                _items.Add(asociacionInfo = new AsociacionInfo(_trabajoInfo)
                {
                    Nombre = nombre,
                    ActividadOrigen = actividadOrigen,
                    ActividadDestino = actividadDestino
                });
            
            return asociacionInfo;
        }
        
        public AsociacionInfo Obtener(string nombre, string actividadOrigen, string actividadDestino)
        {
            return this.FirstOrDefault(item =>
                item.Nombre == nombre &&
                item.ActividadOrigen == actividadOrigen &&
                item.ActividadDestino == actividadDestino
                );
        }

        IEnumerator<AsociacionInfo> IEnumerable<AsociacionInfo>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
