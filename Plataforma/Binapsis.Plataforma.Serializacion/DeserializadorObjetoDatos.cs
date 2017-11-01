using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Estrategia;
using Binapsis.Plataforma.Serializacion.Interno;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion
{
    public class DeserializadorObjetoDatos : Deserializador
    {
        public DeserializadorObjetoDatos(ISecuencia secuencia, ILector lector) 
            : base(secuencia, lector)
        {
        }

        public DeserializadorObjetoDatos(ISecuencia secuencia, ILector lector, IFabrica fabrica)
            : base(secuencia, lector, fabrica)
        {            
        }
        
        public override void Deserializar(object obj)
        {
            if (obj is IObjetoDatos od)
                Deserializar(od);
        }

        public void Deserializar(IObjetoDatos od)
        {
            DeserializarObjetoDatos estrategia = new DeserializarObjetoDatos(od, Lector);

            estrategia.Fabrica = Fabrica;
            estrategia.HeapId = new HeapId();

            Deserializar(estrategia);
        }

        public override void Deserializar(ITipo tipo, IList items)
        {
            DeserializarColeccionObjetoDatos estrategia = new DeserializarColeccionObjetoDatos(tipo, items, Lector);

            estrategia.Fabrica = Fabrica;
            estrategia.HeapId = new HeapId();

            Deserializar(estrategia);
        }

    }
}
