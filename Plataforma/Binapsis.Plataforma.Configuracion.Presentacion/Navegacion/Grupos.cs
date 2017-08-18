using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class Grupos : IEnumerable<Grupo>
    {
        List<Grupo> _items;

        #region Constructores
        internal Grupos()
        {
            _items = new List<Grupo>();
        }            

        internal Grupos(Grupo propietario)
            : this()
        {
            Propietario = propietario;            
        }
        #endregion


        #region Metodos
        public void Agregar(Grupo grupo)
        {
            _items.Add(grupo);
            grupo.Padre = Propietario;
        }

        public void Remover(int indice)
        {
            if (indice >= 0 && indice < _items.Count)
                _items.RemoveAt(indice);
        }

        public void Remover(Grupo item)
        {
            _items.Remove(item);
        }

        public void RemoverTodo()
        {
            _items.Clear();
        }
        #endregion


        #region Propiedades
        public int Longitud
        {
            get => _items.Count;
        }

        private Grupo Propietario
        {
            get;
        }
        #endregion 


        #region IEnumerable        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Grupo>)_items).GetEnumerator();
        }

        IEnumerator<Grupo> IEnumerable<Grupo>.GetEnumerator()
        {
            return ((IEnumerable<Grupo>)_items).GetEnumerator();
        }
        #endregion
    }
}
