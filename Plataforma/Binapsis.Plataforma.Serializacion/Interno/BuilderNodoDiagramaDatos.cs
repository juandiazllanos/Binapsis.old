using Binapsis.Plataforma.Cambios;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    class BuilderNodoDiagramaDatos : BuilderNodo
    {
        public BuilderNodoDiagramaDatos(Nodo nodo) 
            : base(nodo)
        {
        }
        
        public void Construir(IDiagramaDatos dd)
        {
            // crear nodo
            NodoObjeto ndd = Nodo as NodoObjeto;
            if (ndd == null) return;

            // construir nodo
            ConstruirNodoDiagramaDatos(ndd, dd);
            // resolver nodos
            ResolverNodos();            
        }

        public void Construir(IList items)
        {
            // crear nodo
            NodoColeccion nco = Nodo as NodoColeccion; 
            if (nco == null) return;

            // crear nodos
            foreach (IDiagramaDatos item in items)
            {
                NodoObjeto ndd = new NodoObjeto(nco); 
                ConstruirNodoDiagramaDatos(ndd, item);
                nco.Agregar(ndd);
            }
            // resolver nodos
            ResolverNodos();            
        }
    }
}
