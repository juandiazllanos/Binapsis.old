using Binapsis.Plataforma.Serializacion.Interno;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class SerializarColeccionObjetoDatos : SerializarColeccion
    {
        public SerializarColeccionObjetoDatos(IList items, IEscritor escritor) 
            : base(escritor)
        {
            Items = items;
        }

        public IList Items
        {
            get;
        }

        public override void Escribir()
        {
            NodoColeccion nco = new NodoColeccion();
            BuilderNodoObjetoDatos builder = new BuilderNodoObjetoDatos(nco);
            builder.Construir(Items);

            Escribir(nco);            
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
