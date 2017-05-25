using Binapsis.Plataforma.Configuracion.Sql.Clave;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderActualizarUri : SqlBuilderEscritura<Uri>
    {
        string _clave;

        public SqlBuilderActualizarUri(string clave, Uri obj) 
            : base(obj)
        {
            _clave = clave;
        }

        public override string ConstruirSql()
        {
            return $"Update Uri Set FK_Ensamblado='{new ClaveEnsamblado(Objeto.Ensamblado)}', Nombre='{Objeto.Nombre}', PK_Uri='{new ClaveUri(Objeto)}' Where PK_Uri='{_clave}'";
        }
    }
}
