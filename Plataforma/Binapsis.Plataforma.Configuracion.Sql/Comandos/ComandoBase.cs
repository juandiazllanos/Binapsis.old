﻿using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal abstract class ComandoBase 
    {
        public ComandoBase()
        {            
        }

        public ComandoBase(ISqlBuilder builder)
        {
            ComandoSql = builder.ConstruirSql();
        }

        //public virtual void Ejecutar()
        //{
        //    if (!string.IsNullOrEmpty(ComandoSql))
        //        Contexto.Ejecutar(this);
        //}

        public virtual void Ejecutar(SqlConnection conexion)
        {
            Ejecutar(conexion, null);
        }
                
        public abstract void Ejecutar(SqlConnection conexion, SqlTransaction transaccion);

        public Contexto Contexto
        {
            get;
            set;
        }

        //public string CadenaConexion
        //{
        //    get;
        //    set;
        //}

        protected string ComandoSql
        {
            get;
            set;
        }

        
        
    }
}
