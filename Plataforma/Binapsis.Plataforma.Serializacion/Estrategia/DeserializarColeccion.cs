using System.Collections;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarColeccion : Deserializar
    {
        public DeserializarColeccion(IList items, ILector lector) 
            : base(lector)
        {
            Items = items;
        }
        
        public IList Items
        {
            get;
        }
    }
}
