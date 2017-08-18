using Binapsis.Plataforma.Datos.Impl;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Binapsis.Plataforma.Datos.SQLServer
{
    public class ContextoSQLServer : IContexto, IDisposable
    {
        #region Constructores
        public ContextoSQLServer(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }
        #endregion


        #region Metodos
        public void EjecutarComando(IComando comando)
        {
            EjecutarComando(comando as ComandoBase);
        }

        private void EjecutarComando(ComandoBase comando)
        {
            if (comando == null) return;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = comando.Sql;

            foreach (ParametroComando parametro in comando.Parametros)
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@" + parametro.Nombre, Value = parametro.Valor });

            cmd.Connection = Conexion;
            cmd.Transaction = Transaccion;

            cmd.ExecuteNonQuery();

            //System.Diagnostics.Debug.WriteLine(cmd.CommandText);
        }


        public IResultado EjecutarConsulta(IComando comando)
        {
            return EjecutarConsulta(comando as ComandoBase);
        }

        private IResultado EjecutarConsulta(ComandoBase comando)
        {
            if (comando == null) return null;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = comando.Sql;

            foreach (ParametroComando parametro in comando.Parametros)
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@" + parametro.Nombre, Value = parametro.Valor });

            cmd.Connection = Conexion;
            cmd.Transaction = Transaccion;

            SqlDataReader reader = cmd.ExecuteReader();
            Resultado resultado = new Resultado(reader);

            System.Diagnostics.Debug.WriteLine(cmd.CommandText);

            return resultado;
        }

        public void AbrirConexion()
        {
            if (Conexion == null)
                Conexion = new SqlConnection(CadenaConexion);

            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();
        }

        public void CerrarConexion()
        {
            if (Conexion != null && Conexion.State != ConnectionState.Closed)
                Conexion.Close();
        }

        public void DeshacerTransaccion()
        {
            if (Transaccion != null)
            {
                Transaccion.Rollback();
                Transaccion.Dispose();
                Transaccion = null;
            }

            CerrarConexion();
        }
               
        public void IniciarTransaccion()
        {
            if (Transaccion != null) return;

            AbrirConexion();

            Transaccion = Conexion.BeginTransaction();
        }

        public void TerminarTransaccion()
        {
            if (Transaccion == null) return;

            Transaccion.Commit();
            Transaccion.Dispose();
            Transaccion = null;

            CerrarConexion();
        }

        public void Dispose()
        {
            DeshacerTransaccion();
        }
        #endregion


        #region Propiedades
        public string CadenaConexion
        {
            get;
            set;
        }

        public SqlConnection Conexion
        {
            get;
            private set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public SqlTransaction Transaccion
        {
            get;
            private set;
        }
        #endregion

    }
}
