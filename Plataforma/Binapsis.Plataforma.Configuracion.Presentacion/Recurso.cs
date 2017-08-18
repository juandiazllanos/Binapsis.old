using System;
using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    class Recurso
    {        
        IDictionary _items;

        public Recurso(string nombre, Type typeClave, Type typeValor)
        {
            TypeClave = typeClave;
            TypeValor = typeValor;
            Nombre = nombre;

            Inicializar();
        }

        private void Inicializar()
        {
            Type typeBase = typeof(Dictionary<,>);
            Type typeItem = typeBase.MakeGenericType(new Type[] { TypeClave, TypeValor });

            _items = Activator.CreateInstance(typeItem) as IDictionary;
        }
               
        public object Obtener(object clave)
        {
            if (_items.Contains(clave))
                return _items[clave];
            else
                return null;
        }

        public void Establecer(object clave, object valor)
        {
            if (_items.Contains(clave))
                _items[clave] = valor;
            else
                _items.Add(clave, valor);
        }

        public object this[string clave]
        {
            get => Obtener(clave);
            set => Establecer(clave, value);
        }

        public ICollection Claves
        {
            get => _items.Keys;
        }

        public string Nombre
        {
            get;
        }

        internal Type TypeClave
        {
            get;
        }

        internal Type TypeValor
        {
            get;
        }

        public ICollection Valores
        {
            get => _items.Values;
        }
    }
}
