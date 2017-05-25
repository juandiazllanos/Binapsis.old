using Binapsis.Plataforma.Configuracion.Sql.Clave;
using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderActualizarTipo : SqlBuilderEscritura<Tipo>
    {
        string _clave;

        public SqlBuilderActualizarTipo(string clave, Tipo obj) 
            : base(obj)
        {
            _clave = clave;
        }

        public override string ConstruirSql()
        {
            return $"Update Tipo Set FK_Tipo_Base = '{new ClaveTipo(Objeto.Base)}', FK_Uri = '{new ClaveUri(Objeto.Uri)}', Alias = '{Objeto.Alias}', EsTipoDeDato = {Convert.ToByte(Objeto.EsTipoDeDato)}, PK_Tipo = '{new ClaveTipo(Objeto)}' Where PK_Tipo = '{_clave}'";
        }
    }
}
