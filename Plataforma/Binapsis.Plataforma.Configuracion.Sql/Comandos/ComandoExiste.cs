using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal class ComandoExiste : ComandoBase
    {
        bool _resultado;

        public ComandoExiste()
        {
        }

        public ComandoExiste(ISqlBuilder builder) 
            : base(builder)
        {
        }
        
        public override void Ejecutar(SqlConnection conexion, SqlTransaction transaccion)
        {
            if (string.IsNullOrEmpty(ComandoSql)) return;

            using (SqlCommand cmd = new SqlCommand(ComandoSql, conexion, transaccion))
            {                
                _resultado = cmd.ExecuteScalar() != null;
            }
        }

        public bool Resultado
        {
            get { return _resultado; }
        }

    }    
}
