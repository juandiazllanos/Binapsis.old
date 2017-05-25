using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderSeleccionarDefinicionItem : SqlBuilderSeleccion
    {
        string _definicion;

        public SqlBuilderSeleccionarDefinicionItem(string definicion, string clave) 
            : base(clave)
        {
            _definicion = definicion;
        }

        protected override string ConstruirSelect()
        {
            return $"Select Alias = Nombre, Nombre = 'Ensamblado', Valor = PK_Ensamblado From Ensamblado";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            switch (_definicion?.ToLower())
            {
                case "configuracion":
                    return ConstruirSelect();

                case "ensamblado":
                    return $"Select Alias = Nombre, Nombre = 'Uri', Valor = PK_Uri From Uri Where FK_Ensamblado = '{clave}'";

                case "uri":
                    return $"Select Alias = Alias, Nombre = 'Tipo', Valor = PK_Tipo From Tipo Where FK_Uri = '{clave}'";

                case "tipo":
                    return $"Select Alias = Alias, Nombre = 'Propiedad', Valor = PK_Propiedad From Propiedad Where FK_Tipo_Propietario = '{clave}'";

                default:
                    return "";
            }
        }
    }
}
