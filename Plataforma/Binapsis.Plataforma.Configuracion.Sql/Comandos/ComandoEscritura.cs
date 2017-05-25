using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal class ComandoEscritura : ComandoBase
    {
        public ComandoEscritura()
        {
        }

        public ComandoEscritura(ISqlBuilder builder) 
            : base(builder)
        {
        }

        //public override void Ejecutar()
        //{
        //    //using (SqlConnection cnn = new SqlConnection(CadenaConexion))
        //    //using (SqlCommand cmd = new SqlCommand(ComandoSql, cnn))
        //    //{
        //    //    cmd.CommandType = System.Data.CommandType.Text;                
        //    //    // ejecutar
        //    //    cnn.Open();
        //    //    cmd.ExecuteNonQuery();
        //    //}
        //}

        public override void Ejecutar(SqlConnection conexion, SqlTransaction transaccion)
        {
            if (string.IsNullOrEmpty(ComandoSql)) return;

            using (SqlCommand cmd = new SqlCommand(ComandoSql, conexion, transaccion))
            {
                cmd.CommandType = System.Data.CommandType.Text;                
                cmd.ExecuteNonQuery();
            }
        }
    }
}
