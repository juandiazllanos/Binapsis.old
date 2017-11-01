using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.ServicioDatos.Operaciones
{
    class Crear : Operacion
    {
        public Crear(IConfiguracion configuracion, IContexto contexto)
            : base(configuracion, contexto)
        {
        }

        public void Ejecutar(IObjetoDatos od)
        {
            IDiagramaDatos dd = CrearDiagramaDatos(od);
            Ejecutar(dd);
        }

        public void Ejecutar(IColeccion col)
        {
            IDiagramaDatos[] dd = new IDiagramaDatos[col.Longitud];

            for (int i = 0; i < col.Longitud; i++)
                dd[i] = CrearDiagramaDatos(col[i]);

            Ejecutar(dd);
        }

        //private IDiagramaDatos CrearDiagramaDatos(IObjetoDatos od)
        //{
        //    if (od == null) return null;

        //    IDiagramaDatos dd = new DiagramaDatos(od.Tipo);
        //    BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
        //    builder.Construir(od, null as IObjetoDatos);

        //    return dd;
        //}
    }
}
