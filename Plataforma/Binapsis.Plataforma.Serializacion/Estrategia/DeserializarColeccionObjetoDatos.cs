using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarColeccionObjetoDatos : DeserializarColeccion<IObjetoDatos>
    {
        public DeserializarColeccionObjetoDatos(ITipo tipo, List<IObjetoDatos> items, ILector lector) 
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
            IObjetoDatos[] items = new IObjetoDatos[longitud];
                        
            for (int i = 0; i < longitud; i++)
                items[i] = LeerItem();

            Items.AddRange(items);
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
