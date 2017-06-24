using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Builder;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Interno;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarDiagramaDatos : Deserializar
    {
        public DeserializarDiagramaDatos(IDiagramaDatos dd, ILector lector)
            : base(lector)
        {
            DiagramaDatos = dd;            
        }

        public override void Leer()
        {
            IObjetoDatos datos = Fabrica.Crear(DiagramaDatos.Tipo);
            IObjetoCambios cambios = new ObjetoCambios(DiagramaDatos.Tipo);

            // leer objeto de datos
            Lector.Leer();
            Deserializar deserializar = new DeserializarObjetoDatos(datos, Lector) { Fabrica = Fabrica, HeapId = HeapId };
            deserializar.Leer();

            // leer objeto de cambios
            Lector.Leer();
            deserializar = new DeserializarObjetoCambios(cambios, Lector) { Fabrica = Fabrica, HeapId = HeapId };
            deserializar.Leer();

            // construir diagrama de datos
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(DiagramaDatos);
            builder.Construir(datos, cambios);            
        }

        public IDiagramaDatos DiagramaDatos
        {
            get;
        }
        
    }
}
