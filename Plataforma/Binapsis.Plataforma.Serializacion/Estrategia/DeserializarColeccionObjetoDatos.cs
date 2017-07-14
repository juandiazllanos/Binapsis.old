using Binapsis.Plataforma.Estructura;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarColeccionObjetoDatos : DeserializarColeccion
    {
        public DeserializarColeccionObjetoDatos(ITipo tipo, IList items, ILector lector) 
            : base(items, lector)
        {
            Tipo = tipo;
        }

        public ITipo Tipo
        {
            get;
        }
        
        public override void Leer()
        {
            //leer items
            int longitud = Lector.LeerItems();
                        
            for (int i = 0; i < longitud; i++)
                Items.Add(LeerItem());            
        }

        private IObjetoDatos LeerItem()
        {
            // avanzar lector
            if (!Lector.Leer()) return null;

            DeserializarObjetoDatos estrategia = new DeserializarObjetoDatos(Tipo, Lector) { Fabrica = Fabrica, HeapId = HeapId };
            estrategia.Leer();

            return estrategia.ObjetoDatos;
        }

    }
}
