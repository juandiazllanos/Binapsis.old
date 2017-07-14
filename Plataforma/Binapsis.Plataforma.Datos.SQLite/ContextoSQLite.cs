﻿using Binapsis.Plataforma.Datos.Impl;
using Microsoft.Data.Sqlite;
using System.Data;
using System;

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
            EjecutarComando(comando as Comando);
        }

        private void EjecutarComando(Comando comando)
        {
            if (comando == null) return;

            SqliteCommand cmd = new SqliteCommand();            

            cmd.CommandText = comando.Sql;

            foreach (Parametro parametro in comando.Parametros)            
                cmd.Parameters.Add(new SqliteParameter { ParameterName = "@" + parametro.Nombre, Value = parametro.Valor });            

            cmd.Connection = Conexion;
            cmd.Transaction = Transaccion;

            cmd.ExecuteNonQuery();

            System.Diagnostics.Debug.WriteLine(cmd.CommandText);
        }

        private void AbrirConexion()
        {
            if (Conexion == null)
                Conexion = new SqliteConnection(CadenaConexion);

            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();            
        }

        private void CerrarConexion()
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