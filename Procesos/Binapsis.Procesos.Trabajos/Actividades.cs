using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Binapsis.Procesos.Trabajos
{
    public class Actividades : IEnumerable<Actividad>
    {
        List<Actividad> _items = new List<Actividad>();
        
        public void Agregar(Actividad actividad)
        {
            _items.Add(actividad);
        }

        public Actividad Obtener(string nombre)
        {
            return _items.FirstOrDefault(item => item.ActividadInfo.Nombre == nombre);
        }

        public Actividad this[string nombre]
        {
            get => Obtener(nombre);
        }

        #region IEnumerable
        IEnumerator<Actividad> IEnumerable<Actividad>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        #endregion

    }
}
