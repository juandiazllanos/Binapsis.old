using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal class ComandoExiste : ComandoBase
    {
        bool _resultado;

        public override void Ejecutar()
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            using (SqlCommand cmd = new SqlCommand(ComandoSql, cnn))
            {
                cnn.Open();
                _resultado = cmd.ExecuteScalar() != null;                
            }
        }
                
        public bool Resultado
        {
            get { return _resultado; }
        }

    }    
}
