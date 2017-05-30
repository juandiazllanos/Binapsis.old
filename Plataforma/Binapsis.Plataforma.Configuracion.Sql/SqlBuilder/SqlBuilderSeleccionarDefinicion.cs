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
            string definicion = _definicion?.ToLower();

            if (definicion == "categoria")
                switch(clave.ToLower())
                {
                    case "ensamblado":
                        return "Select Alias = 'Ensamblado', Nombre = 'Categoria', Valor = 'Ensamblado'";

                    case "conexion":
                        return "Select Alias = 'Conexion', Nombre = 'Categoria', Valor = 'Conexion'";

                    case "tabla":
                        return "Select Alias = 'Tabla', Nombre = 'Categoria', Valor = 'Tabla'";

                    case "relacion":
                        return "Select Alias = 'Relacion', Nombre = 'Categoria', Valor = 'Relacion'";

                    default:
                        return "";
                }
            else 
                switch (definicion)
                {   
                    case "ensamblado":
                        return $"Select Alias = Nombre, Nombre = 'Ensamblado', Valor = PK_Ensamblado From Ensamblado Where PK_Ensamblado = '{clave}'"; 

                    case "uri":
                        return $"Select Alias = Nombre, Nombre = 'Uri', Valor = PK_Uri From Uri Where PK_Uri = '{clave}'"; 

                    case "tipo":
                        return $"Select Alias = Alias, Nombre = 'Tipo', Valor = PK_Tipo From Tipo Where PK_Tipo = '{clave}'";

                    case "propiedad":
                        return $"Select Alias = Alias, Nombre = 'Propiedad', Valor = PK_Propiedad From Propiedad Where PK_Propiedad = '{clave}'";

                    case "tabla":
                        return $"Select Alias = Nombre, Nombre = 'Tabla', Valor = PK_Tabla From Tabla Where PK_Tabla = '{clave}'";

                    case "columna":
                        return $"Select Alias = Alias, Nombre = 'Columna', Valor = PK_Columna From Propiedad Where PK_Columna = '{clave}'";

                    default:
                        return "";
                }
        }
    }
}
