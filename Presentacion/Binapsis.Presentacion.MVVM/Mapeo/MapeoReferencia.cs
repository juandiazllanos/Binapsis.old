namespace Binapsis.Presentacion.MVVM.Mapeo
{
    public class MapeoReferencia : MapeoPropiedad
    {
        public MapeoReferencia(MapeoTipo mapeo) 
            : base(mapeo)
        {
        }
        
        public  MapeoTipo Mapeo
        {
            get;
            set;
        }        		
	}

}