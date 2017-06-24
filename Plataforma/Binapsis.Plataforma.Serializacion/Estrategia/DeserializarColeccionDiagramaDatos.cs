using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarColeccionDiagramaDatos : DeserializarColeccion<IDiagramaDatos>
    {
        public DeserializarColeccionDiagramaDatos(ITipo tipo, List<IDiagramaDatos> items, ILector lector) 
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
            IDiagramaDatos[] items = new IDiagramaDatos[longitud];

            for (int i = 0; i < longitud; i++)
                items[i] = LeerItem();

            Items.AddRange(items);
        }

        private IDiagramaDatos LeerItem()
        {
            // avanzar lector
            if (!Lector.Leer()) return null;

            IDiagramaDatos dd = new DiagramaDatos(Tipo);
            DeserializarDiagramaDatos estrategia = new DeserializarDiagramaDatos(dd, Lector) { Fabrica = Fabrica, HeapId = HeapId };
            estrategia.Leer();

            return dd;
        }
    }
}
