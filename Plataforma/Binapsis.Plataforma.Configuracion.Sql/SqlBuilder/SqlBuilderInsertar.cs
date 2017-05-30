using Binapsis.Plataforma.Configuracion.Sql.Clave;
using Binapsis.Plataforma.Estructura;
using System;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderInsertar : SqlBuilderEscritura<ConfiguracionBase>
    {
        public SqlBuilderInsertar(ConfiguracionBase obj)
            : this(ClaveBase.Crear(obj)?.ToString(), obj)
        {

        }
        public SqlBuilderInsertar(string clave, ConfiguracionBase obj)
            : base(obj)
        {
            Clave = clave;
        }

        public override string ConstruirSql()
        {
            StringBuilder sql = new StringBuilder();
            IObjetoDatos od = Objeto;

            sql.Append($"Insert into {Objeto.Tipo.Nombre} (PK_{Objeto.Tipo.Nombre} ");

            foreach (IPropiedad propiedad in Objeto.Tipo.Propiedades)
                if (propiedad.Tipo.EsTipoDeDato)
                    sql.Append($", {propiedad.Nombre}");

            sql.Append($") Values ('{Clave}'");
            
            foreach (IPropiedad propiedad in Objeto.Tipo.Propiedades)
                if (propiedad.Tipo.Nombre == "String" || propiedad.Tipo.Nombre == "DateTime")
                    sql.Append($", '{od.Obtener(propiedad)}'");
                else if (propiedad.Tipo.Nombre == "Boolean")
                    sql.Append($", {Convert.ToByte(od.Obtener(propiedad))}");
                else if (propiedad.Tipo.EsTipoDeDato)
                    sql.Append($", {od.Obtener(propiedad)}");

            sql.Append(")");

            return sql.ToString();
        }
        
        public string Clave
        {
            get;
            set;
        }
    }
}
