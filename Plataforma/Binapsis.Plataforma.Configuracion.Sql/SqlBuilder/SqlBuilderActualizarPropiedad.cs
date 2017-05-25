using Binapsis.Plataforma.Configuracion.Sql.Clave;
using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderActualizarPropiedad : SqlBuilderEscritura<Propiedad>
    {
        public SqlBuilderActualizarPropiedad(Propiedad obj) 
            : base(obj)
        {
        }

        public override string ConstruirSql()
        {
            return $"Update Propiedad Set FK_Tipo_Tipo = '{new ClaveTipo(Objeto.TipoAsociado)}', Alias = '{Objeto.Alias}', Asociacion = {Convert.ToByte(Objeto.Asociacion)}, Cardinalidad = {Convert.ToByte(Objeto.Cardinalidad)}, Indice = {Objeto.Indice}, ValorInicial = '{Objeto.ValorInicial}' Where PK_Propiedad = '{new ClavePropiedad(Objeto)}' ";
        }
    }
}
