namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderSeleccionarDefinicion : SqlBuilderSeleccion
    {
        string _definicion;

        public SqlBuilderSeleccionarDefinicion(string definicion)
            : this(definicion, "")
        {
        }

        public SqlBuilderSeleccionarDefinicion(string definicion, string clave) 
            : base(clave)
        {
            _definicion = definicion;
        }

        protected override string ConstruirSelect()
        {
            return "Select Alias = 'Configuracion', Nombre = 'Configuracion', Valor = 'Configuracion'";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            switch (_definicion?.ToLower())
            {
                case "ensamblado":
                    return $"Select Alias = Nombre, Nombre = 'Ensamblado', Valor = PK_Ensamblado From Ensamblado Where PK_Ensamblado = '{clave}'"; 

                case "uri":
                    return $"Select Alias = Nombre, Nombre = 'Uri', Valor = PK_Uri From Uri Where PK_Uri = '{clave}'"; 

                case "tipo":
                    return $"Select Alias = Alias, Nombre = 'Tipo', Valor = PK_Tipo From Tipo Where PK_Tipo = '{clave}'";

                case "Propiedad":
                    return $"Select Alias = Alias, Nombre = 'Propiedad', Valor = PK_Propiedad From Propiedad Where PK_Propiedad = '{clave}'";

                default:
                    return "";
            }
        }
    }
}
