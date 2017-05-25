using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal abstract class SqlBuilderSeleccion : ISqlBuilder
    {
        string _clave;

        public SqlBuilderSeleccion()
        {
        }

        public SqlBuilderSeleccion(string clave)
        {
            _clave = clave;
        }
        
        protected abstract string ConstruirSelect();

        protected abstract string ConstruirSelectWhere(string clave);

        public string ConstruirSql()
        {
            if (_clave != null)
                return ConstruirSelectWhere(_clave);
            else
                return ConstruirSelect();
        }
    }
}
