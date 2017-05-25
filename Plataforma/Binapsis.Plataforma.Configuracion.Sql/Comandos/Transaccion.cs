using System.Data;
using System.Data.SqlClient;


namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    class Transaccion : Contexto
    {
        SqlConnection _cnn;
        SqlTransaction _tran;        
        bool _iniciado;
        bool _confirmado;

        public Transaccion(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Ejecutar(ComandoBase comando)
        {
            Iniciar();
            comando.Ejecutar(_cnn, _tran);
        }


        private void Iniciar()
        {
            if (_iniciado) return;

            // crear conexion
            _cnn = new SqlConnection(CadenaConexion);
            _cnn.Open();

            // iniciar transaccion
            _tran = _cnn.BeginTransaction();

            _iniciado = true;
        }

        private void Cerrar()
        {
            if (_cnn != null || _cnn.State != ConnectionState.Closed)
            { 
                _cnn.Close();
                _cnn.Dispose();
            }            
        }

        public override void Dispose()
        {
            if (!_confirmado)
                Deshacer();
        }

        public void Deshacer()
        {
            if (_tran != null)
            {
                _tran.Rollback();
                _tran.Dispose();
            }            

            Cerrar();
        }

        public void Terminar()
        {
            if (_tran != null)
            {
                _tran.Commit();
                _tran.Dispose();
                _tran = null;
            }

            Cerrar();

            _confirmado = true;
        }

    }
}
