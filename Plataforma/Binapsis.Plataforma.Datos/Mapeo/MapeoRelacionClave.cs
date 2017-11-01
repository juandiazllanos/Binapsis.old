namespace Binapsis.Plataforma.Datos.Mapeo
{
    class MapeoRelacionClave
    {
        public MapeoRelacionClave(MapeoRelacion relacion)
        {
            MapeoRelacion = relacion;
        }

        public IPrimaryKey ObtenerPrimaryKey()
        {
            if (ClavePrincipal != null)
                return ClavePrincipal.MapeoTabla.ObtenerPrimaryKey(ClavePrincipal.Columna.Nombre);
            else
                return null;
        }

        public MapeoColumna ClavePrincipal
        {
            get;
            set;
        }

        public MapeoColumna ClaveSecundaria
        {
            get;
            set;
        }

        public MapeoRelacion MapeoRelacion
        {
            get;
        }

    }
}
