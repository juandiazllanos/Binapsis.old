using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Interno;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class SerializarColeccionObjetoDatos : SerializarColeccion
    {
        public SerializarColeccionObjetoDatos(IObjetoDatos[] items, IEscritor escritor) 
            : base(escritor)
        {
            Items = items;
        }

        public IObjetoDatos[] Items
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
            EscribirObjetoDatos(item as NodoObjetoDatos);
        }

        private void EscribirObjetoDatos(NodoObjetoDatos nod)
        {
            if (nod is null) return;

            SerializarObjetoDatos estrategia = new SerializarObjetoDatos(nod.ObjetoDatos, Escritor);            
            estrategia.Escribir(nod);
        }
        
    }
}
