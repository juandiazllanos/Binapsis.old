using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Serializacion.Interno;
using System.Reflection;

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
            Diagrama diagrama = new Diagrama();
            BuilderDiagrama builder = new BuilderDiagrama(diagrama);
            builder.Construir(DiagramaDatos);

            Escribir(diagrama.Root as NodoObjeto);            
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

            //Escritor.EscribirObjetoDatos(nod.Tipo, nod.Id);
            //estrategia.EscribirObjetoDatos(nod);
            //Escritor.EscribirObjetoDatosCierre();
        }

        private void EscribirObjetoCambios(NodoObjetoDatos nod)
        {
            IObjetoCambios cambios = nod.ObjetoDatos as IObjetoCambios;
            if (cambios == null) return;

            SerializarObjetoCambios estrategia = new SerializarObjetoCambios(cambios, Escritor);
            estrategia.Escribir(nod);

            //Escritor.EscribirObjetoDatos(nod.Tipo, nod.Id, cambios.Referencia, cambios.Cambio);
            //estrategia.EscribirObjetoDatos(nod);
            //Escritor.EscribirObjetoDatosCierre();
        }
        
    }
}
