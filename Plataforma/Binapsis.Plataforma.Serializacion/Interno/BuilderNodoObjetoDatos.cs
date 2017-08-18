using Binapsis.Plataforma.Estructura;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    class BuilderNodoObjetoDatos : BuilderNodo
    {
        public BuilderNodoObjetoDatos(NodoObjetoDatos nodo) 
            : base(nodo)
        {
        }

        public BuilderNodoObjetoDatos(NodoColeccion nodo)
            : base(nodo)
        {
        }

        public void Construir(IObjetoDatos od)
        {
            // crear nodo
            NodoObjetoDatos nod = Nodo as NodoObjetoDatos; 
            if (nod == null) return;
                        
            // construir nodo
            ConstruirNodoObjetoDatos(nod, od);
            // resolver nodos
            ResolverNodos();            
        }

        //public void Construir(IList items)
        //{
        //    Construir(items as IEnumerable);
        //}

        public void Construir(IEnumerable items)
        {
            // crear nodo
            NodoColeccion nco = (Nodo as NodoColeccion);
            if (nco == null) return;

            nco.Nombre = "Coleccion";

            // crear nodos
            foreach (IObjetoDatos item in items)
            {
                NodoObjetoDatos nod = new NodoObjetoDatos(nco);
                ConstruirNodoObjetoDatos(nod, item);
                nco.Agregar(nod);
            }
            // resolver nodos
            ResolverNodos();
        }
    }
}
