using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Serializacion.Estrategia;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion
{
    public class SerializadorDiagramaDatos : Serializador
    {
        public SerializadorDiagramaDatos(ISecuencia secuencia, IEscritor escritor) 
            : base(secuencia, escritor)
        {
        }

        public override void Serializar(object obj)
        {
            if (obj is IDiagramaDatos dd)
                Serializar(dd);
            else if (obj is IList items)
                Serializar(items);
        }

        public void Serializar(IDiagramaDatos dd)
        {
            Serializar estrategia = new SerializarDiagramaDatos(dd, Escritor);
            Serializar(estrategia);
        }

        public void Serializar(IList items)
        {
            Serializar estrategia = new SerializarColeccionDiagramaDatos(items, Escritor);
            Serializar(estrategia);
        }
    }
}
