using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Procesos.Trabajos
{
    public class Asociaciones : IEnumerable<Asociacion>
    {
        List<Asociacion> _items = new List<Asociacion>();

        public Asociacion Crear(Actividad actividadOrigen, Actividad actividadDestino, Resultado resultado)
        {
            Asociacion asociacion = new Asociacion { ActividadDestino = actividadDestino, ActividadOrigen = actividadOrigen, Resultado = resultado };
            Agregar(asociacion);
            return asociacion;
        }

        public void Agregar(Asociacion asociacion)
        {
            _items.Add(asociacion);
        }

        #region IEnumerable
        IEnumerator<Asociacion> IEnumerable<Asociacion>.GetEnumerator()
        {
            return ((IEnumerable<Asociacion>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Asociacion>)_items).GetEnumerator();
        }
        #endregion
    }
}
