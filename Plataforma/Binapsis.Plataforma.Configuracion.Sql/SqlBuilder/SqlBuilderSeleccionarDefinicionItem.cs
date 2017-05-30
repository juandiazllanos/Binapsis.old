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
            return "Select Alias = 'Ensamblado', Nombre = 'Categoria', Valor = 'Ensamblado' Union All " +
                   "Select Alias = 'Conexion', Nombre = 'Categoria', Valor = 'Conexion' Union All " +
                   "Select Alias = 'Tabla', Nombre = 'Categoria', Valor = 'Tabla' Union All " +
                   "Select Alias = 'Relacion', Nombre = 'Categoria', Valor = 'Relacion'";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            string definicion = _definicion?.ToLower();

            if (definicion == "configuracion")
                return ConstruirSelect();

            else if (definicion.ToLower() == "categoria")
                switch(clave.ToLower())
                {
                    case "ensamblado":
                        return "Select Alias = Nombre, Nombre = 'Ensamblado', Valor = PK_Ensamblado From Ensamblado";

                    case "conexion":
                        return "Select Alias = Nombre, Nombre = 'Conexion', Valor = PK_Conexion From Conexion";

                    case "tabla":
                        return "Select Alias = Nombre, Nombre = 'Tabla', Valor = PK_Tabla From Tabla";

                    case "relacion":
                        return "Select Alias = Nombre, Nombre = 'Relacion', Valor = PK_Relacion From Relacion";

                    default:
                        return "";
                }

            else
                switch (_definicion.ToLower())
                {
                    case "ensamblado":
                        return $"Select Alias = Nombre, Nombre = 'Uri', Valor = PK_Uri From Uri Where FK_Ensamblado = '{clave}'";

                    case "uri":
                        return $"Select Alias = Alias, Nombre = 'Tipo', Valor = PK_Tipo From Tipo Where FK_Uri = '{clave}'";

                    case "tipo":
                        return $"Select Alias = Alias, Nombre = 'Propiedad', Valor = PK_Propiedad From Propiedad Where FK_Tipo_Propietario = '{clave}'";

                    case "tabla":
                        return $"Select Alias = Nombre, Nombre = 'Columna', Valor = PK_Columna From Columna Where FK_Tabla = '{clave}'";

                    default:
                        return "";
                }
        }
    }
}
