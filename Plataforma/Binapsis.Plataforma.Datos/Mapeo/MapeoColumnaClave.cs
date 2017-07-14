namespace Binapsis.Plataforma.Datos.Mapeo
{
    class MapeoColumnaClave : MapeoColumna
    {
        public MapeoColumnaClave(MapeoTabla tabla) 
            : base(tabla)
        {
        }

        public MapeoRelacionClave MapeoRelacionClave
        {
            get;
            set;
        }
    }
}
