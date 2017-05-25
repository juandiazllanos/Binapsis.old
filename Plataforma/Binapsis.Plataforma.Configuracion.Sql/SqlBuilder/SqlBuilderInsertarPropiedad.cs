using Binapsis.Plataforma.Configuracion.Sql.Clave;
using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderInsertarPropiedad : SqlBuilderEscritura<Propiedad>
    {
        public SqlBuilderInsertarPropiedad(Propiedad obj) 
            : base(obj)
        {
        }

        public override string ConstruirSql()
        {
            string PK_Propiedad = new ClavePropiedad(Objeto).ToString();
            string FK_Propietario = new ClaveTipo(Objeto.Propietario).ToString();
            string FK_Tipo = new ClaveTipo(Objeto.TipoAsociado).ToString();

            return "Insert Into Propiedad (PK_Propiedad, FK_Tipo_Propietario, FK_Tipo_Tipo, Alias, Asociacion, Cardinalidad, Indice, Nombre, ValorInicial) " +
                    $"Values ('{PK_Propiedad}', '{FK_Propietario}', '{FK_Tipo}', '{Objeto.Alias}', {Convert.ToByte(Objeto.Asociacion)}, {Convert.ToByte(Objeto.Cardinalidad)}, {Objeto.Indice}, '{Objeto.Nombre}', '{Objeto.ValorInicial}')";
        }
    }
}
