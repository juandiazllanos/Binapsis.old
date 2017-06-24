using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Serializacion.Interno;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class SerializarColeccionDiagramaDatos : SerializarColeccion
    {
        public SerializarColeccionDiagramaDatos(IDiagramaDatos[] items, IEscritor escritor) 
            : base(escritor)
        {
            Items = items;
        }

        public IDiagramaDatos[] Items
        {
            get;
        }
        
        public override void Escribir()
        {
            Diagrama diagrama = new Diagrama();
            BuilderDiagrama builder = new BuilderDiagrama(diagrama);
            builder.Construir(Items);

            Escribir(diagrama);
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
