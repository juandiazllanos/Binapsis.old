using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Cambios.Impl
{
    public class DiagramaDatos : IDiagramaDatos
    {
        public DiagramaDatos(ITipo tipo)
        {
            Tipo = tipo;
        }

        public IObjetoDatos ObjetoDatos
        {
            get;
            set;
        }

        public IResumenCambios ResumenCambios
        {
            get;
            set;
        }

        public ITipo Tipo
        {
            get;
        }
    }
}
