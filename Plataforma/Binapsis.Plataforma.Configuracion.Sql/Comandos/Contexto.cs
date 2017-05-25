using System;
using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    class Contexto : IDisposable
    {
        bool _disposed;

        public Contexto(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        public virtual void Dispose()
        {            
        }

        public virtual void Ejecutar(ComandoBase comando)
        {            
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                cnn.Open();
                comando.Ejecutar(cnn);
            }
        }

        public string CadenaConexion
        {
            get;
        }

        void IDisposable.Dispose()
        {
            if (_disposed) return;
            Dispose();
            _disposed = true;
        }
    }
}
