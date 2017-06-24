using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarColeccion<T> : Deserializar
    {
        public DeserializarColeccion(List<T> items, ILector lector) 
            : base(lector)
        {
            Items = items;
        }
        
        public List<T> Items
        {
            get;
        }
    }
}
