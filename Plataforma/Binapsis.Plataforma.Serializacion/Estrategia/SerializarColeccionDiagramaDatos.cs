using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Serializacion.Interno;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class SerializarColeccionDiagramaDatos : SerializarColeccion
    {
        public SerializarColeccionDiagramaDatos(IEnumerable items, IEscritor escritor) 
            : base(escritor)
        {
            Items = items;
        }

        public IEnumerable Items
        {
            get;
        }
        
        public override void Escribir()
        {
            NodoColeccion nco = new NodoColeccion();
            BuilderNodoDiagramaDatos builder = new BuilderNodoDiagramaDatos(nco);
            builder.Construir(Items);

            Escribir(nco);
        }

        protected override void EscribirItem(Nodo item)
        {
            EscribirDiagramaDatos(item as NodoObjeto);
        }
        
        private void EscribirDiagramaDatos(NodoObjeto ndd)
        {
            if (ndd is null) return;

            IDiagramaDatos dd = ndd.Objeto as IDiagramaDatos;
            if (dd == null) return;

            SerializarDiagramaDatos estrategia = new SerializarDiagramaDatos(ndd.Objeto as IDiagramaDatos, Escritor);
            estrategia.Escribir(ndd);
        }
        
    }
}
