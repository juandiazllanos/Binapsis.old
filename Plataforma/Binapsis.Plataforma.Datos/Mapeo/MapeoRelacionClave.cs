namespace Binapsis.Plataforma.Datos.Mapeo
{
    class MapeoRelacionClave
    {
        public MapeoRelacionClave(MapeoRelacion relacion)
        {
            MapeoRelacion = relacion;
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
