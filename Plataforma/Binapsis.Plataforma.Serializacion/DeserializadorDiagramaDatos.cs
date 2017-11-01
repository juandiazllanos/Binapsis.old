using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Estrategia;
using Binapsis.Plataforma.Serializacion.Interno;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion
{
    public class DeserializadorDiagramaDatos : Deserializador
    {
        public DeserializadorDiagramaDatos(ISecuencia secuencia, ILector lector) 
            : base(secuencia, lector)
        {
        }

        public DeserializadorDiagramaDatos(ISecuencia secuencia, ILector lector, IFabrica fabrica)
            : base(secuencia, lector, fabrica)
        {
        }

        public override void Deserializar(object obj)
        {
            if (obj is IDiagramaDatos dd)
                Deserializar(dd);
        }

        public void Deserializar(IDiagramaDatos dd)
        {
            DeserializarDiagramaDatos estrategia = new DeserializarDiagramaDatos(dd, Lector);

            estrategia.Fabrica = Fabrica;
            estrategia.HeapId = new HeapId();

            Deserializar(estrategia);
        }

        public override void Deserializar(ITipo tipo, IList items)
        {
            DeserializarColeccionDiagramaDatos estrategia = new DeserializarColeccionDiagramaDatos(tipo, items, Lector);

            estrategia.Fabrica = Fabrica;
            estrategia.HeapId = new HeapId();

            Deserializar(estrategia);
        }
    }
}
