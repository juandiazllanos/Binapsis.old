using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class Parametros
    {
        Dictionary<string, object> _valores;

        public Parametros()
        {
            _valores = new Dictionary<string, object>();
        }

        public object Obtener(string nombre)
        {
            if (_valores.ContainsKey(nombre))
                return _valores[nombre];
            else
                return null;
        }

        public void Establecer(string nombre, object valor)
        {
            if (_valores.ContainsKey(nombre))
                _valores[nombre] = valor;
            else
                _valores.Add(nombre, valor);
        }

        public object this[string nombre]
        {
            get => Obtener(nombre);
            set => Establecer(nombre, value);
        }
    }
}
