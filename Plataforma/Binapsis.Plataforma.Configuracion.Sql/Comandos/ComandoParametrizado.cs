using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal class ComandoParametrizado : ComandoBase
    {
        List<SqlParameter> _parametros;

        protected ComandoParametrizado()             
        {
            _parametros = new List<SqlParameter>();
        }
        
        public override void Ejecutar(SqlConnection conexion, SqlTransaction transaccion)
        {
            if (string.IsNullOrEmpty(ComandoSql)) return;

            using (SqlCommand cmd = new SqlCommand(ComandoSql, conexion, transaccion))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // agregar parametros
                _parametros.ForEach((item) => cmd.Parameters.Add(item));
                // ejecutar
                cmd.ExecuteNonQuery();
            }
        }

        public IList<SqlParameter> Parametros
        {
            get { return _parametros; }
        }
        
    }
}
