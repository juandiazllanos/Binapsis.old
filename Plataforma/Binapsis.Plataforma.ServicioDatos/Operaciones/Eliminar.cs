using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.ServicioDatos.Operaciones
{
    class Eliminar : Operacion
    {
        public Eliminar(IConfiguracion configuracion, IContexto contexto)
            : base(configuracion, contexto)
        {
        }

        public void Ejecutar(IObjetoDatos obj)
        {
            IDiagramaDatos dd = CrearDiagramaDatos(null, obj);            
            Ejecutar(dd);
        }

        public void Ejecutar(IColeccion col)
        {
            IDiagramaDatos[] dd = new IDiagramaDatos[col.Longitud];

            for (int i = 0; i < col.Longitud; i++)
                dd[i] = CrearDiagramaDatos(null, col[i]);

            Ejecutar(dd);
        }
        
    }
}
