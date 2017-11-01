using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.SQLite;
using Binapsis.Plataforma.Datos.SQLServer;

namespace Binapsis.Plataforma.ServicioConfiguracion
{
    static class ContextoHelper
    {
        public static IContexto CrearContexto(ContextoInfo contextoInfo)
        {
            switch(contextoInfo.Controlador)
            {
                case "SQLite":
                    return new ContextoSQLite(contextoInfo.CadenaConexion);

                case "SQLServer":
                    return new ContextoSQLServer(contextoInfo.CadenaConexion);

                default:
                    return null;
            }

            //Type type = Type.GetType(contextoInfo.Controlador);
            //IContexto contexto = Activator.CreateInstance(type) as IContexto;

            //return contexto;
        }        
    }
}
