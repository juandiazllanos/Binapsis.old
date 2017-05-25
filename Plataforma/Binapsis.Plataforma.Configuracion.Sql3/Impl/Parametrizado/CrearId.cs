using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Impl.Parametrizado
{
    internal class CrearId : ComandoParametrizado
    {
        public CrearId(string clave) 
            : base()
        {
            ComandoSql = "usp_CrearId";
            Parametros.Add(new SqlParameter("@clave", clave));
            Parametros.Add(new SqlParameter("@resul", null) { Direction = System.Data.ParameterDirection.ReturnValue });
        }
    }
}
