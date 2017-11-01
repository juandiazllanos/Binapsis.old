using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.SQLite;
using Binapsis.Plataforma.Datos.SQLServer;
using Binapsis.Plataforma.ServicioDatos.Impl;

using System.Collections.Generic;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    static class ContextoHelper
    {
        
        //public static IContexto CrearContexto(ContextoInfo contextoInfo)
        //{
        //    switch(contextoInfo.Controlador)
        //    {
        //        case "SQLite":
        //            return new ContextoSQLite(contextoInfo.CadenaConexion);

        //        case "SQLServer":
        //            return new ContextoSQLServer(contextoInfo.CadenaConexion);

        //        default:
        //            return null;
        //    }            
        //}      
        
        public static IContexto CrearContexto(Conexion conexion)
        {
            if (conexion != null)
                return new ContextoSQLServer(conexion.CadenaConexion);
            else
                return null;
        }

    }
}
