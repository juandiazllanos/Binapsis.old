using Binapsis.Plataforma.Serializacion.Interno;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class SerializarColeccion : Serializar
    {
        public SerializarColeccion(IEscritor escritor) 
            : base(escritor)
        {
        }

        //protected void Escribir(Diagrama diagrama)
        //{
        //    NodoColeccion root = diagrama.Root as NodoColeccion;
        //    if (root == null) return;

        //    EscribirColeccion(root.Nodos.Count);
        //    EscribirItems(root);
        //    EscribirColeccionCierre();
        //}

        protected void Escribir(NodoColeccion items)
        {
            EscribirColeccion(items.Nodos.Count);
            EscribirItems(items.Nodos);
            EscribirColeccionCierre();
        }

        protected virtual void EscribirItems(IEnumerable<Nodo> items)
        {
            foreach (Nodo item in items)
                EscribirItem(item);
        }

        protected virtual void EscribirItem(Nodo item)
        {

        }

        protected void EscribirColeccion(int items)
        {
            Escritor.EscribirColeccion(items);
        }

        protected void EscribirColeccionCierre()
        {
            Escritor.EscribirColeccionCierre();
        }
    }
}
