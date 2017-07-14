using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Serializacion.Interno;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class SerializarDiagramaDatos : Serializar
    {
        public SerializarDiagramaDatos(IDiagramaDatos dd, IEscritor escritor) 
            : base(escritor)
        {
            DiagramaDatos = dd;
        }

        public IDiagramaDatos DiagramaDatos
        {
            get;
        }

        public override void Escribir()
        {
            NodoObjeto ndd = new NodoObjeto();
            BuilderNodoDiagramaDatos builder = new BuilderNodoDiagramaDatos(ndd);
            builder.Construir(DiagramaDatos);

            Escribir(ndd);
        }

        public void Escribir(NodoObjeto ndd)
        {
            if (ndd == null || (ndd.Objeto as IDiagramaDatos) == null) return; // !typeof(IDiagramaDatos).GetTypeInfo().IsAssignableFrom(ndd.Type.GetTypeInfo())) return;

            NodoObjetoDatos nod = ndd.Nodos[0] as NodoObjetoDatos;
            NodoObjetoDatos noc = ndd.Nodos[1] as NodoObjetoDatos;

            if (nod == null || noc == null) return;

            EscribirDiagramaDatos();
            EscribirObjetoDatos(nod);
            EscribirObjetoCambios(noc);
            EscribirDiagramaDatosCierre();
        }

        private void EscribirDiagramaDatos()
        {
            Escritor.EscribirDiagramaDatos();
        }

        private void EscribirDiagramaDatosCierre()
        {
            Escritor.EscribirDiagramaDatosCierre();
        }

        private void EscribirObjetoDatos(NodoObjetoDatos nod)
        {
            SerializarObjetoDatos estrategia = new SerializarObjetoDatos(nod.ObjetoDatos, Escritor);
            estrategia.Escribir(nod);            
        }

        private void EscribirObjetoCambios(NodoObjetoDatos nod)
        {
            IObjetoCambios cambios = nod.ObjetoDatos as IObjetoCambios;
            if (cambios == null) return;

            SerializarObjetoCambios estrategia = new SerializarObjetoCambios(cambios, Escritor);
            estrategia.Escribir(nod);
        }
        
    }
}
