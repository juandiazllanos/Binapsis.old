using Binapsis.Plataforma.Configuracion.Sql.Clave;
using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderInsertarTipo : SqlBuilderEscritura<Tipo>
    {
        public SqlBuilderInsertarTipo(Tipo obj) 
            : base(obj)
        {
        }

        public override string ConstruirSql()
        {   
            string PK_Tipo = new ClaveTipo(Objeto).ToString();
            string FK_Base = new ClaveTipo(Objeto.Base).ToString();
            string FK_Uri = new ClaveUri(Objeto.Uri).ToString();

            return $"Insert Into Tipo (PK_Tipo, FK_Tipo_Base, FK_Uri, Alias, EsTipoDeDato, Nombre) " +
                   $"Values ('{PK_Tipo}', '{FK_Base}', '{FK_Uri}', '{Objeto.Alias}', {Convert.ToByte(Objeto.EsTipoDeDato)}, '{Objeto.Nombre}')";
        }
    }
}
