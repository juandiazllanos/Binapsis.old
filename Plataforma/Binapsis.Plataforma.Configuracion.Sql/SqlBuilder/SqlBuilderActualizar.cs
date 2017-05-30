using Binapsis.Plataforma.Configuracion.Sql.Clave;
using Binapsis.Plataforma.Estructura;
using System;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderActualizar : SqlBuilderEscritura<ConfiguracionBase>
    {
        public SqlBuilderActualizar(string claveActual, ConfiguracionBase obj) 
            : this(claveActual, ClaveBase.Crear(obj)?.ToString(), obj)
        {

        }

        public SqlBuilderActualizar(string claveActual, string claveNueva, ConfiguracionBase obj) 
            : base(obj)
        {
            ClaveActual = claveActual;
            ClaveNueva = claveNueva;
        }

        public override string ConstruirSql()
        {
            StringBuilder sql = new StringBuilder();
            IObjetoDatos od = Objeto;
            
            sql.Append($"Update {Objeto.Tipo.Nombre} Set PK_{Objeto.Tipo.Nombre} = '{ClaveNueva}'");

            foreach (IPropiedad propiedad in Objeto.Tipo.Propiedades)
            {
                if (!propiedad.Tipo.EsTipoDeDato) continue;
                            
                sql.Append($", {propiedad.Nombre} = ");

                if (propiedad.Tipo.Nombre == "String" || propiedad.Tipo.Nombre == "DateTime")
                    sql.Append($"'{od.Obtener(propiedad)}'");
                else if (propiedad.Tipo.Nombre == "Boolean")
                    sql.Append($"{Convert.ToByte(od.Obtener(propiedad))}");
                else
                    sql.Append($"{od.Obtener(propiedad)}");
            }

            sql.Append($" Where PK_{od.Tipo.Nombre} = '{ClaveActual}'");

            return sql.ToString();
        }

        public string ClaveNueva
        {
            get;
            set;
        }

        public string ClaveActual
        {
            get;
            set;
        }
    }
}
