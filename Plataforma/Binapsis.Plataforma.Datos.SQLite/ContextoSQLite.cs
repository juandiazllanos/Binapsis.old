using Binapsis.Plataforma.Datos.Impl;
using Microsoft.Data.Sqlite;
using System.Data;
using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos.SQLite
{
    public class ContextoSQLite : IContexto, IDisposable
    {
        public ContextoSQLite(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        #region Metodos
        public void EjecutarComando(IComando comando)
        {
            EjecutarComando(comando as ComandoBase);
        }

        private void EjecutarComando(ComandoBase comando)
        {
            if (comando == null) return;

            SqliteCommand cmd = new SqliteCommand();            

            cmd.CommandText = comando.Sql;

            foreach (ParametroComando parametro in comando.Parametros)            
                cmd.Parameters.Add(new SqliteParameter { ParameterName = "@" + parametro.Nombre, Value = parametro.Valor });            

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

            SqliteCommand cmd = new SqliteCommand();

            cmd.CommandText = comando.Sql;

            foreach (ParametroComando parametro in comando.Parametros)
                cmd.Parameters.Add(new SqliteParameter { ParameterName = "@" + parametro.Nombre, Value = parametro.Valor });

            cmd.Connection = Conexion;
            cmd.Transaction = Transaccion;

            SqliteDataReader reader = cmd.ExecuteReader();            
            ResultadoSQLite resultado = new ResultadoSQLite(reader);

            System.Diagnostics.Debug.WriteLine(cmd.CommandText);

            return resultado;
        }


        public void AbrirConexion()
        {
            if (Conexion == null)
                Conexion = new SqliteConnection(CadenaConexion);

            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();            
        }

        public void CerrarConexion()
        {
            if (Conexion != null && Conexion.State != ConnectionState.Closed)
                Conexion.Close();
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

        void IDisposable.Dispose()
        {
            DeshacerTransaccion();
        }

        //public IClave ObtenerClave(ITipo tipo)
        //{
        //    return null;
        //}
        #endregion


        #region Propiedades
        public string CadenaConexion
        {
            get;
            set;
        }

        private SqliteConnection Conexion
        {
            get;
            set;
        }
        
        public string Nombre
        {
            get;
            set;
        }

        private SqliteTransaction Transaccion
        {
            get;
            set;
        }
        #endregion

    }
}
