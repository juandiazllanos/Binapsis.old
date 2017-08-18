using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    class Recursos
    {
        Dictionary<string, Recurso> _items;

        public Recursos()
        {
            _items = new Dictionary<string, Recurso>();
        }

        public void Crear<V>(string nombre)
        {
            Crear(nombre, typeof(V));
        }

        public void Crear<K,V>(string nombre)
        {
            Crear(nombre, typeof(K), typeof(V));
        }

        public void Crear(string nombre, Type typeValor)
        {
            Crear(nombre, typeof(string), typeValor);
        }

        public void Crear(string nombre, Type typeKey, Type typeValor)
        {
            if (!_items.ContainsKey(nombre))
                _items.Add(nombre, new Recurso(nombre, typeKey, typeValor));
        }

        public Recurso Obtener(string nombre)
        {
            if (_items.ContainsKey(nombre))
                return _items[nombre];
            else
                return null;
        }

        public Recurso this[string nombre]
        {
            get => Obtener(nombre);
        }
    }
}
