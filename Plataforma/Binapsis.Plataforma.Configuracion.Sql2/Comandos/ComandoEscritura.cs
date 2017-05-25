using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal class ComandoEscritura : ComandoBase
    {
        public override void Ejecutar()
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            using (SqlCommand cmd = new SqlCommand(ComandoSql, cnn))
            {
                cmd.CommandType = System.Data.CommandType.Text;                
                // ejecutar
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
