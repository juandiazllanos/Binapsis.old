using Binapsis.Plataforma.Configuracion.Sql.Clave;
using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderInsertarColumna : SqlBuilderInsertar
    {
        public SqlBuilderInsertarColumna(ConfiguracionBase obj) 
            : base(obj)
        {
        }

        public override string ConstruirSql()
        {
            Columna columna = (Objeto as Columna);
            return $"Insert Into Columna (PK_Columna, FK_Tabla, ClavePrincipal, Nombre, Propiedad) Values ('{Clave}', '{new ClaveTabla((Tabla)columna.Propietario)}', {Convert.ToByte(columna.ClavePrimaria)}, '{columna.Nombre}', '{columna.Propiedad}')";
        }
    }
}
