using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderSeleccionar : SqlBuilderSeleccion
    {
        Type _type;

        public SqlBuilderSeleccionar(Type type, string clave)
            : base(clave)
        {
            _type = type;
        }
        
        protected override string ConstruirSelect()
        {
            return $"Select * from {_type.Name}";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            return $"Select * from {_type.Name} Where PK_{_type.Name} = '{clave}'";
        }
    }
}
