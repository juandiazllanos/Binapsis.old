using Binapsis.Plataforma.Datos.Impl;
using System;
using System.Data;
using System.Data.SqlClient;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion;

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

            // determinar tipo de comando            
            CommandType comandoType = comando.ComandoTipo == ComandoTipo.PROCEDURE ? CommandType.StoredProcedure : CommandType.Text;

            SqlCommand cmd = new SqlCommand();
            
            // construir comando
            cmd.CommandText = comando.Sql;
            cmd.CommandType = comandoType;

            // establecer parametros
            foreach (ParametroComando parametro in comando.Parametros)
                cmd.Parameters.Add(ConstruirParametro(parametro, new SqlParameter()));

            // establecer conexion
            cmd.Connection = Conexion;
            cmd.Transaction = Transaccion;
            // ejecutar
            cmd.ExecuteNonQuery();

            // validar aplicación parametros de salida
            if (cmd.CommandType != CommandType.StoredProcedure) return;
            // establecer parametros de salida
            foreach (ParametroComando parametro in comando.ObtenerParametroSalida())
                comando.EstablecerParametro(parametro.Nombre, cmd.Parameters[$"@{parametro.Nombre}"].Value);
            
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
                cmd.Parameters.Add(ConstruirParametro(parametro, new SqlParameter()));

            cmd.Connection = Conexion;
            cmd.Transaction = Transaccion;

            SqlDataReader reader = cmd.ExecuteReader();
            ResultadoSQLServer resultado = new ResultadoSQLServer(reader);

            //System.Diagnostics.Debug.WriteLine(cmd.CommandText);

            return resultado;
        }

        private SqlParameter ConstruirParametro(ParametroComando parametro, SqlParameter parametroSql)
        {
            parametroSql.ParameterName = $"@{parametro.Nombre}";
            parametroSql.Value = parametro.Valor;

            if (parametro.Direccion == "OUT")
                parametroSql.Direction = ParameterDirection.Output;
            if (parametro.Longitud > 0)
                parametroSql.Size = parametro.Longitud;

            return parametroSql;
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

        public IClave ObtenerClave(ITipo tipo)
        {
            return null;
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
