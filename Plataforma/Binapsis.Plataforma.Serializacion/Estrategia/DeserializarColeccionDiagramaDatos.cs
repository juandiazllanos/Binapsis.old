using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using System.Collections;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarColeccionDiagramaDatos : DeserializarColeccion
    {
        public DeserializarColeccionDiagramaDatos(ITipo tipo, IList items, ILector lector) 
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
