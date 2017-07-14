using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Estrategia;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion
{
    public class SerializadorObjetoDatos : Serializador
    {
        public SerializadorObjetoDatos(ISecuencia secuencia, IEscritor escritor) 
            : base(secuencia, escritor)
        {
        }
        
        public override void Serializar(object obj)
        {
            if (obj is IObjetoDatos od)
                Serializar(od);
            else if (obj is IList items)
                Serializar(items);
        }

        public void Serializar(IObjetoDatos od)
        {
            Serializar estrategia = new SerializarObjetoDatos(od, Escritor);
            Serializar(estrategia);
        }

        public void Serializar(IList items)
        {
            Serializar estrategia = new SerializarColeccionObjetoDatos(items, Escritor);
            Serializar(estrategia);
        }

    }
}
