using System.Collections.Generic;

namespace Binapsis.Procesos.Orquestacion
{
    public class Parametros : IParametros
    {
        Dictionary<string, object> _items = new Dictionary<string, object>();

        #region Metodos
        public void Establecer(Parametros parametros)
        {
            _items.Clear();

            foreach (string nombre in parametros._items.Keys)
                Establecer(nombre, parametros._items[nombre]);
        }

        public void Establecer(string nombre, object valor)
        {
            if (_items.ContainsKey(nombre))
                _items[nombre] = valor;
            else
                _items.Add(nombre, valor);
        }

        public object Obtener(string nombre)
        {
            if (_items.ContainsKey(nombre))
                return _items[nombre];
            else
                return null;
        }
        #endregion


        #region Propiedades
        public object this[string nombre]
        {
            get => Obtener(nombre);
            set => Establecer(nombre, value);
        }
        #endregion


        #region IParametros
        void IParametros.Establecer(string nombre, object valor)
        {
            Establecer(nombre, valor);
        }

        object IParametros.Obtener(string nombre)
        {
            return Obtener(nombre);
        }
        #endregion
    }
}
