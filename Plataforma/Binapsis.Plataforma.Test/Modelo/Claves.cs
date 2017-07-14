using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Test.Modelo
{
    static class Claves
    {
        static Dictionary<Type, int> _claves;

        static  Claves()
        {
            _claves = new Dictionary<Type, int>();
        }

        public static int CrearId(Type type)
        {
            if (!_claves.ContainsKey(type))
                _claves.Add(type, 0);

            return ++_claves[type];
        }
    }
}
